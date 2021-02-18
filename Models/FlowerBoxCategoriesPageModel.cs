using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baciu_Theodora_Proiect.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Baciu_Theodora_Proiect.Models
{
    public class FlowerBoxCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Baciu_Theodora_ProiectContext context,
         FlowerBox flowerBox)
        {
            var allCategories = context.Category;
            var flowerBoxCategories = new HashSet<int>(
            flowerBox.FlowerBoxCategories.Select(c => c.FlowerBoxID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = flowerBoxCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateFlowerBoxCategories(Baciu_Theodora_ProiectContext context,
        string[] selectedCategories, FlowerBox flowerBoxToUpdate)
        {
            if (selectedCategories == null)
            {
                flowerBoxToUpdate.FlowerBoxCategories = new List<FlowerBoxCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var flowerBoxCategories = new HashSet<int>
            (flowerBoxToUpdate.FlowerBoxCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!flowerBoxCategories.Contains(cat.ID))
                    {
                        flowerBoxToUpdate.FlowerBoxCategories.Add(
                        new FlowerBoxCategory
                        {
                            FlowerBoxID = flowerBoxToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (flowerBoxCategories.Contains(cat.ID))
                    {
                        FlowerBoxCategory courseToRemove
                        = flowerBoxToUpdate
                        .FlowerBoxCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
