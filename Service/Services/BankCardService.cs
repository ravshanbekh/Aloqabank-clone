

using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.BankCard;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class BankCardService:IBankCardService
{
    private readonly IMapper mapper;
    private readonly IRepository<BankCard> repository;

    public BankCardService(IRepository<BankCard> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<BankCardResultDto> AddAsync(BankCardCreationDto dto)
    {
        
        var mappedBankCard = mapper.Map<BankCard>(dto);
        await this.repository.CreateAsync(mappedBankCard);
        await this.repository.SaveAsync();

        var result = mapper.Map<BankCardResultDto>(mappedBankCard);
        return result;
    }

    public async Task<BankCardResultDto> ModifyAsync(BankCardUpdateDto dto)
    {
        BankCard existBankCard = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existBankCard is null)
        {
            throw new NotFoundException($"This BankCard is not found with Id-{dto.Id}");
        }

        var mappedBankCard = mapper.Map<BankCard>(dto);
        this.repository.Update(mappedBankCard);
        await this.repository.SaveAsync();

        var result = mapper.Map<BankCardResultDto>(mappedBankCard);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        BankCard existBankCard = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existBankCard is null)
        {
            throw new NotFoundException($"This BankCard is not found with Id-{id}");
        }

        this.repository.Delete(existBankCard);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<BankCardResultDto>> RetrieveAllAsync()
    {
        var BankCards = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<BankCardResultDto>>(BankCards);
        return result;
    }

    public async Task<BankCardResultDto> RetrieveByIdAsync(long id)
    {
        BankCard existBankCard = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existBankCard is null)
        {
            throw new NotFoundException($"This BankCard is not found with Id-{id}");
        }
        return mapper.Map<BankCardResultDto>(existBankCard);
    }
}
