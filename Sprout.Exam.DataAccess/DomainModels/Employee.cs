using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sprout.Exam.DataAccess.DomainModels
{
    public class Employee
    {

        public Employee(int id, string fullName, DateTime birthdate, string tIN, int employeeTypeId, bool isDeleted) 
        {
            Id = id;
            FullName = fullName;
            Birthdate = birthdate;
            TIN = tIN;
            EmployeeTypeId = employeeTypeId;
            IsDeleted = isDeleted;        
        }

        public int Id { get; private set; }
        public string FullName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public string TIN { get; private set; }
        public int EmployeeTypeId { get; private set; }
        public bool IsDeleted { get; private set; }

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

        public EmployeeDto ToDto()
        {
            return new EmployeeDto
            {
                Birthdate = this.Birthdate.ToString("yyyy-MM-dd"),
                FullName = this.FullName,
                Id = this.Id,
                Tin = this.TIN,
                TypeId = this.EmployeeTypeId

            };
        }
    }
}
