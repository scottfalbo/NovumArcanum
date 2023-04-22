///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

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

        public async void OnGet()
        {
            SecretLairPageContent = await _secretLairProcessor.GetSeceretLair();
        }
    }
}