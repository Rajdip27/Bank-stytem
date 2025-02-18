using AutoMapper;
using BankSystem.Core.Entities;
using BankSystem.Data.Persistence;
using BankSystem.Service.ViewModel;

namespace BankSystem.Service.Repository;

public interface ICardInfoRepsitory: IBaseRepository<CardInfo, CardInfoVm, long>
{
}
public class CardInfoRepsitory(IMapper mapper, ApplicationDbContext context) : BaseRepository<CardInfo, CardInfoVm, long>(mapper, context), ICardInfoRepsitory
{

}
