using Service.DTOs.Credit;
using Service.DTOs.Deposit;

namespace Service.Interfaces;

public interface IDepositService
{
    Task<DepositResultDto> AddAsync(DepositCreationDto dto);
    Task<DepositResultDto> ModifyAsync(DepositUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<DepositResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<DepositResultDto>> RetrieveAllAsync();
}
