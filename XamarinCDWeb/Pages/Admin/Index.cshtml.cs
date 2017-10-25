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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<MobileApp> MobileApp { get;set; }

        public async Task OnGetAsync()
        {
            MobileApp = await _db.MobileApps.ToListAsync();
        }
    }
}
