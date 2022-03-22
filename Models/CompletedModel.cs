using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Models
{
    public class CompletedModel
    {
        public int Id { get; set; }
        public int CohortId { get; set; }
        public string? CodewarName { get; set; }
        public string? KataName { get; set; }
        public string? KataSlug { get; set; }
        public string? KataLink { get; set; }
        public string? KataLanguage { get; set; }

        public CompletedModel() { }
    }
}