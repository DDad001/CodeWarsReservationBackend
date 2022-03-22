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

        [HttpPost("DeleteCohort")]
        public bool DeleteCohort(CohortModel CohortDelete)
        {
            return _data.DeleteCohort(CohortDelete);
        }

        [HttpGet("GetCohortByTitle/{Title}")]
        public IEnumerable<CohortModel> GetCohortByTitle(string title)
        {
            return _data.GetCohortByTitle(title);
        }
        
    }
}