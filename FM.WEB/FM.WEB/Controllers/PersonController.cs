using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService , IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        [HttpGet("List")]
        public ActionResult<IEnumerable<PersonViewModel>> GetList()
        {
            var persons = _personService.GetPersons().ToList();
            var res = _mapper.Map<List<PersonViewModel>>(persons);
			return Ok(res);
        }

        [HttpGet]
        public Person GetPerson(int id)
        {
            return _personService.GetPerson(id);
        }

        [HttpPost("Add")]
        public ActionResult<bool> AddPerson(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = new
                {
                    isSuccess = true,
                    id = _personService.InsertPerson(_mapper.Map<Person>(model))?.Id
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public ActionResult<bool> Update(int id, [FromBody]PersonViewModel model)
        {
            var oldperson = _personService.GetPerson(id);
            if (oldperson == null)
                return BadRequest("Таку людину не знайдено");
            if (ModelState.IsValid)
            {
                oldperson.FirstName = model.FirstName;
                oldperson.LastName = model.LastName;
                oldperson.Telephone = model.Telephone;
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

        [HttpPost("AsignToGroup")]
        public ActionResult<bool> AsignToGroup(AssignPersonViewModel model)
        {
            var oldperson = _personService.GetPerson(model.PersonId);
            if (oldperson == null)
                return BadRequest("Таку людину не знайдено");
            if (model.IsAssigne)
            {
                oldperson.HomeGroupId = model.GroupId;
            }
            else
            {
                oldperson.HomeGroupId = null;
            }

            return Ok(_personService.UpdatePerson(oldperson));
        }


    }
}
