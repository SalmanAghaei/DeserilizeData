using MediatR;
using Microsoft.Identity.Client;
using System;
using System.ComponentModel.DataAnnotations;
using Toolkit;

namespace Contract.Commands;

public record PersonEditCommand(
      [Required]Guid PersonSalaryId,
      [Required]decimal Allowance ,
      [Required]decimal BasicSalary,
      [Required]decimal Transportation ,
      [Required] string OverTimeCalculator
    ) : IRequest<ServiceResult>;

