///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models.Pages;
using NovumArcanum.Repository;

namespace NovumArcanum.Processors
{
    public class SecretLairProcessor : ISecretLairProcessor
    {
        private readonly IWizardRepository _wizardRepository;

        public SecretLairProcessor(IWizardRepository wizardRepository)
        {
            _wizardRepository = wizardRepository;
        }

        public async Task<SecretLairPageContent> GetSeceretLair()
        {
            Task.CompletedTask.Wait();
            throw new NotImplementedException();
        }
    }
}