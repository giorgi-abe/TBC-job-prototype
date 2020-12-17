using ApplicationCustomExceptions;
using ApplicationDomainCore.Abstraction;
using ApplicationDomainModels;
using ApplicationDtos;
using ApplicationUIServices.PhotoService.Abstraction;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonTbcProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<Person> _repository = default;
        private readonly IPhotoService _photoService = default;
        private readonly ICityRepository _cityRepository = default;

        public PersonController(IRepository<Person> repository, IMapper mapper, IPhotoService photoService, ICityRepository cityRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _photoService = _photoService;
            _cityRepository = cityRepository;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IEnumerable<PersonDto>> Get()
        {
            var data = await _repository.Get().Include("ConnectedPeople").Include("Numbers").ToListAsync();
            var returnData = _mapper.Map<IEnumerable<PersonDto>>(data);
            return returnData;
        }

        [HttpGet("SearchBy")]
        public async Task<IEnumerable<PersonDto>> Get(string name, string surname, string identityNumber)
        {
            var data = await _repository.Get().Include("ConnectedPeople").Include("Numbers").ToListAsync();
            if (name != null && surname !=null && identityNumber == null)
            {
                var returnData = _mapper.Map<IEnumerable<PersonDto>>(data).Where(o => o.Name == name).Where(o => o.Surname == surname);
                return returnData;
            }
            else if(identityNumber != null)
            {
                var returnData = _mapper.Map<IEnumerable<PersonDto>>(data).Where(o => o.IdentityNumber == identityNumber);
                return returnData;
            }
            else if (name != null && surname == null)
            {
                var returnData = _mapper.Map<IEnumerable<PersonDto>>(data).Where(o => o.Name == name);
                return returnData;
            }
            else if (name == null && surname != null)
            {
                var returnData = _mapper.Map<IEnumerable<PersonDto>>(data).Where(o => o.Surname == surname);
                return returnData;
            }
            return _mapper.Map<IEnumerable<PersonDto>>(data);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<PersonDto> Get(int id)
        {
            var obj = await _repository.Get().Include("ConnectedPeople").Include("Numbers").FirstOrDefaultAsync(o => o.Id == id);
            return _mapper.Map<PersonDto>(obj);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto item)
        {
            //string path = await _photoService.AddPhoto(Image);
            var cities = await _cityRepository.ReadAsync();
            if (!cities.Contains(item.CityId) && item.CityId !=null)
            {
                throw new CityNotFoundexception("City id not found");
            }
            if (item == null) { return BadRequest(ModelState); }
            try
            {

                var obj = _mapper.Map<Person>(item);
                //item.Image = path;
                var result = await _repository.CreateAsync(obj);
                if (result)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return StatusCode(500, ModelState);
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonDto item)
        {
            if (item == null) { return BadRequest(ModelState); }
            var cities = await _cityRepository.ReadAsync();
            if (!cities.Contains(item.CityId))
            {
                return StatusCode(500);
            }
            try
            {
                var obj = _mapper.Map<Person>(item);
                var result = await _repository.UpdateAsync(id, obj);
                if (result)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return StatusCode(500, ModelState);
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _repository.DeleteAsync(id);
                if (result)
                {
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return StatusCode(500, ModelState);
            }
        }
    }
}
