﻿using FootballLeagueApp.Authentication;
using FootballLeagueApp.Models;
using FootballLeagueApp.Services.TokenService;
using Microsoft.AspNetCore.Identity;

namespace FootballLeagueApp.Services.AuthenticationService;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    public async Task<AuthResult> RegisterAsync(string email, string userName, string password)
    {
        var result = await _userManager.CreateAsync(new ApplicationUser { Email = email, UserName = userName }, password);

        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, userName);
        }
        return new AuthResult(true, email, userName, "");
    }

    private static AuthResult FailedRegistration(IdentityResult result, string email, string userName)
    {
        var authResult = new AuthResult(false, email, userName, "");

        foreach (var error in result.Errors)
        {
            authResult.ErrorMessages.Add(error.Code, error.Description);
        }
        return authResult;
    }

    public async Task<AuthResult> LoginAsync(string email, string password)
    {
        var managedUser = await _userManager.FindByEmailAsync(email);

        if (managedUser == null)
        {
            return InvalidEmail(email);
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
        if (!isPasswordValid)
        {
            return InvalidPassword(email);
        }

        var accessToken = _tokenService.CreateToken(managedUser);

        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }

    private AuthResult InvalidPassword(string email)
    {
        var result = new AuthResult(false, email, "", "");
        result.ErrorMessages.Add("Bad credentials", "Invalid Email");
        return result;
    }

    private AuthResult InvalidEmail(string email)
    {
        var result = new AuthResult(false, email, "", "");
        result.ErrorMessages.Add("Bad credentials", "Invalid Email");
        return result;
    }
}
