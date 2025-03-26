using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork UOW;

        public BooksController(IUnitOfWork UOW)
        {
            this.UOW = UOW;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(UOW.Books.GetById(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(UOW.Books.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(UOW.Books.Find(b => b.Title == "book", new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(UOW.Books.FindAll(b => b.Title.Contains("book"), new[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(UOW.Books.FindAll(b => b.Title.Contains("book"), null, null, b => b.Id));
        }

        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = UOW.Books.Add(new Book { Title = "book test", AuthorId = 1 });
            UOW.Complete();

            return Ok(book);
        }

        [HttpPost("AddMany")]
        public IActionResult AddMany()
        {
            return Ok(UOW.Books.Add(new Book { Title = "book test", AuthorId = 1 }));
        }
    }
}
