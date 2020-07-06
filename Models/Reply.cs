using System;
namespace frame.Models
{
    public class Reply
    {
        public int id_Reply { get; set; }
        public int id_Comment { get; set; }
        public string content { get; set; }
        public DateTime date_Reply { get; set; }
    }
}