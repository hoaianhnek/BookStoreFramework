using System;
using System.Data;
using System.Windows;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using frame.Models;
using frame.Data;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Syncfusion.Pdf.Parsing;
using System.IO;
using System.Text;
using System.Globalization;

namespace frame.Controllers
{
    public class AdminController : Controller
    {
        
        public IActionResult Index() {
            return View();
        }
        
        #region author
        public IActionResult AuthorManagement() {
            BookStoreContext context = new BookStoreContext();
            List<Author> authors = context.GetAllAuthor();
            var athour = authors.Where(a => a.status == "true");
            return View(athour);
        }

        public IActionResult CreateAuthor()
        {
            BookStoreContext context = new BookStoreContext();
            List<Author> authors = context.GetAllAuthor();
            string idLast = authors.Select(a => a.idAuthor).LastOrDefault();
            var so = idLast.Substring(1,3);
            string id = "";
            for(int i=0;i<so.Length;i++) {
                if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                    id= ("A00").ToString() + (int.Parse(so)+1).ToString();
                } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                    id = ("A0").ToString() + (int.Parse(so)+1).ToString();
                } else {
                    id = ("A").ToString() + (int.Parse(so)+1).ToString();
                }
            }
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateAuthor(Author aut)
        {   
            BookStoreContext context = new BookStoreContext();
            context.AddAuthor(aut);
            TempData["StatusCreate"] = "Create Author Success!";
            return RedirectToAction("AuthorManagement");
        }
        public IActionResult EditAuthor(string id)
       {
           BookStoreContext context = new BookStoreContext();
           List<Author> authors = context.GetAllAuthor();
           var name = authors.Where(c=>c.idAuthor == id).FirstOrDefault();
           ViewBag.name = name;
           return View();
       }
        [HttpPost]
        public IActionResult EditAuthor (Author aut)
        {
           BookStoreContext context = new BookStoreContext();
           if(aut.imgAuthor == null) {
               context.UpdateAuthorNotImg(aut);
               TempData["StatusUpdate"] = "Update Author Success!";
               return RedirectToAction("AuthorManagement");
            } else {
               context.UpdateAuthor(aut);
               TempData["StatusUpdate"] = "Update Author Success!";
               return RedirectToAction("AuthorManagement");
            }
       }
        public IActionResult DeleteAuthor(string id)
        {
           BookStoreContext context = new BookStoreContext();
           context.DeleteAuthor(id);
           TempData["StatusDelete"] = "Delete Author Success!";
           return RedirectToAction("AuthorManagement");
       }
        public IActionResult  SearchAuthor(string name) {
            BookStoreContext context = new BookStoreContext();
            var authors = context.SearchAuthor(name);
            var author = authors.Where(a=>a.status == "true");
            return new JsonResult(author);
        }
        #endregion author
        
        #region category
        public IActionResult CategoryManagement()
        {
            BookStoreContext context = new BookStoreContext();
            List<Category> categories = context.GetAllCategory();
            var car = categories.Where(c => c.status == "true");
            return View(car);
        }

        public IActionResult CreateCategory()
        {
            BookStoreContext context = new BookStoreContext();
            List<Category> categories = context.GetAllCategory();
            string idLast = categories.Select(c=>c.idCategory).LastOrDefault();
            var so = idLast.Substring(1,3);
            string id = "";
            for(int i=0;i<so.Length;i++) {
                if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                    id= ("C00").ToString() + (int.Parse(so)+1).ToString();
                } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                    id = ("C0").ToString() + (int.Parse(so)+1).ToString();
                } else {
                    id = ("C").ToString() + (int.Parse(so)+1).ToString();
                }
            }
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(string id, string name)
        {
            BookStoreContext context = new BookStoreContext();
            context.AddCategory(id,name);
            TempData["StatusCreate"] = "Create Category Success!";
            return RedirectToAction("CategoryManagement");
        }

       public IActionResult EditCategory(string id)
       {
           BookStoreContext context = new BookStoreContext();
           List<Category> categories = context.GetAllCategory();
           var name = categories.Where(c => c.idCategory == id)
                        .FirstOrDefault();
            ViewBag.Category = name;
           return View();
       }
       [HttpPost]
       public IActionResult EditCategory (string id, string name)
       {
           BookStoreContext context = new BookStoreContext();
           var button = Request.Form["submit"].ToString();
           if(button == "Cancel") {
               return RedirectToAction("CategoryManagement");
           } else {
               context.UpdateCategory(id,name);
               TempData["StatusUpdate"] = "Update Category Success!";
               return RedirectToAction("CategoryManagement");
           }
       }

        public IActionResult DeleteCategory(string id)
       {
           BookStoreContext context = new BookStoreContext();
           context.DeleteCategory(id);
           TempData["StatusDelete"] = "Delete Category Success!";
           return RedirectToAction("CategoryManagement");
       }
        public IActionResult  SearchCategory(string name) {
            BookStoreContext context = new BookStoreContext();
            var categories = context.SearchCategory(name);
            var Category = categories.Where(c=>c.status=="true");
            return new JsonResult(Category);
        }
        #endregion category
        
        #region supplier
        public IActionResult SupplierManagement() {
            BookStoreContext context = new BookStoreContext();
            List<Supplier> suppliers = context.GetAllSupplier();
            var suppli = suppliers.Where(s => s.status == "true");
            return View(suppli);
        }
        public IActionResult CreateSupplier()
        {
            BookStoreContext context = new BookStoreContext();
            List<Supplier> suppliers = context.GetAllSupplier();
            string idLast = suppliers.Select(s => s.idSupplier).LastOrDefault();
            var so = idLast.Substring(1,3);
            string id = "";
            for(int i=0;i<so.Length;i++) {
                if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                    id= ("S00").ToString() + (int.Parse(so)+1).ToString();
                } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                    id = ("S0").ToString() + (int.Parse(so)+1).ToString();
                } else {
                    id = ("S").ToString() + (int.Parse(so)+1).ToString();
                }
            }
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateSupplier(Supplier sup)
        {
            if(ModelState.IsValid)
            {
                BookStoreContext context = new BookStoreContext();
                context.AddSupplier(sup);
                TempData["StatusCreate"] = "Create Supplier Success!";
                return RedirectToAction("SupplierManagement");
            }
            return View(sup);
        }
        public IActionResult EditSupplier(string id)
       {
           BookStoreContext context = new BookStoreContext();
           List<Supplier> suppliers = context.GetAllSupplier();
           var name = suppliers.Where(c=>c.idSupplier==id).FirstOrDefault();
           ViewBag.name = name;
           return View();
       }
        [HttpPost]
        public IActionResult EditSupplier (Supplier sup)
       {
           BookStoreContext context = new BookStoreContext();
           context.UpdateSupplier(sup);
           TempData["StatusUpdate"] = "Update Supplier Success!";
           return RedirectToAction("SupplierManagement");
       }
        public IActionResult DeleteSupplier(string id)
       {
           BookStoreContext context = new BookStoreContext();
           context.DeleteSupplier(id);
           TempData["StatusDelete"] = "Delete Supplier Success!";
           return RedirectToAction("SupplierManagement");
       }
        public IActionResult  SearchSupplier(string name) {
            BookStoreContext context = new BookStoreContext();
            var suppliers = context.SearchSupplier(name);
            var suppliers1 = suppliers.Where(c=>c.status=="true");
            return new JsonResult(suppliers1);
        }
        #endregion supplier
        
        #region employee
        public IActionResult EmployeeManagement() {
            BookStoreContext context = new BookStoreContext();
            var employee = context.GetAllEmployee();
            var employees = employee.Where(e=>e.status == "true");
            var users = context.GetAllUser();
            ViewBag.employee = employees;
            ViewBag.users = users;
            return View();
        }
        public IActionResult AddEmployee() {
            BookStoreContext context = new BookStoreContext();
            List<Employee> employees = context.GetAllEmployee();
            string idLast = employees.Select(c=>c.idEmployee).LastOrDefault();
            var so = idLast.Substring(1,3);
            string id = "";
            for(int i=0;i<so.Length;i++) {
                if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                    id= ("E00").ToString() + (int.Parse(so)+1).ToString();
                } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                    id = ("E0").ToString() + (int.Parse(so)+1).ToString();
                } else {
                    id = ("E").ToString() + (int.Parse(so)+1).ToString();
                }
            }
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee emp,User user) {
            BookStoreContext context = new BookStoreContext();
            context.CreateUserCus(user.email,user.password,"employee");
            var users = context.GetAllUser().LastOrDefault();
            emp.idUser = users.idUser;
            context.AddEmployee(emp);
            TempData["StatusCreate"] = "Create Employee Success!";
            return RedirectToAction("EmployeeManagement");
        }
        public IActionResult UpdateEmployee(string id) {
            BookStoreContext context = new BookStoreContext();
            List<Employee> employees = context.GetAllEmployee();
            List<User> users = context.GetAllUser();
            var x = employees.Where(d => d.idEmployee == id).FirstOrDefault();
            ViewBag.employees = x;
            ViewBag.user = users;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee em) {
            BookStoreContext context = new BookStoreContext();
            TempData["StatusUpdate"] = "Update Employee Success!";
            context.updateEmployee(em);
            return RedirectToAction("EmployeeManagement");
        }
        public IActionResult EmployeeDelete(string id) {
            BookStoreContext context = new BookStoreContext();
            context.DeleteEmployee(id);
            TempData["StatusDelete"] = "Delete Employee Success!";
            return RedirectToAction("EmployeeManagement");
        }
        public IActionResult SearchEmployee(string name) {
            BookStoreContext context = new BookStoreContext();
            var employees = context.GetAllEmployee();
            var users = context.GetAllUser();
            IEnumerable<Employee> em = new List<Employee>();
            if(name != null) {
                em = employees.Where(c => c.nameEmployee.ToLower().Contains(name.ToLower()) && c.status=="true");
                
            } else {
                em = employees.Where(c=>c.status == "true");
            }
            var customer = from c in em
                                join u in users on c.idUser equals u.idUser
                                select new {
                                    idEmployee = c.idEmployee,
                                    nameEmployee = c.nameEmployee,
                                    phoneEmployee = c.phoneEmployee,
                                    addEmployee = c.addEmployee,
                                    email = u.email,
                                    password = u.password
                                };
                            
            return new JsonResult(customer);
                
        }
        #endregion employee

        #region customer
        public IActionResult CustomerManagement() {
            BookStoreContext context = new BookStoreContext();
            var customer = context.GetAllCustomer();
            var users = context.GetAllUser();
            var customers = customer.Where(c=>c.status == "true");
            var shippings = context.GetAllShipping();
            ViewBag.shippings = shippings;
            ViewBag.customer = customers;
            ViewBag.users = users;
            return View();
        }
        public IActionResult AddCustomer() {
            BookStoreContext context = new BookStoreContext();
            var shipping = context.GetAllShipping();
            ViewBag.shipping = shipping;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer cus,User user) {
            BookStoreContext context = new BookStoreContext();
            
            if(cus.idShip == null) {
                TempData["ErrorShip"] = "Vui lòng nhập tỉnh/ thành phố!";
                return RedirectToAction("AddCustomer");
            }
            else {
                context.CreateUserCus(user.email,user.password,"customer");
                var users = context.GetAllUser().LastOrDefault();
                cus.idUser = users.idUser;
                context.AddCustomer(cus);
                TempData["StatusCreate"] = "Create Customer Success!";
                return RedirectToAction("CustomerManagement");
            }
            
        }
        public IActionResult CustomerDelete(string id) {
            BookStoreContext context = new BookStoreContext();
            context.DeleteCustomer(id);
            TempData["StatusDelete"] = "Delete Customer Success!";
            return RedirectToAction("CustomerManagement");
        }

        public IActionResult UpdateCustomer(int id){
            BookStoreContext context = new BookStoreContext();
            List<Customer> customers = context.GetAllCustomer();
            List<Shipping> shippings = context.GetAllShipping();
            List<User> users = context.GetAllUser();
            var x = customers.Where(d => d.idCustomer == id).FirstOrDefault();
            ViewBag.customer = x;
            ViewBag.shipping = shippings;
            ViewBag.user = users;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer cus) {
            BookStoreContext context = new BookStoreContext();
            TempData["StatusUpdate"] = "Update Customer Success!";
            context.updateCus(cus);
            return RedirectToAction("CustomerManagement");
        }
        public IActionResult SearchCustomer(string name) {
            BookStoreContext context = new BookStoreContext();
            var shippings = context.GetAllShipping();
            var customers = context.GetAllCustomer();
            var users = context.GetAllUser();
            IEnumerable<Customer> cus = new List<Customer>();
            if(name != null) {
                cus = customers.Where(c => c.nameCustomer.ToLower().Contains(name.ToLower()) && c.status=="true");
                
            } else {
                cus = customers.Where(c=>c.status == "true");
            }
            var customer = from s in shippings
                                join c in cus on s.idShip equals c.idShip
                                join u in users on c.idUser equals u.idUser
                                select new {
                                    idCustomer = c.idCustomer,
                                    nameCustomer = c.nameCustomer,
                                    phoneCustomer = c.phoneCustomer,
                                    country = s.country,
                                    addressCustomer = c.addressCustomer,
                                    email = u.email,
                                    password = u.password
                                };
                            
            return new JsonResult(customer);
                
        }
        #endregion customer

        #region discount
        public IActionResult DiscountManagement() {
            BookStoreContext context = new BookStoreContext();
            var discount = context.GetAllDiscount();
            var discounts = discount.Where(d=>d.status == "true");
            ViewBag.discount = discounts;
            return View();
        }
        public IActionResult AddDiscount() {
            BookStoreContext context = new BookStoreContext();
            List<Discount> discounts = context.GetAllDiscount();
            string idLast = discounts.Select(c=>c.idDiscount).LastOrDefault();
            var so = idLast.Substring(1,3);
            string id = "";
            for(int i=0;i<so.Length;i++) {
                if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                    id= ("D00").ToString() + (int.Parse(so)+1).ToString();
                } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                    id = ("D0").ToString() + (int.Parse(so)+1).ToString();
                } else {
                    id = ("D").ToString() + (int.Parse(so)+1).ToString();
                }
            }
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddDiscount(Discount dis) {
            BookStoreContext context = new BookStoreContext();
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if(DateTime.Compare(dis.dateStart,DateTime.Parse(daynow)) < 0) {
                TempData["errorDateStart"] = "Ngày bắt đầu phải lớn hơn ngày hiện tại";
                return RedirectToAction("AddDiscount");
            }else if(DateTime.Compare(dis.dateEnd,dis.dateStart) < 0) {
                TempData["errorDateEnd"] = "Ngày kết thúc phải lớn hơn ngày bắt đầu";
                return RedirectToAction("AddDiscount");
            } else {
                // Console.WriteLine(dis.dateStart);
                context.AddDiscount(dis);
                TempData["StatusCreate"] = "Create Discount Success!";
                return RedirectToAction("DiscountManagement");
            }
            
            
        }
        public IActionResult UpdateDiscount(string id){
            BookStoreContext context = new BookStoreContext();
            List<Discount> discounts = context.GetAllDiscount();
            var x = discounts.Where(d => d.idDiscount == id).FirstOrDefault();
            ViewBag.discount = x;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateDiscount(Discount dis) {
            BookStoreContext context = new BookStoreContext();
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if(DateTime.Compare(dis.dateEnd,dis.dateStart) < 0) {
                TempData["errorDateEnd"] = "Ngày kết thúc phải lớn hơn ngày bắt đầu";
                return RedirectToAction("UpdateDiscount");
            } else {
                TempData["StatusUpdate"] = "Update Discount Success!";
                context.UpdateDiscount(dis);
                return RedirectToAction("DiscountManagement");
            }
        }
        public IActionResult DiscountDelete(string id) {
            BookStoreContext context = new BookStoreContext();
            context.DeleteDiscount(id);
            TempData["StatusDelete"] = "Delete Discount Success!";
            return RedirectToAction("DiscountManagement");
        }   
        public IActionResult SearchDiscount(string name) {
            BookStoreContext context = new BookStoreContext();
            var Discount = context.GetAllDiscount();
            IEnumerable<Discount> dis = new List<Discount>();
            if(name != null) {
                dis = Discount.Where(c => c.nameDiscount.ToLower().Contains(name.ToLower()) && c.status=="true");
                
            } else {
                dis = Discount.Where(c=>c.status == "true");
            } 
            var html ="";
            foreach(var item in dis) {
                html += "<tr><td scope='row'>"+item.idDiscount+"</td>";
                html += "<td>"+item.nameDiscount+"</td>";
                html += "<td>"+item.quantityDis+"</td>";
                html += "<td>"+item.dateStart.ToString("dd-MM-yyyy")+"</td>";
                html += "<td>"+item.dateEnd.ToString("dd-MM-yyyy")+"</td>";
                html += "<td>"+item.numberDiscount+"</td>";
                html += "<td class='actionAdmin' style='width: 100px;'><a href='/Admin/DiscountDelete/"+item.idDiscount+"' class='btnSubmit'>";
                html += "<i class='fa fa-trash'></i></a>|" ;
                html += "<a href='/Admin/UpdateDiscount/"+item.idDiscount+"'><i class='fa fa-edit'></i></a> </td> </tr>";  
            }
            return new JsonResult(html);
                
        }
        #endregion discount

        #region shipping
        public IActionResult ShippingManagement() {
            BookStoreContext context = new BookStoreContext();
            var shippings = context.GetAllShipping();
            ViewBag.shippings = shippings;
            return View();
        }
        #endregion shipping

        #region order
        public IActionResult OrderManagement() {
            BookStoreContext context = new BookStoreContext();
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var customer = context.GetAllCustomer();
            var orders = context.GetAllOrder();
            var orderdetails = context.GetAllOrderDetail();
            var shippings = context.GetAllShipping();
            var books = context.GetAllBook();
            var discounts = context.GetAllDiscount().Where(d=>d.status=="true" && DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0);
            ViewBag.orders = orders;
            ViewBag.customers = customer;
            ViewBag.orderdetails = orderdetails;
            ViewBag.shippings = shippings;
            ViewBag.books = books;
            ViewBag.discounts = discounts;
            return View();
        }
        
        public IActionResult GeneratePdf(int id) {
            BookStoreContext context = new BookStoreContext();
            var order = context.GetAllOrder().Where(o=>o.idOrder==id).FirstOrDefault();
            var orders = context.GetAllOrder();
            var customer = context.GetAllCustomer();
            var shipping = context.GetAllShipping();
            var detailorders = context.GetAllOrderDetail();
            var books = context.GetAllBook();
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var discounts = context.GetAllDiscount().Where(d=>d.status=="true" && DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0);
            double tt = 0;
            //trừ số sách
            var detail = from o in orders
                        join d in detailorders on o.idOrder equals d.idOrder
                        where (o.idOrder == id)
                        select new {
                            idOrder = o.idOrder,
                            id = d.idBook,
                            quantity = d.quantityBook
                        };
            foreach(var d in detail) {
                foreach(var b in books) {
                    if(b.idBook == d.id) {
                        context.UpdateQuantity(b.idBook,d.quantity);
                        context.UpdateStatusOrder(d.idOrder,"Delivered");
                    }
                }
            }
            //tạo invoice
            PdfDocument document = new PdfDocument();//tạo tl pdf
            PdfPage page = document.Pages.Add();//thêm 1 trang vào tl
            PdfGraphics graphics = page.Graphics;  
            //title
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            RectangleF bounds = new RectangleF((graphics.ClientSize.Width)/2-30, 0, 390, 30);
            graphics.DrawString("SkyBook",font,PdfBrushes.Black, bounds);
            //bảng order
            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            bounds = new RectangleF(0,bounds.Bottom + 10, graphics.ClientSize.Width, 20);
            graphics.DrawRectangle(solidBrush, bounds);//hình chữ nhật tím

            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            PdfTextElement element = new PdfTextElement("SHD: " + id.ToString(), subHeadingFont);
            element.Brush = PdfBrushes.White;
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 3));
            string currentDate = "Date Order:" + order.dateOrder.ToString("dd/MM/yyyy");
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);

            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            foreach(var c in customer) {
                if(c.idCustomer == order.idCustomer) {
                    foreach(var s in shipping) {
                        if(s.idShip == c.idShip) {
                            element = new PdfTextElement("Name:"+c.nameCustomer, timesRoman);
                            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 5));

                            element = new PdfTextElement("Address:"+c.addressCustomer+"-"+s.country, timesRoman);
                            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 5));

                            element = new PdfTextElement("Phone:"+c.phoneCustomer,timesRoman);
                            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 5));

                        }
                    }
                }
            }
            
            PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
            PointF startPoint = new PointF(0, result.Bounds.Bottom + 3);
            PointF endPoint = new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 3);
            graphics.DrawLine(linePen, startPoint, endPoint);

            PdfGrid pdfGrid = new PdfGrid();
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name Book");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Total");
            foreach(var od in detailorders) {
                if(od.idOrder == order.idOrder) {
                    foreach(var b in books) {
                        if(b.idBook==od.idBook) {
                            var dem=0;
                            if(b.idBook == od.idBook && b.idDiscount!="") {
                                foreach (var d in discounts) {
                                    if(d.idDiscount == b.idDiscount) {
                                        dem++;
                                        dataTable.Rows.Add(new object[] { 
                                            b.nameBook, 
                                            od.quantityBook,
                                            b.priceBook-b.priceBook*d.numberDiscount/100,
                                            (b.priceBook-b.priceBook*d.numberDiscount/100)*od.quantityBook
                                        });
                                        tt += (b.priceBook-b.priceBook*d.numberDiscount/100)*od.quantityBook;
                                    }
                                }
                                if(dem==0) {
                                    dataTable.Rows.Add(new object[] { 
                                        b.nameBook, 
                                        od.quantityBook,
                                        b.priceBook,
                                        b.priceBook*od.quantityBook
                                    });
                                    tt += b.priceBook*od.quantityBook;
                                }
                            } else if(b.idBook == od.idBook) {
                                dataTable.Rows.Add(new object[] { 
                                    b.nameBook, 
                                    od.quantityBook,
                                    b.priceBook,
                                    b.priceBook*od.quantityBook
                                });
                                tt += b.priceBook*od.quantityBook;
                            }
                            
                        }
                    }
                }
            }
            pdfGrid.DataSource = dataTable;
            PdfGridRow header = pdfGrid.Headers[0];

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14,
                style: PdfFontStyle.Regular);

            for(int i=0;i<header.Cells.Count;i++) {
                if(i==0||i==1) {
                    header.Cells[i].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle
                    );
                } else {
                    header.Cells[i].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle
                    );
                }
                header.Cells[i].Style = headerStyle;
            }

            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217),width: (float)0.70);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman,12);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));

            for (int i = 0; i < pdfGrid.Rows.Count; i++) {
                PdfGridRow row = pdfGrid.Rows[i];
                for (int j = 0; j < row.Cells.Count; j++) {
                    row.Cells[j].Style = cellStyle;
                    if (j == 0 || j == 1) {
                    row.Cells[j].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle);
                    } else {
                        row.Cells[j].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle);
                    }
                }
            }
            PdfLayoutResult gridResult = pdfGrid.Draw(
            page: page,
            bounds: new RectangleF(0, result.Bounds.Bottom + 20,
                graphics.ClientSize.Width, graphics.ClientSize.Height - 100));
            //end detail
            foreach(var c in customer) {
                if(c.idCustomer == order.idCustomer) {
                    foreach(var s in shipping) {
                        if(c.idShip == s.idShip) {
                            gridResult.Page.Graphics.DrawString("Charge Ship: "+s.charge+"$",subHeadingFont,
                            brush: new PdfSolidBrush(new PdfColor(126, 155, 203)),
                            new RectangleF(graphics.ClientSize.Width - textSize.Width - 10,gridResult.Bounds.Bottom + 30,0,0));
                            tt += s.charge;
                        }
                    }
                }
            }

            gridResult.Page.Graphics.DrawString("Grand Total:"+tt+"$",subHeadingFont,
            brush: new PdfSolidBrush(new PdfColor(126, 155, 203)),
            new RectangleF(graphics.ClientSize.Width - textSize.Width - 10,gridResult.Bounds.Bottom + 50,0,0));

            gridResult.Page.Graphics.DrawString(
            "Thank you for your business !", subHeadingFont,
            brush: PdfBrushes.Black,
            new RectangleF((graphics.ClientSize.Width - textSize.Width)/2, gridResult.Bounds.Bottom + 80, 0, 0));
            //lưu pdf vào memory
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            //đặt vị trí là 0
            document.Close(true);
            //xác định type
            string contentType = "application/pdf";
            return File(stream,contentType);
            //string fileName=order.idOrder+".pdf";
            //return File(stream, contentType, fileName);
        }
        
        public string CheckQuantity(int id) {
            BookStoreContext context = new BookStoreContext();
            var Books = context.GetAllBook();
            var Order = context.GetAllOrder();
            var detailorders = context.GetAllOrderDetail();
            var listbook = from o in Order
                                join d in detailorders on o.idOrder equals d.idOrder
                                where(o.idOrder == id)
                                select new {
                                    idOrder = o.idOrder,
                                    id = d.idBook,
                                    quantity = d.quantityBook
                                };

            foreach( var item in listbook) {
                foreach(var b in Books) {
                    if(item.id == b.idBook && item.quantity > b.amountBook) {
                        context.UpdateStatusOrder(item.idOrder,"Cancelled");
                        return "0";
                    }
                }
            }
            return "1";

        }
        #endregion order

        #region book
        public IActionResult BookManagement() {
            BookStoreContext context = new BookStoreContext();
            var books = context.GetAllBook().Where(b=>b.status == "true");
            List<Category> categories = context.GetAllCategory();
            List<Author> authors = context.GetAllAuthor();
            List<Discount> discounts = context.GetAllDiscount();
            ViewBag.categories = categories;
            ViewBag.authors = authors;
            ViewBag.discounts = discounts;
            ViewBag.books = books;
           
            return View();
        }
        public IActionResult CreateBook() {
            BookStoreContext context = new BookStoreContext();
            List<Book> books = context.GetAllBook();
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            var author = context.GetAllAuthor().Where(a=>a.status == "true");
            string idLast = books.Select(c=>c.idBook).LastOrDefault();
            var so = idLast.Substring(1,3);
            string id = "";
            for(int i=0;i<so.Length;i++) {
                if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                    id= ("B00").ToString() + (int.Parse(so)+1).ToString();
                } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                    id = ("B0").ToString() + (int.Parse(so)+1).ToString();
                } else {
                    id = ("B").ToString() + (int.Parse(so)+1).ToString();
                }
            }
            ViewBag.id = id;
            ViewBag.categories = categories;
            ViewBag.authors = author;
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(Book book) {
            BookStoreContext context = new BookStoreContext();
            if(book.idCategory == null) {
                TempData["ErrorCategory"] = "Vui lòng chọn thể loại!";
                return RedirectToAction("CreateBook");
            } else if(book.idAuthor == null) {
                TempData["ErrorAuthor"] = "Vui lòng chọn tác giả!";
                return RedirectToAction("CreateBook");
            }else {
                context.AddBook(book);
                TempData["StatusCreate"] = "Create Book Success!";
                return RedirectToAction("BookManagement");
            }
        }
        public IActionResult EditBook(string id) {
            BookStoreContext context = new BookStoreContext();
            var books = context.GetAllBook().Where(b=>b.idBook==id).FirstOrDefault();
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            var authors = context.GetAllAuthor().Where(c=>c.status == "true");
            ViewBag.books = books;
            ViewBag.categories = categories;
            ViewBag.authors = authors;
            return View();
        }
        [HttpPost]
        public IActionResult EditBook(Book book) {
            BookStoreContext context = new BookStoreContext();
            TempData["StatusUpdate"] = "Update Book Success!";
            context.EditBook(book);
            return RedirectToAction("BookManagement");
        }
        public IActionResult DeleteBook(string id) {
            BookStoreContext context = new BookStoreContext();
            context.DeleteBook(id);
            TempData["StatusDelete"] = "Delete Book Success!";
            return RedirectToAction("BookManagement");
        }
        public IActionResult CreateDiscountBook() {
            return View();
        }
        public IActionResult SearchBook(string name) {
            BookStoreContext context = new BookStoreContext();
            var books = context.GetAllBook();
            List<Category> categories = context.GetAllCategory();
            List<Author> authors = context.GetAllAuthor();
            List<Discount> discounts = context.GetAllDiscount();
            string html = "";
            IEnumerable<Book> bo = new List<Book>();
            if(name!=null) {
                bo = books.Where(b=>b.status=="true"&&b.nameBook.ToLower().Contains(name.ToLower()));
            } else {
                bo = books.Where(b=>b.status=="true");
            }
            foreach(var b in bo) {
                html+="<tr><td>"+b.idBook+"</td><td>"+b.nameBook+"</td><td><img src='../../images/"+b.imgBook+"' src='"+b.nameBook+"' width='64' height='92'>";
                html+="</td><td><p class = 'content_DesBook'>"+b.desBook+"</p></td><td><p class ='content_SumBook'>"+b.summaryBook+"</p></td>";
                html+="<td>"+b.priceBook+"</td><td>";
                foreach(var c in categories) {
                    if(c.idCategory==b.idCategory)
                    html+=c.nameCategory+"</td>";
                }
                html+="<td>"+b.amountBook+"</td><td>"+b.publishingYear+"</td><td>"+b.pageCount+"</td><td>"+b.publisherBook+"</td> <td>";
                foreach(var a in authors) {
                    if(a.idAuthor==b.idAuthor) {
                        html+=a.nameAuthor+"</td><td>";
                    }
                }
                foreach(var d in discounts) {
                    if(d.idDiscount==b.idDiscount)  {
                        html+=d.nameDiscount+"</td><td>";
                    }
                }
                html+="<img src='../../images/"+b.imgBackBook+"' src='"+b.nameBook+"' width='64'height='92'>";
                html+="</td><td class='actionAdmin' style='width: 100px;'><a href='/Admin/DeleteBook/"+b.idBook+"' class='btnSubmit'>";
                html+="<i class='fa fa-trash'></i></a>|<a href='/Admin/EditBook/"+b.idBook+"'>";
                html+="<i class='fa fa-edit'></i></a></td></tr>";
            }
            return new JsonResult(html);
        }
        #endregion book
        
        #region entry
        public IActionResult EntryManagement() {
            BookStoreContext context = new BookStoreContext();
            var entrys = context.GetAllEntry().Where(e=>e.status=="Processing" || e.status == "Delivered");
            var suppliers = context.GetAllSupplier();
            var detail = context.GetAllDetailEntry();
            var books = context.GetAllBook();
            ViewBag.books = books;
            ViewBag.detail = detail;
            ViewBag.supplier = suppliers;
            ViewBag.entry = entrys;
            return View();
        }
        public IActionResult CreateEntry() {
            BookStoreContext context = new BookStoreContext();
            var suppliers = context.GetAllSupplier().Where(s=>s.status=="true");
            var books = context.GetAllBook().Where(b=>b.status == "true");
            var entrys = context.GetAllEntry();
            
            string idLast = entrys.Select(c=>c.idEntry).LastOrDefault();
            var so = idLast.Substring(1,3);
            string id = "";
            for(int i=0;i<so.Length;i++) {
                if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                    id= ("S00").ToString() + (int.Parse(so)+1).ToString();
                } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                    id = ("S0").ToString() + (int.Parse(so)+1).ToString();
                } else {
                    id = ("S").ToString() + (int.Parse(so)+1).ToString();
                }
            }
            ViewBag.id = id;
            ViewBag.suppliers = suppliers;
            ViewBag.books = books;
            return View();
        }   
        
        [HttpPost]
        public IActionResult CreateEntry(Entry entry,DetailEntry detail,List<string> id,List<int> amount,List<float> price) {
            BookStoreContext context = new BookStoreContext();
            
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if(DateTime.Compare(entry.dateEntry,DateTime.Parse(daynow)) < 0) {
                TempData["errorDate"] = "Date Entry must bigger day now";
                return RedirectToAction("CreateEntry");
            } else if(entry.idSupplier == ""){
                TempData["errorSupplier"] = "Name Supplier not empty";
                return RedirectToAction("CreateEntry");
            } else {
                var dem = 0;
                foreach(var item in id) {
                    dem++;
                }

                if(dem==0) {
                    TempData["errordetail"] = "Detail Products not empty";
                    return RedirectToAction("CreateEntry");
                } else {
                    context.AddEntry(entry);
                    for(int i=0;i<dem;i++) {
                    detail.idBook = id[i];
                    detail.quantityEntry = amount[i];
                    detail.priceEntry = price[i];
                    context.AddDetailEntry(detail);
                    }
                    TempData["StatusCreate"] = "Create Entry Success!";
                    return RedirectToAction("EntryManagement");
                }
            }
        }
        public IActionResult EditEntry(string id) {
            BookStoreContext context = new BookStoreContext();
            var entry = context.GetAllEntry().Where(e=>e.idEntry == id).FirstOrDefault();
            var suppliers = context.GetAllSupplier().Where(s=>s.status == "true");
            var books = context.GetAllBook().Where(b=>b.status == "true");
            var detail = context.GetAllDetailEntry();
            ViewBag.detail = detail;
            ViewBag.suppliers = suppliers;
            ViewBag.books = books;
            ViewBag.entry = entry;
            return View();
        }
        [HttpPost]
        public IActionResult EditEntry(Entry entry,DetailEntry detail,List<string> id,List<int> amount,List<float> price) {
            BookStoreContext context = new BookStoreContext();
            var details = context.GetAllDetailEntry();
            
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if(DateTime.Compare(entry.dateEntry,DateTime.Parse(daynow)) < 0) { 
                TempData["errorDate"] = "Date Entry must bigger day now";
                return RedirectToAction("EditEntry");
            } else {
                context.UpdateEntry(entry);
                var dem = 0;
                foreach(var item in id) {
                    dem++;
                }
                for(int i=0;i<dem;i++) {
                    foreach(var d in details) {
                        if(detail.idEntry == d.idEntry && id[i] == d.idBook) {
                            detail.idBook = id[i];
                            detail.quantityEntry = amount[i];
                            detail.priceEntry = price[i];
                            context.UpdateDetailEntry(detail);
                        } else if(detail.idEntry == d.idEntry && id[i] != d.idBook) {
                            detail.idBook = id[i];
                            detail.quantityEntry = amount[i];
                            detail.priceEntry = price[i];
                            context.AddDetailEntry(detail);
                        }
                    }
                }
            }
            TempData["StatusUpdate"] = "Update Entry Success!";
            return RedirectToAction("EntryManagement");
        }
        
        public IActionResult DeleteEntry(string id) {
            BookStoreContext context = new BookStoreContext();
            context.DeleteEntry(id);
            TempData["StatusDelete"] = "Delete Entry Success!";
            return  RedirectToAction("EntryManagement");
        }
        
        public IActionResult GeneratePdfEntry(string id) {
            BookStoreContext context = new BookStoreContext();
            var entry = context.GetAllEntry().Where(o=>o.idEntry==id).FirstOrDefault();
            var entrys = context.GetAllEntry();
            var supplier = context.GetAllSupplier();
            var detail = context.GetAllDetailEntry();
            var book = context.GetAllBook();
            float tt=0;
            //Cộng thêm sách update lại giá
            var de = from e in entrys
                    join d in detail on e.idEntry equals d.idEntry
                    where d.idEntry == id
                    select new {
                        idBook = d.idBook,
                        quantity = d.quantityEntry,
                        idEntry = d.idEntry,
                        price = d.priceEntry
                    };
            foreach(var d in de) {
                foreach(var b in book) {
                    if(b.idBook == d.idBook) {
                        context.UpdateQuantityCong(b.idBook,d.quantity,d.price);
                        context.UpdateStatusEntry(d.idEntry,"Delivered");
                    }
                }
            }
        

            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;  
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            RectangleF bounds = new RectangleF((graphics.ClientSize.Width)/2-30, 0, 390, 30);
            graphics.DrawString("SkyBook",font,PdfBrushes.Black, bounds);

            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            bounds = new RectangleF(0,bounds.Bottom + 10, graphics.ClientSize.Width, 20);
            graphics.DrawRectangle(solidBrush, bounds);

            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            PdfTextElement element = new PdfTextElement("SHD: " + id.ToString(), subHeadingFont);
            element.Brush = PdfBrushes.White;
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 3));

            string currentDate = "Date Order:" + entry.dateEntry.ToString("dd/MM/yyyy");
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);

            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            foreach(var s in supplier) {
                if(s.idSupplier == entry.idSupplier) {
                    element = new PdfTextElement("Name: "+s.nameSupplier, timesRoman);
                    element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                    result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 5));

                    element = new PdfTextElement("Adress: "+s.addressSupplier, timesRoman);
                    element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                    result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 5));

                    element = new PdfTextElement("Phone: "+s.phoneSupplier, timesRoman);
                    element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                    result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 5));
                }
            }
            
            PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
            PointF startPoint = new PointF(0, result.Bounds.Bottom + 3);
            PointF endPoint = new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 3);
            graphics.DrawLine(linePen, startPoint, endPoint);

            PdfGrid pdfGrid = new PdfGrid();
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name Book");
            dataTable.Columns.Add("Quantity");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Total");

            foreach(var item in detail) {
                if(item.idEntry == entry.idEntry) {
                    foreach(var b in book) {
                        if(b.idBook==item.idBook) {
                            dataTable.Rows.Add(new object[] { 
                                b.nameBook,
                                item.quantityEntry,
                                item.priceEntry,
                                item.quantityEntry*item.priceEntry
                            });
                            tt += item.quantityEntry*item.priceEntry;
                        }
                    }
                }
            }

            pdfGrid.DataSource = dataTable;
            PdfGridRow header = pdfGrid.Headers[0];

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14,
                style: PdfFontStyle.Regular);

            for(int i=0;i<header.Cells.Count;i++) {
                if(i==0||i==1) {
                    header.Cells[i].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle
                    );
                } else {
                    header.Cells[i].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle
                    );
                }
                header.Cells[i].Style = headerStyle;
            }

            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217),width: (float)0.70);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman,12);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));

            for (int i = 0; i < pdfGrid.Rows.Count; i++) {
                PdfGridRow row = pdfGrid.Rows[i];
                for (int j = 0; j < row.Cells.Count; j++) {
                    row.Cells[j].Style = cellStyle;
                    if (j == 0 || j == 1) {
                    row.Cells[j].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle);
                    } else {
                        row.Cells[j].StringFormat = new PdfStringFormat(
                        alignment: PdfTextAlignment.Center,
                        lineAlignment: PdfVerticalAlignment.Middle);
                    }
                }
            }

            PdfLayoutResult gridResult = pdfGrid.Draw(
            page: page,
            bounds: new RectangleF(0, result.Bounds.Bottom + 20,
                graphics.ClientSize.Width, graphics.ClientSize.Height - 100));

            gridResult.Page.Graphics.DrawString("Grand Total:"+tt+"$",subHeadingFont,
            brush: new PdfSolidBrush(new PdfColor(126, 155, 203)),
            new RectangleF(graphics.ClientSize.Width - textSize.Width - 10,gridResult.Bounds.Bottom + 50,0,0));

            gridResult.Page.Graphics.DrawString(
            "Thank you for your business !", subHeadingFont,
            brush: PdfBrushes.Black,
            new RectangleF((graphics.ClientSize.Width - textSize.Width)/2, gridResult.Bounds.Bottom + 80, 0, 0));

            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            //đặt vị trí là 0
            document.Close(true);
            //xác định type
            string contentType = "application/pdf";
            return File(stream,contentType);
        }
        //ajax
        public IActionResult AddBookEntry(string name,int quantity,float price) {
            BookStoreContext context = new BookStoreContext();
            var nameBook = context.GetAllBook().Where(b=>b.idBook == name).Select(b=>b.nameBook).FirstOrDefault();
            Book book = new Book();
            book.idBook = name;
            book.nameBook = nameBook;
            book.amountBook = quantity;
            book.priceBook = price;
            return new JsonResult(book);
        }
        #endregion entry
    
    }
}