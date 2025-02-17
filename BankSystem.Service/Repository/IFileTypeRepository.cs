using AutoMapper;
using BankSystem.Core.Entities;
using BankSystem.Data.Persistence;
using BankSystem.Service.ViewModel;

namespace BankSystem.Service.Repository;

public interface IFileTypeRepository:IBaseRepository<FileType, FileTypeVm, long>
{
}
public class FileTypeRepository(IMapper mapper, ApplicationDbContext context) : BaseRepository<FileType, FileTypeVm, long>(mapper, context), IFileTypeRepository
{
}
