using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using XamarinCDWeb.Data;

namespace XamarinCDWeb.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly XamarinCDWeb.Data.ApplicationDbContext _context;

        public CreateModel(XamarinCDWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MobileApp MobileApp { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MobileApps.Add(MobileApp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}