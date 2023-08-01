using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.DomainModels;
using Sprout.Exam.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public EmployeeDto? GetById(int id)
        {
            return GetEmployeeById(id).ToDto();
        }

        public async Task<int> AddAsync(CreateEmployeeDto input)
        {
            var employees = _employeeRepository.GetEmployees();
            var id = employees.Any() ? employees.Max(m => m.Id) + 1 : 0;

            await _employeeRepository.AddAsync(new Employee(
                id, input.FullName, input.Birthdate,
                input.Tin, input.TypeId, false));

            await _employeeRepository.SaveChangesAsync();

            return id;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);

            employee.Delete();

            await _employeeRepository.SaveChangesAsync();
        }

        public async Task<EmployeeDto> Update(EditEmployeeDto dto)
        {
            var employee = GetEmployeeById(dto.Id);

            employee.Update(dto.FullName, dto.Birthdate, dto.Tin, dto.TypeId);

            await _employeeRepository.SaveChangesAsync();

            return employee.ToDto();
        }

        private Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);

            if (employee is null)
            {
                throw new KeyNotFoundException($"Employee with id {id} not found");
            }

            return employee;
        }
    }
}
