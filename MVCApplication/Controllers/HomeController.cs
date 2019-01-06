using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.ViewModels;

namespace MVCApplication.Controllers
{

    public class HomeController : Controller
    {
        public static List<Shape> TheList = new List<Shape>();

        public IActionResult Index()
        {
            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
        }
        
        public IActionResult AllData()
        {
            AllDataViewModel allDataViewModel = new AllDataViewModel();

            List<Dictionary<string, string>> elements = CSVData.FindAll();

            allDataViewModel.elements = elements;

            return View(allDataViewModel);
        }

    }



}
