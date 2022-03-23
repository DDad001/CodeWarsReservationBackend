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
    public class ReservationController : ControllerBase
    {
        
        private readonly ReservationService _data;

        public ReservationController (ReservationService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpPost("AddReserveredKata")]
        public bool AddReserveredKata(ReservationModel newReservation)
        {
            return _data.AddReserveredKata(newReservation);
        }
        
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