using FM.DATA;
using System.Collections.Generic;

namespace FM.SERVICES.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUser(long id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(long id);
        User FindUserByEmailAndPassword(string email, string password);
    }
}
