using BankSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Data.Configurations;

public class CardInfoConfiguration:IEntityTypeConfiguration<CardInfo>
{
    public void Configure(EntityTypeBuilder<CardInfo> builder)
    {
        builder.ToTable(nameof(CardInfo));
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.FileTypes).WithMany(x => x.CardInfos).HasForeignKey(x => x.FileTypeId);
    }
}

