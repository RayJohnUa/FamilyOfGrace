﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;

namespace FM.REPOSITORIES.Classes
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(FMContext context) : base(context)
        {

        }

        public IQueryable<Person> GetListUnesinePersons(int groupId)
        {
            return _entities.Where(x => x.HomeGroupId != groupId);
        }
    }
}
