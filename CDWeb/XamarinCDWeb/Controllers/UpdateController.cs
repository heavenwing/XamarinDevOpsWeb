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
    public class InputDto
    {
        public Guid AppId { get; set; }

        public MobilePlatform Platform { get; set; }

        public string Version { get; set; }
    }

    [Produces("application/json")]
    [Route("api/Update")]
    public class UpdateController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UpdateController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> PostAsync([FromBody] InputDto dto)
        {
            if (dto == null) return BadRequest();
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

                return Ok(item);
            }
            return NotFound();
        }
    }
}