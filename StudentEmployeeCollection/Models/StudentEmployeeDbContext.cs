using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentEmployeeCollection.Models
{
    public class StudentEmployeeDbContext : DbContext
    {
        public StudentEmployeeDbContext()
        {

        }

        public StudentEmployeeDbContext(DbContextOptions<StudentEmployeeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PositionType>().HasData(
                new PositionType { PositionTypeID = 1, PositionName = "TA" },
                new PositionType { PositionTypeID = 2, PositionName = "RA" },
                new PositionType { PositionTypeID = 3, PositionName = "Office" },
                new PositionType { PositionTypeID = 4, PositionName = "Student Instructor" },
                new PositionType { PositionTypeID = 5, PositionName = "Other" }
            );

            modelBuilder.Entity<Supervisor>().HasData(
                new Supervisor { SupervisorID = 1, FirstName = "Greg", LastName = "Anderson" },
                new Supervisor { SupervisorID = 2, FirstName = "Spencer", LastName = "Hilton" },
                new Supervisor { SupervisorID = 3, FirstName = "Katy", LastName = "Reese" }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student {
                    BYUID = "64-844-6387",
                    FirstName = "Alexis",
                    LastName = "Ferolino",
                    International = false,
                    Gender = "Female",
                    EmailAddress = "alexis.transfiguracion@gmail.com",
                    Semester = "Winter",
                    Year = 2022,
                    Phone = "8087969783",
                    ProgramYear = "MSB Core (IS or other)",
                    PayGradTuition = true,
                    SubmittedEForm = true,
                    SubmissionDate = new DateTime(2022, 8, 31),
                    BYUName = "ajt82097",
                    Notes = "Is awesome",
                    NameChangeCompleted = true,
                    Positions = new List<Position>()
                }
            );
            
        }


        public DbSet<Student> Student { get; set; }
        public DbSet<PayIncrease> PayIncrease { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<PositionType> PositionType { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
    }
}
