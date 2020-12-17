using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDomainCore.Abstraction
{
    public interface ICityRepository
    {
        Task<IEnumerable<int>> ReadAsync();
    }
}
