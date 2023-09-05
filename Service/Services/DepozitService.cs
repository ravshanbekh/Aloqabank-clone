using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Deposit;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class DepozitService:IDepositService
{
    private readonly IMapper mapper;
    private readonly IRepository<Deposit> repository;

    public DepozitService(IRepository<Deposit> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<DepositResultDto> AddAsync(DepositCreationDto dto)
    {
        Deposit existDeposit = await this.repository.GetAsync(x => x.DepositName.Equals(dto.DepositName));

        if (existDeposit is not null)
        {
            throw new AllReadyExistException($"This Deposit email {dto.DepositName} allready exist");
        }

        var mappedDeposit = mapper.Map<Deposit>(dto);
        await this.repository.CreateAsync(mappedDeposit);
        await this.repository.SaveAsync();

        var result = mapper.Map<DepositResultDto>(mappedDeposit);
        return result;
    }

    public async Task<DepositResultDto> ModifyAsync(DepositUpdateDto dto)
    {
        Deposit existDeposit = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existDeposit is null)
        {
            throw new NotFoundException($"This Deposit is not found with Id-{dto.Id}");
        }

        var mappedDeposit = mapper.Map<Deposit>(dto);
        this.repository.Update(mappedDeposit);
        await this.repository.SaveAsync();

        var result = mapper.Map<DepositResultDto>(mappedDeposit);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Deposit existDeposit = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existDeposit is null)
        {
            throw new NotFoundException($"This Deposit is not found with Id-{id}");
        }

        this.repository.Delete(existDeposit);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<DepositResultDto>> RetrieveAllAsync()
    {
        var Deposits = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<DepositResultDto>>(Deposits);
        return result;
    }

    public async Task<DepositResultDto> RetrieveByIdAsync(long id)
    {
        Deposit existDeposit = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existDeposit is null)
        {
            throw new NotFoundException($"This Deposit is not found with Id-{id}");
        }
        return mapper.Map<DepositResultDto>(existDeposit);
    }
}
