using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.WebApp.Repository
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee dto);
        Employee? GetById(int id);
        Task SaveChangesAsync();
        List<Employee> GetEmployees();
    }
}
