using AutoMapper;
using Core.Entity;
using Core.Entity.Entities;
using Services.Abstractions;
using Services.Contracts.Users;
using Services.Repositories;

namespace Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    
    
    /// <summary>
    /// Получить произвольный ИД юзера
    /// </summary>
    /// <returns></returns>
    public async Task<int> GetRandomUserId()
    {
        return await _repository.GetRandomUserId();
    }

    /// <summary>
    /// Получить пользователя по его ID
    /// </summary>
    /// <param name="id">ID пользователя</param>
    /// <returns>Запись по пользователе</returns>
    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await _repository.GetAsync(id);
        return _mapper.Map<User, UserDto>(user);
    }

    /// <summary>
    /// Создать нового пользователя
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <param name="createUserDto">DTО пользователя</param>
    /// <returns></returns>
    public async Task<int> CreateNewUserAsync(int userId, CreateUserDto createUserDto)
    {
        // var mapUser = _mapper.Map<CreateUserDto, User>(createUserDto);
        var mapUser = new User();
        mapUser.Email = createUserDto.Email;
        mapUser.DateCreated = createUserDto.DateCreated;
        mapUser.UserType = createUserDto.UserType;
        mapUser.IsActiveUser = createUserDto.IsActiveUser;
        mapUser.Name = createUserDto.Name;
        mapUser.City = createUserDto.City;
        mapUser.Email = createUserDto.Email;
        mapUser.Id = createUserDto.Id;
        mapUser.PhoneNumber = createUserDto.PhoneNumber;
        mapUser.NotificationTypes = createUserDto.NotificationTypes;
        if (mapUser != null)
        {
            var user = await _repository.AddAsync(mapUser);
            await _repository.SaveChangesAsync();
            return user.Id;
        }
        else
        {
            throw new Exception($"Произошла ошибка при маппинге");
        }
    }

    /// <summary>
    /// Обновить информацию по пользователю
    /// </summary>
    /// <param name="userId">ID пользователя</param>
    /// <param name="updateUserDto">DTO на ообновление</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
    {
        var userUpd = await _repository.GetAsync(userId);
        if (userUpd is null)
            throw new Exception($"Нет пользователя по ID: {userId}");

        userUpd.City = updateUserDto.City;
        userUpd.IsActiveUser = updateUserDto.IsActiveUser;
        userUpd.UserType = updateUserDto.UserType;
        // userUpd.NotificationTypes = updateUserDto.NotificationTypes;
        userUpd.Name = updateUserDto.Name;
        userUpd.SecondName = updateUserDto.SecondName;
        userUpd.Email = updateUserDto.Email;
        userUpd.PhoneNumber = updateUserDto.PhoneNumber;
        
        _repository.Update(userUpd);
        await _repository.SaveChangesAsync();
    }

    /// <summary>
    /// Удалить пользователя
    /// </summary>
    /// <param name="userId">Ид пользователя</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task DeleteUser(int userId)
    {
        var user = await _repository.GetAsync(userId);
        user.IsActiveUser = false;
        await _repository.SaveChangesAsync();
    }
}