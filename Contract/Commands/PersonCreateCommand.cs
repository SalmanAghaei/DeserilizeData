using MediatR;
using Toolkit;

namespace Contract.Commands;

public record PersonCreateCommand(string Data,string OverTimeCalculator) : IRequest<ServiceResult>;

