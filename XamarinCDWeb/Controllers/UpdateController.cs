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

        public class InputDto
        {
            public Guid AppId { get; set; }

            public MobilePlatform Platform { get; set; }

            public string Version { get; set; }
        }

        public async Task PostAsync(InputDto dto)
        {
            var item = await _db.MobileApps.FindAsync(dto.AppId);
            if (item != null)
            {
                switch (dto.Platform)
                {
                    case MobilePlatform.Android:
                        item.ApkVersion = dto.Version;
                        break;
                    case MobilePlatform.iOS:
                        item.IpaVersion = dto.Version;
                        break;
                }
                await _db.SaveChangesAsync();
            }
        }
    }
}