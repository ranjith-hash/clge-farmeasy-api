using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Services.Accounts;
using EasyFarm.Api.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFarm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("signup")]
        public async Task<ResponseWrapper<UserAccounts>> SignUp(SignUpVw signUpVw)
        {
            var signUpData = await _userService.SignUp(signUpVw);
            return new ResponseWrapper<UserAccounts>(signUpData.StatusCode, signUpData.Message, signUpData.Sucess,
                signUpData.ApiData);
        }
        
        [HttpPost("signin")]
        public async Task<ResponseWrapper<SignInResponseVw>> SignIn(SignInVw signInVw)
        {
            var signInData = await _userService.SignIn(signInVw);
            return new ResponseWrapper<SignInResponseVw>(signInData.StatusCode, signInData.Message, signInData.Sucess,
                signInData.ApiData);
        }
    }
}
