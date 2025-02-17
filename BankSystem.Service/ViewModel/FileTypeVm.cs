using AutoMapper;
using BankSystem.Core.Common;
using BankSystem.Core.Entities;

namespace BankSystem.Service.ViewModel;
[AutoMap(typeof(FileType),ReverseMap =true)]
public class FileTypeVm: BaseEntity
{
    public string Name { get; set; }
}
