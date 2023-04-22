///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using NovumArcanum.Aegis.Sentinals;
using NovumArcanum.Models.Constants;
using NovumArcanum.Models.Pages;
using NovumArcanum.Repository;

namespace NovumArcanum.Processors
{
    public class SecretLairProcessor : ISecretLairProcessor
    {
        private readonly IMapper _mapper;
        private readonly IScribeSentinal _scribeSentinal;
        private readonly IWizardRepository _wizardRepository;

        public SecretLairProcessor(IMapper mapper, IScribeSentinal scribeSentinal, IWizardRepository wizardRepository)
        {
            _mapper = mapper;
            _scribeSentinal = scribeSentinal;
            _wizardRepository = wizardRepository;
        }

        public async Task<SecretLairPageContent> GetSeceretLair()
        {
            var wizards = await _wizardRepository.SummonAllWizards();
            var wizardRoles = WizardRole.GetRoles();

            var secretLairPageContent = new SecretLairPageContent()
            {
                Wizards = new List<WizardSecretLairDTO>(),
                WizardRoles = wizardRoles,
            };

            foreach (var wizard in wizards)
            {
                var wizardDTO = _mapper.Map<WizardSecretLairDTO>(wizard);
                secretLairPageContent.Wizards.Add(wizardDTO);
            }

            return secretLairPageContent;
        }
    }
}