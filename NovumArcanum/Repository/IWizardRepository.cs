///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models;

namespace NovumArcanum.Repository
{
    public interface IWizardRepository
    {
        Task<bool> InscribeWizard(Wizard wizard);

        Task SummonWizard(string id);

        Task DestroyWizard(string id);

        Task ReCombobulateWizard(Wizard wizard);

        Task<List<Wizard>> SummonAllWizards();
    }
}