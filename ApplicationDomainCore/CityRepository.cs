using ApplicationDomainCore.Abstraction;
using ApplicationDomainEntity.Db;
using ApplicationDomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _db = default;
        public CityRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<int>> ReadAsync()
        {
            var data = await _db.CityTb.ToListAsync();
            return data.Select(o=> o.Id);
        }
    }
}
