using WebShopApi.Entities;

namespace WebShopApi.Repository
{
  public interface IUserRepository
  {
    IEnumerable<User> GetAllUsers();
    User? GetById(int id);
    void CreateUser(User newUser);

    void UpdateUser(User newUser);

  }
}
