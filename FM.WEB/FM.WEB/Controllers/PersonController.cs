using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FM.DATA;
using FM.SERVICES.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FM.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet("List")]
        public ActionResult<IEnumerable<Person>> GetList()
        {
			var res = _personService.GetPersons().ToList();
			return Ok(JsonConvert.SerializeObject(res, new JsonSerializerSettings()
			{
				PreserveReferencesHandling = PreserveReferencesHandling.Objects,
				Formatting = Formatting.Indented
			}));
        }

        [HttpGet]
        public Person GetPerson(int id)
        {
            return _personService.GetPerson(id);
        }

        [HttpPost("Add")]
        public ActionResult<bool> AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                var response = new
                {
                    isSuccess = true,
                    id = _personService.InsertPerson(person)?.Id
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public ActionResult<bool> Update(int id, [FromBody]Person person)
        {
            var oldperson = _personService.GetPerson(id);
            if (oldperson == null)
                return BadRequest("Таку людину не знайдено");
            if (ModelState.IsValid)
            {
                oldperson.FirstName = person.FirstName;
                oldperson.LastName = person.LastName;
                oldperson.Telephone = person.Telephone;
                return Ok(_personService.UpdatePerson(oldperson));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete")]
        public ActionResult<bool> Delete(int id)
        {
            var oldperson = _personService.GetPerson(id);
            if (oldperson == null)
                return BadRequest("Таку людину не знайдено");
            return Ok(_personService.DeletePerson(id));
        }
    }
}
