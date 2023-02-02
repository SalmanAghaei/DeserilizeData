using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class CommandDbContext : DbContext
{
    #region DbSet
    public DbSet<Person> People { get; set; }
    public DbSet<PersonSalary> PersonSalaries { get; set; }
    #endregion
    public CommandDbContext(DbContextOptions<CommandDbContext> option) : base(option)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CommandDbContext).Assembly);
    }
}