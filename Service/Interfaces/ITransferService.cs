using Service.DTOs.Transfer;
using Service.DTOs.User;

namespace Service.Interfaces;

public interface ITransferService
{
    Task<TransferResultDto> AddAsync(TransferCreationDto dto);
    Task<TransferResultDto> ModifyAsync(TransferUpdateDto dto);
    Task<bool> RemoveAsync(long id);
    Task<TransferResultDto> RetrieveByIdAsync(long id);
    Task<IEnumerable<TransferResultDto>> RetrieveAllAsync();
}
