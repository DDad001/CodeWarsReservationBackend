using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using CodeWarsReservationBackend.Services.Context;
using Microsoft.AspNetCore.Mvc;

namespace CodeWarsReservationBackend.Services
{
    public class CohortService
    {
        private readonly DataContext _context;
        
        public CohortService(DataContext context)
        {
            _context = context;
        }
        
        public bool AddCohort (CohortModel newCohort)
        {
            _context.Add(newCohort);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<CohortModel> GetCohortByCohortName(string cohortName)
        {
            return _context.CohortInfo.Where(item => item.CohortName == cohortName);
        }
        //  public IEnumerable<CohortModel> GetAllArchivedCohorts()
        // {
        //     bool result = false;
        //     UserModel FoundCohort = GetUserById(id);
        //     if(FoundCohort != null)
        //     {
        //         FoundCohort.IsAdmin = !FoundCohort.IsAdmin;
        //         _context.Update<UserModel>(FoundCohort);
        //         result = _context.SaveChanges() != 0;
        //     }
        //     return _context.CohortInfo;
        // }

        public CohortModel GetCohortById(int id)
        {
            return _context.CohortInfo.SingleOrDefault(item => item.Id == id);
        }

        public bool UpdateCohort(CohortModel updatedCohort)
        {
            _context.Update<CohortModel>(updatedCohort);
            return _context.SaveChanges() != 0;
        }

        //  public bool ArchiveCohort (CohortModel CohortArchived)
        // {
        //     CohortArchived.IsArchived = true;
        //     _context.Update<CohortModel>(CohortArchived);
        //     return _context.SaveChanges() !=0;
        // }

        
    }
}