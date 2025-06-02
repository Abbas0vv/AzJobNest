using AzJobNest.Database.DomainModels;
using AzJobNest.Helpers.Enums;
using AzJobNest.Services.Abstract;
using AzJobNest.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace AzJobNest.Services.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<AzJobNestUser> _userManager;
    private readonly SignInManager<AzJobNestUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IImageService _imageService;
    private readonly IFileService _fileService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private const string IMAGE_FOLDER_NAME = "Uploads/ProfilePictures";
    private const string RESUME_FOLDER_NAME = "Uploads/Resumes";

    public UserService(UserManager<AzJobNestUser> userManager, SignInManager<AzJobNestUser> signInManager, RoleManager<IdentityRole> roleManager, IWebHostEnvironment webHostEnvironment, IImageService imageService, IFileService fileService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _webHostEnvironment = webHostEnvironment;
        _imageService = imageService;
        _fileService = fileService;
    }

    public async Task<bool> Login(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user is not null)
        {
            var result = await _userManager.CheckPasswordAsync(user, model.Password);
            if (result)
            {
                await _signInManager.SignInAsync(user, model.RememberMe);
                return true;
            }
        }

        return false;
    }

    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<IdentityResult> Register(RegisterViewModel model)
    {
        var user = new AzJobNestUser()
        {
            UserName = model.UserName,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, model.SelectedRole.ToString());
        }

        return result;
    }

    public async Task<AzJobNestUser> GetCurrentUserAsync(ClaimsPrincipal user)
    {
        return await _userManager.GetUserAsync(user);
    }
    public async Task<IdentityResult> UpdateProfileAsync(ClaimsPrincipal userPrincipal, UpdateProfileViewModel model)
    {
        var user = await _userManager.GetUserAsync(userPrincipal);
        if (user is null)
            return IdentityResult.Failed(new IdentityError { Description = "User not found" });

        // Update basic info
        user.UserName = model.UserName;

        // Update profile info
        user.Name = model.Name;
        user.MiddleName = model.MiddleName;
        user.LastName = model.LastName;
        user.PhoneNumber = model.PhoneNumber;
        user.LinkedInUrl = model.LinkedInUrl;
        user.GitHubUrl = model.GitHubUrl;
        user.Gender = model.Gender;
        user.BirthDate = model.BirthDate;

        // Handle file uploads
        if (model.ProfilePictureFile is not null && model.ProfilePictureFile.Length > 0)
        {
            user.ProfilePicture = _imageService.CreateImage(model.ProfilePictureFile, _webHostEnvironment.WebRootPath, IMAGE_FOLDER_NAME);
        }

        if (model.CVFile is not null && model.CVFile.Length > 0)
        {
            user.CV = _fileService.CreateFile(model.CVFile, _webHostEnvironment.WebRootPath, RESUME_FOLDER_NAME);
        }

        return await _userManager.UpdateAsync(user);
    }


    public async Task CreateRole()
    {
        foreach (var item in Enum.GetValues(typeof(Role)))
        {
            await _roleManager.CreateAsync(new IdentityRole()
            {
                Name = item.ToString()
            });
        }
    }

}
