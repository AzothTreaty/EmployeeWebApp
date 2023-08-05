using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sprout.Exam.DataAccess.DomainModels
{
    public class ContractualEmployee : Employee
    {
        public ContractualEmployee(int id, string fullName, DateTime birthdate, string tIN, int employeeTypeId, bool isDeleted, decimal salary) 
            : base(id, fullName, birthdate, tIN, employeeTypeId, isDeleted, salary, null)
        {
        }

        public override decimal CalculateSalary(decimal numberOfDaysWorked)
        {
            return Salary * numberOfDaysWorked;
        }
    }
}
