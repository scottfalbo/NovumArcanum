///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;
using Mechanisms.Repository;

namespace Mechanisms.Processors
{
    public class InscriptioProcessor : IInscriptioProcessor
    {
        private readonly IWizardRepository _inscriptioRepository;

        public InscriptioProcessor(IWizardRepository inscriptioRepository)
        {
            _inscriptioRepository = inscriptioRepository;
        }

        public Task<Wizard> ProcessCorporeal(SanctumCorporeal sanctumCorporeal)
        {
            throw new NotImplementedException();
        }
    }
}
