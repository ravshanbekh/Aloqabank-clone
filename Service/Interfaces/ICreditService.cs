using Service.DTOs.BankCard;
using Service.DTOs.Credit;

namespace Service.Interfaces;

public interface ICreditService
{
    Task<CreditResultDto> AddAsync(CreditCreationDto dto);
    Task<CreditResultDto> ModifyAsync(CreditUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<CreditResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<CreditResultDto>> RetrieveAllAsync();
}
