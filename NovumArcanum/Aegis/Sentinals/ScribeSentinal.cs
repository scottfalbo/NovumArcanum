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

            var result = await _userManager.CreateAsync(user, sanctumInitiate.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { WizardRole.MagusAdeptus });

                return new SanctumCorporeal
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = new List<string>() { WizardRole.MagusAdeptus },
                    IsRegistered = true
                };
            }

            return null;
        }

        public Task<IdentityResult> UpdatePassword(string userId, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateUserEmail(string userId, string newEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateUserName(string userId, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
