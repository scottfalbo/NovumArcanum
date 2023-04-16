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

        /// <summary>
        /// Register a new user
        /// </summary>
        public async Task<SanctumCorporeal> Register(SanctumInitiate sanctumInitiate, ModelStateDictionary modelState)
        {
            var user = new IdentityUser()
            {
                UserName = sanctumInitiate.UserName,
                Email = sanctumInitiate.Email,
            };

            var sanctumCorporeal = new SanctumCorporeal()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = WizardRole.DefaultRoles,
                IsRegistered = false
            };

            var result = await _userManager.CreateAsync(user, sanctumInitiate.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, WizardRole.DefaultRoles);
                sanctumCorporeal.IsRegistered = true;

                return sanctumCorporeal;
            }

            foreach (var error in result.Errors)
            {
                sanctumCorporeal.RegistrationErrors.Add(error.Description);
            }

            return sanctumCorporeal;
        }

        /// <summary>
        /// Update user password.
        /// </summary>
        public async Task<IdentityResult> UpdatePassword(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        /// <summary>
        /// Update user email.
        /// </summary>
        public async Task<IdentityResult> UpdateUserEmail(string userId, string newEmail)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.SetEmailAsync(user, newEmail);
        }

        /// <summary>
        /// Update user name.
        /// </summary>
        public async Task<IdentityResult> UpdateUserName(string userId, string newName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.UserName = newName;
            return await _userManager.UpdateAsync(user);
        }
    }
}