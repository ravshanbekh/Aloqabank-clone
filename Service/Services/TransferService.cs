using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Transfer;

using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class TransferService:ITransferService
{
    private readonly IMapper mapper;
    private readonly IRepository<Transfer> repository;

    public TransferService(IRepository<Transfer> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<TransferResultDto> AddAsync(TransferCreationDto dto)
    {
        Transfer existTransfer = await this.repository.GetAsync(x => x.TransferName.Equals(dto.TransferName));

        if (existTransfer is not null)
        {
            throw new AllReadyExistException($"This Transfer email {dto.TransferName} allready exist");
        }

        var mappedTransfer = mapper.Map<Transfer>(dto);
        await this.repository.CreateAsync(mappedTransfer);
        await this.repository.SaveAsync();

        var result = mapper.Map<TransferResultDto>(mappedTransfer);
        return result;
    }

    public async Task<TransferResultDto> ModifyAsync(TransferUpdateDto dto)
    {
        Transfer existTransfer = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existTransfer is null)
        {
            throw new NotFoundException($"This Transfer is not found with Id-{dto.Id}");
        }

        var mappedTransfer = mapper.Map<Transfer>(dto);
        this.repository.Update(mappedTransfer);
        await this.repository.SaveAsync();

        var result = mapper.Map<TransferResultDto>(mappedTransfer);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Transfer existTransfer = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existTransfer is null)
        {
            throw new NotFoundException($"This Transfer is not found with Id-{id}");
        }

        this.repository.Delete(existTransfer);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<TransferResultDto>> RetrieveAllAsync()
    {
        var Transfers = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<TransferResultDto>>(Transfers);
        return result;
    }

    public async Task<TransferResultDto> RetrieveByIdAsync(long id)
    {
        Transfer existTransfer = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existTransfer is null)
        {
            throw new NotFoundException($"This Transfer is not found with Id-{id}");
        }
        return mapper.Map<TransferResultDto>(existTransfer);
    }
}
