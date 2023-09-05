using AutoMapper;
using DAL.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.Credit;
using Service.Exceptions;
using Service.Interfaces;

namespace Service.Services;

public class CreditService:ICreditService
{
    private readonly IMapper mapper;
    private readonly IRepository<Credit> repository;

    public CreditService(IRepository<Credit> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<CreditResultDto> AddAsync(CreditCreationDto dto)
    {
        Credit existCredit = await this.repository.GetAsync(x => x.CreditName.Equals(dto.CreditName));

        if (existCredit is not null)
        {
            throw new AllReadyExistException($"This Credit email {dto.CreditName} allready exist");
        }

        var mappedCredit = mapper.Map<Credit>(dto);
        await this.repository.CreateAsync(mappedCredit);
        await this.repository.SaveAsync();

        var result = mapper.Map<CreditResultDto>(mappedCredit);
        return result;
    }

    public async Task<CreditResultDto> ModifyAsync(CreditUpdateDto dto)
    {
        Credit existCredit = await this.repository.GetAsync(x => x.Id.Equals(dto.Id));

        if (existCredit is null)
        {
            throw new NotFoundException($"This Credit is not found with Id-{dto.Id}");
        }

        var mappedCredit = mapper.Map<Credit>(dto);
        this.repository.Update(mappedCredit);
        await this.repository.SaveAsync();

        var result = mapper.Map<CreditResultDto>(mappedCredit);
        return result;
    }

    public async Task<bool> RemoveAsync(long id)
    {
        Credit existCredit = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existCredit is null)
        {
            throw new NotFoundException($"This Credit is not found with Id-{id}");
        }

        this.repository.Delete(existCredit);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<CreditResultDto>> RetrieveAllAsync()
    {
        var Credits = await this.repository.GetAll().ToListAsync();
        var result = mapper.Map<IEnumerable<CreditResultDto>>(Credits);
        return result;
    }

    public async Task<CreditResultDto> RetrieveByIdAsync(long id)
    {
        Credit existCredit = await this.repository.GetAsync(x => x.Id.Equals(id));

        if (existCredit is null)
        {
            throw new NotFoundException($"This Credit is not found with Id-{id}");
        }
        return mapper.Map<CreditResultDto>(existCredit);
    }
}
