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
        
        public bool AddCohort(CohortModel CohortToAdd) 
        {
            bool result = false;
            if (!DoesCohortExist(CohortToAdd.CohortName)) {
                // The user does exist
                CohortModel newCohort = new CohortModel();
                newCohort.Id = CohortToAdd.Id;
                newCohort.CodeWarName = CohortToAdd.CodeWarName;
                newCohort.CohortName = CohortToAdd.CohortName;               
                newCohort.CohortLevelOfDifficulty = CohortToAdd.CohortLevelOfDifficulty;          
                newCohort.DateCreated = CohortToAdd.DateCreated;
                newCohort.IsArchived = CohortToAdd.IsArchived;

                _context.Add(newCohort);  
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool DoesCohortExist(string? cohortName) 
        {
            return _context.CohortInfo.SingleOrDefault( user => user.CohortName == cohortName) != null;
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

        public IEnumerable<CohortModel> GetAllCohorts()
        {
            return _context.CohortInfo;
        }
        public CohortModel GetCohortById(int id)
        {
            return _context.CohortInfo.SingleOrDefault(item => item.Id == id);
        }

        public CohortModel GetCohortByCodeWarName(string codeWarName)
        {
            return _context.CohortInfo.SingleOrDefault(item => item.CodeWarName == codeWarName);
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