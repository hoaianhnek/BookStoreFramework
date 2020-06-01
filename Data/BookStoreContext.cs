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
            conn_string.ConvertZeroDateTime = true;
            MySqlConnection cnn = new MySqlConnection(conn_string.ToString());
            return cnn;
        }
        
        #region book
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
                            imgBackBook = reader["imgback_Book"].ToString(),
                            status = reader["status"].ToString()
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
                            imgBackBook = reader["imgback_Book"].ToString(),
                            status = reader["status"].ToString()
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
        
        public void AddBook(Book book) {
            string sql = "INSERT INTO book(id_Book,name_Book,img_Book,describe_Book,summary_Book,price_Book,id_Category,amount_Book,publishing_Year,page_Count,publisher_Book,id_Author,imgback_Book,status) values (N'"+book.idBook+"',N'"+book.nameBook+"',N'"+book.imgBook+"',"+
            "N'"+book.desBook+"',N'"+book.summaryBook+"',"+book.priceBook+",N'"+book.idCategory+"',"+book.amountBook+","+
            ""+book.publishingYear+","+book.pageCount+",N'"+book.publisherBook+"',N'"+book.idAuthor+"',"+
            "N'"+book.imgBackBook+"',N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try {
                conn.Open();
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                conn.Close();
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }
        
        public void EditBook(Book book) {
            string sql = "";
            if(book.imgBook == null) {
                if(book.imgBackBook==null) {
                    sql= "update book set name_Book=N'"+book.nameBook+"',"+
                    "describe_Book=N'"+book.desBook+"',summary_Book=N'"+book.summaryBook+"',price_Book="+book.priceBook+","
                    +"id_Category=N'"+book.idCategory+"',amount_Book="+book.amountBook+",publishing_Year="+book.publishingYear+","
                    +"page_Count="+book.pageCount+",publisher_Book=N'"+book.publisherBook+"',id_Author=N'"+book.idAuthor+"'"+
                    " Where id_Book=N'"+book.idBook+"'";
                } else {
                    sql= "update book set name_Book=N'"+book.nameBook+"',"+
                    "describe_Book=N'"+book.desBook+"',summary_Book=N'"+book.summaryBook+"',price_Book="+book.priceBook+","
                    +"id_Category=N'"+book.idCategory+"',amount_Book="+book.amountBook+",publishing_Year="+book.publishingYear+","
                    +"page_Count="+book.pageCount+",publisher_Book=N'"+book.publisherBook+"',id_Author=N'"+book.idAuthor+"',"+
                    "imgback_Book=N'"+book.imgBackBook+"' Where id_Book=N'"+book.idBook+"'";
                }
            } else {
                if(book.imgBackBook==null) {
                    sql= "update book set name_Book=N'"+book.nameBook+"',img_Book=N'"+book.imgBook+"',"+
                "describe_Book=N'"+book.desBook+"',summary_Book=N'"+book.summaryBook+"',price_Book="+book.priceBook+","
                +"id_Category=N'"+book.idCategory+"',amount_Book="+book.amountBook+",publishing_Year="+book.publishingYear+","
                +"page_Count="+book.pageCount+",publisher_Book=N'"+book.publisherBook+"',id_Author=N'"+book.idAuthor+"'"+
                " Where id_Book=N'"+book.idBook+"'";
                }else {
                    sql= "update book set name_Book=N'"+book.nameBook+"',img_Book=N'"+book.imgBook+"',"+
                "describe_Book=N'"+book.desBook+"',summary_Book=N'"+book.summaryBook+"',price_Book="+book.priceBook+","
                +"id_Category=N'"+book.idCategory+"',amount_Book="+book.amountBook+",publishing_Year="+book.publishingYear+","
                +"page_Count="+book.pageCount+",publisher_Book=N'"+book.publisherBook+"',id_Author=N'"+book.idAuthor+"',"+
                "imgback_Book=N'"+book.imgBackBook+"' Where id_Book=N'"+book.idBook+"'";
                }
                
            }
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try {
               conn.Open();
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                conn.Close(); 
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }
        
        public void DeleteBook(string id) {
            string sql = "update book set status=N'false' where id_book=N'"+id+"'";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try {
                conn.Open();
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                conn.Close();
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }
        
        public List<Book> SearchBook(string name) {
            List<Book> list = new List<Book>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from book where name_Book LIKE '%"+name+"%'",cnn);
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
                            imgBackBook = reader["imgback_Book"].ToString(),
                            status = reader["status"].ToString()
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
                            imgBackBook = reader["imgback_Book"].ToString(),
                            status = reader["status"].ToString()
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
        
        public void UpdateQuantity(string id, int quantity) {

            string sql = "update book set amount_Book=amount_Book-"+quantity+" where id_Book=N'"+id+"'";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try {
                conn.Open();
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                conn.Close();
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }

        public void UpdateQuantityCong(string id, int quantity,float price) {

            string sql = "update book set amount_Book=amount_Book+"+quantity+",price_Book="+price+" where id_Book=N'"+id+"'";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try {
                conn.Open();
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                conn.Close();
            } catch(Exception e) {
                Console.WriteLine(e);
            }
        }
        #endregion book
        
        #region category
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
                            nameCategory = reader["name_Category"].ToString(),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
        
        public void AddCategory(string id, string name)
        {
            string sql = "INSERT INTO category VALUES (N'"+ id + "',N'" + name + "',N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        
        public void UpdateCategory(string id, string name)
        {
            string sql = "Update category set name_Category= N'"+name+"' where id_Category= '"+ id+"'";
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
            string sql = "update category set status = N'false' where id_Category= '"+id+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        
        public List<Category> SearchCategory(string name) {
            List<Category> list = new List<Category>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from category where name_Category LIKE '%"+name+"%'",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Category() {
                            idCategory= reader["id_Category"].ToString(),
                            nameCategory = reader["name_Category"].ToString(),
                            status = reader["status"].ToString() 
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
            return list;
        }
        #endregion category
        
        #region author
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
                            describeAuthor = reader["describe_Author"].ToString(),
                            status = reader["status"].ToString() 
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
            string sql = "INSERT INTO author VALUES (N'"+aut.idAuthor + "',N'" + aut.nameAuthor + "',N'" + aut.imgAuthor + "',N'" + aut.describeAuthor + "',N'true')";
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
            {Console.WriteLine(e);}
        }
        
        public void UpdateAuthorNotImg(Author aut)
        {
            string sql = "Update author set name_Author= N'"+aut.nameAuthor+ "', describe_Author= N'" + aut.describeAuthor + "' where id_Author= '"+ aut.idAuthor+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            try{
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
            } catch (Exception e)
            {Console.WriteLine(e);}
        }
        
        public void DeleteAuthor(String id)
        {
            string sql = "update author set status = N'false' where id_Author= '"+id+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        
        public List<Author> SearchAuthor(string name) {
            List<Author> list = new List<Author>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from author where name_Author LIKE '%"+name+"%'",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Author() {
                            idAuthor= reader["id_Author"].ToString(),
                            nameAuthor = reader["name_Author"].ToString(),
                            imgAuthor = reader["img_Author"].ToString(),
                            describeAuthor = reader["describe_Author"].ToString(),
                            status = reader["status"].ToString() 
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
            return list;
        }
        #endregion author
        
        #region discount
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
                            numberDiscount = int.Parse(reader["number_Discount"].ToString()),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
        
        public void DeleteDiscount(String id)
        {
            string sql = "update discount set status = N'false' where id_Discount= '"+id+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
        
        public void AddDiscount(Discount dis){
            string sql = "INSERT INTO discount VALUES (N'"+ dis.idDiscount + "',N'" + dis.nameDiscount + "'," + dis.quantityDis + ",N'" + dis.dateStart.ToString("yyyy-MM-dd HH:mm:ss") +"',N'"+dis.dateEnd.ToString("yyyy-MM-dd HH:mm:ss")+"',"+dis.numberDiscount+",N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        
        public void UpdateDiscount( Discount dis) {
            MySqlConnection cnn = GetConnection();
            try { 
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("update discount set name_Discount = N'"+dis.nameDiscount+"',"+
                "quantity_Discount = "+dis.quantityDis+", date_start = N'"+dis.dateStart.ToString("yyyy-MM-dd HH:mm:ss")+"',date_end = N'"+dis.dateEnd.ToString("yyyy-MM-dd HH:mm:ss")+"' where id_Discount = N'"+dis.idDiscount+"'",cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }
        #endregion discount
        
        #region order
        public List<OrderDetail> GetAllOrderDetail() {
            List<OrderDetail> list = new List<OrderDetail>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from detailorder",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new OrderDetail() {
                            idOrder = int.Parse(reader["id_Order"].ToString()),
                            idBook = reader["id_Book"].ToString(),
                            quantityBook = int.Parse(reader["quantity"].ToString())
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }

        public List<Order> GetAllOrder() {
            List<Order> list = new List<Order>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from `order`",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new Order() {
                            idOrder = int.Parse(reader["id_Order"].ToString()),
                            idCustomer = int.Parse(reader["id_Customer"].ToString()),
                            dateOrder = DateTime.Parse(reader["date_Order"].ToString()),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }

        public void deleteDetailOrder( int id) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from detailorder where id_Order = @idOrder",cnn);
                var idOrder = new MySqlParameter("idOrder",id);
                cmd.Parameters.Add(idOrder);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void deleteOrder (int id) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("delete from `order` where id_Order = @idOrder",cnn);
                var idOrder = new MySqlParameter("idOrder",id);
                cmd.Parameters.Add(idOrder);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void CreateOrder (int idCustomer) {
            MySqlConnection cnn = GetConnection();
            try {
                var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into `order`(id_Customer,date_Order,status) values (@idCustomer,@dateOrder,'Processing')",cnn);
                var idCus = new MySqlParameter("idCustomer",idCustomer);
                var dateOrder = new MySqlParameter("dateOrder",DateTime.Parse(daynow));
                cmd.Parameters.Add(idCus);
                cmd.Parameters.Add(dateOrder);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void CreateDetailOrder(int idOrder, string idBook, int quantity) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into detailorder values (@idOrder,@idBook,@quantity)",cnn);
                var idOr = new MySqlParameter("idOrder",idOrder);
                var idB = new MySqlParameter("idBook",idBook);
                var qtt = new MySqlParameter("quantity",quantity);
                cmd.Parameters.Add(idOr);
                cmd.Parameters.Add(idB);
                cmd.Parameters.Add(qtt);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void UpdateStatusOrder(int id,string status) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open(); 
                string sql = "update `order` set status=N'"+status+"' where id_Order="+id+"";
                
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }
        #endregion order
        
        #region user
        public List<User> GetAllUser() {
            List<User> list =  new List<User>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from user",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new User() {
                            idUser = int.Parse(reader["id_User"].ToString()),
                            email = reader["email"].ToString(),
                            password = reader["password"].ToString(),
                            role = reader["role"].ToString()
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
        #endregion user
        
        #region customer
        public List<Customer> GetAllCustomer() {
            List<Customer> list =  new List<Customer>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from customer",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new Customer() {
                            idUser = int.Parse(reader["id_User"].ToString()),
                            idCustomer = int.Parse(reader["id_Customer"].ToString()),
                            phoneCustomer = reader["phone_Cus"].ToString(),
                            idShip = reader["id_Ship"].ToString(),
                            addressCustomer = reader["address_Customer"].ToString(),
                            nameCustomer = reader["name_Customer"].ToString(),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }

        public void AddCustomer(Customer cus){
            string sql = "INSERT INTO customer(name_Customer,phone_Cus,id_Ship,address_Customer,id_User,status) VALUES (N'" + cus.nameCustomer + "'," + cus.phoneCustomer + ",N'" + cus.idShip +"',N'"+cus.addressCustomer+"',N'"+cus.idUser+"',N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }
        
        public void updateCus (Customer customer) {
            MySqlConnection cnn = GetConnection();
            try { 
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("update customer set name_Customer = @nameCustomer,"+
                "phone_Cus = @phoneCustomer, id_Ship = @idShip,address_Customer = @addressCustomer where id_Customer = @idCustomer",cnn);
                var idCustomer = new MySqlParameter("idCustomer",customer.idCustomer);
                var nameCustomer = new MySqlParameter("nameCustomer",customer.nameCustomer);
                var phoneCustomer = new MySqlParameter("phoneCustomer",customer.phoneCustomer);
                var idShip = new MySqlParameter("idShip",customer.idShip);
                var addressCustomer = new MySqlParameter("addressCustomer",customer.addressCustomer);
                cmd.Parameters.Add(idCustomer);
                cmd.Parameters.Add(nameCustomer);
                cmd.Parameters.Add(phoneCustomer);
                cmd.Parameters.Add(idShip);
                cmd.Parameters.Add(addressCustomer);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void DeleteCustomer(String idCus) {
            string sql = "update customer set status = N'false' where id_Customer= '"+idCus+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public void CreateUserCus(string email,string password,string status) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into user(email,password,role) values"+
                "(@email,@password,@status)",cnn);
                var Email = new MySqlParameter("email",email);
                var Password = new MySqlParameter("password",password);
                var Status = new MySqlParameter("status",status);
                cmd.Parameters.Add(Email);
                cmd.Parameters.Add(Password);
                cmd.Parameters.Add(Status);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void CreateCus(int idUser) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into customer(id_User) values"+
                "(@idUs)",cnn);
                
                var ID = new MySqlParameter("idUs",idUser);
                cmd.Parameters.Add(ID);
                cmd.ExecuteNonQuery();
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        #endregion customer
        
        #region shipping
        public List<Shipping> GetAllShipping() {
            List<Shipping> list = new List<Shipping>();

            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from shipping",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new Shipping() {

                            idShip = reader["id_Ship"].ToString(),
                            country = reader["country"].ToString(),
                            charge = float.Parse(reader["charge"].ToString())
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
            return list;
        }
        #endregion shipping
        
        #region supplier
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
                            phoneSupplier = reader["phone_Supplier"].ToString(),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } 
            catch (Exception e)
                {
                     Console.WriteLine("Can not open connection ! " + e.Message);
                }
               return list;    
        }
        
        public List<Supplier> SearchSupplier(string name) {
            List<Supplier> list = new List<Supplier>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from supplier where name_Supplier LIKE '%"+name+"%'",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Supplier() {
                            idSupplier = reader["id_Supplier"].ToString(),
                            nameSupplier = reader["name_Supplier"].ToString(),
                            addressSupplier = reader["address_Supplier"].ToString(),
                            phoneSupplier = reader["phone_Supplier"].ToString(),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
            return list;
        }

        public void AddSupplier(Supplier sup)
        {
            string sql = "INSERT INTO supplier VALUES (N'"+ sup.idSupplier + "',N'" + sup.nameSupplier + "',N'" + sup.addressSupplier + "',N'" + sup.phoneSupplier +"',N'true')";
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
            string sql = "update supplier set status = N'false' where id_Supplier= '"+id+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        #endregion supplier
        
        #region employee
        public List<Employee> GetAllEmployee() {
            List<Employee> list = new List<Employee>();

            MySqlConnection cnn = GetConnection();

            try {
                cnn.Open();
                
                MySqlCommand cmd = new MySqlCommand("select * from employee",cnn);
                using ( var reader = cmd.ExecuteReader()) {
                     while(reader.Read()) {
                        list.Add(new Employee() {
                            idEmployee= reader["id_Employee"].ToString(),
                            nameEmployee = reader["name_Employee"].ToString(),
                            phoneEmployee= reader["phone_Employee"].ToString(),
                            addEmployee = reader["address_Employee"].ToString(),
                            idUser = int.Parse(reader["id_User"].ToString()),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }

        public void AddEmployee(Employee emp){
            string sql = "INSERT INTO employee VALUES (N'"+ emp.idEmployee + "',N'" + emp.nameEmployee + "'," + emp.phoneEmployee + ",N'" + emp.addEmployee +"',N'"+emp.idUser+"',N'true')";
            MySqlConnection conn = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            cmd.ExecuteNonQuery();           
            cmd.Dispose();
            conn.Close();
        }

        public void DeleteEmployee(String idEmp) {
            string sql1 = "update employee set status = N'false' where id_Employee = '"+idEmp+"'";
            MySqlConnection conn= GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql1,conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        public void updateEmployee (Employee employee) {
            MySqlConnection cnn = GetConnection();
            try { 
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("update employee set name_Employee = @nameEmployee,"+
                "phone_Employee = @phoneEmployee, address_Employee = @addressEmployee where id_Employee = @idEmployee",cnn);
                var idCustomer = new MySqlParameter("idEmployee",employee.idEmployee);
                var nameCustomer = new MySqlParameter("nameEmployee",employee.nameEmployee);
                var phoneCustomer = new MySqlParameter("phoneEmployee",employee.phoneEmployee);
                var addressCustomer = new MySqlParameter("addressEmployee",employee.addEmployee);
                cmd.Parameters.Add(idCustomer);
                cmd.Parameters.Add(nameCustomer);
                cmd.Parameters.Add(phoneCustomer);
                cmd.Parameters.Add(addressCustomer);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        #endregion employee
    
        #region entry

        public List<Entry> GetAllEntry() {
            List<Entry> list = new List<Entry>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from entry",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new Entry() {
                            idEntry = reader["id_Entry"].ToString(),
                            dateEntry = DateTime.Parse(reader["date_Entry"].ToString()),
                            idSupplier = reader["id_Supplier"].ToString(),
                            status = reader["status"].ToString()
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }

        public List<DetailEntry> GetAllDetailEntry() {
            List<DetailEntry> list = new List<DetailEntry>();
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from detailentry",cnn);
                using( var reader = cmd.ExecuteReader()) {
                    while(reader.Read()) {
                        list.Add(new DetailEntry() {
                            idEntry = reader["id_Entry"].ToString(),
                            idBook = reader["id_Book"].ToString(),
                            quantityEntry = int.Parse(reader["quantity_entry"].ToString()),
                            priceEntry = float.Parse(reader["price_entry"].ToString())
                        });
                    }
                }
                cnn.Close();
            }catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }

            return list;
        }
        
        public void AddEntry(Entry entry) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into entry values (N'"+entry.idEntry+"',N'"+entry.dateEntry.ToString("yyyy-MM-dd HH:mm:ss")+"',N'"+entry.idSupplier+"',N'Processing')",cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void AddDetailEntry(DetailEntry detail) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into detailentry values (N'"+detail.idEntry+"',N'"+detail.idBook+"',"+detail.quantityEntry+","+detail.priceEntry+")",cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        public void UpdateEntry(Entry entry) {
            MySqlConnection cnn = GetConnection();
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("update entry set date_Entry=N'"+entry.dateEntry.ToString("yyyy-MM-dd HH:mm:ss")+"',id_Supplier=N'"+entry.idSupplier+"' where id_Entry=N'"+entry.idEntry+"'",cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void UpdateDetailEntry(DetailEntry detail) {
            MySqlConnection cnn = GetConnection();
                cnn.Open();
                MySqlCommand cmd = new MySqlCommand("update detailentry set quantity_Entry="+detail.quantityEntry+",price_Entry="+detail.priceEntry+" where id_Entry=N'"+detail.idEntry+"' and id_Book=N'"+detail.idBook+"'",cnn);
                cmd.ExecuteNonQuery();
                cnn.Close();
        }

        public void DeleteEntry(string id) {
            MySqlConnection cnn = GetConnection();
            cnn.Open();
            MySqlCommand cmd = new MySqlCommand("update entry set status =N'Cancelled' where id_Entry=N'"+id+"'",cnn);
            cmd.ExecuteNonQuery();
            cnn.Close();
        } 
        
        public void UpdateStatusEntry(string id,string status) {
            MySqlConnection cnn = GetConnection();
            try {
                cnn.Open(); 
                string sql = "update entry set status=N'"+status+"' where id_Entry=N'"+id+"'";
                
                MySqlCommand cmd = new MySqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();           
                cmd.Dispose();
                cnn.Close();
            } catch(Exception e) {
                Console.WriteLine("Can not open connection ! "+e.Message);
            }
        }

        #endregion entry
    }
}