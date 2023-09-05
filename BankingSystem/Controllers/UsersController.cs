using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.User;
using Service.Interfaces;
using Service.Services;

namespace BankingSystem.Controllers;

public class UsersController: Controller
{
    private readonly IMapper mapper;
    private readonly IUserService userService;
    public UsersController(IUserService userService, IMapper mapper)
    {
        this.userService = userService;
        this.mapper = mapper;
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreationDto dto)
    {
        var createdUser = await this.userService.AddAsync(dto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(long id)
    {
        var user = await this.userService.RetrieveByIdAsync(id);
        var mappedUser = this.mapper.Map<User>(user);
        return View(mappedUser);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User model)
    {
        var mappedUser = this.mapper.Map<UserUpdateDto>(model);
        var user = await this.userService.ModifyAsync(mappedUser);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Index()
    {
        var users = (await this.userService.RetrieveAllAsync()).OrderBy(t => t.Id);
        return View(users);
    }

    public async Task<IActionResult> Detail(long id)
    {
        var user = await this.userService.RetrieveByIdAsync(id);
        return View(user);
    }
}
