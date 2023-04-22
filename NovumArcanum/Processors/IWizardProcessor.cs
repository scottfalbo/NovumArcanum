
using NovumArcanum.Models.Pages;
///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

namespace NovumArcanum.Processors
{
    public interface IWizardProcessor
    {
        Task<WizardPageContent> GetWizardPage(string id);
    }
}
