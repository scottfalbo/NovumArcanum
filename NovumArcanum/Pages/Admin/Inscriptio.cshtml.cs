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
    public class InscriptioModel : PageModel
    {
        private readonly IScribeSentinal _scribeSentinal;

        public InscriptioModel(IScribeSentinal scribeSentinal)
        {
            _scribeSentinal = scribeSentinal;
        }

        public void OnGet()
        {
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

            // TODO: create user in cosmos

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
