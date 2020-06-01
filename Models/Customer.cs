using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;
namespace frame.Models
{
    public class Customer
    {
        public int idCustomer {get;set;}
        [Required]
        public string nameCustomer { get; set; }
        [Required]
        [Phone]
        public string phoneCustomer { get; set; }
        public string idShip { get; set; }
        [Required]
        public string addressCustomer { get; set; }
        public int idUser { get; set; }
        public string status { get; set; }
    }
}