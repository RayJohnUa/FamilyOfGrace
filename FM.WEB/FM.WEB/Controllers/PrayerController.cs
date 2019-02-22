using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FM.DATA;
using FM.SERVICES.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FM.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PrayerController : ControllerBase
    {
        private readonly IPrayerService _prayerService;

        public PrayerController(IPrayerService prayerService)
        {
            _prayerService = prayerService;
        }

        [AllowAnonymous]
        [HttpGet("List")]
        public ActionResult<List<Prayer>> Get()
        {
            return _prayerService.GetPrayers().ToList();
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Prayer> Get(int id)
        {
            return _prayerService.GetPrayer(id);
        }

        [HttpPost("Add")]
        public ActionResult<Prayer> Post([FromBody] Prayer value)
        {
            return _prayerService.InsertPrayer(value);
        }

        [HttpPut("{id}")]
        public ActionResult<Prayer> Put(int id, [FromBody] Prayer value)
        {
            var old = _prayerService.GetPrayer(id);
            if(old == null)
                return BadRequest("Такої потреби не існує");

            old.Content = value.Content;
            old.Name = value.Name;
            old.Phone = value.Phone;
            old.Status = value.Status;
            return _prayerService.UpdatePrayer(value);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            return _prayerService.DeletePrayer(id);
        }
    }
}
