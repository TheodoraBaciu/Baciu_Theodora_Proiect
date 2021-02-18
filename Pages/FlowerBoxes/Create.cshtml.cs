using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Baciu_Theodora_Proiect.Data;
using Baciu_Theodora_Proiect.Models;

namespace Baciu_Theodora_Proiect.Pages.FlowerBoxes
{
    public class CreateModel : FlowerBoxCategoriesPageModel
    {
        private readonly Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext _context;

        public CreateModel(Baciu_Theodora_Proiect.Data.Baciu_Theodora_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");
            var flowerBox = new FlowerBox();
            flowerBox.FlowerBoxCategories = new List<FlowerBoxCategory>();
            PopulateAssignedCategoryData(_context, flowerBox);
            return Page();
        }

        [BindProperty]
        public FlowerBox FlowerBox { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newFlowerBox = new FlowerBox();

            if (selectedCategories != null)
            {
                newFlowerBox.FlowerBoxCategories = new List<FlowerBoxCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FlowerBoxCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newFlowerBox.FlowerBoxCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<FlowerBox>(
            newFlowerBox,
            "FlowerBox",
            i => i.Series, i => i.Brand,
            i => i.Price, i => i.AparitionDate, i => i.Size, i => i.StoreID))
            {
                _context.FlowerBox.Add(newFlowerBox);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newFlowerBox);
            return Page();


        }
    }
}
