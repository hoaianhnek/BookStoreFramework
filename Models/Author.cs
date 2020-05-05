using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using frame.Data;
using frame.Models;
using MySql.Data.MySqlClient;

namespace frame.Models
{
    public class Author
    {
        public string idAuthor { get; set;}
        public string nameAuthor { get; set;}
        public string imgAuthor { get; set;}
        public string describeAuthor { get; set;}
    }
}