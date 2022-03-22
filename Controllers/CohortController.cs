using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}