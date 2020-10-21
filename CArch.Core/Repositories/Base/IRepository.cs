using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CArch.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}
