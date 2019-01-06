using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.ViewModels
{
    public class MainelementsViewModel
    {
        public string columns { get; set; }
        public string values { get; set; }
        public List<Dictionary<String, String>> mainelements { get; set; }

    }
}
