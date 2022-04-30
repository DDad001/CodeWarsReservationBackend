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

        [HttpGet("GetReservedKataByKataName/{kataName}")]
        public IEnumerable<ReservationModel> GetReservedKataByKataName(string kataName)
        {
            return _data.GetReservedKataByKataName(kataName);
        }

        [HttpGet("GetAllReservedKatas")]
        public IEnumerable<ReservationModel> GetAllReservedKatas()
        {
            return _data.GetAllReservedKatas();
        }
        
        [HttpGet("GetKataById/{id}")]
        public ReservationModel GetKataById(int id)
        {
            return _data.GetKataById(id);
        }

        [HttpPost("UpdateReservedKata")]
         public bool UpdateReservedKata(ReservationModel updateReservation)
        {
            return _data.UpdateReservedKata(updateReservation);
        }

        
        [HttpPost("UpdateReservation/{Id}/{IsCompleted}")]
        public bool UpdateReservation(int Id, bool IsCompleted)
        {
            return _data.UpdateReservation(Id, IsCompleted);
        }

    }
}