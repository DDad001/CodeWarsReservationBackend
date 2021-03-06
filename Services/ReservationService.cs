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

        public bool AddReserveredKata(ReservationModel newReservedKata)
        {
            _context.Add(newReservedKata);
            return _context.SaveChanges() != 0;
        }
        public IEnumerable<ReservationModel> GetAllReservedKatas()
        {
            return _context.ReservationInfo;

        }
        public IEnumerable<ReservationModel> GetReservedKataByCodeWarName(string codeWarName)
        {
            return _context.ReservationInfo.Where(item => item.CodeWarName == codeWarName);
        }
          public IEnumerable<ReservationModel> GetReservedKataByKataName(string kataName)
        {
            return _context.ReservationInfo.Where(item => item.KataName == kataName);
        }

         public bool UpdateReservedKata(ReservationModel updatedReservedKata)
        {
            _context.Update<ReservationModel>(updatedReservedKata);
            return _context.SaveChanges() != 0;
        }

        public ReservationModel GetKataById(int id)
        {
            return _context.ReservationInfo.SingleOrDefault(item => item.Id == id);
        }
          public bool UpdateReservation(int id, bool IsCompleted)
        {
            ReservationModel foundUser = GetKataById(id);
            bool result = false;
            if(foundUser != null)
            {
                foundUser.Id = id;
                foundUser.IsCompleted = IsCompleted;
                

                _context.Update<ReservationModel>(foundUser);
               result =  _context.SaveChanges() != 0;
            }
            return result;
        }

    }
}