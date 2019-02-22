using FM.DATA;
using FM.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using FM.REPOSITORIES.Interfaces;

namespace FM.SERVICES.Classes
{
    public class PrayerService : IPrayerService
    {
        private readonly IPrayerRepository _prayerRepository;
        public PrayerService(IPrayerRepository prayerRepository)
        {
            _prayerRepository = prayerRepository;
        }
        public bool DeletePrayer(long id)
        {
            try
            {
                _prayerRepository.Delete(GetPrayer(id));
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Prayer GetPrayer(long id)
        {
            return _prayerRepository.Get(id);
        }

        public IEnumerable<Prayer> GetPrayers()
        {
            return _prayerRepository.GetAll();
        }

        public Prayer InsertPrayer(Prayer Prayer)
        {
            return _prayerRepository.Insert(Prayer);
        }

        public Prayer UpdatePrayer(Prayer Prayer)
        {
            return _prayerRepository.Update(Prayer);
        }
    }
}
