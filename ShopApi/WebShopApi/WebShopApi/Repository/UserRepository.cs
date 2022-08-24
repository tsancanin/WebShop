using WebShopApi.Entities;

namespace WebShopApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

    public void UpdateUser(User user)
    {
      _dbContext.User.Update(user);
      _dbContext.SaveChanges();
    }

        public void CreateUser(User newUser)
        {
            _dbContext.User.Add(newUser);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.User.ToList();
        }

        public User? GetById(int id)
        {
            return _dbContext.User.FirstOrDefault(x => x.Id == id);
        }


    }
}
