using System;
using MediatR;
using Toolkit;
using OvetimePolicies;
using System.Threading;
using Contract.Commands;
using Contract.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.CommandHandlers;

public class PersonEditCommandHandler : IRequestHandler<PersonEditCommand, ServiceResult>
{
    readonly IPersonCommandRepository _personRepository;
    readonly IPersonSalaryCommandRepository _personSalaryRepository;
    readonly ICalculatorProvider _calculatorProvider;
    public PersonEditCommandHandler(
        IPersonCommandRepository repository,
        ICalculatorProvider calculatorProvider,
        IPersonSalaryCommandRepository personSalaryRepository
        )
    {
        _personRepository = repository;
        _calculatorProvider = calculatorProvider;
        _personSalaryRepository = personSalaryRepository;
    }

    public Task<ServiceResult> Handle(PersonEditCommand request, CancellationToken cancellationToken)
    {
        //TO DO : Moved Try Catch To ExceptionHandler 
        try
        {
            var personSalary = _personSalaryRepository.Get(x => x.Id == request.PersonSalaryId);
            if (personSalary is null)
                return ServiceResultHandler.FailAsync(message: "Salary date not found");
            var calculator = _calculatorProvider.GetCalculator(request.OverTimeCalculator);
            var calculatSalary = calculator.Calculate(request.BasicSalary, request.Allowance, request.Transportation, 0);
            personSalary.Update(0, calculatSalary, request.Allowance, request.BasicSalary, request.Transportation, request.OverTimeCalculator);
            _personRepository.SaveChanges();
            return ServiceResultHandler.OkAsync();
        }

        catch (DbUpdateException ex)
        {
            return ServiceResultHandler.FailAsync(message: "Duplicated Data");
        }
        catch (Exception ex)
        {
            return ServiceResultHandler.FailAsync(message: ex.Message);
        }

    }


}
