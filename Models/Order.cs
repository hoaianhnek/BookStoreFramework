using System;
namespace frame.Models
{
    public class Order
    {
        public int idOrder { set; get; }
        public int  idCustomer { get; set;}
        public DateTime dateOrder { get; set; }
        public string status { get; set; }
    }
}