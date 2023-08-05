using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sprout.Exam.DataAccess.DomainModels
{
    public class RegularEmployee : Employee
    {
        private static int NUMBEROFDAYSPERMONTH = 22;
        public RegularEmployee(int id, string fullName, DateTime birthdate, string tIN, int employeeTypeId, bool isDeleted, decimal salary, decimal? taxPercentage) 
            : base(id, fullName, birthdate, tIN, employeeTypeId, isDeleted, salary, taxPercentage)
        {
        }

        public override decimal CalculateSalary(decimal numberOfDaysAbsent)
        {
            var perDay = Salary / (decimal)NUMBEROFDAYSPERMONTH;
            decimal taxes = Salary * TaxPercentage!.Value;

            return (perDay * (NUMBEROFDAYSPERMONTH - numberOfDaysAbsent)) - taxes;
        }
    }
}


