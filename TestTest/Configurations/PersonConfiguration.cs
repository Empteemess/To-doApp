using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTest.Entities;

namespace TestTest.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .HasMany(x => x.Connections)
            .WithOne(x => x.Persons)
            .HasForeignKey(x => x.Person1Id)
            .IsRequired();

        builder
            .HasOne(x => x.MailPassword)
            .WithOne(x => x.Person)
            .HasForeignKey<MailPassword>(x => x.PersonId)
            .IsRequired();
    }
}