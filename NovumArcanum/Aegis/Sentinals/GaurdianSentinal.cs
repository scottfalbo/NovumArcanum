///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;

namespace NovumArcanum.Aegis.Sentinals
{
    public class GaurdianSentinal : IGaurdianSentinal
    {
        public Task<SanctumAdeptus> Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
