using Toolkit.Data;
using Data.Contexts;
using Domain.Entities;
using Contract.Repositories;
using System;

namespace Data.Repositories;

public class PersonSalaryCommandRepository : Repository<PersonSalary, Guid, CommandDbContext>, IPersonSalaryCommandRepository
{
    public PersonSalaryCommandRepository(CommandDbContext context) : base(context)
    {
    }
}
