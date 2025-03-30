using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Users;
using WebApi.Models.User;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService,
        IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    /// <summary>
    /// Получить произвольный ИД пользователя
    /// </summary>
    /// <returns></returns>
    [HttpGet]    
    public async Task<IActionResult> GetRandomUserId()
    {
        return Ok(await _userService.GetRandomUserId());
    }
    
    /// <summary>
    /// Получить информацию по пользователю
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <returns>Модель позователя</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(_mapper.Map<UserModel>(user));
    }

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <param name="createUserModel">Модель новго пользователя</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateNewUserAsync(CreateUserModel createUserModel)
    {
        var id = await _userService.GetRandomUserId();
        var user = _mapper.Map<CreateUserDto>(createUserModel);
        await _userService.CreateNewUserAsync(id, user);
        return Ok(user.Id);
    }

    /// <summary>
    /// Обновить информаию по пользователю
    /// </summary>
    /// <param name="id">ИД пользователя</param>
    /// <param name="updateUserModel">Модель пользователя</param>
    /// <returns></returns>
    [HttpPost("{id}")]
    public async Task<IActionResult> UpdateUserAsync(int id, UpdateUserModel updateUserModel)
    {
        var user = _mapper.Map<UpdateUserModel, UpdateUserDto>(updateUserModel);
        await _userService.UpdateUserAsync(id, user);
        return Ok();
    }
    
    /// <summary>
    /// Удалить пользователя
    /// </summary>
    /// <param name="id">Ид пользователя</param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _userService.DeleteUser(id);
        return Ok();
    }
}