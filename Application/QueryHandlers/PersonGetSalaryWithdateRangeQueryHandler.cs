using MediatR;
using Toolkit;
using Contract.Dtos;
using Contract.Queries;
using System.Threading;
using Toolkit.DateTimes;
using Contract.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.QueryHandlers;

public class PersonGetSalaryWithdateRangeQueryHandler : IRequestHandler<PersonGetSalaryWithdateRangeQuery, ServiceResult<List<PersonGetSalaryDto>>>
{
    readonly IPersonQueryRepository _personQueryRepository;

    public PersonGetSalaryWithdateRangeQueryHandler(IPersonQueryRepository personQueryRepository)
    {
        _personQueryRepository = personQueryRepository;
    }

    public Task<ServiceResult<List<PersonGetSalaryDto>>> Handle(PersonGetSalaryWithdateRangeQuery request, CancellationToken cancellationToken)
    {
        if (!CheckValidateDate(request.FromDate))
            return ServiceResultHandler.FailAsync<List<PersonGetSalaryDto>>(null, message: "FromDate Format Incorrect");
        if (!CheckValidateDate(request.ToDate))
            return ServiceResultHandler.FailAsync<List<PersonGetSalaryDto>>(null, message: "ToDate Format Incorrect");
        var result = _personQueryRepository.GetPersonSalaryDateRange(request);
        return ServiceResultHandler.OkAsync(result);
    }

    private bool CheckValidateDate(string date) =>
      date.ValidDateString();

}
