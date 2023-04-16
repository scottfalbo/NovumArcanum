///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;

namespace Mechanisms.Repository
{
    public interface IWizardRepository
    {
        Task InscribeWizard(Wizard wizard);
        Task SummonWizard(string id);
        Task DestroyWizard(string id);
        Task RebirthWizard(Wizard wizard);
    }
}
