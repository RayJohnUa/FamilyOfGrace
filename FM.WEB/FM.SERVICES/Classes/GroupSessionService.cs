using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using FM.SERVICES.Interfaces;

namespace FM.SERVICES.Classes
{
    public class GroupSessionService : IGroupSessionService
    {
        private readonly IGroupSessionRepository _groupSessionRepository;
        private IRepository<GroupSesionPerson> _groupSesionPersonRepository;
        public GroupSessionService(IGroupSessionRepository groupSessionRepository, IRepository<GroupSesionPerson> groupSesionPersonRepository)
        {
            _groupSessionRepository = groupSessionRepository;
            _groupSesionPersonRepository = groupSesionPersonRepository;
        }

        public bool DeleteGroupSession(long id)
        {
            try
            {
                _groupSessionRepository.Delete(_groupSessionRepository.Get(id));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public GroupSession GetGroupSession(long id)
        {
            return _groupSessionRepository.Get(id);
        }

        public IEnumerable<GroupSession> GetGroupSessions()
        {
            return _groupSessionRepository.GetAll();
        }

        public GroupSession InsertGroupSession(GroupSession GroupSession)
        {
            try
            {
                return _groupSessionRepository.Insert(GroupSession);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public GroupSession UpdateGroupSession(GroupSession GroupSession, List<Person> persons)
        {
            try
            {
                var groupSession = _groupSessionRepository.Get(GroupSession.Id);
                _groupSesionPersonRepository.Remove(GroupSession.GroupSesionPersons?.ToList());
                GroupSession.GroupSesionPersons = new List<GroupSesionPerson>();
                if (persons != null)
                {
                    foreach (var person in persons)
                    {
                        GroupSession.GroupSesionPersons.Add(new GroupSesionPerson()
                        {
                            IsDelete = false,
                            GroupSessionId = GroupSession.Id,
                            PersonId = person.Id,
                        });
                    }
                }

                return _groupSessionRepository.Update(GroupSession);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
