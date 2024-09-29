using _1st_Project_Api.Dtos.Account;
using _1st_Project_Api.Interfaces;
using _1st_Project_Api.Models;
using Azure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

namespace _1st_Project_Api.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController :ControllerBase
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly ITokenService _tokenService;
        public readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;   
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("login")]

        public async Task<IActionResult> login(LoginDto loginDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if(user == null)
                return Unauthorized("Invalid username!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(!result.Succeeded)
                return Unauthorized("Username not found and/or password is incorrect");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)


                }
                );


        }





        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser()
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok(/* $"User {appUser.UserName} was created successfully!"*/
                            new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}
