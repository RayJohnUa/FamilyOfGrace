using System;
using System.Collections.Generic;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using FM.SERVICES.Interfaces;

namespace FM.SERVICES.Classes
{
    public class GroupSessionService : IGroupSessionService
    {
        private readonly IGroupSessionRepository _groupSessionRepository;
        public GroupSessionService(IGroupSessionRepository groupSessionRepository)
        {
            _groupSessionRepository = groupSessionRepository;
        }

        public bool DeleteGroupSession(long id)
        {
            try
            {
                _groupSessionRepository.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public GroupSession GetGroupSession(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupSession> GetGroupSessions()
        {
            throw new NotImplementedException();
        }

        public GroupSession InsertGroupSession(GroupSession GroupSession)
        {
            throw new NotImplementedException();
        }

        public GroupSession UpdateGroupSession(GroupSession GroupSession, List<Person> persons)
        {
            throw new NotImplementedException();
        }
    }
}
