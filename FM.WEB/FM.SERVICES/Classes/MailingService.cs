using System;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using FM.SERVICES.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FM.SERVICES.Classes
{
    public class MailingService : IMailingService
    {
        private IMailingRepository _mailingRepository;
        private IRepository<MailingPerson> _mailingPersonRepository;

        public MailingService(IMailingRepository mailingRepository , IRepository<MailingPerson> mailingPersonRepository)
        {
            _mailingRepository = mailingRepository;
            _mailingPersonRepository = mailingPersonRepository;
        }

        public bool DeleteMailing(long id)
        {
            try
            {
                Mailing Mailing = GetMailing(id);
                _mailingRepository.Remove(Mailing);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Mailing GetMailing(long id)
        {
            return _mailingRepository.Get(id);
        }

        public IEnumerable<Mailing> GetMailings()
        {
            return _mailingRepository.GetAll();
        }

        public Mailing InsertMailing(Mailing Mailing)
        {
            try
            {
                return _mailingRepository.Insert(Mailing);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateMailing(Mailing Mailing , List<Person> persons)
        {
            try
            {
                var mailing = _mailingRepository.Get(Mailing.Id);
                _mailingPersonRepository.Remove(Mailing.MailingPerson?.ToList());
                Mailing.MailingPerson = new List<MailingPerson>();
                foreach (var person in persons)
                {
                    Mailing.MailingPerson.Add(new MailingPerson()
                    {
                        IsDelete = false,
                        MailingId = Mailing.Id,
                        PersonId = person.Id
                    });
                }
                _mailingRepository.Update(Mailing);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
