using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.BankCard;
using Service.Interfaces;

namespace BankingSystem.Controllers;

public class BankCardsController:Controller
{
    private readonly IMapper mapper;
    private readonly IBankCardService bankCardService;
    public BankCardsController(IBankCardService bankCardService, IMapper mapper)
    {
        this.bankCardService = bankCardService;
        this.mapper = mapper;
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BankCardCreationDto dto)
    {
        var createdCard = await this.bankCardService.AddAsync(dto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(long id)
    {
        var card = await this.bankCardService.RetrieveByIdAsync(id);
        var mappedCard = this.mapper.Map<BankCard>(card);
        return View(mappedCard);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BankCard model)
    {
        var mappedCard = this.mapper.Map<BankCardUpdateDto>(model);
        var bankCard = await this.bankCardService.ModifyAsync(mappedCard);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Index()
    {
        var bankCards = (await this.bankCardService.RetrieveAllAsync()).OrderBy(t => t.Id);
        return View(bankCards);
    }

    public async Task<IActionResult> Detail(long id)
    {
        var bankCard = await this.bankCardService.RetrieveByIdAsync(id);
        return View(bankCard);
    }
}
