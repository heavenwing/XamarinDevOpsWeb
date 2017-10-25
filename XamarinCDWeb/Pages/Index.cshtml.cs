using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XamarinCDWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Extensions;
using XamarinCDWeb.Extensions;

namespace XamarinCDWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<MobileApp> MobileApps { get; private set; }

        public List<string> AndroidDownloadUrls { get; set; }

        public List<string> IosDownloadUrls { get; set; }

        public async Task OnGetAsync()
        {
            MobileApps = await _db.MobileApps.ToListAsync();
            AndroidDownloadUrls = new List<string>();
            IosDownloadUrls = new List<string>();
            foreach (var item in MobileApps)
            {
                AndroidDownloadUrls.Add(Request.GetUriAuthority() + Url.Page("Download", new
                {
                    appId = item.Id,
                    platform = Common.MobilePlatform.Android
                }));

                IosDownloadUrls.Add(Request.GetUriAuthority() + Url.Page("Download", new
                {
                    appId = item.Id,
                    platform = Common.MobilePlatform.iOS
                }));
            }
        }
    }
}
