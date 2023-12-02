using Microsoft.AspNetCore.Mvc;
using UserApi.Authorization;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private IUserService _userService;

    public ProfileController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieves the authenticated user's profile information.
    /// </summary>
    /// <remarks>
    /// Endpoint to fetch profile data of the currently authenticated user. 
    /// The method will return the user's profile information once implemented.
    /// </remarks>
    /// <response code="200">Profile retrieved successfully.</response>
    /// <response code="401">User is not authenticated.</response>
    /// <response code="404">Profile not found.</response>
    /// <response code="500">A server error occurred while processing the request.</response>
    [HttpGet]
    public Task<IActionResult> GetProfile()
    {
        throw new NotImplementedException();
    }

    // Add more actions here
}
