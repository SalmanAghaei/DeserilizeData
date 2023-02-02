using System;

namespace Contract.Dtos;

public class PersonGetSalaryFilterDto
{
    public DateTime Date { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }

}
