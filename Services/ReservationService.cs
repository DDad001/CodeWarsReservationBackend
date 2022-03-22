using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using CodeWarsReservationBackend.Services.Context;

namespace CodeWarsReservationBackend.Services
{
    public class ReservationService
    {
        
        private readonly DataContext _context;

       public ReservationService(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<ReservationModel> GetAllReservedKatas()
        {
            return _context.ReservationInfo;

        }
        public IEnumerable<ReservationModel> GetReservedKataByCodeWarName(string codeWarName)
        {
            return _context.ReservationInfo.Where(item => item.CodeWarName == codeWarName);
        }
    }
}