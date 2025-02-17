namespace BankSystem.Service.Extensions.Dropdown;

public interface IDropdown<T>
{
    public IList<T> Data { get; set; }
}
