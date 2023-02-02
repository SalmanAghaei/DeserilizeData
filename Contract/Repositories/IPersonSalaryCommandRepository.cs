using Domain.Entities;
using System;
using Toolkit.Data;

namespace Contract.Repositories;

public interface IPersonSalaryCommandRepository:IRepository<PersonSalary, Guid> { }
