using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Baciu_Theodora_Proiect.Models
{
    public class FlowerBoxCategory
    {
        public int ID { get; set; }
        public int FlowerBoxID { get; set; }
        public FlowerBox FlowerBox { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
