using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Entities;

namespace TestProject.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .HasMany(x => x.Number)
            .WithOne(x => x.Person)
            .HasForeignKey(x => x.PersonId)
            .IsRequired();
    }
}