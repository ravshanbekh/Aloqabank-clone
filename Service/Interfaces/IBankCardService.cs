using Service.DTOs.BankCard;
using Service.DTOs.User;

namespace Service.Interfaces;

public interface IBankCardService
{
    Task<BankCardResultDto> AddAsync(BankCardCreationDto dto);
    Task<BankCardResultDto> ModifyAsync(BankCardUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<BankCardResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<BankCardResultDto>> RetrieveAllAsync();
}
