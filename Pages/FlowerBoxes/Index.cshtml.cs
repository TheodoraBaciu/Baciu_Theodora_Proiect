using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Baciu_Theodora_Proiect.Data;
using Baciu_Theodora_Proiect.Models;

namespace Baciu_Theodora_Proiect.Pages.FlowerBoxes
{
    public class IndexModel : PageModel
    {
        private readonly Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext _context;

        public IndexModel(Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext context)
        {
            _context = context;
        }

        public IList<FlowerBox> FlowerBox { get; set; }

        public FlowerBoxData FlowerBoxD { get; set; }
        public int FlowerBoxID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            FlowerBoxD = new FlowerBoxData();

            FlowerBoxD.FlowerBoxes = await _context.FlowerBox
            .Include(b => b.Store)
            .Include(b => b.FlowerBoxCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Series)
            .ToListAsync();
            if (id != null)
            {
                FlowerBoxID = id.Value;
                FlowerBox flowerBox = FlowerBoxD.FlowerBoxes
                .Where(i => i.ID == id.Value).Single();
                FlowerBoxD.Categories = flowerBox.FlowerBoxCategories.Select(s => s.Category);
            }
        }

    }
}
