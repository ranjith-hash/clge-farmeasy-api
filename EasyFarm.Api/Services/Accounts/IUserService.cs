using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Views;

namespace EasyFarm.Api.Services.Accounts;

public interface IUserService
{
   Task<ResponseWrapper<UserAccounts>> SignUp(SignUpVw signUpVw);
   Task<ResponseWrapper<SignInResponseVw>> SignIn(SignInVw signInVw);
    
}