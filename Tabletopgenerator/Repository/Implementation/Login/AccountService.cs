using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Text;
using Tabletopgenerator.Models.Entity;
using Tabletopgenerator.Models.Entity.Login;
using Tabletopgenerator.Models.ViewModel.Login;
using Tabletopgenerator.Repository.Interface.Login;

namespace Tabletopgenerator.Repository.Implementation.Login
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;


        public AccountService
                             (
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IEmailService emailservice,
                                IConfiguration confuguration
                             )
        {
            _configuration = confuguration;
            _userManager = userManager;
            _emailService = emailservice;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> ConfirmEmailAsync(Guid userId, string token)
        {
            if (userId == Guid.Empty || string.IsNullOrEmpty(token))
                return IdentityResult.Failed(new IdentityError { Description = "Invalid token or User ID" });

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User Not Found" });

            var decodedBytes = WebEncoders.Base64UrlDecode(token);
            var decodedToken = Encoding.UTF8.GetString(decodedBytes);
            
            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
            {
                var baseUrl = _configuration["AppSettings:BaseUrl"] ?? throw new InvalidOperationException("BaseUrl is not configured");
                var loginLink = $"{baseUrl}/Account/Login";

                await _emailService.SendAccountCreatedEmailAsync(user.Email!, user.FirstName!, loginLink);
            }

            return result;
        }

        public async Task<ProfileViewModel> GetUserProfileByEmailAsync(string email)
        {
            if (!string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null of empty.", nameof(email));

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new ArgumentException("User not found.", nameof(email));
            }

            return new ProfileViewModel
            {
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                LastLoggedIn = user.LastLoggedIn,
                CreatedOn = user.CreatedOn,
                DateOfBirth = user.DateOfBirth,
                LastUpdatedOn = user.LastUpdated
            };
        }

        public async Task<SignInResult> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return SignInResult.Failed;

            if(!await _userManager.IsEmailConfirmedAsync(user))
                return SignInResult.NotAllowed;

            var result = await _signInManager.PasswordSignInAsync(user.UserName!, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                user.LastLoggedIn = DateTime.Now;
                await _userManager.UpdateAsync(user);
            }

            return result;
        }

        public async Task LogOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                IsActive = true,
                CreatedOn = DateTime.Now,
                LastLoggedIn = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return result;

            IdentityResult roleAssignResult = await _userManager.AddToRoleAsync(user, "UserFree");
            // Handle Error - optionally return this failure instead
            // or log the issue and continue
            if (!roleAssignResult.Succeeded) return roleAssignResult;

            var token = await GenerateEmailConfirmationTokenAsync(user);
            var baseUrl = _configuration["AppSettings:BaseUrl"] ?? throw new InvalidOperationException("BaseUrl is not configured.");
            var confirmationLink = $"{baseUrl}/Account/ConfirmEmail?userId={user.Id}&token={token}";

            await _emailService.SendRegistrationConfirmationEmailAsync(user.Email, user.FirstName, confirmationLink);

            return result;
        }

        public async Task SendEmailConfirmationAsync(string email)
        {
            Guard.AgainstNullOrWhiteSpace(email, nameof(email));

            var user = await _userManager.FindByEmailAsync(email);
            // Prevent user enumeration by not disclosing existence
            if (user == null) return;

            // Email already confirmed not action needed
            if (await _userManager.IsEmailConfirmedAsync(user)) return;

            var token = await GenerateEmailConfirmationTokenAsync(user);
            var baseUrl = _configuration["AppSettings:BaseUrl"] ?? throw new InvalidOperationException("BaseUrl is not configured.");
            var confimationLink = $"{baseUrl}/Account/ConfirmEmail?userId={user.Id}%token={token}";

            await _emailService.SendResendConfirmationEmailAsync(user.Email!, user.FirstName!, confimationLink);
        }

        private async Task<string> GenerateEmailConfirmationTokenAsync(ApplicationUser user)
        {
            Guard.AgainstNull(user, nameof(user));

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

            return encodedToken;
        }
    }
}
