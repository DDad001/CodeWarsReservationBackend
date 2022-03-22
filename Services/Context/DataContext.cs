using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeWarsReservationBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeWarsReservationBackend.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel> UserInfo { get; set;}
        public DbSet<CohortModel> CohortInfo { get; set; }
        public DbSet<ReservationModel> ReservationInfo { get; set; }
        public DbSet<CompletedKatasModel> CompletedKatasInfo { get; set; }
        public DataContext(DbContextOptions options ): base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}