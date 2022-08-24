using System.ComponentModel.DataAnnotations;

namespace WebShopApi.Entities
{
  public class User
  {
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
