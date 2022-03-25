using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Models.DTO
{
    public class CreateAccountDTO
    {
        public int Id { get; set; } 
        public string? CodeWarName { get; set; }
        public string? CohortName { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}