using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities;

public class Person
{
    private Person()
    {

    }


    public Person(string firstName,string lastName)
    {
        LastName= lastName;
        FirstName = firstName;
    }

    public void CreatePersonSalary(List<PersonSalary> personSalary)
    {
        PersonSalaries=personSalary;
    }

    public void AddPersonSalary(List<PersonSalary> personSalary)
    {
        PersonSalaries.AddRange(personSalary);  
    }
    public Guid Id { get;private set; }

    private  string lastName;
    public string LastName
    {
        get { return lastName; }
        set 
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Lastname is not null or empty");
            lastName = value; 
        }
    }

    private string firstName;
    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("FirstName is not null or empty");
            firstName = value;
        }
    }
    public List<PersonSalary> PersonSalaries { get; private set; }   
}
