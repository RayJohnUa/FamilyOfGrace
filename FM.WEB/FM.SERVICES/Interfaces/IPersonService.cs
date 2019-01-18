using FM.DATA;
using System.Collections.Generic;

namespace FM.SERVICES.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPersons();
        Person GetPerson(long id);
        bool InsertPerson(Person Person);
        bool UpdatePerson(Person Person);
        bool DeletePerson(long id);
    }
}
