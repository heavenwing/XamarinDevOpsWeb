using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XamarinCDWeb.Common;

namespace XamarinCDWeb.Controllers
{
    public class DownloadFileController : Controller
    {
        public IActionResult Index(Guid appId, MobilePlatform platform)
        {
            var ext = "";
            var mime = "";
            switch (platform)
            {
                case MobilePlatform.Android:
                    ext = ".apk";
                    mime = "application/vnd.android.package-archive";
                    break;
                case MobilePlatform.iOS:
                    ext = ".ipa";
                    mime = "application/octet-stream";
                    break;
                default:
                    break;
            }
            return File($"~/AppPackages/{appId.ToString("N")}{ext}", mime);
        }
    }
}