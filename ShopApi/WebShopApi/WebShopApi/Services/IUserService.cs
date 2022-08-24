using WebShopApi.CreateModels;
using WebShopApi.Dtos;
using WebShopApi.Entities;

namespace WebShopApi.Services
{
  public interface IUserService
  {
    List<UserDto> GetAllUsers();
    UserDto GetById(int id);         
    UserDto CreateUser(UserCreateModel model);

  }
}
