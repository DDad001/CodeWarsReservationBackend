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

        // side thing if we have time 
        // [HttpPost("ArchiveCohort")]
        // public bool ArchiveCohort(CohortModel CohortArchive)
        // {
        //     return _data.ArchiveCohort(CohortArchive);
        // }

        [HttpGet("GetCohortByCohortName/{cohortName}")]
        public IEnumerable<CohortModel> GetCohortByCohortName(string cohortName)
        {
            return _data.GetCohortByCohortName(cohortName);
        }

        
        
        [HttpGet("GetCohortByCodeWarName/{codeWarName}")]
        public CohortModel GetCohortByCodeWarName(string codeWarName)
        {
            return _data.GetCohortByCodeWarName(codeWarName);
        }
        
        // [HttpGet("GetAllArchivedCohorts")]
        // public IEnumerable<CohortModel> GetAllArchivedCohorts()
        // {
        //     return _data.GetAllArchivedCohorts();
        // }

        [HttpGet("GetCohortById/{id}")]
        public CohortModel GetCohortById(int id)
        {
            return _data.GetCohortById(id);
        }

        [HttpGet("GetAllUsersByCohortName/{cohortName}")]

        public IEnumerable<CohortModel> GetAllUsersByCohortName(string cohortName)
        {
            return _data.GetCohortByCohortName(cohortName);
        }
    }
}