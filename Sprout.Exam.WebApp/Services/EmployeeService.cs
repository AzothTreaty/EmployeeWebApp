using Humanizer;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
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

            decimal salary = decimal.Parse(input.SalaryAmount);

            await _employeeRepository.AddAsync(
                new Employee(
                    id, 
                    input.FullName,
                    input.Birthdate,
                    input.Tin, 
                    input.TypeId, 
                    false, 
                    salary, 
                    GetTaxPercentage((EmployeeType)input.TypeId, salary)));

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

        public decimal Calculate(int id, decimal absentDays, decimal workedDays)
        {
            var employee = GetEmployeeById(id);

            var convertedEmployee = employee.ConvertToCorrectSubClass();

            return ((EmployeeType)employee.EmployeeTypeId) switch
            {
                EmployeeType.Regular => convertedEmployee.CalculateSalary(absentDays),
                EmployeeType.Contractual => convertedEmployee.CalculateSalary(workedDays),
                _ => throw new NotImplementedException()
            }; ;
        }

        private Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);

            return employee ?? throw new KeyNotFoundException($"Employee with id {id} not found");
        }

        private static decimal? GetTaxPercentage(EmployeeType type, decimal salary)
        {
            return type switch
            {
                EmployeeType.Regular => 0.12m,
                EmployeeType.Contractual => null,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
