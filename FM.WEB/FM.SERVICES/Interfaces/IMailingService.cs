using FM.DATA;
using System.Collections.Generic;

namespace FM.SERVICES.Interfaces
{
    public interface IMailingService
    {
        IEnumerable<Mailing> GetMailings();
        Mailing GetMailing(long id);
        Mailing InsertMailing(Mailing Mailing);
        bool UpdateMailing(Mailing Mailing , List<Person> persons);
        bool DeleteMailing(long id);
    }
}
