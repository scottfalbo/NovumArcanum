///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;
using Microsoft.AspNetCore.Identity;

namespace NovumArcanum.Aegis.Sentinals
{
    public class GaurdianSentinal : IGaurdianSentinal
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public GaurdianSentinal(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signin)
        {
            _userManager = userManager;
            _signInManager = signin;
        }
        public async Task<SanctumCorporeal> Authenticate(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);

                var temp = await _userManager.GetRolesAsync(user);

                return new SanctumCorporeal
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user),
                };
            }
            return null;
        }
    }
}
