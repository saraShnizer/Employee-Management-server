using EmployeesList.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesList.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }


        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>()
                .HasKey(pe => new { pe.EmployeeId, pe.RoleId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
            optionsBuilder.LogTo((message) => Debug.Write(message));
        }
      
   



    }
}
