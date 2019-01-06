using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplication.ViewModels
{
    public class ValuesViewModel
    {
        public List<Dictionary<string, string>> elements { get; set; }
        public string column { get; set; }
        public List<string> items { get; set; }
    }
}
