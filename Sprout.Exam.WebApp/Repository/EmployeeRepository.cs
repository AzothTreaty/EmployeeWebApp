using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.DomainModels;
using Sprout.Exam.WebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task AddAsync(Employee dto)
        {
            await _context.AddAsync(dto);
        }

        public Employee? GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
