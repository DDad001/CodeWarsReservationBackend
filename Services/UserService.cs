using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using CodeWarsReservationBackend.Models.DTO;
using CodeWarsReservationBackend.Services.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CodeWarsReservationBackend.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context) 
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.UserInfo;
        }

        public bool DoesUserExist(string? codeWarName) 
        {
            return _context.UserInfo.SingleOrDefault( user => user.CodeWarName == codeWarName) != null;
        }

        public UserModel GetUserByUsername(string codeWarName)
        {
            return _context.UserInfo.SingleOrDefault( user => user.CodeWarName == codeWarName);
        }

        public UserModel GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Id == id);
        }

        public UserIdDTO GetUserIdDTOByUsername(string codeWarName)
        {
            var UserInfo = new UserIdDTO();
            var foundUser = _context.UserInfo.SingleOrDefault(user => user.CodeWarName == codeWarName);
            UserInfo.UserId = foundUser.Id;
            UserInfo.CodeWarName = foundUser.CodeWarName;
            return UserInfo;
        }

        public IActionResult Login(LoginDTO user)
        {
            IActionResult Result = Unauthorized();
            // Check to see if the user exist
            if (DoesUserExist(user.CodeWarName)) {
                // true
                var foundUser = GetUserByUsername(user.CodeWarName);
                // Check to see if the password is correct
                if (VerifyUserPassword(user.Password, foundUser.Hash, foundUser.Salt)) {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DayClassSuperDuperSecretKey@209"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
                } 
            }
            return Result;
        }

        public bool AddUser(CreateAccountDTO UserToAdd) 
        {
            bool result = false;
            if (!DoesUserExist(UserToAdd.CodeWarName)) {
                // The user does exist
                UserModel newUser = new UserModel();
                var hashedPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.CodeWarName = UserToAdd.CodeWarName;
                newUser.Salt = hashedPassword.Salt;
                newUser.Hash = hashedPassword.Hash;

                _context.Add(newUser);
                
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public PasswordDTO HashPassword(string? password) 
        {
            PasswordDTO newHashedPassword = new PasswordDTO();
            byte[] SaltBytes = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(SaltBytes);
            var Salt = Convert.ToBase64String(SaltBytes);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltBytes, 10000);
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            newHashedPassword.Salt = Salt;
            newHashedPassword.Hash = Hash;

            return newHashedPassword;
        }

        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt)
        {
            var SaltBytes = Convert.FromBase64String(storedSalt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            return newHash == storedHash;
        }
        
        // public bool UpdateUser(UserModel userToUpdate)
        // {
        //     //This one is sending over the whole object to be updated
        //     _context.Update<UserModel>(userToUpdate);
        //     return _context.SaveChanges() !=0; 
        // }


        public bool UpdateUsername(int id, string codeWarName, string cohortName, bool isAdmin, bool isDeleted)
        {
            UserModel foundUser = GetUserById(id);
            bool result = false;
            if(foundUser != null)
            {
                foundUser.CodeWarName = codeWarName;
                foundUser.IsAdmin = isAdmin;
                foundUser.CohortName = cohortName;
                foundUser.IsDeleted = isDeleted;

                _context.Update<UserModel>(foundUser);
               result =  _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool DeleteUser(int id)
        {
            bool result = false;
            UserModel foundUser = GetUserById(id);
            if(foundUser != null)
            {
                //if you want to hard delete instead of update do Remove
                foundUser.IsDeleted = !foundUser.IsDeleted;
                _context.Update<UserModel>(foundUser);
               result =  _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool UpdateUserRole(string codeWarName, bool IsAdmin)
        {
            UserModel foundUser = GetUserByUsername(codeWarName);

            foundUser.CodeWarName = codeWarName;
            foundUser.IsAdmin = IsAdmin;
            
            _context.Update<UserModel>(foundUser);
            return _context.SaveChanges() != 0;
        }

        public bool GiveUserAdmin(int id)
        {
            bool result = false;
            UserModel FoundUser = GetUserById(id);
            if(FoundUser != null)
            {
                FoundUser.IsAdmin = !FoundUser.IsAdmin;
                _context.Update<UserModel>(FoundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

         public IEnumerable<UserModel> GetAllUsersByCohortName(string cohortName)
        {
            return _context.UserInfo.Where(item => item.CohortName == cohortName);
        }

    }
}