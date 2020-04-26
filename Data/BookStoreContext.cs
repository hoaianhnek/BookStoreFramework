using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using frame.Models;

namespace frame.Data
{
    public class BookStoreContext
    {   

        public MySqlConnection GetConnection() {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.UserID = "root";
            conn_string.Password = "123";
            conn_string.Database = "bookstore";
            conn_string.Port = 3306;
            MySqlConnection cnn = new MySqlConnection(conn_string.ToString());
            return cnn;
        }
        public List<Book> GetAllBook() {
            List<Book> list = new List<Book>();
        
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from book",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        if(reader["id_Discount"].ToString() != null){
                            list.Add(new Book() {
                            idBook = reader["id_Book"].ToString(),
                            nameBook = reader["name_Book"].ToString(),
                            imgBook = reader["img_Book"].ToString(),
                            desBook = reader["describe_Book"].ToString(),
                            summaryBook =reader["summary_Book"].ToString(),
                            priceBook = float.Parse(reader["price_Book"].ToString(),System.Globalization.CultureInfo.InvariantCulture),
                            idCategory = reader["id_Category"].ToString(),
                            amountBook = Convert.ToInt32(reader["amount_Book"].ToString()),
                            publishingYear = Convert.ToInt32(reader["publishing_Year"].ToString()),
                            pageCount = Convert.ToInt32(reader["page_Count"].ToString()),
                            publisherBook = reader["publisher_Book"].ToString(),
                            idAuthor = reader["id_Author"].ToString(),
                            idDiscount = reader["id_Discount"].ToString(),
                            imgBackBook = reader["imgback_Book"].ToString()
                            });
                        }else {
                            list.Add(new Book() {
                            idBook = reader["id_Book"].ToString(),
                            nameBook = reader["name_Book"].ToString(),
                            imgBook = reader["img_Book"].ToString(),
                            desBook = reader["describe_Book"].ToString(),
                            summaryBook =reader["summary_Book"].ToString(),
                            priceBook = float.Parse(reader["price_Book"].ToString(),System.Globalization.CultureInfo.InvariantCulture),
                            idCategory = reader["id_Category"].ToString(),
                            amountBook = Convert.ToInt32(reader["amount_Book"].ToString()),
                            publishingYear = Convert.ToInt32(reader["publishing_Year"].ToString()),
                            pageCount = Convert.ToInt32(reader["page_Count"].ToString()),
                            publisherBook = reader["publisher_Book"].ToString(),
                            idAuthor = reader["id_Author"].ToString(),
                            idDiscount = null,
                            imgBackBook = reader["imgback_Book"].ToString()
                            });
                        }
                        
                    }
                }
                cnn.Close();
            } catch(Exception ex) {
                Console.WriteLine("Can not open connection ! "+ ex.Message);
            }
            return list;
        }
      
        public List<Category> GetAllCategory() {
            List<Category> list = new List<Category>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from category",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Category() {
                            idCategory = reader["id_Category"].ToString(),
                            nameCategory = reader["name_Category"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
    
        public List<Author> GetAllAuthor() {
            List<Author> list = new List<Author>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from author",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Author() {
                            idAuthor= reader["id_Author"].ToString(),
                            nameAuthor = reader["name_Author"].ToString(),
                            imgAuthor = reader["img_Author"].ToString(),
                            describeAuthor = reader["describe_Author"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
    
        public List<Discount> GetAllDiscount() {
            List<Discount> list = new List<Discount>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from discount",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Discount() {
                            idDiscount= reader["id_Discount"].ToString(),
                            nameDiscount = reader["name_Discount"].ToString(),
                            quantityDis = int.Parse(reader["quantity_Discount"].ToString()),
                            dateStart = reader["date_start"].ToString(),
                            dateEnd = reader["date_end"].ToString(),
                            numberDiscount = int.Parse(reader["number_Discount"].ToString())
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
    }
}