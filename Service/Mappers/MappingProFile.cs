using Service.DTOs.User;
using AutoMapper;
using Domain.Entities;
using Service.DTOs.BankCard;
using Service.DTOs.Credit;
using Service.DTOs.Deposit;
using Service.DTOs.Transfer;

namespace Service.Mappers;

public class MappingProFile:Profile
{
    public MappingProFile()
    {
        //User
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();

        //BankCard
        CreateMap<BankCard, BankCardCreationDto>().ReverseMap();
        CreateMap<BankCardUpdateDto, BankCard>().ReverseMap();
        CreateMap<BankCardResultDto, BankCard>().ReverseMap();
       
        //Credit
        CreateMap<Credit, CreditCreationDto>().ReverseMap();
        CreateMap<CreditUpdateDto, Credit>().ReverseMap();
        CreateMap<CreditResultDto, Credit>().ReverseMap();
        
        //Deposit
        CreateMap<Deposit, DepositCreationDto>().ReverseMap();
        CreateMap<DepositUpdateDto, Deposit>().ReverseMap();
        CreateMap<DepositResultDto, Deposit>().ReverseMap();

        //Transfer
        CreateMap<Transfer, TransferCreationDto>().ReverseMap();
        CreateMap<TransferUpdateDto, Transfer>().ReverseMap();
        CreateMap<TransferResultDto, Transfer>().ReverseMap();
    }
}
