using FM.DATA;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.SERVICES.Interfaces
{
    public interface IGroupSessionService
    {
        IEnumerable<GroupSession> GetGroupSessions();
        GroupSession GetGroupSession(long id);
        GroupSession InsertGroupSession(GroupSession GroupSession);
        GroupSession UpdateGroupSession(GroupSession GroupSession, List<Person> persons);
        bool DeleteGroupSession(long id);
    }
}
