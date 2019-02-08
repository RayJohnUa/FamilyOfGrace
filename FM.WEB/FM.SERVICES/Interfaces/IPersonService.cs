using FM.DATA;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace FM.SERVICES.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPersons();
        IEnumerable<Person> GetPersons(int groupId);
        Person GetPerson(long id);
        Person InsertPerson(Person Person);
        bool UpdatePerson(Person Person);
        bool DeletePerson(long id);
    }
}
