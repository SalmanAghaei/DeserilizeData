using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(x => x.FirstName).HasColumnType("Nvarchar(50)");
        builder.Property(x => x.LastName).HasColumnType("Nvarchar(50)");
    }
}
