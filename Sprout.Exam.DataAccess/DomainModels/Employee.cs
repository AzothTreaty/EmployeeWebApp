using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Sprout.Exam.DataAccess.DomainModels
{
    public class Employee
    {

        public Employee(int id, string fullName, DateTime birthdate, string tIN, int employeeTypeId, bool isDeleted, decimal salary, decimal? taxPercentage) 
        {
            Id = id;
            FullName = fullName;
            Birthdate = birthdate;
            TIN = tIN;
            EmployeeTypeId = employeeTypeId;
            IsDeleted = isDeleted;
            Salary = salary;
            TaxPercentage = taxPercentage;

        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string TIN { get; private set; }
        public int EmployeeTypeId { get; private set; }
        public bool IsDeleted { get; private set; }
        public decimal Salary { get; private set; }
        public decimal? TaxPercentage { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Update(string fullName, DateTime birthDate, string tin, int employeeTypeId)
        {
            FullName = fullName;
            Birthdate = birthDate;
            TIN = tin;
            EmployeeTypeId = employeeTypeId;
        }

        public virtual decimal CalculateSalary(decimal numberOfDays)
        {
            throw new NotImplementedException();
        }

        public EmployeeDto ToDto()
        {
            return new EmployeeDto
            {
                Birthdate = this.Birthdate.ToString("yyyy-MM-dd"),
                FullName = this.FullName,
                Id = this.Id,
                Tin = this.TIN,
                TypeId = this.EmployeeTypeId,
                SalaryAmount = Salary.ToString()
            };
        }

        //Factory Method
        public Employee ConvertToCorrectSubClass()
        {
            return (EmployeeType)EmployeeTypeId switch
            {
                EmployeeType.Regular => new RegularEmployee(Id, FullName, Birthdate, TIN, EmployeeTypeId, IsDeleted, Salary, TaxPercentage),
                EmployeeType.Contractual => new ContractualEmployee(Id, FullName, Birthdate, TIN, EmployeeTypeId, IsDeleted, Salary),
                _ => throw new NotImplementedException()
            };
        }
    }
}
