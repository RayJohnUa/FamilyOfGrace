using System;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using FM.SERVICES.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FM.SERVICES.Classes
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetPersons()
        {
            return _personRepository.GetAll().OrderBy(x => x.LastName);
        }

        public Person GetPerson(long id)
        {
            return _personRepository.Get(id);
        }

        public bool InsertPerson(Person Person)
        {
            try
            {
                _personRepository.Insert(Person);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
        public bool UpdatePerson(Person Person)
        {
            try
            {
                _personRepository.Update(Person);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool DeletePerson(long id)
        {
            try
            {
                Person Person = GetPerson(id);
                _personRepository.Remove(Person);
                _personRepository.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
