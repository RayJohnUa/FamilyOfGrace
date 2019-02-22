using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using FM.DATA;
using FM.SERVICES.Interfaces;
using FM.SMSSERVICES;
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
    public class HomeGroupController : ControllerBase
    {
        private readonly IHomeGroupService _groupService;
        private readonly IGroupSessionService _groupSessionService;
        private readonly IPersonService _personService;
        private readonly ISmsService _smsService;
        private readonly IMapper _mapper;
        public HomeGroupController(IHomeGroupService groupService , IMapper mapper , IGroupSessionService groupSessionService , IPersonService personService , ISmsService smsService)
        {
            _groupService = groupService;
            _mapper = mapper;
            _groupSessionService = groupSessionService;
            _personService = personService;
            _smsService = smsService;
        }

        [HttpGet("List")]
        public ActionResult<IEnumerable<HomeGroupViewModel>> GetList()
        {
            try
            {
                var res = _groupService.GetHomeGroups().ToList();
                var rw = _mapper.Map<List<HomeGroupViewModel>>(res);
                string json = JsonConvert.SerializeObject(rw, Formatting.Indented);
                return Ok(rw);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("Get")]
        public ActionResult<HomeGroupViewModel> GetMailing(int id)
        {
			var res = _groupService.GetHomeGroup(id);
			return Ok(_mapper.Map<HomeGroupViewModel>(res));
        }

        [HttpPost("Add")]
        public ActionResult<bool> AddMailind(HomeGroupViewModel homeGroup)
        {
            if (ModelState.IsValid)
            {
                var response = new
                {
                    isSuccess = true,
                    id = _groupService.InsertHomeGroup (_mapper.Map<HomeGroup>(homeGroup))?.Id
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("Update")]
        public ActionResult<bool> Update(int id, [FromBody]HomeGroupViewModel model)
        {
            var homeGroups = _groupService.GetHomeGroup(id);
            if (homeGroups == null)
                return BadRequest("Таку домашню групу не знайдено");
            if (ModelState.IsValid)
            {
                homeGroups.Name = model.Name;
                return Ok(_groupService.UpdateHomeGroup(homeGroups));
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("Delete")]
        public ActionResult<bool> Delete(int id)
        {
            var oldMailing = _groupService.GetHomeGroup(id);
            if (oldMailing == null)
                return BadRequest("Таку домашню шрупу не знайдено");
            return Ok(_groupService.DeleteHomeGroup(id));
        }

        [HttpPost("AddWeek")]
        public ActionResult<bool> CreateWeek(int id, [FromBody]DateTime model)
        {
            var res = _groupSessionService.InsertGroupSession(new GroupSession()
            {
                Date = model,
                HomeGroupId = id,
                IsDelete = false
            });
            return Ok(_mapper.Map<GroupSessionViewModel>(res));
        }

        [HttpDelete("DeleteWeek")]
        public ActionResult<bool> DeleteWeek(int id)
        {
            return Ok(_groupSessionService.DeleteGroupSession(id));
        }

        [HttpPost("AsignToWeek")]
        public ActionResult<bool> AsignToWeek(AssignPersonWeekViewModel model)
        {
            var oldperson = _personService.GetPerson(model.PersonId);
            if (oldperson == null)
                return BadRequest("Таку людину не знайдено");
            return Ok(_groupSessionService.AssigneToWeek(model.PersonId , model.WeekId , model.IsAssigne));
        }

        [HttpPost("Send")]
        public ActionResult<bool> SendSmsPray(int id)
        {
            var group = _groupService.GetHomeGroup(id);
            if (group == null)
                return BadRequest("Таку групу не знайдено");
            var groupSesionPersons = group.GroupSession.LastOrDefault().GroupSesionPersons.ToArray();

            Shuffle(groupSesionPersons);

            for (int i = 0; i < groupSesionPersons.Length; i++)
            {
                string body = "";
                if (i + 1 >= groupSesionPersons.Length)
                {
                    body = string.Format("Привіт {0}, твій молитовний партнер на наступний тиждень {1} {2} ({3}). Благословенного тобі тижня!", groupSesionPersons[i].Person.FirstName, groupSesionPersons[0].Person.FirstName, groupSesionPersons[0].Person.LastName , groupSesionPersons[0].Person.Telephone);
                }
                else
                {
                    body = string.Format("Привіт {0}, твій молитовний партнер на наступний тиждень {1} {2} ({3}). Благословенного тобі тижня!", groupSesionPersons[i].Person.FirstName, groupSesionPersons[i + 1].Person.FirstName, groupSesionPersons[i + 1].Person.LastName , groupSesionPersons[i + 1].Person.Telephone);
                }
                _smsService.Send(groupSesionPersons[i].Person.Telephone, body);
            }

            return Ok(true);
        }

        public static void Shuffle<T>(T[] array)
        {
            Random random = new Random();
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + random.Next(n - i);
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }
    }
}
