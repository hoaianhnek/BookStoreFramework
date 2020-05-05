using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;
using MySql.Data.Common;
using frame.Models;
using System.Data;

namespace frame.Data
{
    public class BookStoreContext
    {   

        public MySqlConnection GetConnection() {
            MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
            conn_string.Server = "localhost";
            conn_string.UserID = "root";
            conn_string.Password = "";
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
      
      // Category
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
        public void AddCategory(Category cat)
        {
            string sql = "INSERT INTO category(id_Category, name_Category) VALUES (N'"+ cat.idCategory + "',N'" + cat.nameCategory + "')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        public void UpdateCategory(Category cat)
        {
            string sql = "Update category set name_Category= N'"+cat.nameCategory+"' where id_Category= '"+ cat.idCategory+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            try {
                 conn.Open();
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                conn.Close();
            } catch(Exception e ) {
                Console.WriteLine(e);
            }
           
        }
        public void DeleteCategory(String id)
        {
            string sql = "Delete from category where id_Category= '"+ id +"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

//Author
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
        public void AddAuthor(Author aut)
        {
            string sql = "INSERT INTO author(id_Author, name_Author, img_Author, describe_Author) VALUES (N'"+aut.idAuthor + "',N'" + aut.nameAuthor + "',N'" + aut.imgAuthor + "',N'" + aut.describeAuthor + "')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        public void UpdateAuthor(Author aut)
        {
            string sql = "Update author set name_Author= N'"+aut.nameAuthor+ "', img_Author= N'" + aut.imgAuthor + "', describe_Author= N'" + aut.describeAuthor + "' where id_Author= '"+ aut.idAuthor+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            try{
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
            } catch (Exception e)
            {   Console.WriteLine(e);}
        }
        public void DeleteAuthor(String id)
        {
            string sql = "Delete from author where id_Author= '"+ id +"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

// Supplier
        public List<Supplier> GetAllSupplier()
        {
            List<Supplier> list = new List<Supplier>();

            MySqlConnection cnn = GetConnection();   
            try
            {
                cnn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from supplier", cnn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Supplier()
                        {
                            idSupplier = reader["id_Supplier"].ToString(),
                            nameSupplier = reader["name_Supplier"].ToString(),
                            addressSupplier = reader["address_Supplier"].ToString(),
                            phoneSupplier = reader["phone_Supplier"].ToString()
                        });
                    }
                }
                cnn.Close();
            } 
            catch (Exception e)
                {
                     Console.WriteLine("Can not open connection ! " + e.Message);
                }
               return list;    
        }
        public void AddSupplier(Supplier sup)
        {
            string sql = "INSERT INTO supplier(id_Supplier, name_Supplier, address_Supplier, phone_Supplier) VALUES (N'"+ sup.idSupplier + "',N'" + sup.nameSupplier + "',N'" + sup.addressSupplier + "',N'" + sup.phoneSupplier +"')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        public void UpdateSupplier(Supplier sup)
        {
            string sql = "Update supplier set name_Supplier= N'"+sup.nameSupplier+"',address_Supplier=N'"+sup.addressSupplier+"',phone_Supplier=N'"+sup.phoneSupplier+"' where id_Supplier= '"+ sup.idSupplier+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            try{
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
            } catch (Exception e)
            { Console.WriteLine(e);}
        }
        public void DeleteSupplier(String id)
        {
            string sql = "Delete from supplier where id_Supplier= '"+ id +"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
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
                            dateStart = DateTime.Parse(reader["date_start"].ToString()),
                            dateEnd = DateTime.Parse(reader["date_end"].ToString()),
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