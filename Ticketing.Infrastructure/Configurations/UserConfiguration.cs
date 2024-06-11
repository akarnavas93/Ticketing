using Ticketing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Ticketing.Infrastructure.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users", schema: "accounts")
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasIndex(x => x.Email)
            .IsUnique();

        builder.HasData(
            new User
            {
                // Password is 123456!Aa
                Id = Guid.Parse("0afe7827-a0cf-47d4-9820-488d84b894b0"),
                Name = "foo",
                Email = "operations@bar.com",
                AccountType = Shared.Constants.AccountType.Operations,
                PasswordHash = "y0hJNdP2TNzYp1JrFnO/PhrGL7BI567/OskMBZ/bjBzmlQND1AO3bTiYFTGlGcMmDRNfUbOVLytbH+K3k2FjYw==",
                PasswordSalt = "6MonNb30kVohmzyk6hvpm9Pn7x66ATPe7DbEhUqeHAPZtL5xS8D29xEfs9lewyMKBQzAiYCH2aH5FpgH+Edd3Ov5Qk+rImsGdiN49W43SafAXsx5XFmRJs1UrJV6HgA70GrLpoZ//MJVH7DoKw7E8i1YhsIIzXb9m1Xr6EVGlYk="
            },
            new User
            {
                // Password is 123456!Aa
                Id = Guid.Parse("30b3e2db-213c-4519-8dee-83b70133db35"),
                Name = "bar",
                Email = "it@bar.com",
                AccountType = Shared.Constants.AccountType.InformationTechnology,
                PasswordHash = "y0hJNdP2TNzYp1JrFnO/PhrGL7BI567/OskMBZ/bjBzmlQND1AO3bTiYFTGlGcMmDRNfUbOVLytbH+K3k2FjYw==",
                PasswordSalt = "6MonNb30kVohmzyk6hvpm9Pn7x66ATPe7DbEhUqeHAPZtL5xS8D29xEfs9lewyMKBQzAiYCH2aH5FpgH+Edd3Ov5Qk+rImsGdiN49W43SafAXsx5XFmRJs1UrJV6HgA70GrLpoZ//MJVH7DoKw7E8i1YhsIIzXb9m1Xr6EVGlYk="
            },
            new User
            {
                // Password is 123456!Aa
                Id = Guid.Parse("df862849-2e4b-4f54-ae81-a8b55cf2fd17"),
                Name = "foobar",
                Email = "undefined@bar.com",
                AccountType = Shared.Constants.AccountType.Undefined,
                PasswordHash = "y0hJNdP2TNzYp1JrFnO/PhrGL7BI567/OskMBZ/bjBzmlQND1AO3bTiYFTGlGcMmDRNfUbOVLytbH+K3k2FjYw==",
                PasswordSalt = "6MonNb30kVohmzyk6hvpm9Pn7x66ATPe7DbEhUqeHAPZtL5xS8D29xEfs9lewyMKBQzAiYCH2aH5FpgH+Edd3Ov5Qk+rImsGdiN49W43SafAXsx5XFmRJs1UrJV6HgA70GrLpoZ//MJVH7DoKw7E8i1YhsIIzXb9m1Xr6EVGlYk="
            }
            );
    }
}
