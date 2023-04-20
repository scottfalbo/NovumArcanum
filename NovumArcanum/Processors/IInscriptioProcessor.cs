///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models;

namespace NovumArcanum.Processors
{
    public interface IInscriptioProcessor
    {
        Task<Wizard> ProcessCorporeal(SanctumCorporeal sanctumCorporeal);
    }
}