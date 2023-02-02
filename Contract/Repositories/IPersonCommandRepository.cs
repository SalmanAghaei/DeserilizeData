using System;
using Toolkit.Data;
using Domain.Entities;

namespace Contract.Repositories;

public interface IPersonCommandRepository : IRepository<Person, Guid> { }
