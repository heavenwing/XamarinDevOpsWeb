using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XamarinCDWeb.Data;
using XamarinCDWeb.Common;
using Microsoft.AspNetCore.Http.Extensions;
using XamarinCDWeb.Extensions;
using System.Net;

namespace XamarinCDWeb.Pages
{
    public class DownloadModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DownloadModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public string DownloadUrl { get; set; }

        public MobileApp App { get; set; }

        public MobilePlatform  Platform { get; set; }

        public async Task OnGetAsync(Guid appId, MobilePlatform platform)
        {
            Platform = platform;
            App = await _db.MobileApps.FindAsync(appId);
            if (platform == MobilePlatform.Android)
                DownloadUrl = Request.GetUriAuthority() + Url.Content($"~/AppPackages/{appId.ToString("N")}.apk");
            else
            {
                var plistUrl = Request.GetUriAuthority() + Url.Page("Plist", new { appId = appId });
                DownloadUrl = $"itms-services://?action=download-manifest&url={WebUtility.UrlEncode(plistUrl)}";
            }
        }
    }
}