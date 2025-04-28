using Microsoft.AspNetCore.Mvc;
using BookCatalogApi.Services;
using BookCatalogApi.Models;
using System.Collections.Generic;

namespace BookCatalogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = _service.GetAll();
            return Ok(books);
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Book>> Search(string title = "", string author = "")
        {
            var books = _service.Search(title, author);
            return Ok(books);
        }

        [HttpGet("orderbyprice")]
        public ActionResult<IEnumerable<Book>> OrderByPrice(string order = "asc")
        {
            var books = _service.OrderByPrice(order);
            return Ok(books);
        }

        [HttpGet("shipping/{price}")]
        public ActionResult<decimal> CalculateShipping(decimal price)
        {
            var shipping = _service.CalculateShipping(price);
            return Ok(shipping);
        }
    }
}
