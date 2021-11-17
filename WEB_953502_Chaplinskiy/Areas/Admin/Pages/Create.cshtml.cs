using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB_953502_Chaplinskiy.Data;
using WEB_953502_Chaplinskiy.Entities;

namespace WEB_953502_Chaplinskiy.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WEB_953502_Chaplinskiy.Data.ApplicationDbContext _context;

        public CreateModel(WEB_953502_Chaplinskiy.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DishGroupId"] = new SelectList(_context.DishGroups, "DishGroupId", "DishGroupId");
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
