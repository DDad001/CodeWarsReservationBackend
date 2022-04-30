using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Models.DTO
{
    public class LoginDTO
    {
        public string? CodeWarName { get; set; }
        public string? Password { get; set; }
    }
}