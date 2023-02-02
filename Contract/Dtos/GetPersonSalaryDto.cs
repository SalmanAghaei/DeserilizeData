using System;
using Toolkit.DateTimes;

namespace Contract.Dtos;

public class PersonGetSalaryDto
{
    public Guid PersonSalaryId { get; set; }
    public DateTime Date { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public decimal Allowance { get; set; }
    public decimal BasicSalary { get; set; }
    public decimal Salary { get; set; }
    public decimal Transportation { get; set; }
    public string OverTimeCalculator { get; set; }
    public decimal Tax { get; set; }
    public string PersianDate => Date.MiladiToPersianDate();
}
