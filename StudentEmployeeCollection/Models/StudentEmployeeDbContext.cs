using System;
using Microsoft.EntityFrameworkCore;

namespace StudentEmployeeCollection.Models
{
    public class StudentEmployeeDbContext : DbContext
    {
        public StudentEmployeeDbContext(DbContextOptions<StudentEmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }

        public DbSet<StudentPositionType> StudentPositionType { get; set; }

        public DbSet<PositionType> PositionType { get; set; }

        public DbSet<Student_Supervisor> Student_Supervisor { get; set; }

        public DbSet<Supervisor> Supervisor { get; set; }

        public DbSet<QualtricsSent> QualtricsSent { get; set; }


    }
}
