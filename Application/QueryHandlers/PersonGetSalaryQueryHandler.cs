using MediatR;
using Toolkit;
using Contract.Dtos;
using Contract.Queries;
using System.Threading;
using Toolkit.DateTimes;
using Contract.Repositories;
using System.Threading.Tasks;

namespace Application.QueryHandlers;

public class PersonGetSalaryQueryHandler : IRequestHandler<PersonGetSalaryQuery, ServiceResult<PersonGetSalaryDto>>
{
    readonly IPersonQueryRepository _personQueryRepository;

    public PersonGetSalaryQueryHandler(IPersonQueryRepository personQueryRepository)
    {
        _personQueryRepository = personQueryRepository;
    }

    public Task<ServiceResult<PersonGetSalaryDto>> Handle(PersonGetSalaryQuery request, CancellationToken cancellationToken)
    {
        if (!CheckValidateDate(request.Date))
            return ServiceResultHandler.FailAsync<PersonGetSalaryDto>(null, message: "Date Format Incorrect");
        var result = _personQueryRepository.GetPersonSalary(request);
        return ServiceResultHandler.OkAsync(result);
    }

    private bool CheckValidateDate(string date) =>
      date.ValidDateString();

}
