using GSM.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GSM.DAL.Data
{
    public class GMSContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserWorkoutDay>().HasKey(uwd => new { uwd.UserId,uwd.WorkId });
        }

        public GMSContext(DbContextOptions<GMSContext> options)
            : base(options)
        {

        }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Traniner> MstTrainner { get; set; }
        public DbSet<User> MstUser { get; set; }
        public DbSet<WorkoutDay> WorkoutDays { get; set; }

        public DbSet<UserWorkoutDay> UserWorkoutDays { get; set; }
    }
}