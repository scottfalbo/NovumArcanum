///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;
using Mechanisms.Models.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NovumArcanum.Aegis.Sentinals
{
    public class ScribeSentinal : IScribeSentinal
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ScribeSentinal(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<SanctumCorporeal> Register(SanctumInitiate sanctumInitiate, ModelStateDictionary modelState)
        {
            var user = new IdentityUser()
            {
                UserName = sanctumInitiate.UserName,
                Email = sanctumInitiate.Email,
            };

            var sanctumCorporeal = new SanctumCorporeal();

            var result = await _userManager.CreateAsync(user, sanctumInitiate.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { WizardRole.MagusAdeptus });

                sanctumCorporeal.Id = user.Id;
                sanctumCorporeal.UserName = user.UserName;
                sanctumCorporeal.Email = user.Email;
                sanctumCorporeal.Roles = new List<string>() { WizardRole.MagusAdeptus };
                sanctumCorporeal.IsRegistered = true;

                return sanctumCorporeal;
            }

            sanctumCorporeal.IsRegistered = false;

            foreach (var error in result.Errors)
            {
                sanctumCorporeal.RegistrationErrors.Add(error.Description);
            }

            return sanctumCorporeal;
        }

        public async Task<IdentityResult> UpdatePassword(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<IdentityResult> UpdateUserEmail(string userId, string newEmail)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.SetEmailAsync(user, newEmail);
        }

        public async Task<IdentityResult> UpdateUserName(string userId, string newName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.UserName = newName;
            return await _userManager.UpdateAsync(user);
        }
    }
}