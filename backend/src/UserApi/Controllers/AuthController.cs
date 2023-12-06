using Microsoft.AspNetCore.Mvc;
using UserApi.Authorization;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Authenticates a user based on provided credentials.
    /// </summary>
    /// <remarks>
    /// This endpoint processes the authentication request. If credentials are valid, it returns an authentication token; 
    /// otherwise, it responds with an error message.
    /// </remarks>
    /// <param name="model">The authentication request containing the user's credentials.</param>
    /// <response code="200">Authentication successful. Returns the auth token.</response>
    /// <response code="400">Bad request. The request body may be missing or with incorrect data.</response>
    /// <response code="500">Internal Server Error. Could occur if there is an issue while processing the authentication.</response>
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }
}
