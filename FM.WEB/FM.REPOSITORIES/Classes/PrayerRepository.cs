using System;
using System.Collections.Generic;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;

namespace FM.REPOSITORIES.Classes
{
    public class PrayerRepository : Repository<Prayer>, IPrayerRepository
    {
        public PrayerRepository(FMContext context) : base(context)
        {

        }
    }
}
