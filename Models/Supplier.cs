using System.ComponentModel.DataAnnotations;
namespace frame.Models
{
    public class Supplier
    {
        public string idSupplier { get; set;}
        public string nameSupplier { get; set;}
        public string addressSupplier { get; set;}
        [Phone]
        public string phoneSupplier { get; set;}
        public string status { get; set; }
    }
}