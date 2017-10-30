using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XamarinCDWeb.Data;

namespace XamarinCDWeb.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly XamarinCDWeb.Data.ApplicationDbContext _context;

        public DeleteModel(XamarinCDWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MobileApp MobileApp { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MobileApp = await _context.MobileApps.SingleOrDefaultAsync(m => m.Id == id);

            if (MobileApp == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MobileApp = await _context.MobileApps.FindAsync(id);

            if (MobileApp != null)
            {
                _context.MobileApps.Remove(MobileApp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
