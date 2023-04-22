///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NovumArcanum.Models;
using NovumArcanum.Models.Constants;
using NovumArcanum.Models.Pages;
using NovumArcanum.Processors;

namespace NovumArcanum.Pages
{
    public class WizardModel : PageModel
    {
        private readonly UserManager<SanctumTrustee> _userManager;
        private readonly IWizardProcessor _wizardProcessor;

        private bool HasSanctumPermission =>
            User.IsInRole(WizardRole.MagusAdeptus) ||
            User.IsInRole(WizardRole.MagusMagister) ||
            User.IsInRole(WizardRole.MagusPrimus);

        public WizardPageContent WizardPageContent { get; set; }

        public WizardModel(UserManager<SanctumTrustee> userManager, IWizardProcessor wizardProcessor)
        {
            _userManager = userManager;
            _wizardProcessor = wizardProcessor;
        }

        public async Task OnGet(string wizardId)
        {
            var trustee = HasSanctumPermission ? await _userManager.FindByNameAsync(User.Identity.Name) : null;
            WizardPageContent = await _wizardProcessor.GetWizardPage(wizardId);
        }
    }
}