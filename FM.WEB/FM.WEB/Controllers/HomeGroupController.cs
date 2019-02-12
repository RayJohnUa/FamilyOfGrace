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
    public class HomeGroupController : ControllerBase
    {
        private readonly IHomeGroupService _groupService;
        private readonly IGroupSessionService _groupSessionService;
        private readonly IMapper _mapper;
        public HomeGroupController(IHomeGroupService groupService , IMapper mapper , IGroupSessionService groupSessionService)
        {
            _groupService = groupService;
            _mapper = mapper;
            _groupSessionService = groupSessionService;
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
        public ActionResult<bool> CreateWeek(int id, [FromBody]GroupSessionViewModel model)
        {
            return Ok(_groupSessionService.InsertGroupSession(_mapper.Map<GroupSession>(model)));
        }
    }
}
