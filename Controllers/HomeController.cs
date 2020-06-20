using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using frame.Models;
using frame.Data;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using frame.Common;


namespace frame.Controllers
{
    public class HomeController : Controller
    {   
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Home/
        
        public PartialViewResult Header() {
            BookStoreContext context = new BookStoreContext();
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            
            return PartialView("_Header");
        }
        
        public IActionResult Index()
        {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var books = context.GetAllBook().Where(a=>a.status == "true");
            var categories = context.GetAllCategory().Where(a=>a.status == "true");
            var discounts = context.GetAllDiscount().Where(d=>d.status=="true");
            List<OrderDetail> orderDetails = context.GetAllOrderDetail();
            //giờ hiện tại
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //sách đang khuyến mãi
            //1 nhỏ hơn 2 => <0
            var bookdis = from b in books 
                        join d in discounts on b.idDiscount equals d.idDiscount
                        where DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0
                        select new {
                            idBook = b.idBook,
                            nameBook = b.nameBook,
                            imgBook = b.imgBook,
                            priceBook = b.priceBook,
                            numberDiscount = d.numberDiscount,
                            idCategory = b.idCategory
                        };
            // sách được bán nhiều nhất và đang khuyến mãi
            var bookdisbest = (from b in bookdis 
                            join o in orderDetails on b.idBook equals o.idBook
                            group o by o.idBook into soluong
                            select new {
                                Key = soluong.Key,
                                sl = soluong.Sum(s => s.quantityBook)
                            }).OrderByDescending(s => s.sl).Take(10);
            var bookbest = from b in bookdisbest
                            join bo in bookdis on b.Key equals bo.idBook
                            select new BookSeller() {
                                idBook = bo.idBook,
                                nameBook = bo.nameBook,
                                imgBook = bo.imgBook,
                                priceBook = bo.priceBook,
                                numberDiscount = bo.numberDiscount
                            };
            //time flash sale
            var timesale = from d in discounts
                            where DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                            && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0
                            && d.nameDiscount.ToLower() == ("Flash Sale").ToLower()
                            select new FlashSale(){
                                dateEnd = d.dateEnd,
                                dateStart = d.dateStart
                            };

            //best seller
            var bestsel = (from b in books
                            join o in orderDetails on b.idBook equals o.idBook
                            group o by o.idBook into soluong
                            select new {
                                Key = soluong.Key,
                                sl = soluong.Sum(s=>s.quantityBook),
                            }).OrderByDescending(s => s.sl).Take(10);
            var best = from b in books
                        join be in bestsel on b.idBook equals be.Key
                        select new {
                            id = b.idBook,
                            idDis = b.idDiscount
                        };
            IEnumerable<BookSeller> bestseller = new List<BookSeller>();
            IEnumerable<BookSeller> bestsellerdis = new List<BookSeller>();
            foreach(var item in best) {
                if(item.idDis == "") {
                    bestseller = from b in books
                                where b.idBook == item.id
                                select new BookSeller() {
                                idBook = b.idBook,
                                nameBook = b.nameBook,
                                imgBook = b.imgBook,
                                priceBook = b.priceBook
                            };
                } else {
                    bestsellerdis = from b in books
                                    join d in discounts on b.idDiscount equals d.idDiscount
                                    where b.idBook == item.id
                                    select new BookSeller() {
                                        idBook = b.idBook,
                                        nameBook = b.nameBook,
                                        imgBook = b.imgBook,
                                        priceBook = b.priceBook,
                                        numberDiscount = d.numberDiscount
                                    };
                }
            }
            //giảm giá theo thể loại
            var drama = (from b in bookdis
                        join c in categories on b.idCategory equals c.idCategory
                        where c.nameCategory == "Drama"
                        select new BookSeller() {
                            idBook = b.idBook,
                            nameBook = b.nameBook,
                            imgBook = b.imgBook,
                            priceBook = b.priceBook,
                            numberDiscount = b.numberDiscount
                        }).Take(5);
            var trueStory = (from b in bookdis
                        join c in categories on b.idCategory equals c.idCategory
                        where c.nameCategory == "True Story"
                        select new BookSeller() {
                            idBook = b.idBook,
                            nameBook = b.nameBook,
                            imgBook = b.imgBook,
                            priceBook = b.priceBook,
                            numberDiscount = b.numberDiscount
                        }).Take(5);
            var loved = (from b in bookdis
                        join c in categories on b.idCategory equals c.idCategory
                        where c.nameCategory == "Loved"
                        select new BookSeller() {
                            idBook = b.idBook,
                            nameBook = b.nameBook,
                            imgBook = b.imgBook,
                            priceBook = b.priceBook,
                            numberDiscount = b.numberDiscount
                        }).Take(5);

            ViewBag.flashsale = timesale;
            ViewBag.Book = books;
            ViewBag.Category = categories;
            ViewBag.BookDisBest = bookbest;
            ViewBag.BestSellerDis = bestsellerdis;
            ViewBag.BestSeller = bestseller;
            ViewBag.Drama = drama;
            ViewBag.TrueStory = trueStory;
            ViewBag.Loved = loved;
            
            return View();
        }
        
        public IActionResult DetailProduct(string id) {
            BookStoreContext context = new BookStoreContext();
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            var books = context.GetAllBook().Where(c=>c.status == "true");
            var authors = context.GetAllAuthor().Where(c=>c.status == "true");
            var discounts = context.GetAllDiscount().Where(d=>d.status=="true" && DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0);
            var orderDetails = context.GetAllOrderDetail();

            var detail = from c in categories
                            join b in books on c.idCategory equals b.idCategory where b.idBook == id
                            join a in authors on b.idAuthor equals a.idAuthor
                            select new {
                                idDis = b.idDiscount,
                                idBook=b.idBook,nameBook=b.nameBook,imgBook=b.imgBook,
                                imgBackBook=b.imgBackBook,nameAuthor=a.nameAuthor,
                                describeAuthor=a.describeAuthor,imgAuthor=a.imgAuthor,
                                priceBook=b.priceBook,summaryBook=b.summaryBook,
                                nameCategory=c.nameCategory,desBook=b.desBook,pageCount=b.pageCount,
                                publishingYear=b.publishingYear,publisherBook=b.publisherBook
                            };
            IEnumerable<DetailBook> detailBook = new List<DetailBook>();
            IEnumerable<DetailBook> detailBookNotDis = new List<DetailBook>();
            foreach(var item in detail) {
                if(item.idDis == "") {
                        detailBookNotDis = from d in detail
                                        select new DetailBook() {
                                        idBook = d.idBook,imgBackBook=d.imgBackBook,nameAuthor=d.nameAuthor,
                                        nameBook=d.nameBook,describeAuthor=d.describeAuthor,imgAuthor=d.imgAuthor,
                                        imgBook=d.imgBook,priceBook=d.priceBook,summaryBook=d.summaryBook,
                                        nameCategory=d.nameCategory,desBook=d.desBook,pageCount=d.pageCount,
                                        publishingYear=d.publishingYear,publisherBook=d.publisherBook
                                    };
                   
                } else {
                    var x = discounts.Where(d=>d.idDiscount == item.idDis).DefaultIfEmpty(null).FirstOrDefault();
                    if(x == null) {
                        detailBookNotDis = from d in detail
                                        select new DetailBook() {
                                        idBook = d.idBook,imgBackBook=d.imgBackBook,nameAuthor=d.nameAuthor,
                                        nameBook=d.nameBook,describeAuthor=d.describeAuthor,imgAuthor=d.imgAuthor,
                                        imgBook=d.imgBook,priceBook=d.priceBook,summaryBook=d.summaryBook,
                                        nameCategory=d.nameCategory,desBook=d.desBook,pageCount=d.pageCount,
                                        publishingYear=d.publishingYear,publisherBook=d.publisherBook
                                    };
                    } else {
                        detailBook = from d in detail 
                                join dis in discounts on d.idDis equals dis.idDiscount
                                select new DetailBook() {
                                    idBook = d.idBook,imgBackBook=d.imgBackBook,nameAuthor=d.nameAuthor,
                                    nameBook=d.nameBook,describeAuthor=d.describeAuthor,imgAuthor=d.imgAuthor,
                                    imgBook=d.imgBook,priceBook=d.priceBook,summaryBook=d.summaryBook,
                                    nameCategory=d.nameCategory,desBook=d.desBook,pageCount=d.pageCount,
                                    publishingYear=d.publishingYear,publisherBook=d.publisherBook,
                                    numberDis = dis.numberDiscount
                                };
                    }  
                }
            }
            //sp liên quan
            var idCategory = from b in books
                            where b.idBook == id
                            select new {
                                id = b.idCategory
                            };
            IEnumerable<FourRel> product = new List<FourRel>();
            foreach(var item in idCategory) {
                product = (from b in books
                        join o in orderDetails on b.idBook equals o.idBook
                        where b.idCategory == item.id && b.idBook != id
                        group o by o.idBook into soluong
                        select new FourRel(){
                            id = soluong.Key,
                            sl = soluong.Sum(s=>s.quantityBook)
                        }).OrderByDescending(s=>s.sl).Take(4);
            }
            var proRel = from p in product
                        join b in books on p.id equals b.idBook
                        select new {
                            id = b.idBook,
                            idDiscount = b.idDiscount
                        };

            List<BookSeller> prorelDis = new List<BookSeller>();
            List<Book> prorel = new List<Book>();
            foreach(var item in proRel) {
                if(item.idDiscount == "") {
                    prorel.AddRange((from b in books
                            select new Book() {
                            idBook = b.idBook,
                            nameBook = b.nameBook,
                            imgBook = b.imgBook,
                            priceBook = b.priceBook
                        }).Where(b=>b.idBook == item.id).ToList()) ;
                } else {
                    var x = discounts.Where(d=>d.idDiscount == item.idDiscount).DefaultIfEmpty(null).FirstOrDefault();
                    if(x == null) { 
                        prorel.AddRange((from b in books
                            select new Book() {
                            idBook = b.idBook,
                            nameBook = b.nameBook,
                            imgBook = b.imgBook,
                            priceBook = b.priceBook
                        }).Where(b=>b.idBook == item.id).ToList()) ;
                    }else {
                        prorelDis.AddRange((from b in books
                                join d in discounts on b.idDiscount equals d.idDiscount
                                where b.idBook == item.id
                                select new BookSeller() {
                                    idBook = b.idBook,
                                    nameBook = b.nameBook,
                                    imgBook = b.imgBook,
                                    priceBook = b.priceBook,
                                    numberDiscount = d.numberDiscount
                                }).ToList());
                    }
                    
                }
            }
            
            ViewBag.ProRel = prorel;
            ViewBag.ProRelDis = prorelDis;
            ViewBag.DetailBook = detailBook;
            ViewBag.DetailBookNotDis = detailBookNotDis;
            ViewBag.Category = categories;
            return View();
        }
        
        public IActionResult MyAccount()
        {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            var password = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"password");
            var role = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"role");
            
            ViewBag.Email = email;
            ViewBag.Password = password;
            ViewBag.Role = role;
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            ViewBag.Category = categories;
            return View();
        }
        
        //ajax
        [HttpPost]
        public string ValidateEmailId(string email) {
            BookStoreContext context = new BookStoreContext();
            List<User> users = context.GetAllUser();
            var check = users.Where(u => u.email == email)
                        .Select(u => u.email).DefaultIfEmpty("").First();  
            if(check == "") {
                return "0";
            } else {
                return "1";
            }
        }
        
        public IActionResult SearchBook(string name) {
            BookStoreContext context = new BookStoreContext();
            List<Book> books = context.SearchBook(name);
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var discounts = context.GetAllDiscount().Where(d=>d.status=="true" && DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0);
            var bookdisplay = books.Where(b => b.status == "true");
            var html = "<div class='content clearfix'><div class='page-header page-header-product'>";
            html += "<div class='container'><h1>Search</h1><ul class='breadcrumb'><li class='breadcrumb-item'>";
            html+="<a href='/Home'>Home</a></li><li class='breadcrumb-item active'><strong>Search</strong>";
            html+="</li></ul></div></div></div><div class='ads-grid py-sm-5 py-4'>";
            html+="<div class='container py-xl-4 py-lg-2'><h3 class='tittle-w3l text-center mb-lg-5 mb-sm-4 mb-3'>";
            html+="<span>SẢN PHẨM ĐƯỢC TÌM THẤY</span></h3><div class='row search-book'>";
            foreach(var item in bookdisplay) {
                if(item.idDiscount != "") {
                    var x = discounts.Where(d=>d.idDiscount==item.idDiscount).DefaultIfEmpty(null).FirstOrDefault();
                    if(x == null) {
                        html += "<div class='col-md-3 product-men mt-5'>";
                        html += "<div class='men-pro-item simpleCart_shelfItem'>";
                        html += "<div class='men-thumb-item text-center'>";
                        html += "<img src='../../images/"+item.imgBook+"'alt='"+item.nameBook+"'widtd= '194px' height='300px'>";
                        html += "<div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='/Home/DetailProduct/"+item.idBook+"' class='link-product-add-cart'>Quick View</a> ";
                        html += "</div></div></div><div class='item-info-product text-center border-top mt-4'>";
                        html += "<h4 class='pt-1'><a href='#'>"+item.nameBook+"</a></h4>";
                        html += "<div class='info-product-price my-2'><span class='item_price'>"+item.priceBook+"$</span>";
                        html +="</div><div class='snipcart-details add-to-cart top_brand_home_details item_add single-item hvr-outline-out'>";
                        html += "<a class='button btn'data-name='"+item.nameBook+"'data-price = '"+item.priceBook+"'data-number = '0'data-image= '"+item.imgBook+"'id='"+item.idBook+"'>Add to cart</a>  ";
                        html += "</div></div></div></div>";
                    } else {
                        html += "<div class='col-md-3 product-men mt-5'>";
                        html += "<div class='men-pro-item simpleCart_shelfItem'>";
                        html += "<div class='men-thumb-item text-center'>";
                        html += "<img src='../../images/"+item.imgBook+"'alt='"+item.nameBook+"'widtd= '194px' height='300px'>";
                        html += "<div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='/Home/DetailProduct/"+item.idBook+"' class='link-product-add-cart'>Quick View</a> ";
                        html += "</div></div><span class='product-new-top'>-"+x.numberDiscount+"%</span></div><div class='item-info-product text-center border-top mt-4'>";
                        html += "<h4 class='pt-1'><a href='#'>"+item.nameBook+"</a></h4>";
                        html += "<div class='info-product-price my-2'><span class='item_price'>"+(item.priceBook-item.priceBook*x.numberDiscount/100)+"$</span>";
                        html += "<del>$"+item.priceBook+"</del>";
                        html +="</div><div class='snipcart-details add-to-cart top_brand_home_details item_add single-item hvr-outline-out'>";
                        html += "<a class='button btn'data-name='"+item.nameBook+"'data-price = '"+item.priceBook+"'data-number = '"+x.nameDiscount+"'data-image= '"+item.imgBook+"'id='"+item.idBook+"'>Add to cart</a>  ";
                        html += "</div></div></div></div>";
                    }                
                } else {
                    html += "<div class='col-md-3 product-men mt-5'>";
                    html += "<div class='men-pro-item simpleCart_shelfItem'>";
                    html += "<div class='men-thumb-item text-center'>";
                    html += "<img src='../../images/"+item.imgBook+"'alt='"+item.nameBook+"'widtd= '194px' height='300px'>";
                    html += "<div class='men-cart-pro'><div class='inner-men-cart-pro'><a href='/Home/DetailProduct/"+item.idBook+"' class='link-product-add-cart'>Quick View</a> ";
                    html += "</div></div></div><div class='item-info-product text-center border-top mt-4'>";
                    html += "<h4 class='pt-1'><a href='#'>"+item.nameBook+"</a></h4>";
                    html += "<div class='info-product-price my-2'><span class='item_price'>"+item.priceBook+"$</span>";
                    html +="</div><div class='snipcart-details add-to-cart top_brand_home_details item_add single-item hvr-outline-out'>";
                    html += "<a class='button btn'data-name='"+item.nameBook+"'data-price = '"+item.priceBook+"'data-number = '0'data-image= '"+item.imgBook+"'id='"+item.idBook+"'>Add to cart</a>  ";
                    html += "</div></div></div></div>";
                }
            }
            html+="</div></div></div>";
            return Json(new {html = html});
        }
        [HttpPost]
        public IActionResult MyAccount (User user) {
            BookStoreContext context = new BookStoreContext();
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            var customer = context.GetAllCustomer().Where(c=>c.status == "true");
            var users = from x in context.GetAllUser()
                        join c in customer on x.idUser equals c.idUser
                        select x;
            ViewBag.Category = categories;
            var button = Request.Form["submit"].ToString();
            if(button == "login") {
                if(ModelState.IsValid) {
                var login = users.Where(u => u.email == user.email && u.password == user.password)
                            .Select(u => u.role).DefaultIfEmpty("").First();  
                    
                if(login == "" ) {
                    var Error = "Email hoặc password không đúng!";
                    ViewBag.Error = Error;
                    return View(user);
                } else if(user.role == "admin") {
                    // if(login == "customer"){
                    //     SessionHelper.SetObjectAsJson(HttpContext.Session,"email",user.email);
                    //     return RedirectToAction("Index");
                    // }
                    SessionHelper.SetObjectAsJson(HttpContext.Session,"email",user.email);
                    SessionHelper.SetObjectAsJson(HttpContext.Session,"password",user.password);
                    SessionHelper.SetObjectAsJson(HttpContext.Session,"role",user.role);
                    return RedirectToAction("Index");
                    
                }
            }
            } else {
                if(ModelState.IsValid) {
                var check = users.Where(u => u.email == user.email)
                        .Select(u => u.email).DefaultIfEmpty("").First();  
                if(check == "") {
                    context.CreateUserCus(user.email,user.password,"customer");
                    var idUser = users.LastOrDefault();
                    context.CreateCus(idUser.idUser+1);
                    SessionHelper.SetObjectAsJson(HttpContext.Session,"email",user.email);
                    return RedirectToAction("Index");
                } else {
                    var Error = "Email đã tồn tại!";
                    ViewBag.Error = Error;
                    return View(user);
                    }
                }
            }
            
            return View(user);
        }

        public float ChargeCheckOut(string id) {
            BookStoreContext context = new BookStoreContext();
            List<Shipping> shippings = context.GetAllShipping();
            var charge = shippings.Where(s => s.idShip == id)
                            .Select(s => s.charge).FirstOrDefault();
            return charge;
        }
        
        public IActionResult CheckOut() {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            ViewBag.Category = categories;
            List<User> users = context.GetAllUser();
            var customers = context.GetAllCustomer().Where(c=>c.status == "true");
            var shippings = context.GetAllShipping();

            var idUser = users.Where(u => u.email == email)
                        .Select(u => u.idUser)
                        .FirstOrDefault();
            var infocus = customers.Where(c =>c.idUser == idUser).FirstOrDefault();
            
            ViewBag.Shipping = shippings;
            ViewBag.InfoCus = infocus;
            return View();
        }
        
        [HttpPost]
        public IActionResult CheckOut(Customer cus) {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            var button = Request.Form["submit"].ToString();
            if(button == "Hủy"){
                return RedirectToAction("Cart");
            } else {
                context.updateCus(cus);
                context.CreateOrder(cus.idCustomer);
                // context.CreateDetailOrder(idOrder,);
                return RedirectToAction("AlertSuccess");
            }
        }
        
        public IActionResult AlertSuccess() {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            ViewBag.Category = categories;
            return View();
        }
        
        [HttpPost]
        public string CreateCart(string id, int quantity) {
            BookStoreContext context = new BookStoreContext();
            var orders = context.GetAllOrder();
            var idOrder = orders.Select(o=>o.idOrder).LastOrDefault();
            context.CreateDetailOrder(idOrder,id,quantity);
            return "huhu";
        }
        
        public IActionResult Information() {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(c=>c.status == "true");
            ViewBag.Category = categories;
            List<User> users = context.GetAllUser();
            var customers = context.GetAllCustomer().Where(c=>c.status == "true");
            List<Shipping> shippings = context.GetAllShipping();

            var detailinfo = from u in users
                                join c in customers on u.idUser equals c.idUser
                                where u.email == email
                                select new Customer(){
                                    nameCustomer = c.nameCustomer,
                                    idCustomer = c.idCustomer,
                                    phoneCustomer = c.phoneCustomer,
                                    idShip = c.idShip,
                                    addressCustomer = c.addressCustomer,
                                    idUser = u.idUser
                                };
            var city = from s in shippings
                        join c in detailinfo on s.idShip equals c.idShip
                        select new Shipping() {
                            idShip = s.idShip,
                            country = s.country,
                            charge = s.charge
                        };
            ViewBag.detailinfo = detailinfo;
            ViewBag.city = city;
            ViewBag.cityList = shippings;
            return View();
        }
        
        [HttpPost]
        public IActionResult Information(Customer customer) {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(a=>a.status == "true");
            ViewBag.Category = categories;
            if(ModelState.IsValid) {
                context.updateCus(customer);
                TempData["StatusUpdate"] = "Update Success!";
                return RedirectToAction("Information");
            }
            return View();
        }
       
        public IActionResult Logout() {
            HttpContext.Session.Remove("email");
            return RedirectToAction("MyAccount");
        }
        
        public IActionResult InformationMyself() {
            BookStoreContext context = new BookStoreContext();
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(a=>a.status == "true");
            ViewBag.Category = categories;
            List<User> users = context.GetAllUser();
            var customers = context.GetAllCustomer().Where(a=>a.status == "true");
            List<Order> orders = context.GetAllOrder();
            List<OrderDetail> orderDetails = context.GetAllOrderDetail();
            var books = context.GetAllBook().Where(a=>a.status == "true");
            var discounts = context.GetAllDiscount().Where(d=>d.status == "true"&&DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0);

            var idUser = users.Where(u => u.email == email)
                        .Select(u =>u.idUser).FirstOrDefault();
            string detailinfo = (from c in customers
                                where c.idUser == idUser
                                select c.nameCustomer).FirstOrDefault();

            var myOrder = (from o in orders
                        join c in customers on o.idCustomer equals c.idCustomer 
                        where c.idUser == idUser
                        select new Order() {
                            idOrder = o.idOrder,
                            idCustomer = c.idCustomer,
                            status = o.status
                        }).ToList();
            ViewBag.Discount = discounts;
            ViewBag.Book = books;
            ViewBag.myOrderDetail = orderDetails;
            ViewBag.myOrder = myOrder;
            ViewBag.detailinfo = detailinfo;
            return View();
        }
        
        [HttpPost]
        public IActionResult InformationMyself(int id) {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            var categories = context.GetAllCategory().Where(a=>a.status == "true");
            ViewBag.Category = categories;
            context.deleteDetailOrder(id);
            context.deleteOrder(id);
            TempData["StatusDelete"] = "Delete Success!";
            return RedirectToAction("InformationMyself");
        }
        
        public IActionResult Cart() {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(a=>a.status == "true");
            ViewBag.Category = categories;
            return View();
        }
        
        public IActionResult SearchProduct() {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var categories = context.GetAllCategory().Where(a=>a.status == "true");
            ViewBag.Category = categories;
            return View();
        }
        
        public IActionResult ProductCategory(string id) {
            BookStoreContext context = new BookStoreContext();
            var email = SessionHelper.GetObjectFromJson<string>(HttpContext.Session,"email");
            
            ViewBag.Email = email;
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var categories = context.GetAllCategory().Where(a=>a.status == "true");
            var books = context.GetAllBook().Where(a=>a.status == "true");
            var discounts = context.GetAllDiscount().Where(d=>d.status=="true" && DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0);
            ViewBag.Category = categories;

            //lấy tên thể loại
            List<Category> nameCategory = categories.Where(c => c.idCategory == id).ToList();
            // Lấy list sách theo id thể loại
            var bookcategory = books.Where(b=>b.idCategory == id);
            // Lấy danh đang khuyến mãi theo id thể loại
            List<Book> booknotdis = new List<Book>();
            List<BookSeller> bookdis = new List<BookSeller>();
            foreach(var item in bookcategory) {
                if(item.idDiscount == "" ) {
                    booknotdis.AddRange(books.Where(b => b.idBook == item.idBook).ToList());
                } else {
                    var x = discounts.Where(d=>d.idDiscount==item.idDiscount).DefaultIfEmpty(null).FirstOrDefault();
                    if(x == null) { 
                        booknotdis.AddRange(books.Where(b => b.idBook == item.idBook).ToList());
                    } else {
                        bookdis.AddRange((from b in books
                                        join d in discounts on b.idDiscount equals d.idDiscount
                                        where b.idBook == item.idBook
                                        select new BookSeller(){
                                            idBook = b.idBook,
                                            nameBook = b.nameBook,
                                            imgBook = b.imgBook,
                                            priceBook = b.priceBook,
                                            numberDiscount = d.numberDiscount
                                        }).ToList());
                    }
                    
                }
            }
            ViewBag.NameCategory = nameCategory;
            ViewBag.BookNotDis = booknotdis;
            ViewBag.BookDis = bookdis;
            return View();
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
