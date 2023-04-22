
using NovumArcanum.Models.Pages;
using NovumArcanum.Repository;
///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------
namespace NovumArcanum.Processors
{
    public class WizardProcessor : IWizardProcessor
    {
        private readonly IWizardRepository _wizardRepository;

        public WizardProcessor(IWizardRepository wizardRepository)
        {
            _wizardRepository = wizardRepository;
        }

        public Task<WizardPageContent> GetWizardPage(string id)
        {
            throw new NotImplementedException();
        }
    }
}
