using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baciu_Theodora_Proiect.Models
{
    public class FlowerBox
    {
        public int ID { get; set; }
        [RegularExpression(@"^[1-9][A-Z]+$"), Required, StringLength(20, MinimumLength = 5)]
        [Display(Name = "FlowerBox Series")]
        public string Series { get; set; }
        public string Brand { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        [Range(100, 5000)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime AparitionDate { get; set; }
        [RegularExpression(@"^[S,M,L]+$", ErrorMessage = "FlowerBox size must be S,M or L"), Required, StringLength(50,
  MinimumLength = 1)]
        public string Size { get; set; }
        public int StoreID { get; set; }
        public Store Store { get; set; }
        public ICollection<FlowerBoxCategory> FlowerBoxCategories { get; set; }
    }
}
