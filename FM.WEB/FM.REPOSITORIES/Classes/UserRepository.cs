using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FM.DATA;
using FM.REPOSITORIES.Interfaces;

namespace FM.REPOSITORIES.Classes
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FMContext context) : base(context)
        {

        }

        public User FindByEmailAndPassword(string email, string password)
        {
            return _entities.FirstOrDefault(x => !x.IsDelete && x.Email == email && x.Password == password);
        }
    }
}
