using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XamarinCDWeb.Common;
using XamarinCDWeb.Data;

namespace XamarinCDWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Update")]
    public class UpdateController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UpdateController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task GetAsync(Guid appId, MobilePlatform platform, string version)
        {
            var item = await _db.MobileApps.FindAsync(appId);
            if (item!=null)
            {
                switch (platform)
                {
                    case MobilePlatform.Android:
                        item.ApkVersion = version;
                        break;
                    case MobilePlatform.iOS:
                        item.IpaVersion = version;
                        break;
                }
                await _db.SaveChangesAsync();
            }
        }
    }
}