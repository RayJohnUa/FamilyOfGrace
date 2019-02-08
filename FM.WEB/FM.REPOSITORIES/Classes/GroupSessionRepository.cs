using System;
using System.Collections.Generic;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;

namespace FM.REPOSITORIES.Classes
{
    public class GroupSessionRepository : Repository<GroupSession>, IGroupSessionRepository
    {
        public GroupSessionRepository(FMContext context) : base(context)
        {
        }

    }
}
