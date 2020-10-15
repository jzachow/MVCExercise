using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MVCExercise
{
    public class HomeModel
    {
        [DisplayName("ViewBag Color")]
        public string ViewBagColor { get; set; }

        [DisplayName("ViewData Color")]
        public string ViewDataColor { get; set; }

        [DisplayName("TempData Color")]
        public string TempDataColor { get; set; }
    }
}
