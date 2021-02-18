using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Baciu_Theodora_Proiect.Data;
using Baciu_Theodora_Proiect.Models;

namespace Baciu_Theodora_Proiect.Pages.Stores
{
    public class DetailsModel : PageModel
    {
        private readonly Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext _context;

        public DetailsModel(Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext context)
        {
            _context = context;
        }

        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _context.Store.FirstOrDefaultAsync(m => m.ID == id);

            if (Store == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
