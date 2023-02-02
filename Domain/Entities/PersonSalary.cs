using System;

namespace Domain.Entities;

public class PersonSalary
{
    private PersonSalary() { }
    public PersonSalary(decimal tax, DateTime date, Guid personId, decimal salary, decimal allowance, decimal basicSalary, decimal transportation, string overTimeCalculator
        )
    {
        Tax = tax;
        Date = date;
        PersonId = personId;
        Salary = salary;
        Allowance = allowance;
        BasicSalary = basicSalary;
        Transportation = transportation;
        OverTimeCalculator = overTimeCalculator;
    }


    public void Update(decimal tax, decimal salary, decimal allowance, decimal basicSalary, decimal transportation, string overTimeCalculator
        )
    {
        Tax = tax;
        Salary = salary;
        Allowance = allowance;
        BasicSalary = basicSalary;
        Transportation = transportation;
        OverTimeCalculator = overTimeCalculator;
    }
    public Guid Id { get; private set; }

    private decimal tax;
    public decimal Tax
    {
        get { return tax; }

        set
        {
            if (decimal.IsNegative(value))
                throw new Exception("Tax is not negative");
            tax = value;
        }
    }

    private decimal salary;
    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (decimal.IsNegative(value))
                throw new Exception("Salary is not negative");
            salary = value;
        }
    }


    private decimal allowance;
    public decimal Allowance
    {
        get { return allowance; }
        set
        {
            if (decimal.IsNegative(value))
                throw new Exception("Allowance is not negative");
            allowance = value;
        }
    }


    private decimal basicSalary;
    public decimal BasicSalary
    {
        get { return basicSalary; }
        set
        {
            if (decimal.IsNegative(value))
                throw new Exception("BasicSalary is not negative");
            basicSalary = value;
        }
    }

    private decimal transportation;
    public decimal Transportation
    {
        get { return transportation; }
        set
        {
            if (decimal.IsNegative(value))
                throw new Exception("Transportation is not negative");
            transportation = value;

        }
    }



    private DateTime date;
    public DateTime Date { get; set; }


    private string overTimeCalculator;
    public string OverTimeCalculator
    {
        get { return overTimeCalculator; }
        set
        {
            overTimeCalculator = value.ToUpper();
        }
    }


    public Guid PersonId { get; private set; }
    public Person Person { get; private set; }

}
