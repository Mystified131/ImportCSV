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
            IndexViewModel indexViewModel = new IndexViewModel();
            indexViewModel.columns = columnChoices;
            return View(indexViewModel);
        }

        public IActionResult Values(string column)
        {
            column = "all";
            ValuesViewModel valuesViewModel = new ValuesViewModel();

            if (column.Equals("all"))
            {

                    List<Dictionary<string, string>> elements = CSVData.FindAll();

                    valuesViewModel.elements = elements;

                    return View(valuesViewModel);
                }
        
            else
            {
       
                List<string> items = CSVData.FindAll(column);

                valuesViewModel.column = column;
                valuesViewModel.items = items;

                return View(valuesViewModel);
            }
        }

        public IActionResult Mainelements(string column, string value)
        {
            MainelementsViewModel mainelementsViewModel = new MainelementsViewModel();

            List<Dictionary<String, String>> mainelements = CSVData.FindByColumnAndValue(column, value);
            mainelementsViewModel.mainelements = mainelements;


            return View(mainelementsViewModel);
        }
    }
}