using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using CodeWarsReservationBackend.Models.DTO;
using CodeWarsReservationBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeWarsReservationBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;

        public UserController(UserService dataFromService){
            _data = dataFromService;
        }

        [HttpPost("AddUser")]
        public bool AddUser(CreateAccountDTO UserToAdd) {
            return _data.AddUser(UserToAdd);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        //this endpoint really does not work-- ask for help tommorow
        [HttpPost("UpdateUser")]
        public bool UpdateUser(UserModel userToUpdate)
        {
            return _data.UpdateUser(userToUpdate);
        }

        //this endpoint really does not work-- ask for help tommorow
        [HttpPost("UpdateUsername/{id}/{codeWarName}")]
        public bool UpdateUsername(int id, string codeWarName)
        {
            return _data.UpdateUsername(id, codeWarName);
        }

        [HttpPost("GiveUserAdmin/{id}")]
        public bool GiveUserAdmin(int id)
        {
            return _data.GiveUserAdmin(id);
        }

        [HttpPost("DeleteUser/{id}")]
        public bool DeleteUser(int id)
        {
            return _data.DeleteUser(id);
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers() 
        {
            return _data.GetAllUsers();
        }

       [HttpGet("GetUserByUsername/{codeWarName}")]
        public UserModel GetUserByUsername(string codeWarName)
        {
            return _data.GetUserByUsername(codeWarName);
        }

        [HttpGet("GetUserById/{id}")]
        public UserModel GetUserById(int id)
        {
            return _data.GetUserById(id);
        }
    }
}