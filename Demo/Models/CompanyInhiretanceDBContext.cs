using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    internal class CompanyInhiretanceDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.;Database= CompanyInhiretance; Trusted_Connection= true; trustservercertificate= true");
        }

        //public DbSet<FT_Employee> FullTimeEmployee { get; set; }
        //public DbSet<PT_Employee> PartTimeEmployee { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FT_Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal");
            modelBuilder.Entity<PT_Employee>()
                .Property(e => e.HourRate)
                .HasColumnType("decimal");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region TPH
            modelBuilder.Entity<FT_Employee>()
                .HasBaseType<Employee>();
            modelBuilder.Entity<PT_Employee>()
                .HasBaseType<Employee>();
            #endregion
        }
    }
}
