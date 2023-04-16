///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NovumArcanum.Aegis.Sentinals;
using System.Text.RegularExpressions;

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

        public async Task<IActionResult> OnPostRegister(string username, string password, string email)
        {
            username = Regex.Replace(username, " ", "");

            var newUser = new SanctumInitiate()
            {
                UserName = username,
                Password = password,
                Email = email
            };

            var user = await _scribeSentinal.Register(newUser, ModelState);

            if (user.IsRegistered)
            {
                return Redirect("/Index");
            }
            else
            {
                return Redirect($"/Admin/Ingressus");
            }

        }
    }
}
