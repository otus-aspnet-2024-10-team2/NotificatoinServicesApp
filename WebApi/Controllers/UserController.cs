using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.Users;
using WebApi.Models.User;

namespace WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService,
        IMapper mapper,
        ILogger<UserController> logger)
    {
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
    }

    // /// <summary>
    // /// Получить произвольный ИД пользователя
    // /// </summary>
    // /// <returns></returns>
    // [HttpGet(Name = "Get")]    
    // public async Task<IActionResult> GetRandomUserId()
    // {
    //     return Ok(await _userService.GetRandomUserId());
    // }
    
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
    /// <param name="createUserModel">Модель нового пользователя</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateNewUserAsync(CreateUserModel createUserModel)
    {
        try
        {
            _logger.LogInformation("Creating new user");
            var id = await _userService.GetRandomUserId();
            _logger.LogInformation($"User Id: {id}");
            createUserModel.Id = id;
            CreateUserDto d = new CreateUserDto();
            d.Id = id;
            d.City = createUserModel.City;
            d.PhoneNumber = createUserModel.PhoneNumber;
            d.Email = createUserModel.Email;
            d.DateCreated = createUserModel.DateCreated;
            d.Name = createUserModel.Name;
            d.UserType = createUserModel.UserType;
            
            //var user = _mapper.Map<CreateUserDto>(createUserModel);
            
            _logger.LogInformation("Начало процесса записи в БД");
            await _userService.CreateNewUserAsync(id, d);
            _logger.LogInformation("Created new user successfully");
            return Ok(d.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error creating new user. {ex.StackTrace}\n{ex.InnerException?.Message}");
            return BadRequest($"Возникла ошибка при попытке сохранить информацию о пользователе: {ex.Message}");
        }
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