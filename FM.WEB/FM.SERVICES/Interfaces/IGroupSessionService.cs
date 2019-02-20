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
        bool AssigneToWeek(int personId, int groupSesionId, bool isAsigne);
        bool DeleteGroupSession(long id);
    }
}
