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
    public class DeleteModel : PageModel
    {
        private readonly Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext _context;

        public DeleteModel(Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FlowerBox FlowerBox { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlowerBox = await _context.FlowerBox.FirstOrDefaultAsync(m => m.ID == id);

            if (FlowerBox == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FlowerBox = await _context.FlowerBox.FindAsync(id);

            if (FlowerBox != null)
            {
                _context.FlowerBox.Remove(FlowerBox);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
