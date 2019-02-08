using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;

namespace FM.REPOSITORIES.Classes
{
    public class HomeRepository : Repository<HomeGroup>, IHomeGroupRepository
    {
        public HomeRepository(FMContext context) : base(context)
        {

        }

    }
}
