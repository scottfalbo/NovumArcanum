///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models;
using NovumArcanum.Repository;

namespace NovumArcanum.Processors
{
    public class InscriptioProcessor : IInscriptioProcessor
    {
        private readonly IWizardRepository _inscriptioRepository;

        public InscriptioProcessor(IWizardRepository inscriptioRepository)
        {
            _inscriptioRepository = inscriptioRepository;
        }

        public async Task<Wizard> ProcessCorporeal(SanctumCorporeal sanctumCorporeal)
        {
            var wizard = new Wizard(sanctumCorporeal.Id, sanctumCorporeal.UserName, sanctumCorporeal.Email, sanctumCorporeal.Roles);
            var result = await _inscriptioRepository.InscribeWizard(wizard);

            return wizard;
        }
    }
}