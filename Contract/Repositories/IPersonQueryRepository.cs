using Contract.Dtos;
using Contract.Queries;
using System.Collections.Generic;

namespace Contract.Repositories;

public interface IPersonQueryRepository
{
    PersonGetSalaryDto GetPersonSalary(PersonGetSalaryQuery filter);

    List<PersonGetSalaryDto> GetPersonSalaryDateRange(PersonGetSalaryWithdateRangeQuery filter);
}
