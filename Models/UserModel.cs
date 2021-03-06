using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? CohortName { get; set; }
        public string? CodeWarName { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }

        public UserModel(){}

    }
}