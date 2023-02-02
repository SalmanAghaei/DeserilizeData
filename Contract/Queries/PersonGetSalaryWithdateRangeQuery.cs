using Contract.Dtos;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Toolkit;

namespace Contract.Queries;

public class PersonGetSalaryWithdateRangeQuery : IRequest<ServiceResult<List<PersonGetSalaryDto>>>
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

 
 
    [Required]
    [RegularExpression("^[0-9]{8}$", ErrorMessage = "FromDate Format Invalid(Example : 14010402")]
    public string FromDate { get; set; }

    [Required]
    [RegularExpression("^[0-9]{8}$", ErrorMessage = "ToDate Format Invalid(Example : 14010402")]
    public string ToDate { get; set; }

}
