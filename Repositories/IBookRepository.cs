using System.Collections.Generic;
using BookCatalogApi.Models;

namespace BookCatalogApi.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();

    }
}
