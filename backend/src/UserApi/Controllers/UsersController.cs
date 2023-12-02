using Microsoft.AspNetCore.Mvc;
using UserApi.Authorization;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Controllers;

[ApiController]
[Authorize(Role = RoleNames.Admin)]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieves a list of all users in the system.
    /// </summary>
    /// <remarks>
    /// This endpoint is responsible for fetching and returning a list of all registered users.
    /// It does not require any parameters and will return an array of user data.
    /// </remarks>
    /// <response code="200">User list retrieved successfully. Returns a list of user data.</response>
    /// <response code="204">No Content. No users are available to return.</response>
    /// <response code="401">Unauthorized. The requester does not have permission to access user data.</response>
    /// <response code="500">Internal Server Error. Could occur if there is an issue with the server or database.</response>
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <remarks>
    /// This endpoint is used to obtain the details of a specific user by their unique ID. 
    /// If a user with the given ID exists, their details are returned. Otherwise, a not found response is issued.
    /// </remarks>
    /// <param name="id">The unique identifier of the user to retrieve.</param>
    /// <response code="200">The user was found and their details are returned.</response>
    /// <response code="400">Bad request. The provided ID may be in an incorrect format.</response>
    /// <response code="404">Not found. A user with the specified ID does not exist.</response>
    /// <response code="500">Internal Server Error. Could occur if there is an issue with the server or database.</response>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(string id)
    {
        var user = await _userService.GetByIdAsync(id);
        return Ok(user);
    }

     /// <summary>
     /// Creates a new user with the given details.
     /// </summary>
     /// <remarks>
     /// This endpoint is responsible for registering a new user in the system. It accepts user details, 
     /// creates a new user record, and returns the newly created user data.
     /// </remarks>
     /// <param name="newUser">The user details required to create a new user account.</param>
     /// <response code="200">User created successfully. Returns the created user's data.</response>
     /// <response code="400">Bad request. The request body may be missing or with incorrect data.</response>
     /// <response code="409">Conflict. A user with similar details might already exist.</response>
     /// <response code="500">Internal Server Error. Could occur if there is an issue with the server or database.</response>
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest newUser)
    {
        var createdUser = await _userService.CreateUserAsync(newUser);
        return Ok(createdUser);
    }
}
