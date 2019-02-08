using FM.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FM.REPOSITORIES.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        IQueryable<Person> GetListUnesinePersons(int groupId);
    }
}
