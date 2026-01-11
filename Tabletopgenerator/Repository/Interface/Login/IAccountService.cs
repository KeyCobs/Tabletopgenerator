using Microsoft.AspNetCore.Identity;
using Tabletopgenerator.Models.ViewModel.Login;

namespace Tabletopgenerator.Repository.Interface.Login
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterViewModel model);
        Task<IdentityResult> ConfirmEmailAsync(Guid userId, string token);
        Task<SignInResult> LoginUserAsync(LoginViewModel model);
        Task LogOutUserAsync();
        Task SendEmailConfimationAsync(string email);
        Task<ProfileViewModel> GetUserProfileByEmailAsync(string email);
    }
}
