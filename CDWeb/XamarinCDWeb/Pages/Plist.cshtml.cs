using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XamarinCDWeb.Data;
using Microsoft.AspNetCore.Http.Extensions;
using XamarinCDWeb.Common;
using XamarinCDWeb.Extensions;

namespace XamarinCDWeb.Pages
{
    public class PlistModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public PlistModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public string PackageUrl { get; set; }

        public MobileApp App { get; set; }

        public async Task OnGetAsync(Guid appId)
        {
            App = await _db.MobileApps.FindAsync(appId);
            PackageUrl = Request.GetUriAuthority() + Url.Content($"~/AppPackages/{appId.ToString("N")}.ipa");
        }
    }
}