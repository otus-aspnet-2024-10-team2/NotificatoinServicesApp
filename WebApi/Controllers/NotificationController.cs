using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;
    //private readonly IMapper _mapper;

    public NotificationController(INotificationService notificationService/*, IMapper mapper*/)
    {
        _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
      //  _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    
    /// <summary>
    /// Полуть ИД
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> CreateIdNotification()
    {
        var a = await _notificationService.GetDefaultIdAsync();
        return Ok(a);
    }
}