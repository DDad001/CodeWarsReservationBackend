using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Models
{
    public class CohortModel
    {
        public int Id { get; set; }
        public int CohortId { get; set; }
        public string? CohortName { get; set; }
        public string? CohortLevelOfDifficulty { get; set; }
        public string? DateCreated { get; set; }
        public bool IsArchived { get; set; }
        public CohortModel() { }
    }
}