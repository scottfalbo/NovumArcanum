///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;

namespace Mechanisms.Processors
{
    public interface IInscriptioProcessor
    {
        Task<Wizard> ProcessCorporeal(SanctumCorporeal sanctumCorporeal);
    }
}
