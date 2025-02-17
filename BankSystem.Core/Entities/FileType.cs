using BankSystem.Core.Common;

namespace BankSystem.Core.Entities;

public class FileType : AuditableEntity
{
    public string Name { get; set; }
    public ICollection<CardInfo> CardInfos { get; set; }= new List<CardInfo>();
}
