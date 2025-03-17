using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechXpress_Models.IRepository
{
    public interface Iunitofwork : IDisposable
    {
       
    Iproduct Products { get; }
    Ibrand Brands { get; }
    Icategory Categories { get; }

    Isub_category Sub_Categories { get; }

    Iimage Images { get; }

    Task<int> SaveAsync();
    }
}