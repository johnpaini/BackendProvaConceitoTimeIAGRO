using System.Text.Json.Serialization;

namespace BookCatalogApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Title { get; set; }
        [JsonPropertyName("specifications")]
        public Specifications specifications { get; set; }

        public decimal Price { get; set; }
        public class Specifications
        {

            [JsonPropertyName("author")]
            public string Author { get; set; }
        }
        //frete
        public decimal Freight => Price * 0.20m;
    }
}
