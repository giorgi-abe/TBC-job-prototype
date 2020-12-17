using ApplicationDomainCore.Abstraction;
using ApplicationDomainModels;
using ApplicationDtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonTbcProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IMapper _mapper = default;
        private readonly IRepository<PhoneNumber> _repository = default;

        public PhoneNumberController(IRepository<PhoneNumber> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }


        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IEnumerable<PhoneNumberDto>> Get()
        {
            var data = await _repository.ReadAsync();
            var returnData = _mapper.Map<IEnumerable<PhoneNumberDto>>(data);
            return returnData;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<PhoneNumberDto> Get(int id)
        {
            var obj = await _repository.ReadByIdAsync(id);
            return _mapper.Map<PhoneNumberDto>(obj);
        }

        // POST api/<ContactController>
        [HttpPost("{personId}")]
        public async Task<IActionResult> Post(int personId, [FromBody] PhoneNumberDto item)
        {
            if (item == null) { return BadRequest(ModelState); }
            try
            {
                var obj = _mapper.Map<PhoneNumber>(item);
                obj.PersonId = personId;
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
        public async Task<IActionResult> Put(int id, [FromBody] PhoneNumberDto item)
        {
            if (item == null) { return BadRequest(ModelState); }
            try
            {
                var obj = _mapper.Map<PhoneNumber>(item);
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
