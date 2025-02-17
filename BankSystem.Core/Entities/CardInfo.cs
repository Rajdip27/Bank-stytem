using BankSystem.Core.Common;

namespace BankSystem.Core.Entities;

public class CardInfo : AuditableEntity
{
    public string CardFile { get; set; }
    public string CardNumber { get; set; }
    public string CustomerName { get; set; }
    public string AccountNumber { get; set; }
    public long FileTypeId { get; set; }

    public FileType FileType { get; set; }
}
