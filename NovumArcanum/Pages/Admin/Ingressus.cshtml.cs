///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NovumArcanum.Aegis.Sentinals;

namespace NovumArcanum.Pages.Admin
{
    public class IngressusModel : PageModel
    {
        private readonly IGaurdianSentinal _gaurdianSentinal;
        private readonly IScribeSentinal _scribeSentinal;

        public IngressusModel(IGaurdianSentinal gaurdianSentinal, IScribeSentinal scribeSentinal)
        {
            _gaurdianSentinal = gaurdianSentinal;
            _scribeSentinal = scribeSentinal;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            var user = await _gaurdianSentinal.Authenticate(username, password);
            if (user != null)
                return Redirect($"/Wizard");
            return Redirect("/Admin/Ingressus");
        }
    }
}
