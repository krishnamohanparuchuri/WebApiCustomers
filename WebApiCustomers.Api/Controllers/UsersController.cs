using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCustomers.Dataservice;
using WebApiCustomers.Entities.DbSet;
using WebApiCustomers.Entities.Dtos.Incoming;

namespace WebApiCustomers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public  IActionResult GetUsers()
        {
            var users =  _context.Users.Where(x => x.Status == 1).ToList();
            return Ok(users);
        }
        
        [HttpGet]
        [Route("GetUser/{id}")]
        public  IActionResult GetUser(Guid id)
        {
            var user =  _context.Users.Where(x => x.Id == id).ToList();
            return Ok(user);
        }
        
        [HttpPost]
        public  IActionResult AddUser(UserDto user)
        {
            var _user = new User();
            _user.LastName = user.LastName;
            _user.FirstName = user.FirstName;
            _user.Country = user.Country;
            _user.Email = user.Email;
            _user.Phone = user.Phone;
            _user.DateOfBirth = Convert.ToDateTime(user.DateOfBirth);
            _user.Status = 1;
            _context.Users.Add(_user);
            _context.SaveChanges();
            return Ok();
        }
    }
}