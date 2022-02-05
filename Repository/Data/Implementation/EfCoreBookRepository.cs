using DomainModels.Entities;
using Repository.Data.EFCore;
using Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Implementation
{
    public class EfCoreBookRepository : EfCoreRepository<Book, BookDto, AppDbContext>
    {
        public EfCoreBookRepository(AppDbContext context) : base(context) { }
    }
}
