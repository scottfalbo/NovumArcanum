///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models.Pages;

namespace NovumArcanum.Processors
{
    public interface IWizardProcessor
    {
        Task<WizardPageContent> GetWizardPage(string id);
    }
}
