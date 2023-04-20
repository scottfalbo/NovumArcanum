///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;

namespace NovumArcanum.Aegis.Sentinals
{
    public interface IGaurdianSentinal
    {
        Task<SanctumCorporeal> Authenticate(string userName, string password);
    }
}