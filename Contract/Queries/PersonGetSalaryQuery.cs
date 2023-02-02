using Contract.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;
using Toolkit;

namespace Contract.Queries;

public class PersonGetSalaryQuery : IRequest<ServiceResult<PersonGetSalaryDto>>
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }

    [Required]
    [RegularExpression("^[0-9]{8}$",ErrorMessage ="Date Format Invalid(Example : 14010402")]
    public string Date { get; set; }

}
