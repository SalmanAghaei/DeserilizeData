using Contract.Dtos;
using Contract.Queries;
using Contract.Repositories;
using System.Collections.Generic;
using Toolkit.Data;
using Toolkit.DateTimes;

namespace Data.Repositories;

public class PersonQueryRepository : IPersonQueryRepository
{
    private readonly IDapper _dapper;
    public PersonQueryRepository(IDapper dapper)
    {
        _dapper = dapper;
    }

    public PersonGetSalaryDto GetPersonSalary(PersonGetSalaryQuery filter)
    {
     
        var str = "select ps.Id PersonSalaryId,ps.date,ps.tax,p.LastName,p.FirstName,ps.Allowance,ps.BasicSalary,ps.Transportation,ps.Salary,ps.OverTimeCalculator from [TestDb].[dbo].people p\r\n" +
            "  join [TestDb].[dbo].[PersonSalaries] ps on p.id=ps.personId\r\n" +
            $"  where p.FirstName='{filter.FirstName}' and p.LastName='{filter.LastName}' and cast(ps.[Date] as date)='{filter.Date.PersianToMiladiDateToString()}'";
        var result=_dapper.Get<PersonGetSalaryDto>(str, null);
        return result;  
    }
    public List<PersonGetSalaryDto> GetPersonSalaryDateRange(PersonGetSalaryWithdateRangeQuery filter)
    {

        var str = "select ps.Id PersonSalaryId,ps.date,ps.tax,p.LastName,p.FirstName,ps.Allowance,ps.BasicSalary,ps.Transportation,ps.Salary,ps.OverTimeCalculator from [TestDb].[dbo].people p\r\n" +
            "  join [TestDb].[dbo].[PersonSalaries] ps on p.id=ps.personId\r\n" +
            $"  where p.FirstName='{filter.FirstName}' and p.LastName='{filter.LastName}' and cast(ps.[Date] as date) between '{filter.FromDate.PersianToMiladiDateToString()}' and '{filter.ToDate.PersianToMiladiDateToString()}'";
        var result = _dapper.GetAll<PersonGetSalaryDto>(str, null);
        return result;
    }


   
}
