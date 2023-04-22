///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models.Pages;
using NovumArcanum.Repository;

namespace NovumArcanum.Processors
{
    public class WizardProcessor : IWizardProcessor
    {
        private readonly IWizardRepository _wizardRepository;

        public WizardProcessor(IWizardRepository wizardRepository)
        {
            _wizardRepository = wizardRepository;
        }

        public async Task<WizardPageContent> GetWizardPage(string id)
        {
            var wizard = await _wizardRepository.SummonWizard(id);

            var wizardPageContent = new WizardPageContent
            {
                Wizard = wizard
            };

            return wizardPageContent;
        }
    }
}
