using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using frame.Models;
using frame.Data;
using System.Data;
using System.Windows;
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
    public class UserController : Controller
    {
        public IActionResult Index(){
            return View();
        }

        [HttpGet]
        public IActionResult Login(){
            return View();
        }

        // [HttpPost]
        // public IActionResult Login(LoginRequest request){
        //     return View();
        // }
        
    }
}