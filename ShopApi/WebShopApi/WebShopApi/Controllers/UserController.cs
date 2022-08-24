using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopApi.CreateModels;
using WebShopApi.Dtos;
using WebShopApi.Entities;
using WebShopApi.Services;


namespace WebShopApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
      _userService = userService;
      _logger = logger;
    }

    // GET: api/Users
    [HttpGet("GetAllUsers")]
    public ActionResult<IEnumerable<UserDto>> GetUsers()
    {
      var users = _userService.GetAllUsers();
      _logger.LogInformation("All users returned from db!");

      return Ok(users);
    }

    [HttpGet("{userId}")]
    public ActionResult<IEnumerable<UserDto>> GetUserById(int userId)
    {
      var user = _userService.GetById(userId);
      if (user is null)
      {
        _logger.LogInformation($"User with id {userId} not found in db!");
        return NotFound();
      }

      _logger.LogInformation($"User with id {userId} returned from db!");
      return Ok(user);
    }

    [HttpPost("CreateUser")]
    public ActionResult<UserDto> CreateUser(UserCreateModel model)
    {
      var user = _userService.CreateUser(model);

      _logger.LogInformation($"User with id {user.Id} created!");

      return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
    }

    [HttpPut("UpdateUser")]
    public ActionResult<UserDto> putUserDto(int id, UserDto userDto) 
    {
      //var user = _userService.GetById(userId);
      if (id != userDto.Id)
      {
        _logger.LogInformation($"User with id {userDto.Id} not found in db!");
        return NotFound();
      }
      _userService.Entry(userDto).State = EntityState.Modified;

      _logger.LogInformation($"User with id {userDto.Id} returned from db!");
      return Ok(userDto);
    }


  }
}
