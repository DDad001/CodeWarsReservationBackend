using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Models
{
    public class CompletedKatasModel
    {
        public int Id { get; set; }
        public string? KataName { get; set; }
        public string? KataSlug { get; set; }
        public string? KataLink { get; set; }
        public string? KataLanguage { get; set; }
        public string? KataRank { get; set; }

        public CompletedKatasModel(){}
    }
}