///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NovumArcanum.Models.Pages;
using NovumArcanum.Processors;

namespace NovumArcanum.Pages.Admin
{
    public class SecretLairModel : PageModel
    {
        private readonly ISecretLairProcessor _secretLairProcessor;

        public SecretLairPageContent SecretLairPageContent { get; set; }

        public SecretLairModel(ISecretLairProcessor secretLairProcessor)
        {
            _secretLairProcessor = secretLairProcessor;
        }

        public async Task OnGet()
        {
            SecretLairPageContent = await _secretLairProcessor.GetSeceretLair();
            Console.WriteLine();
        }
        public async Task<IActionResult> OnPostToggleDisplay(bool display, string wizardId)
        {
            await _secretLairProcessor.ToggleWizardDisplay(display, wizardId);
            return Redirect("/Admin/SecretLair");
        }
    }
}