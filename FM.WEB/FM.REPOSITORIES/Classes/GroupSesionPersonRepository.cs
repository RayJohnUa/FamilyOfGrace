using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FM.REPOSITORIES.Classes
{
    public class GroupSesionPersonRepository : Repository<GroupSesionPerson>, IGroupSesionPersonRepository
    {
        public GroupSesionPersonRepository(FMContext context) : base(context)
        {
        }

        public bool CheckIsIsset(int personId, int sessionId)
        {
            return _entities.Any(x => x.GroupSessionId == sessionId && x.PersonId == personId);
        }

        public bool DeleteByPersonAndSesion(int personId, int sessionId)
        {
            var sesionPerson = _entities.FirstOrDefault(x => x.PersonId == personId && x.GroupSessionId == sessionId);
            Delete(sesionPerson);
            return true;
        }
    }
}
