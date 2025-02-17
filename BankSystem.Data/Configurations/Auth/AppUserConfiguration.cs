using BankSystem.Core.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Data.Configurations.Auth;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();
        builder.HasKey(x => x.Id);

        builder.HasData(new AppUser
        {
            Id = "1",
            Name = "Rajdip",
            PhoneNumber = "01701734627",
            Address = "Dhaka,Dhanmondi",
            Email = "admin@localhost.com",
            NormalizedEmail = "ADMIN@LOCALHOST.COM",
            UserName = "admin@localhost.com",
            NormalizedUserName = "ADMIN@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()

        }, new AppUser
        {
            Id = "2",
            Name = "Raja",
            PhoneNumber = "01701734627",
            Address = "Dhaka,Dhanmondi",
            Email = "employee@localhost.com",
            NormalizedEmail = "EMPLOYEE@LOCALHOST.COM",
            UserName = "employee@localhost.com",
            NormalizedUserName = "EMPLOYEE@LOCALHOST.COM",
            PasswordHash = hasher.HashPassword(null, "P@ssword1"),
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),

        });
    }
}
