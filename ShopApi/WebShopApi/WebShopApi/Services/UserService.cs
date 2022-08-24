using WebShopApi.CreateModels;
using WebShopApi.Dtos;
using WebShopApi.Entities;
using WebShopApi.Repository;

namespace WebShopApi.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
    
    public UserDto CreateUser(UserCreateModel model)
    {
            var newUser = new User()
            {                
                Username = model.UserName,
                Password = model.Password
            };

            _userRepository.CreateUser(newUser);
            
            return new UserDto()
            {
                Id = newUser.Id,
                Password = newUser.Password,
                UserName = newUser.Username
            };
        }

    public List<UserDto> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            var listOFAllUsers = new List<UserDto>();
            foreach (var user in users)
            {
                listOFAllUsers.Add(new UserDto()
                {
                    Id = user.Id,
                    UserName = user.Username,
                    Password = user.Password,
                });
            };

            return listOFAllUsers;
        }

        public UserDto? GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if( user is null)
            {
                return null;
            }

            return new UserDto()
            {
                Id = user.Id,
                UserName = user.Username,
                Password = user.Password
            };
        }
        
    }
}

