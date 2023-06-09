﻿///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models;
using Microsoft.AspNetCore.Identity;

namespace NovumArcanum.Aegis.Sentinals
{
    public class GaurdianSentinal : IGaurdianSentinal
    {
        private readonly UserManager<SanctumTrustee> _userManager;
        private readonly SignInManager<SanctumTrustee> _signInManager;

        public GaurdianSentinal(UserManager<SanctumTrustee> userManager, SignInManager<SanctumTrustee> signin)
        {
            _userManager = userManager;
            _signInManager = signin;
        }

        /// <summary>
        /// Logs user in.
        /// </summary>
        public async Task<SanctumCorporeal> Authenticate(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userName);

                return new SanctumCorporeal
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user),
                    IsRegistered = true
                };
            }
            return null;
        }
    }
}