using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data;
namespace frame.Models
{
    public class Book
    {
        public string idBook { get; set;}
        
        public string nameBook { get; set;}
        public string imgBook { get; set;}
        public string desBook { get; set;}
        public string summaryBook { get; set;}
        public float priceBook { get; set;}
        public string idCategory { get; set;}
        public int amountBook { get; set;}
        public int publishingYear { get; set;}
        public int pageCount { get; set;}
        public string publisherBook { get; set;}
        public string idAuthor { get; set;}
        public string idDiscount { get; set;}
        public string imgBackBook { get; set;}
    }
}