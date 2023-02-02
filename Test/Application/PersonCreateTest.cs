using Xunit;
using System;
using NSubstitute;
using Contract.Dtos;
using Domain.Entities;
using OvetimePolicies;
using FluentAssertions;
using Contract.Commands;
using Toolkit.Serializer;
using Contract.Repositories;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Application.CommandHandlers;

namespace Test.Application
{
    public class PersonCreateTest : IClassFixture<PersonCommandFixture>
    {
        private readonly PersonCommandFixture _personCommandFixture;

        public PersonCreateTest(PersonCommandFixture personCommandFixture)
        {
            _personCommandFixture = personCommandFixture;
        }

        [Fact]
        public async Task Should_Create_When_Not_Exist_Person()
        {

            var personRepository = Substitute.For<IPersonCommandRepository>();
            var serializer = Substitute.For<ISerializer>();
            var calculatorprovider = Substitute.For<ICalculatorProvider>();
            var calculator = Substitute.For<ICalculator>();
            personRepository.Get(x => x.FirstName == _personCommandFixture.validPersonCreate.FirstName && x.LastName == _personCommandFixture.validPersonCreate.LastName).Returns(x => null);
            calculatorprovider.GetCalculator("").Returns(calculator);

            calculator.Calculate(_personCommandFixture.validPersonCreate.BasicSalary, _personCommandFixture.validPersonCreate.Allowance, _personCommandFixture.validPersonCreate.Transportation, 0).Returns(4002);
            serializer.Desrialize<PersonCreateDto>("").Returns(_personCommandFixture.validPersonCreate);


            var command = new PersonCreateCommand("", "");
            var commandHandler = new PersonCreateCommandHandler(personRepository, serializer, calculatorprovider);
            var act = await commandHandler.Handle(command, System.Threading.CancellationToken.None);
            Received.InOrder(() =>
            {

                personRepository.Insert(Arg.Any<Person>());
                personRepository.SaveChanges();
            });
        }
        [Fact]
        public async Task Should_Update_Person_Salary_When_Exist_Person()
        {
            var returnPerson = new Person("salman", "aghaei");
            returnPerson.CreatePersonSalary(new List<PersonSalary> { });
            var personRepository = Substitute.For<IPersonCommandRepository>();
            var serializer = Substitute.For<ISerializer>();
            var calculatorprovider = Substitute.For<ICalculatorProvider>();
            var calculator = Substitute.For<ICalculator>();

            personRepository.Get(Arg.Any<Expression<Func<Person, bool>>>())
                .Returns(returnPerson);

            calculatorprovider.GetCalculator("").Returns(calculator);

            calculator.Calculate(_personCommandFixture.validPersonCreate.BasicSalary, _personCommandFixture.validPersonCreate.Allowance, _personCommandFixture.validPersonCreate.Transportation, 0).Returns(4002);
            serializer.Desrialize<PersonCreateDto>("").Returns(_personCommandFixture.validPersonCreate);





            var command = new PersonCreateCommand("", "");
            var commandHandler = new PersonCreateCommandHandler(personRepository, serializer, calculatorprovider);
            var act = await commandHandler.Handle(command, System.Threading.CancellationToken.None);

            personRepository.DidNotReceive().Insert(Arg.Any<Person>());
            personRepository.Received(1).SaveChanges();
        }

        [Fact]
        public async Task Should_Failed_When_Invalid_Date()
        {
            var personRepository = Substitute.For<IPersonCommandRepository>();
            var serializer = Substitute.For<ISerializer>();
            var calculatorprovider = Substitute.For<ICalculatorProvider>();
            var calculator = Substitute.For<ICalculator>();

            serializer.Desrialize<PersonCreateDto>("").Returns(_personCommandFixture.invalidDatePersonCreate);

            var command = new PersonCreateCommand("", "");
            var commandHandler = new PersonCreateCommandHandler(personRepository, serializer, calculatorprovider);
            var act = await commandHandler.Handle(command, System.Threading.CancellationToken.None);


            act.IsSuccess.Should().BeFalse();
            act.Message.Should().Be("Date Invalid");
        }
        [Fact]
        public async Task Should_Failed_When_Invalid_Format()
        {
            var personRepository = Substitute.For<IPersonCommandRepository>();
            var serializer = Substitute.For<ISerializer>();
            var calculatorprovider = Substitute.For<ICalculatorProvider>();
            var calculator = Substitute.For<ICalculator>();

            serializer.Desrialize<PersonCreateDto>("").Returns(x => { throw new FormatException(); });

            var command = new PersonCreateCommand("", "");
            var commandHandler = new PersonCreateCommandHandler(personRepository, serializer, calculatorprovider);
            var act = await commandHandler.Handle(command, System.Threading.CancellationToken.None);


            act.IsSuccess.Should().BeFalse();
            act.Message.Should().Be("Format Incorrect");
        }
    }
}
