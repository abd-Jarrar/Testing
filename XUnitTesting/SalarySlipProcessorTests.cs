using Testing.Models;
using Testing.Services;
using Xunit;
using Moq;
using Testing.Interfaces;
namespace Testing.XUnitTesting
{
    public class SalarySlipProcessorTests
    {
        //[Fact]
        //public void Method_Scenario_Outcome()
        //{

        //}
        [Fact]
        public void CalculateBasicSalary_ForEmployeeWageAndWorkingDays_ReturnBasicSalary()
        {
            var emp = new Employee() { Wage = 500m, WorkingDays = 20 };

            var salarySlipProcessor = new SalarySlipProcessor(null!);

            var actual=salarySlipProcessor.CalculateBasicSalary(emp);

            var expected = 10000m;

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void CalculateBasicSalary_ForNullEmployee_ThrowArgumentNullException()
        {
            //Arrange

            Employee emp = null!;

            //Act
            var salarSlipProcessor = new SalarySlipProcessor(null!);
            Func<Employee, Decimal> func1 = salarSlipProcessor.CalculateBasicSalary;



            //Assert
            Assert.Throws<ArgumentNullException>(() => func1(emp));
        }

        [Fact]
        public void CalculateDangerPay_EmployeeIsNull_ArgumentNUllException()
        {
            //Arrange
            Employee emp = null!;
            //Act
            var salarSlipProcesss = new SalarySlipProcessor(new ZoneService());
            Func<Employee,decimal> func1= salarSlipProcesss.CalculateDangerPay;
            //Assert
            Assert.Throws<ArgumentNullException>(()=>func1(emp));
        }

        [Fact]
        public void CalculateDangerPay_EmployeeIsDangerOffAndInDangerZone_ArgumentNUllException()
        {
            //Arrange
            Employee emp = new Employee() { IsDanger =false, DutyStation="f"};
            var mock = new Mock<IZoneService>();
            var setup=mock.Setup(z=>z.IsDangerZone(emp.DutyStation)).Returns(true);
            //Act
            
            var salarSlipProcesss = new SalarySlipProcessor(mock.Object);
            Func<Employee, decimal> func1 = salarSlipProcesss.CalculateDangerPay;
            //Assert
            Assert.Throws<ArgumentNullException>(() => func1(emp));
        }
        //public decimal CalculateDangerPay(Employee employee)
        //{

        //    if (employee is null)
        //        throw new ArgumentNullException(nameof(employee));

        //    if (employee.IsDanger)
        //        return Constants.DangerPayAmount;

        //    var isDangerZone = zoneService.IsDangerZone(employee.DutyStation);

        //    if (isDangerZone)
        //        return Constants.DangerPayAmount;

        //    return 0m;
        //}
    }
}
