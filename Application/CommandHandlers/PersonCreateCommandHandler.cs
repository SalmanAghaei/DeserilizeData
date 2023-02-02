using System;
using MediatR;
using Toolkit;
using Contract.Dtos;
using Domain.Entities;
using OvetimePolicies;
using System.Threading;
using Contract.Commands;
using Toolkit.DateTimes;
using Toolkit.Serializer;
using Contract.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application.CommandHandlers;

public class PersonCreateCommandHandler : IRequestHandler<PersonCreateCommand, ServiceResult>
{
    readonly IPersonCommandRepository _repository;
    readonly ICalculatorProvider _calculatorProvider;
    readonly ISerializer _serializerProvider;
    public PersonCreateCommandHandler(IPersonCommandRepository repository, ISerializer serializerProvider, ICalculatorProvider calculatorProvider)
    {
        _repository = repository;
        _serializerProvider = serializerProvider;
        _calculatorProvider = calculatorProvider;
    }

    public Task<ServiceResult> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
    {
        //TO DO : Moved Try Catch To ExceptionHandler 
        try
        {
            var serializer = _serializerProvider.Desrialize<PersonCreateDto>(request.Data);
            if (!serializer.Date.ValidDateString())
                return ServiceResultHandler.FailAsync(message: "Date Invalid");
            var date = serializer.Date.PersianToMiladiDate();
            var calculator = _calculatorProvider.GetCalculator(request.OverTimeCalculator);
            var calculatSalary = calculator.Calculate(serializer.BasicSalary, serializer.Allowance, serializer.Transportation, 0);
            var person = _repository.Get(x => x.FirstName == serializer.FirstName && x.LastName == serializer.LastName);
            if (person is null)
                CreateNewPerson(serializer, date, calculatSalary, request.OverTimeCalculator);
            else
                AddPersonSalary(serializer, date, calculatSalary, person, request.OverTimeCalculator);
            _repository.SaveChanges();
            return ServiceResultHandler.OkAsync();
        }
        catch (FormatException ex)
        {
            return ServiceResultHandler.FailAsync(message: "Format Incorrect");
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

    private void CreateNewPerson(PersonCreateDto serializer, DateTime date, decimal calculatSalary, string overTimeCalculator)
    {
        var person = new Person(serializer.FirstName, serializer.LastName);
        var personSalary = new PersonSalary
        (
            date: date,
            personId: person.Id,
            salary: calculatSalary,
            tax: 0,
            allowance: serializer.Allowance,
            basicSalary: serializer.BasicSalary,
            transportation: serializer.Transportation,
            overTimeCalculator: overTimeCalculator
        );
        person.CreatePersonSalary(new List<PersonSalary> { personSalary });
        _repository.Insert(person);
    }
    private void AddPersonSalary(PersonCreateDto serializer, DateTime date, decimal calculatSalary, Person person, string overTimeCalculator)
    {
        _repository.LoadCollection(person, x => x.PersonSalaries);
        var personSalary = new PersonSalary
        (
            date: date,
            personId: person.Id,
            salary: calculatSalary,
            tax: 0,
            allowance: serializer.Allowance,
            basicSalary: serializer.BasicSalary,
            transportation: serializer.Transportation,
            overTimeCalculator: overTimeCalculator
        );
        person.AddPersonSalary(new List<PersonSalary> { personSalary });

    }
}
