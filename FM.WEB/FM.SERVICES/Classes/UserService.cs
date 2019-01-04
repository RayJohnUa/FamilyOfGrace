using FM.DATA;
using FM.REPOSITORIES.Interfaces;
using FM.SERVICES.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FM.SERVICES.Classes
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(long id)
        {
            return _userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            _userRepository.Insert(user);
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUser(long id)
        {
            User user = GetUser(id);
            _userRepository.Remove(user);
            _userRepository.SaveChanges();
        }

        public User FindUserByEmailAndPassword(string email , string password)
        {
            return _userRepository.FindByEmailAndPassword(email, password);
        }

    }
}
