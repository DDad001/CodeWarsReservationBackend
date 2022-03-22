using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Services.Context;

namespace CodeWarsReservationBackend.Services
{
    public class CompletedKatasService
    {
        private readonly DataContext _context;
        public CompletedKatasService(DataContext context)
        {
            _context = context;
        }

        
        public IEnumerable<CompletedKatasModel> GetCompletedKatasByCodeWarName(string codewarName)
        {
            return _context.CompletedKatasInfo.Where(item => item.CodeWarName == codewarName);
        }
        

    }
}