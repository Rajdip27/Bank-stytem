﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Data.Configurations.Auth;

internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole
        {
            Id = "1",
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR",

        }, new IdentityRole
        {
            Id = "2",
            Name = "User",
            NormalizedName = "USER",
        });
    }
}
