using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sprout.Exam.DataAccess.DomainModels;
using Sprout.Exam.DataAccess.EntityConfigurations;
using Sprout.Exam.WebApp.Models;
using System.Reflection.Metadata;

namespace Sprout.Exam.WebApp.Data
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeDbContext(
            DbContextOptions<EmployeeDbContext> options) : base (options)
        {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EmployeeEntityConfiguration().Configure(modelBuilder.Entity<Employee>().ToTable("Employee"));
        }
        #endregion
    }
}
