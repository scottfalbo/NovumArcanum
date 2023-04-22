///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models;

namespace NovumArcanum.Repository
{
    public interface IWizardRepository
    {
        Task<bool> InscribeWizard(Wizard wizard);

        Task<Wizard> SummonWizard(string id);

        Task<bool> DestroyWizard(string id);

        Task<bool> ReCombobulateWizard(Wizard wizard);

        Task<IEnumerable<Wizard>> SummonAllWizards();
    }
}