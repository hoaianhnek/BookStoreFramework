using System;
namespace frame.Models
{
    public class Comments
    {
        public int id_Comment { get; set; }
        public int id_User { get; set; }
        public string id_Book { get; set; }
        public DateTime date_Comment { get; set; }
        public string content { get; set; }
        public string status { get; set; }
    }
}