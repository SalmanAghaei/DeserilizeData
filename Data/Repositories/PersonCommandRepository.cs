using Toolkit.Data;
using Data.Contexts;
using Domain.Entities;
using Contract.Repositories;
using System;

namespace Data.Repositories;

public class PersonCommandRepository : Repository<Person, Guid, CommandDbContext>, IPersonCommandRepository
{
    public PersonCommandRepository(CommandDbContext context) : base(context)
    {
    }
}  
