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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public IEnumerable<Person> GetList()
        {
            return _personService.GetPersons();
        }

        [HttpGet]
        public Person GetPerson(int id)
        {
            return _personService.GetPerson(id);
        }

        [HttpPost]
        public bool AddPerson(Person person)
        {
            return _personService.InsertPerson(person);
        }

        [HttpPut]
        public bool Update(int id, Person person)
        {
            var oldperson = _personService.GetPerson(id);
            if (oldperson == null)
                return BadRequest("Таку людину не знайдено");
            return _personService.UpdatePerson();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
