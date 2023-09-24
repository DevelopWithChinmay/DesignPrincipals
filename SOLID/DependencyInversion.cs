namespace SOLID.DIP
{
    /// <summary>
    /// A high-level class must not depend upon a lower-level class. They must both depend upon abstractions.
    /// And secondly, an abstraction must not depend upon details, but the details must depend upon abstractions
    /// </summary>
    #region Violation Sample
    public class SalaryCalculator
    {
        public float CalculateSalary(float hourlyWage, float noOfHours) =>
            hourlyWage * noOfHours;
    }

    public class EmployeeDetails
    {
        public float hourslyWage { get; set; }
        public float noOfHours { get; set; }
        public float GetSalary()
        {
            // This is an example how high level class is dependent on concrete implemented low level classs
            var salaryCalculator = new SalaryCalculator();
            return salaryCalculator.CalculateSalary(hourslyWage, noOfHours);
        }
    }
    #endregion
    #region Abiding Sample
    public interface ISalaryCalculator
    {
        float CalculateSalary(float hourlyWage, float noOfHours);
    }
    public class SalaryCalculator_DI : ISalaryCalculator
    {
        public float CalculateSalary(float hourlyWage, float noOfHours) =>
            hourlyWage * noOfHours;
    }

    public class EmployeeDetails_DI
    {
        private ISalaryCalculator _salaryCalculator;
        public float hourslyWage { get; set; }
        public float noOfHours { get; set; }
        public EmployeeDetails_DI(ISalaryCalculator salaryCalculator) =>
            _salaryCalculator = salaryCalculator;
        
        public float GetSalary()
        {
            // This is an example how high level class is independent from concrete implemented low level classs
            return _salaryCalculator.CalculateSalary(hourslyWage, noOfHours);
        }
    }
    #endregion
}
