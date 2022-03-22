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

        //Update User Account
        [HttpPost("UpdateUser")]
        public bool UpdateUser(UserModel userToUpdate)
        {
            return _data.UpdateUser(userToUpdate);
        }

        [HttpPost("UpdateUser/{username}")]
        public bool UpdateUser(string codeWarName)
        {
            return _data.UpdateUsername(codeWarName);
        }

        [HttpPost("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string? userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<UserModel> GetAllUsers() 
        {
            return _data.GetAllUsers();
        }

        [HttpGet("GetUserByUsername/{username}")]
        public UserModel GetUserByUsername(string codeWarName)
        {
            return _data.GetUserByUsername(codeWarName);
        }
    }
}