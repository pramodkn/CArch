using CArch.Core.Entities;
using CArch.Core.Repositories;
using CArch.Infrastructure.Data;
using CArch.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CArch.Infrastructure.Repositories
{
    public class MovieRepository:Repository<Movie>,IMovieRepository
    {
        public MovieRepository(CArchApplicationDbContext cArchApplicationDbContext):base(cArchApplicationDbContext)
        {

        }
    }
}
