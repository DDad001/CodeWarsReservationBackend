using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeWarsReservationBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
    
        [HttpGet("GetReservedKataByCodeWarName/{codeWarName}")]
        public IEnumerable<ReservationModel> GetReservedKataByCodeWarName(string codeWarName)
        {
            return _data.GetReservedKataByCodeWarName(codeWarName);
        }

        [HttpGet("GetAllReservedKatas")]
        public IEnumerable<ReservationModel> GetAllReservedKatas()
        {
            return _data.GetAllReservedKatas();
        }

        [HttpPost("UpdateReservedKata")]
         public bool UpdateReservedKata(ReservationModel updateReservation)
        {
            return _data.UpdateReservedKata(updateReservation);
        }

    }
}