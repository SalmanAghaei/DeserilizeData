using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class PersonSalaryConfig : IEntityTypeConfiguration<PersonSalary>
{
    public void Configure(EntityTypeBuilder<PersonSalary> builder)
    {
        builder.HasIndex("Date","PersonId").IsUnique();
        builder.Property(x => x.OverTimeCalculator).HasColumnType("Char(11)");
    }
}
