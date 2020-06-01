using System;
namespace frame.Models
{
    public class Discount
    {
        public string idDiscount { get; set;}
        public string nameDiscount { get; set;}
        public int quantityDis { get; set;}
        public DateTime dateStart { get; set;}
        public DateTime dateEnd { get; set;}
        public int numberDiscount { get; set;}
        public string status {get; set;}
    }
}