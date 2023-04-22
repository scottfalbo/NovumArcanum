///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using NovumArcanum.Models;
using NovumArcanum.Models.Pages;

namespace NovumArcanum.Extensions
{
    public static class WizardExtensions
    {
        public static IEnumerable<WizardSecretLairDTO> ToWizardSecretLairDTO(this IEnumerable<Wizard> wizards, IMapper mapper)
        {
            var wizardSecretLairDTOs = new List<WizardSecretLairDTO>();

            foreach (var wizard in wizards)
            {
                var wizardDTO = mapper.Map<WizardSecretLairDTO>(wizard);
                wizardSecretLairDTOs.Add(wizardDTO);
            }

            return wizardSecretLairDTOs;
        }
    }
}
