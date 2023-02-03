using System;
using MediatR;
using Toolkit;
using System.Threading;
using Contract.Commands;
using Toolkit.Serializer;
using Contract.Repositories;
using System.Threading.Tasks;

namespace Application.CommandHandlers;

public class PersonDeleteCommandHandler : IRequestHandler<PersonDeleteCommand, ServiceResult>
{
    readonly IPersonSalaryCommandRepository _personSalaryRepository;
    public PersonDeleteCommandHandler(IPersonCommandRepository personRepository, IPersonSalaryCommandRepository personSalaryRepository)
    {
        _personSalaryRepository = personSalaryRepository;
    }


    public Task<ServiceResult> Handle(PersonDeleteCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var personSalary = _personSalaryRepository.Get(x => x.Id == request.Id);
            if (personSalary is null)
                return ServiceResultHandler.FailAsync(message: "Salary date not found");

            _personSalaryRepository.Delete(personSalary.Id);
            _personSalaryRepository.SaveChanges();
            return ServiceResultHandler.OkAsync();

        }
        catch (Exception ex)
        {
            return ServiceResultHandler.FailAsync(message: ex.Message);
        }
    }
}
