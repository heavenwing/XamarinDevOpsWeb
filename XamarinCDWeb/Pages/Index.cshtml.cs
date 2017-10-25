﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XamarinCDWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace XamarinCDWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<MobileApp> MobileApps { get;private set; }

        public async Task OnGetAsync()
        {
            MobileApps = await _db.MobileApps.ToListAsync();
        }
    }
}
