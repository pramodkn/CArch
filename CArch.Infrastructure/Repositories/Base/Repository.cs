using CArch.Core.Repositories.Base;
using CArch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CArch.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CArchApplicationDbContext _cArchApplicationDbContext;
        public Repository(CArchApplicationDbContext cArchApplicationDbContext)
        {
            _cArchApplicationDbContext = cArchApplicationDbContext?? throw new ArgumentNullException(nameof(cArchApplicationDbContext));
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _cArchApplicationDbContext.Set<T>().ToListAsync();
        }
    }
}
