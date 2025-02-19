using AutoMapper;
using BankSystem.Core.Common;
using BankSystem.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace BankSystem.Service.ViewModel;
[AutoMap(typeof(CardInfo), ReverseMap = true)]
public class CardInfoVm:BaseEntity
{
    public string CardFile { get; set; }
    public string CardNumber { get; set; }
    public string CustomerName { get; set; }
    public string AccountNumber { get; set; }
    public IFormFile FileContent { get; set; }
    public long FileTypeId { get; set; }
    public FileType FileTypes { get; set; }
}
