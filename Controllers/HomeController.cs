using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using frame.Models;
using frame.Data;
using Microsoft.Extensions.DependencyInjection;

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
            List<Category> categories = context.GetAllCategory();
            ViewBag.Category = categories;
            return PartialView("_Header");
        }
        public IActionResult Index()
        {
            BookStoreContext context = new BookStoreContext();

            List<Book> books = context.GetAllBook();
            List<Category> categories = context.GetAllCategory();
            List<Discount> discounts = context.GetAllDiscount();
            //giờ hiện tại
            var daynow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //sách khuyến mãi
            //1 nhỏ hơn 2 => <0
            var bookdis = from b in books 
                        join d in discounts on b.idDiscount equals d.idDiscount
                        where DateTime.Compare(d.dateStart,DateTime.Parse(daynow))  < 0
                        && DateTime.Compare(DateTime.Parse(daynow),d.dateEnd) < 0
                        select new BookSeller(){
                            idBook = b.idBook,
                            nameBook = b.nameBook,
                            imgBook = b.imgBook,
                            priceBook = b.priceBook,
                            numberDiscount = d.numberDiscount
                        };
                       
            ViewBag.Book = books;
            ViewBag.Category = categories;
            ViewBag.BookDis = bookdis;
            return View();
        }
        public IActionResult DetailProduct(string id) {
            BookStoreContext context = new BookStoreContext();

            List<Category> categories = context.GetAllCategory();
            List<Book> books = context.GetAllBook();
            List<Author> authors = context.GetAllAuthor();

            var detail = from c in categories
                            join b in books on c.idCategory equals b.idCategory where b.idBook == id
                            join a in authors on b.idAuthor equals a.idAuthor
                            select new DetailBook(){
                                idBook=b.idBook,nameBook=b.nameBook,imgBook=b.imgBook,
                                imgBackBook=b.imgBackBook,nameAuthor=a.nameAuthor,
                                describeAuthor=a.describeAuthor,imgAuthor=a.imgAuthor,
                                priceBook=b.priceBook,summaryBook=b.summaryBook,
                                nameCategory=c.nameCategory,desBook=b.desBook,pageCount=b.pageCount,
                                publishingYear=b.publishingYear,publisherBook=b.publisherBook
                            };
            // var detailbook = from d in detail
            //                     where d.idBook = id;
            ViewBag.detail = detail;
            ViewBag.Category = categories;
            return View();
        }
        public IActionResult MyAccount()
        {
            //BookStoreContext context = HttpContext.RequestServices.GetService(typeof(frame.Models.BookStoreContext)) as BookStoreContext;

            // List<Category> listCategory = context.GetAllCategory();
            // ViewBag.Category = listCategory;
            return View();
        }
        public IActionResult CheckOut() {
            //BookStoreContext context = HttpContext.RequestServices.GetService(typeof(frame.Models.BookStoreContext)) as BookStoreContext;
            // List<Category> lista = context.GetAllCategory();
            // ViewBag.Category = lista;
            return View();
        }
        public IActionResult InformationMyself() {
            BookStoreContext context = new BookStoreContext();
            List<Category> categories = context.GetAllCategory();
            ViewBag.Category = categories;
            return View();
        }
        public IActionResult Information() {
            BookStoreContext context = new BookStoreContext();
            List<Category> categories = context.GetAllCategory();
            ViewBag.Category = categories;
            return View();
        }
        public IActionResult SearchProduct() {
            //BookStoreContext context = HttpContext.RequestServices.GetService(typeof(frame.Models.BookStoreContext)) as BookStoreContext;
            // List<Category> lista = context.GetAllCategory();
            // ViewBag.Category = lista;
            return View();
        }
        public IActionResult ProductCategory() {
            //BookStoreContext context = HttpContext.RequestServices.GetService(typeof(frame.Models.BookStoreContext)) as BookStoreContext;
            // List<Category> lista = context.GetAllCategory();
            // ViewBag.Category = lista;
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
