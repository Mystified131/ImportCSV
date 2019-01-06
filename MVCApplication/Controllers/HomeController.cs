using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.ViewModels;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        internal static Dictionary<string, string> columnChoices = new Dictionary<string, string>();

        // This is a "static constructor" which can be used
        // to initialize static members of a class
        static HomeController()
        {

            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
        }

        public IActionResult Index()
        {

            ViewBag.columns = columnChoices;

            return View();


        }

        public IActionResult Values(string column)
        {

            ValuesViewModel valuesViewModel = new ValuesViewModel();


            List<Dictionary<string, string>> elements = CSVData.FindAll();

            valuesViewModel.elements = elements;

            return View(valuesViewModel);
        }


        public IActionResult Results(string searchType, string searchTerm)

        {

            ViewBag.columns = columnChoices;

            if (searchTerm == null)

            {

                return Redirect("/search");

            }
            {
                if (searchType != "all")
                {
                    List<Dictionary<string, string>> elements = CSVData.FindByColumnAndValue(searchType, searchTerm);
                    ViewBag.elements = elements;
                    return View();
                }

                else
                {
                    List<Dictionary<string, string>> elements = CSVData.FindByValue(searchTerm);
                    ViewBag.elements = elements;
                    return View();

                }
            }

        }

    }

}
