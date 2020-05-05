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
    public class AdminController : Controller
    {
        public IActionResult Index() {
                return View();
        }

 


        public IActionResult BookManagement() {
            BookStoreContext context = new BookStoreContext();
            List<Book> books = context.GetAllBook();
            List<Category> categories = context.GetAllCategory();
            List<Author> authors = context.GetAllAuthor();
            List<Discount> discounts = context.GetAllDiscount();
            ViewBag.categories = categories;
            ViewBag.authors = authors;
            ViewBag.discounts = discounts;
            return View(books);
        }
        public IActionResult AuthorManagement() {
            BookStoreContext context = new BookStoreContext();
            List<Author> authors = context.GetAllAuthor();
            return View(authors);
        }

//Author
        public IActionResult CreateAuthor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAuthor(Author aut)
        {
            if(ModelState.IsValid)
            {
                BookStoreContext context = new BookStoreContext();
                context.AddAuthor(aut);
                return RedirectToAction("AuthorManagement");
            }
            return View(aut);
        }

       public IActionResult EditAuthor(string idAuthor)
       {
           BookStoreContext context = new BookStoreContext();
           List<Author> authors = context.GetAllAuthor();
           var name = authors.Where(c=>c.idAuthor == idAuthor).FirstOrDefault();
           return View(name);
       }
       [HttpPost]
       public IActionResult EditAuthor (Author aut)
       {
           BookStoreContext context = new BookStoreContext();
           context.UpdateAuthor(aut);
           return RedirectToAction("AuthorManagement");
       }

     

       public IActionResult DeleteAuthor(string idAuthor)
       {
           BookStoreContext context = new BookStoreContext();
           context.DeleteAuthor(idAuthor);
           Console.WriteLine("đã xóa");
           return RedirectToAction("AuthorManagement");
       }
 
 //Category
        public IActionResult CategoryManagement()
        {
            BookStoreContext context = new BookStoreContext();
            List<Category> categories = context.GetAllCategory();
            return View(categories);
        }

         public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category cat)
        {
            if (ModelState.IsValid)
            {
                BookStoreContext context = new BookStoreContext();
                context.AddCategory(cat);
                return RedirectToAction("CategoryManagement");
            }
            return View(cat);
        }

       public IActionResult EditCategory(String idCategory)
       {
           BookStoreContext context = new BookStoreContext();
           List<Category> categories = context.GetAllCategory();
           var name = categories.Where(c => c.idCategory == idCategory)
                        .FirstOrDefault();
           return View(name);
       }
       [HttpPost]
       public IActionResult EditCategory (Category cat)
       {
           BookStoreContext context = new BookStoreContext();
           context.UpdateCategory(cat);
           return RedirectToAction("CategoryManagement");
       }

      

       public IActionResult DeleteCategory(string idCategory)
       {
           BookStoreContext context = new BookStoreContext();
           context.DeleteCategory(idCategory);
           Console.WriteLine("Đã xóa");
           return RedirectToAction("CategoryManagement");
       }
        public IActionResult SupplierManagement() {
            BookStoreContext context = new BookStoreContext();
            List<Supplier> suppliers = context.GetAllSupplier();
            return View(suppliers);
        }


        public IActionResult CreateSupplier()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSupplier(Supplier sup)
        {
            if(ModelState.IsValid)
            {
                BookStoreContext context = new BookStoreContext();
                context.AddSupplier(sup);
                return RedirectToAction("SupplierManagement");
            }
            return View(sup);
        }

       public IActionResult EditSupplier(string idSupplier)
       {
           BookStoreContext context = new BookStoreContext();
           List<Supplier> suppliers = context.GetAllSupplier();
           var name = suppliers.Where(c=>c.idSupplier==idSupplier).FirstOrDefault();
           return View(name);
       }
       [HttpPost]
       public IActionResult EditSupplier (Supplier sup)
       {
           BookStoreContext context = new BookStoreContext();
           context.UpdateSupplier(sup);
           return RedirectToAction("SupplierManagement");
       }


       public IActionResult DeleteSupplier(string idSupplier)
       {
           BookStoreContext context = new BookStoreContext();
           context.DeleteSupplier(idSupplier);
           Console.WriteLine("Đã xóa");
           return RedirectToAction("SupplierManagement");
       }

        public IActionResult InsertBook()
        {
            return View();
        }
        public IActionResult AccountManagement() {
            return View();
        }    
        public IActionResult OrderManagement() {
            return View();
        }
    }

}