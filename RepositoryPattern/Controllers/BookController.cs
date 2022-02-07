using AutoMapper;
using DomainModels.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Data.Implementation;
using Repository.Dtos;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class BookController : BaseController<Book, BookDto, EfCoreBookRepository>
    {
        public BookController(EfCoreBookRepository repository, IMapper mapper) : base(repository, mapper) { }

    }
}
