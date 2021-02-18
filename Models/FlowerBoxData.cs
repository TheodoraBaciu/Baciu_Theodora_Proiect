using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baciu_Theodora_Proiect.Models
{
    public class FlowerBoxData
    {
        public IEnumerable<FlowerBox> FlowerBoxes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<FlowerBoxCategory> FlowerBoxCategories { get; set; }
    }
}
