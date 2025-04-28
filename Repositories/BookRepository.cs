using System.Collections.Generic;
using BookCatalogApi.Models;
using BookCatalogApi.Utils;

namespace BookCatalogApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository(string jsonPath)
        {
            _books = JsonLoader.LoadBooks(jsonPath);

        }



        public List<Book> GetAll()
        {
            return _books;
        }
    }
}

