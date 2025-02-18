using AutoMapper;
using BankSystem.Core.Entities;
using BankSystem.Data.Persistence;
using BankSystem.Service.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankSystem.Service.Repository;

public interface IFileTypeRepository:IBaseRepository<FileType, FileTypeVm, long>
{
    public IEnumerable<SelectListItem> Dropdown();
}
public class FileTypeRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<FileType, FileTypeVm, long>(mapper, context), IFileTypeRepository
{
    public IEnumerable<SelectListItem> Dropdown()
    {
        return DbSet.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
    }
}
