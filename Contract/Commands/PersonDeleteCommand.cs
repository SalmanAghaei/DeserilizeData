using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using Toolkit;

namespace Contract.Commands;

public record PersonDeleteCommand ([Required]Guid Id ) : IRequest<ServiceResult>;

