using FM.DATA;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.SERVICES.Interfaces
{
    public interface IPrayerService
    {
        IEnumerable<Prayer> GetPrayers();
        Prayer GetPrayer(long id);
        Prayer InsertPrayer(Prayer Prayer);
        Prayer UpdatePrayer(Prayer Prayer);
        bool DeletePrayer(long id);
    }
}
