using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Services; 
using Voedselbank.Domain.Models;
using Voedselbank.BusinessLogic.Services;
using Voedselbank.Domain.Inheritance;

namespace Presentation.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        var users = _userService.GetAllUsers();
        return View(users);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _userService.AddUser(user);
        return RedirectToAction("Index");
    }
}