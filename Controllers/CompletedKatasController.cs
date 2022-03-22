using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeWarsReservationBackend.Controllers
//Get all completed katas
//GetCompletedkatabycodewarname
{
    [ApiController]
    [Route("[controller]")]
    public class CompletedKatasController : ControllerBase
    {
        private readonly CompletedKatasService _data;

        public CompletedKatasController(CompletedKatasService _dataFromService)
        {
            _data = _dataFromService;
        }

        [HttpGet("GetAllCompletedKatas")]
        public IEnumerable<CompletedKatasModel>GetAllCompletedKatas()
        {
            return _data.GetAllCompletedKatas();
        }

        [HttpGet("GetCompletedKatasByCodeWarName/{CodewarName}")]
        public IEnumerable<CompletedKatasModel> GetCompletedKatasByCodeWarName(string CodewarName)
        {
            return _data.GetByCompletedKatas(CodewarName);
        }


    }
}