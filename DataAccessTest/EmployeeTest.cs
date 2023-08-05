using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.DomainModels;

namespace DataAccessTest
{
    public class EmployeeTest
    {
        [Fact]
        public void CalculateSalary_Negative_ThrowNotImplementedException()
        {
            #region Arrange
            Employee employee = new Employee(1, "test", DateTime.Now, "TestTIN", (int)EmployeeType.Regular, false, 2345, 0.12m);
            #endregion

            #region Act
            Assert.Throws<NotImplementedException>(() => employee.CalculateSalary(7));
            #endregion

            #region Assert
            #endregion
        }

        [Fact]
        public void CalculateSalary_Positive_TestCase1InPdf()
        {
            #region Arrange
            Employee employee = new RegularEmployee(1, "test", DateTime.Now, "TestTIN", (int)EmployeeType.Regular, false, 20000, 0.12m);
            #endregion

            #region Act
            var actualSalary = employee.CalculateSalary(1);
            #endregion

            #region Assert
            Assert.Equal("16690.91", String.Format("{0:0.00}", Math.Round(actualSalary, 2)));
            #endregion
        }

        [Fact]
        public void CalculateSalary_Positive_TestCase2InPdf()
        {
            #region Arrange
            Employee employee = new ContractualEmployee(1, "test", DateTime.Now, "TestTIN", (int)EmployeeType.Regular, false, 500);
            #endregion

            #region Act
            var actualSalary = employee.CalculateSalary(15.5m);
            #endregion

            #region Assert
            Assert.Equal(7750m, actualSalary);
            #endregion
        }
    }
}