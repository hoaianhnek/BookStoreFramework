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
using System.IO;
using System.Text;
using System.Globalization;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using frame.Common;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace frame.Controllers
{
    public class AdminController : Controller
    {
        
        public IActionResult Index() {
            BookStoreContext context = new BookStoreContext();
            var daynow = DateTime.Now.ToString("yyyy-MM-dd");
            var orders = context.GetAllOrder().Where(o=>o.dateOrder.ToString("yyyy-MM-dd") == daynow);
            int countsOrder = orders.Count();
            ViewBag.CountOrder = countsOrder;
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
            string id = "";
            if(idLast == null) {
                id = "A001";
            } else {
                var so = idLast.Substring(1,3);
                for(int i=0;i<so.Length;i++) {
                    if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                        id= ("A00").ToString() + (int.Parse(so)+1).ToString();
                    } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                        id = ("A0").ToString() + (int.Parse(so)+1).ToString();
                    } else {
                        id = ("A").ToString() + (int.Parse(so)+1).ToString();
                    }
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
            string id = "";
            if(idLast == null) {
                id = "C001";
            } else {
                var so = idLast.Substring(1,3);
                for(int i=0;i<so.Length;i++) {
                    if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                        id= ("C00").ToString() + (int.Parse(so)+1).ToString();
                    } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                        id = ("C0").ToString() + (int.Parse(so)+1).ToString();
                    } else {
                        id = ("C").ToString() + (int.Parse(so)+1).ToString();
                    }
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
            string id = "";
            if(idLast == null) {
                id = "S001";
            } else {
                var so = idLast.Substring(1,3);
                for(int i=0;i<so.Length;i++) {
                    if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                        id= ("S00").ToString() + (int.Parse(so)+1).ToString();
                    } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                        id = ("S0").ToString() + (int.Parse(so)+1).ToString();
                    } else {
                        id = ("S").ToString() + (int.Parse(so)+1).ToString();
                    }
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
            string id = "";
            if (idLast == null) {
                id = "E001";
            } else {
                var so = idLast.Substring(1,3);         
                for(int i=0;i<so.Length;i++) {
                    if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                        id= ("E00").ToString() + (int.Parse(so)+1).ToString();
                    } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                        id = ("E0").ToString() + (int.Parse(so)+1).ToString();
                    } else {
                        id = ("E").ToString() + (int.Parse(so)+1).ToString();
                    }
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
            string id = "";
            if(idLast == null) {
                id = "D001";
            } else {
                var so = idLast.Substring(1,3);
                for(int i=0;i<so.Length;i++) {
                    if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                        id= ("D00").ToString() + (int.Parse(so)+1).ToString();
                    } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                        id = ("D0").ToString() + (int.Parse(so)+1).ToString();
                    } else {
                        id = ("D").ToString() + (int.Parse(so)+1).ToString();
                    }
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
            var shipping = context.GetAllShipping();
            var shippings = shipping.Where(s=>s.status == "true");
            ViewBag.shipping = shippings;
            return View();
        }
        public IActionResult CreateShipping()
        {
            BookStoreContext context = new BookStoreContext();
            List<Shipping> shippings = context.GetAllShipping();
            string idLast = shippings.Select(s=>s.idShip).LastOrDefault();
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
        public IActionResult CreateShipping(string id, string country, float charge)
        {
            BookStoreContext context = new BookStoreContext();
            context.AddShipping(id,country, charge);
            TempData["StatusCreateShipping"] = "Create Shipping Success!";
            return RedirectToAction("ShippingManagement");
        }

        public IActionResult EditShipping(string id)
        {
           BookStoreContext context = new BookStoreContext();
           List<Shipping> shipping = context.GetAllShipping();
           var country = shipping.Where(c => c.idShip == id)
                        .FirstOrDefault();
           var charge = shipping.Where(c => c.idShip == id)
                        .FirstOrDefault();
            ViewBag.Shipping = country;
            ViewBag.Shipping = charge;
           return View();
       }
       [HttpPost]
       public IActionResult EditShipping (string id, string country, float charge)
       {
           BookStoreContext context = new BookStoreContext();
           var button = Request.Form["submit"].ToString();
           if(button == "Cancel") {
               return RedirectToAction("ShippingManagement");
           } else {
               context.UpdateShipping(id,country,charge);
               TempData["StatusUpdateShipping"] = "Update Shipping Success!";
               return RedirectToAction("ShippingManagement");
           }
       }

        public IActionResult DeleteShipping(string id)
        {
           BookStoreContext context = new BookStoreContext();
           context.DeleteShipping(id);
           TempData["StatusDeleteShipping"] = "Delete Shipping Success!";
           return RedirectToAction("ShippingManagement");
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
            var daynow = DateTime.Now.ToString("yyyy-MM-dd");
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
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            XGraphics graphics = XGraphics.FromPdfPage(page);  
            XFont font = new XFont("Timenewroman", 20, XFontStyle.Regular);
            XRect bounds = new XRect((graphics.PageSize.Width)/2-30, 40, 390, 0);
            graphics.DrawString("SkyBook",font,XBrushes.Black, bounds);

            XBrush solidBrush = new XSolidBrush(XColor.FromArgb(126, 151, 173));
            bounds = new XRect(30,bounds.Bottom + 15, graphics.PageSize.Width-60, 20);
            graphics.DrawRectangle(solidBrush, bounds);

            XFont subHeadingFont = new XFont("Timenewroman", 12, XFontStyle.Regular);
            bounds = new XRect(bounds.Left+10,bounds.Top+13,graphics.PageSize.Width-60,0);
            graphics.DrawString("SHD: " + id.ToString(),subHeadingFont, XBrushes.White, bounds);

            string currentDate = "Ngày đặt hàng: " + order.dateOrder.ToString("dd/mm/yyyy");
            var fontsize = graphics.MeasureString(currentDate,subHeadingFont);
            var point = new XPoint(bounds.Width - fontsize.Width, bounds.Y);
            graphics.DrawString(currentDate, subHeadingFont, XBrushes.White, point);

            XFont timesRoman = new XFont("Timenewroman", 12, XFontStyle.Regular);
            var color = new XSolidBrush(XColor.FromArgb(126, 155, 203));
            bounds = new XRect(bounds.Left,bounds.Bottom + 20,graphics.PageSize.Width-60,0);

            foreach(var c in customer) {
                if(c.idCustomer == order.idCustomer) {
                    foreach(var s in shipping) {
                        if(s.idShip == c.idShip) {
                            graphics.DrawString("Họ và tên: "+c.nameCustomer,timesRoman, color,bounds);
                            
                            bounds = new XRect(bounds.Left,bounds.Bottom + 20,graphics.PageSize.Width-60,0);
                            graphics.DrawString("Địa chỉ: "+c.addressCustomer,timesRoman, color,bounds);

                            bounds = new XRect(bounds.Left,bounds.Bottom + 20,graphics.PageSize.Width-60,0);
                            graphics.DrawString("SĐT: "+c.phoneCustomer,timesRoman, color,bounds);
                        }
                    }
                }
            }
            
            XPen linePen = new XPen(XColor.FromArgb(126, 151, 173), 0.70f);
            XPoint startPoint = new XPoint(bounds.Left-10, bounds.Bottom + 10);
            XPoint endPoint = new XPoint(bounds.Width+28, bounds.Bottom + 10);
            graphics.DrawLine(linePen, startPoint, endPoint);

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

            solidBrush = new XSolidBrush(XColor.FromArgb(126, 151, 173));
            var bounds1 = new XRect(30,bounds.Bottom + 15, graphics.PageSize.Width-60, 20);
            graphics.DrawRectangle(solidBrush, bounds1);

            var bounds2 = new XRect(bounds1.Left+10,bounds1.Top+13,graphics.PageSize.Width-60,0);
            graphics.DrawString("STT",timesRoman,XBrushes.White,bounds2);

            fontsize = graphics.MeasureString("STT",subHeadingFont);
            var bounds3 = new XRect(bounds2.Left+fontsize.Width+80,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Tên Sách",timesRoman,XBrushes.White,bounds3);

            fontsize = graphics.MeasureString("Tên Sách",subHeadingFont);
            var bounds4 = new XRect(bounds3.Left+fontsize.Width+110,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Số lượng",timesRoman,XBrushes.White,bounds4);

            fontsize = graphics.MeasureString("Số lượng",subHeadingFont);
            var bounds5 = new XRect(bounds4.Left+fontsize.Width+80,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Giá",timesRoman,XBrushes.White,bounds5);

            fontsize = graphics.MeasureString("Giá",subHeadingFont);
            var bounds6 = new XRect(bounds.Width-fontsize.Width-10,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Tổng tiền",timesRoman,XBrushes.White,bounds6);
            point = new XPoint(40,bounds1.Bottom);
            for(int i=0;i<dataTable.Rows.Count;i++) {
                point = new XPoint(point.X,point.Y+20);
                graphics.DrawString((i+1).ToString(),timesRoman,color,point);

                fontsize = graphics.MeasureString("STT",subHeadingFont);
                point = new XPoint(bounds2.Left+fontsize.Width+20,point.Y);
                graphics.DrawString(dataTable.Rows[i]["Name Book"].ToString(),timesRoman,color,point);
                
                fontsize = graphics.MeasureString("Tên Sách",subHeadingFont);
                point = new XPoint(bounds3.Left+fontsize.Width+120,point.Y);
                graphics.DrawString(dataTable.Rows[i]["Quantity"].ToString(),timesRoman,color,point);
                
                fontsize = graphics.MeasureString("Số lượng",subHeadingFont);
                point = new XPoint(bounds4.Left+fontsize.Width+75, point.Y);
                graphics.DrawString(dataTable.Rows[i]["Price"].ToString(),timesRoman,color,point);
                
                fontsize = graphics.MeasureString("Giá",subHeadingFont);
                point = new XPoint(bounds.Width-fontsize.Width-10,point.Y);
                graphics.DrawString(dataTable.Rows[i]["Total"].ToString(),timesRoman,color,point);

                point = new XPoint(40,point.Y);
            }

            linePen = new XPen(XColor.FromArgb(126, 151, 173), 0.70f);
            startPoint = new XPoint(30, point.Y+13);
            endPoint = new XPoint(bounds.Width+28, point.Y+13);
            graphics.DrawLine(linePen, startPoint, endPoint);

            foreach(var c in customer) {
                if(c.idCustomer == order.idCustomer) {
                  foreach(var s in shipping) {
                    if(c.idShip == s.idShip) {
                        tt += s.charge;
                        fontsize = graphics.MeasureString("Phí Ship: " +s.charge,subHeadingFont);
                        bounds = new XRect(graphics.PageSize.Width - fontsize.Width - 30,point.Y+32,0,0);
                        graphics.DrawString("Phí Ship: "+s.charge, timesRoman, color, bounds);
                       }
                   }
                }
            }

            fontsize = graphics.MeasureString("Tổng tiền: " +tt,subHeadingFont);
            bounds = new XRect(graphics.PageSize.Width - fontsize.Width - 30, bounds.Bottom+20,0,0);
            graphics.DrawString("Tổng tiền: "+tt,timesRoman,color,bounds);

            fontsize = graphics.MeasureString("Cảm ơn quý khách!",subHeadingFont);
            bounds = new XRect((graphics.PageSize.Width - fontsize.Width)/2,bounds.Bottom+80,0,0);
            graphics.DrawString("Cảm ơn quý khách! ",timesRoman,color,bounds);

            MemoryStream stream = new MemoryStream();
            
            document.Save(stream);
            stream.Position = 0;

            string contentType = "application/pdf";
            return File(stream,contentType);

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
            string id = "";
            if(idLast == null) {
                id = "B001";
            } else {
                var so = idLast.Substring(1,3);
                for(int i=0;i<so.Length;i++) {
                    if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                        id= ("B00").ToString() + (int.Parse(so)+1).ToString();
                    } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                        id = ("B0").ToString() + (int.Parse(so)+1).ToString();
                    } else {
                        id = ("B").ToString() + (int.Parse(so)+1).ToString();
                    }
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
            BookStoreContext context = new BookStoreContext();
            var discounts = context.GetAllDiscount().Where(d=>d.status=="true");
            var entrys = context.GetAllEntry();
            ViewBag.discounts = discounts;
            ViewBag.entrys = entrys;
            return View();
        }
        [HttpPost]
        public IActionResult CreateDiscountBook(List<string> idBook,string idDiscount) {
            BookStoreContext context = new BookStoreContext();
            foreach(var i in idBook) {
                context.UpdateDiscountBook(i,idDiscount);
            }
            TempData["StatusUpdateDiscount"] = "Create Discount Book Success!";
            return RedirectToAction("BookManagement");
        }
        
        //ajax
        public IActionResult SelectDis (int category) {
            BookStoreContext context = new BookStoreContext();
            var categories = context.GetAllCategory().Where(c=>c.status=="true");
            var books = context.GetAllBook();
            if(category == 1) {
                return new JsonResult(categories);
            } else {
                var b = books.OrderByDescending(bo=>bo.amountBook).Take(10);
                return new JsonResult(b);
            }   
        }
        public IActionResult CateDis (string idCategory) {
            BookStoreContext context = new BookStoreContext();
            var books = context.GetAllBook().Where(b=>b.idCategory == idCategory)
                            .OrderByDescending(bo=>bo.amountBook)
                            .Take(5);
            return new JsonResult(books);
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
                var dem =0;
                foreach(var d in discounts) {
                    if(d.idDiscount==b.idDiscount)  {
                        html+=d.nameDiscount+"</td><td>";
                        dem++;
                    }
                }
                if(dem == 0) {
                    html+="</td><td>";
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
            var entrys = context.GetAllEntry();
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
            string id = "";
            if (idLast == null) {
                id = "S001";
            } else {
                var so = idLast.Substring(1,3);
                for(int i=0;i<so.Length;i++) {
                    if(int.Parse(so) >=0 && int.Parse(so)<=8) {
                        id= ("S00").ToString() + (int.Parse(so)+1).ToString();
                    } else if(int.Parse(so)>=9 && int.Parse(so)<=98) {
                        id = ("S0").ToString() + (int.Parse(so)+1).ToString();
                    } else {
                        id = ("S").ToString() + (int.Parse(so)+1).ToString();
                    }
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
            context.DeleteDetailEntry(id);
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
            XGraphics graphics = XGraphics.FromPdfPage(page);  
            XFont font = new XFont("Timenewroman", 20, XFontStyle.Regular);
            XRect bounds = new XRect((graphics.PageSize.Width)/2-30, 40, 390, 0);
            graphics.DrawString("SkyBook",font,XBrushes.Black, bounds);

            XBrush solidBrush = new XSolidBrush(XColor.FromArgb(126, 151, 173));
            bounds = new XRect(30,bounds.Bottom + 15, graphics.PageSize.Width-60, 20);
            graphics.DrawRectangle(solidBrush, bounds);

            XFont subHeadingFont = new XFont("Timenewroman", 12, XFontStyle.Regular);
            bounds = new XRect(bounds.Left+10,bounds.Top+13,graphics.PageSize.Width-60,0);
            graphics.DrawString("SHD: " + id.ToString(),subHeadingFont, XBrushes.White, bounds);

            string currentDate = "Ngày đặt hàng: " + entry.dateEntry.ToString("dd/mm/yyyy");
            var fontsize = graphics.MeasureString(currentDate,subHeadingFont);
            var point = new XPoint(bounds.Width - fontsize.Width, bounds.Y);
            graphics.DrawString(currentDate, subHeadingFont, XBrushes.White, point);

            XFont timesRoman = new XFont("Timenewroman", 12, XFontStyle.Regular);
            var color = new XSolidBrush(XColor.FromArgb(126, 155, 203));
            bounds = new XRect(bounds.Left,bounds.Bottom + 20,graphics.PageSize.Width-60,0);

            foreach(var s in supplier) {
                if(s.idSupplier == entry.idSupplier) {
                    graphics.DrawString("Họ và tên: "+s.nameSupplier,timesRoman, color,bounds);
                            
                    bounds = new XRect(bounds.Left,bounds.Bottom + 20,graphics.PageSize.Width-60,0);
                    graphics.DrawString("Địa chỉ: "+s.addressSupplier,timesRoman, color,bounds);

                    bounds = new XRect(bounds.Left,bounds.Bottom + 20,graphics.PageSize.Width-60,0);
                    graphics.DrawString("SĐT: "+s.phoneSupplier,timesRoman, color,bounds);

                }
            }
            
            XPen linePen = new XPen(XColor.FromArgb(126, 151, 173), 0.70f);
            XPoint startPoint = new XPoint(bounds.Left-10, bounds.Bottom + 10);
            XPoint endPoint = new XPoint(bounds.Width+28, bounds.Bottom + 10);
            graphics.DrawLine(linePen, startPoint, endPoint);

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

           solidBrush = new XSolidBrush(XColor.FromArgb(126, 151, 173));
            var bounds1 = new XRect(30,bounds.Bottom + 15, graphics.PageSize.Width-60, 20);
            graphics.DrawRectangle(solidBrush, bounds1);

            var bounds2 = new XRect(bounds1.Left+10,bounds1.Top+13,graphics.PageSize.Width-60,0);
            graphics.DrawString("STT",timesRoman,XBrushes.White,bounds2);

            fontsize = graphics.MeasureString("STT",subHeadingFont);
            var bounds3 = new XRect(bounds2.Left+fontsize.Width+80,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Tên Sách",timesRoman,XBrushes.White,bounds3);

            fontsize = graphics.MeasureString("Tên Sách",subHeadingFont);
            var bounds4 = new XRect(bounds3.Left+fontsize.Width+110,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Số lượng",timesRoman,XBrushes.White,bounds4);

            fontsize = graphics.MeasureString("Số lượng",subHeadingFont);
            var bounds5 = new XRect(bounds4.Left+fontsize.Width+80,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Giá",timesRoman,XBrushes.White,bounds5);

            fontsize = graphics.MeasureString("Giá",subHeadingFont);
            var bounds6 = new XRect(bounds.Width-fontsize.Width-10,bounds2.Top,graphics.PageSize.Width-60,0);
            graphics.DrawString("Tổng tiền",timesRoman,XBrushes.White,bounds6);
            point = new XPoint(40,bounds1.Bottom);

            for(int i=0;i<dataTable.Rows.Count;i++) {
                point = new XPoint(point.X,point.Y+20);
                graphics.DrawString((i+1).ToString(),timesRoman,color,point);

                fontsize = graphics.MeasureString("STT",subHeadingFont);
                point = new XPoint(bounds2.Left+fontsize.Width+20,point.Y);
                graphics.DrawString(dataTable.Rows[i]["Name Book"].ToString(),timesRoman,color,point);
                
                fontsize = graphics.MeasureString("Tên Sách",subHeadingFont);
                point = new XPoint(bounds3.Left+fontsize.Width+120,point.Y);
                graphics.DrawString(dataTable.Rows[i]["Quantity"].ToString(),timesRoman,color,point);
                
                fontsize = graphics.MeasureString("Số lượng",subHeadingFont);
                point = new XPoint(bounds4.Left+fontsize.Width+75, point.Y);
                graphics.DrawString(dataTable.Rows[i]["Price"].ToString(),timesRoman,color,point);
                
                fontsize = graphics.MeasureString("Giá",subHeadingFont);
                point = new XPoint(bounds.Width-fontsize.Width-10,point.Y);
                graphics.DrawString(dataTable.Rows[i]["Total"].ToString(),timesRoman,color,point);

                point = new XPoint(40,point.Y);
            }

            linePen = new XPen(XColor.FromArgb(126, 151, 173), 0.70f);
            startPoint = new XPoint(30, point.Y+13);
            endPoint = new XPoint(bounds.Width+28, point.Y+13);
            graphics.DrawLine(linePen, startPoint, endPoint);

            fontsize = graphics.MeasureString("Tổng tiền: " +tt,subHeadingFont);
            bounds = new XRect(graphics.PageSize.Width - fontsize.Width - 30, point.Y+32,0,0);
            graphics.DrawString("Tổng tiền: "+tt,timesRoman,color,bounds);

            fontsize = graphics.MeasureString("Cảm ơn quý khách!",subHeadingFont);
            bounds = new XRect((graphics.PageSize.Width - fontsize.Width)/2,bounds.Bottom+80,0,0);
            graphics.DrawString("Cảm ơn quý khách! ",timesRoman,color,bounds);

            MemoryStream stream = new MemoryStream();
            
            document.Save(stream);
            stream.Position = 0;

            string contentType = "application/pdf";
            return File(stream,contentType);
        }
        // //ajax
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

        #region report

        public IActionResult SalesReport() {
            BookStoreContext context = new BookStoreContext();
            var year = context.GetAllOrder().Select(y=>y.dateOrder.Year).Distinct();
            var orders = context.GetAllOrder().Where(o=>o.status == "Delivered");
            var detailorders = context.GetAllOrderDetail();
            var detail = from o in orders join d in detailorders on o.idOrder equals d.idOrder
                        group d by //new {
                            // o.dateOrder.Year,
                            o.dateOrder.Month
                        /*}*/ into doanhthu
                        select new {
                            // year = doanhthu.Key.Year,
                            month = doanhthu.Key,
                            dt = doanhthu.Sum(d=>d.quantityBook*d.priceOrder)
                        };
            ViewBag.dt = detail;
            ViewBag.year = year;
            return View();
        }
        public IActionResult ReportFilter( int year) {
            BookStoreContext context = new BookStoreContext();
            var orders = context.GetAllOrder().Where(o=>o.dateOrder.Year == year && o.status == "Delivered");
            var detailorders = context.GetAllOrderDetail();
            var detail = from o in orders join d in detailorders on o.idOrder equals d.idOrder
                        orderby o.dateOrder.Month
                        group d by o.dateOrder.Month into dt
                        select new {
                            month = dt.Key,
                            doanhthu = dt.Sum(d=>d.priceOrder*d.quantityBook)
                        };

            return new JsonResult(detail);
        }
        // [HttpPost]
        // public IActionResult SalesReport(int year) {
        //     BookStoreContext context = new BookStoreContext();
        //     var y = context.GetAllOrder();

        // }
        #endregion report

        #region Account
        [HttpGet]
        public IActionResult AccountAdmin()
        {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            ViewBag.Email = email;
            return View();
        }
        [HttpPost]
        public IActionResult AccountAdmin (User user) {
            BookStoreContext context = new BookStoreContext();
            
            var users = context.GetAllUser();
                if(ModelState.IsValid) {
                var login = users.Where(u => u.email == user.email && u.password == user.password).FirstOrDefault();
                    if(login == null ) {
                        var Error = "Email hoặc password không đúng!";
                        ViewBag.Error = Error;
                        return View();
                    } else {
                        if(login.role.Equals("customer")) {
                            // SessionHelper.SetObjectAsJson(HttpContext.Session,"email",user.email);
                            ViewBag.Error = "Đây là tài khoản khách hàng, không thể đăng nhập";
                            return View();
                        }
                        else if (login.role.Equals("Admin") || login.role.Equals("employee")) {
                            HttpContext.Session.SetString("login", JsonConvert.SerializeObject(login));
                            return Redirect("/Admin/Index");
                        }
                    }
                }
            return View(user);
        }
        public IActionResult Logout(){
            HttpContext.Session.Remove("login");
            return Redirect("/Admin/AccountAdmin");
        }
        #endregion Account
    }
}