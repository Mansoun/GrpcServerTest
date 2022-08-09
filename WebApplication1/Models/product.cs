using System.ComponentModel.DataAnnotations;

namespace CacheServer.Models
{
    public class product
    {
        [Key]
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }

    }
}
