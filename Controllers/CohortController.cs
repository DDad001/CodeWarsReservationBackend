using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using CodeWarsReservationBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeWarsReservationBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CohortController : ControllerBase
    {
        private readonly CohortService _data;

        public CohortController(CohortService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpPost("AddCohort")]
            public bool AddCohort(CohortModel newCohort)
        {
            return _data.AddCohort(newCohort);
        }

        [HttpPost("UpdateCohort")]
        public bool UpdateCohort(CohortModel CohortUpdate)
        {
            return _data.UpdateCohort(CohortUpdate);
        }

        [HttpPost("ArchiveCohort")]
        public bool ArchiveCohort(CohortModel CohortArchive)
        {
            return _data.ArchiveCohort(CohortArchive);
        }

        [HttpGet("GetCohortByCohortName/{CohortName}")]
        public IEnumerable<CohortModel> GetCohortByCohortName(string cohortName)
        {
            return _data.GetCohortByCohortName(cohortName);
        }
        
        [HttpGet("GetAllArchivedCohorts")]
        public IEnumerable<CohortModel> GetAllArchivedCohorts()
        {
            return _data.GetAllArchivedCohorts();
        }

        [HttpGet("GetCohortById/{CohortId}")]
        public CohortModel GetCohortById(int CohortId)
        {
            return _data.GetCohortById(CohortId);
        }
    }
}