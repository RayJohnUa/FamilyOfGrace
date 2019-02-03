using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FM.DATA;
using FM.SERVICES.Interfaces;
using FM.WEB.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FM.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MailingController : ControllerBase
    {
        private readonly IMailingService _mailingService;
        public MailingController(IMailingService mailingService)
        {
            _mailingService = mailingService;
        }

        [HttpGet("List")]
        public ActionResult<IEnumerable<Mailing>> GetList()
        {

            var res = _mailingService.GetMailings().ToList();
            return Ok(JsonConvert.SerializeObject(res , new JsonSerializerSettings()
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects,
				Formatting = Formatting.Indented
			}));
        }

        [HttpGet("Get")]
        public ActionResult<Mailing> GetMailing(int id)
        {
			var res = _mailingService.GetMailing(id);
			return Ok(JsonConvert.SerializeObject(res, new JsonSerializerSettings()
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects,
				Formatting = Formatting.Indented
			}));
        }

        [HttpPost("Add")]
        public ActionResult<bool> AddPerson(Mailing mailing)
        {
            if (ModelState.IsValid)
            {
                var response = new
                {
                    isSuccess = true,
                    id = _mailingService.InsertMailing(mailing)?.Id
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public ActionResult<bool> Update(int id, [FromBody]MailingViewModel mailing)
        {
            var oldMailing = _mailingService.GetMailing(id);
            if (oldMailing == null)
                return BadRequest("Таку розсилку не знайдено");
            if (ModelState.IsValid)
            {
                oldMailing.Name = mailing.Name;
                oldMailing.Content = mailing.Content;
                return Ok(_mailingService.UpdateMailing(oldMailing , mailing.Persons));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete")]
        public ActionResult<bool> Delete(int id)
        {
            var oldMailing = _mailingService.GetMailing(id);
            if (oldMailing == null)
                return BadRequest("Таку людину не знайдено");
            return Ok(_mailingService.DeleteMailing(id));
        }
    }
}
