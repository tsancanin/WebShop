using Microsoft.EntityFrameworkCore;

namespace WebShopApi.Entities
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
      : base(options) { }

    public DbSet<User> User { get; set; }

  }
}
