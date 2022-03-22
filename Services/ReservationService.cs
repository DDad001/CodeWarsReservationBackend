using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeWarsReservationBackend.Services
{
    public class ReservationService
    {
        public IEnumerable<ReservationModel> GetReservedKataByCodeWarName(string codeWarName)
        {
            return _context.ReservationInfo.Where(item => item.CodeWarName == codeWarName);
        }
    }
}