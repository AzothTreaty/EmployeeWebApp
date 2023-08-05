using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Services
{
    public interface IEmployeeService
    {
        EmployeeDto? GetById(int id);
        Task<int> AddAsync(CreateEmployeeDto input);
        List<Employee> GetEmployees();
        Task DeleteEmployee(int id);
        Task<EmployeeDto> Update(EditEmployeeDto dto);
        decimal Calculate(int id, decimal absentDays, decimal workedDays);
    }
}
