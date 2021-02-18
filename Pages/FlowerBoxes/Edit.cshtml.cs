using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Baciu_Theodora_Proiect.Data;
using Baciu_Theodora_Proiect.Models;

namespace Baciu_Theodora_Proiect.Pages.FlowerBoxes
{
    public class EditModel : FlowerBoxCategoriesPageModel
    {
        private readonly Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext _context;

        public EditModel(Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext context)
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

            FlowerBox = await _context.FlowerBox.Include(b => b.Store).Include(b => b.FlowerBoxCategories).ThenInclude(b => b.Category).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (FlowerBox == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, FlowerBox);

            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flowerBoxToUpdate = await _context.FlowerBox
            .Include(i => i.Store)
            .Include(i => i.FlowerBoxCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (flowerBoxToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<FlowerBox>(
            flowerBoxToUpdate,
            "FlowerBox",
            i => i.Series, i => i.Brand,
            i => i.Price, i => i.AparitionDate, i => i.Size, i => i.StoreID))
            {
                UpdateFlowerBoxCategories(_context, selectedCategories, flowerBoxToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateFlowerBoxCategories(_context, selectedCategories, flowerBoxToUpdate);
            PopulateAssignedCategoryData(_context, flowerBoxToUpdate);
            return Page();
        }
        private bool FlowerBoxExists(int id)
        {
            return _context.FlowerBox.Any(e => e.ID == id);
        }
    }

}
