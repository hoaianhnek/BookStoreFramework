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
            return View();
        }
        public IActionResult AccountManagement() {
            return View();
        }
        public IActionResult EmployeeManagement() {
            return View();
        }
        public IActionResult CustomerManagement() {
            return View();
        }
        public IActionResult OrderManagement() {
            return View();
        }
    }
}