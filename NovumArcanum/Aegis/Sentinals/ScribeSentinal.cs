///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NovumArcanum.Aegis.Sentinals
{
    public class ScribeSentinal : IScribeSentinal
    {
        public Task<SanctumCorporeal> Register(SanctumInitiate sanctumInitiate, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
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
