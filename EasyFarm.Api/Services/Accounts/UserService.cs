using EasyFarm.Api.Entities;
using EasyFarm.Api.Helpers;
using EasyFarm.Api.Views;
using Microsoft.EntityFrameworkCore;

namespace EasyFarm.Api.Services.Accounts;

public class UserService : IUserService
{
    private readonly AppDbContext _appDbContext;


    public UserService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<ResponseWrapper<UserAccounts>> SignUp(SignUpVw signUpVw)
    {
        try
        {
            UserAccounts userAccounts = new UserAccounts();
            var checkUserExist = await _appDbContext.TblUserAccounts.Where(a => a.Email == signUpVw.Email).FirstOrDefaultAsync();
            if (checkUserExist == null)
            {
                userAccounts.FirstName = signUpVw.FirstName;
                userAccounts.LastName = signUpVw.LastName;
                    
                userAccounts.Email = signUpVw.Email;
                userAccounts.Password = signUpVw.Password;
                userAccounts.UserId = new Guid();
                userAccounts.IsSeller = signUpVw.IsSeller;
                
                await _appDbContext.AddAsync(userAccounts);
                await _appDbContext.SaveChangesAsync();

                return new ResponseWrapper<UserAccounts>(200, "User Added", true, userAccounts);
            }
            else
            {
                return new ResponseWrapper<UserAccounts>(200, "User Already exists", false, checkUserExist);
            }
        }
        catch (Exception e)
        {
            return new ResponseWrapper<UserAccounts>(500, e.Message, false, null);

        }
    }

    public async Task<ResponseWrapper<SignInResponseVw>> SignIn(SignInVw signInVw)
    {
        try
        {
            var userData = await _appDbContext.TblUserAccounts
                .Where(a => a.Email == signInVw.Email && a.Password == signInVw.Password).FirstOrDefaultAsync();
            if (userData != null)
            {
                SignInResponseVw signInResponseVw = new SignInResponseVw();

                signInResponseVw.UserId = userData.UserId;
                signInResponseVw.FirstName = userData.FirstName;
                signInResponseVw.LastName = userData.LastName;
                signInResponseVw.Email = userData.Email;
                signInResponseVw.IsSeller = userData.IsSeller;

                return new ResponseWrapper<SignInResponseVw>(200, "Valid User", true, signInResponseVw);
            }
            else
            {
                return new ResponseWrapper<SignInResponseVw>(200, "Invalid Email or Password", false, null);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}