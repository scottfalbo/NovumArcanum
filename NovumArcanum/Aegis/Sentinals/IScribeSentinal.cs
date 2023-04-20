///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NovumArcanum.Aegis.Sentinals
{
    public interface IScribeSentinal
    {
        Task<SanctumCorporeal> Register(SanctumInitiate sanctumInitiate, ModelStateDictionary modelState);

        Task<IdentityResult> UpdatePassword(string userId, string currentPassword, string newPassword);

        Task<IdentityResult> UpdateUserName(string userId, string newName);

        Task<IdentityResult> UpdateUserEmail(string userId, string newEmail);
    }
}