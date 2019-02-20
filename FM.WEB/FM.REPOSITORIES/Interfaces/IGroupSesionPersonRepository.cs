using FM.DATA;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.REPOSITORIES.Interfaces
{
    public interface IGroupSesionPersonRepository : IRepository<GroupSesionPerson>
    {
        bool DeleteByPersonAndSesion(int personId, int sessionId);
        bool CheckIsIsset(int personId, int sessionId);
    }
}
