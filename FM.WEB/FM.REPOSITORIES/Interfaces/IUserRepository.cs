using FM.DATA;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.REPOSITORIES.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmailAndPassword(string email , string password);
    }
}
