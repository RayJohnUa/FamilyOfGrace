using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;

namespace FM.REPOSITORIES.Classes
{
    public class MailingRepository : Repository<Mailing>, IMailingRepository
    {
        public MailingRepository(FMContext context) : base(context)
        {

        }

    }
}
