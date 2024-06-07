using ValidateJWT.Authorization;
using ValidateJWT.Entities;

namespace ValidateJWT.Services
{

    public interface IUserService
    {
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private IJwtUtils _jwtUtils;
        public User GetById(int id)
        {
            return new User() { Id = id, FirstName = "Tam", LastName = "Ngo Minh", UserName = "tam.ngo"};
        }
    }
}
