using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using frame.Data;
using frame.Models;
using MySql.Data.MySqlClient;

namespace frame.Models
{
    public class Supplier
    {
        public string idSupplier { get; set;}
        public string nameSupplier { get; set;}
        public string addressSupplier { get; set;}
        public string phoneSupplier { get; set;}
    }
}