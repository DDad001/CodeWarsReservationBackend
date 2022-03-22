using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Models
{
    public class ReservationModel
    {
        public int Id { get; set; }
        public int CohortId { get; set; }
        public string? CodeWarName { get; set; }
        public string? KataName { get; set; }
        public string? KataSlug { get; set; }
        public string? KataLink { get; set; }
        public string? KataLanguage { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }

        public ReservationModel(){}

    }
}