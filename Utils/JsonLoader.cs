
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BookCatalogApi.Models;

namespace BookCatalogApi.Utils
{
    public static class JsonLoader
    {
        public static List<Book> LoadBooks(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Arquivo não encontrado: {filePath}");
            }

            var jsonString = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var books = JsonSerializer.Deserialize<List<Book>>(jsonString, options);

            return books ?? new List<Book>();
        }
    }
}
