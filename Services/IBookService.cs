using System.Collections.Generic;
using BookCatalogApi.Models;

namespace BookCatalogApi.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
        List<Book> Search(string title = "", string author = "");
        List<Book> OrderByPrice(string order);
        decimal CalculateShipping(decimal price);
    }
}
