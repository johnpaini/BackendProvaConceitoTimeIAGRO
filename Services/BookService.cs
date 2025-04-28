using System.Collections.Generic;
using System.Linq;
using BookCatalogApi.Models;
using BookCatalogApi.Repositories;

namespace BookCatalogApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Book> Search(string title, string author)
        {
            var books = _repository.GetAll();

            if (!string.IsNullOrEmpty(title))
                books = books.Where(b => b.Title.Contains(title, System.StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(author))
                books = books.Where(b => b.specifications.Author.Contains(author, System.StringComparison.OrdinalIgnoreCase)).ToList();

            return books;
        }

        public List<Book> OrderByPrice(string order)
        {
            var books = _repository.GetAll();

            return order.ToLower() == "desc"
                ? books.OrderByDescending(b => b.Price).ToList()
                : books.OrderBy(b => b.Price).ToList();
        }

        public decimal CalculateShipping(decimal price)
        {
            return price * 0.2m;
        }
    }
}
