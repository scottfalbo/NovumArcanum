///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models;
using NovumArcanum.Processors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NovumArcanum.Aegis.Sentinals;
using System.Text.RegularExpressions;

namespace NovumArcanum.Pages.Admin
{
    public class InscriptioModel : PageModel
    {
        private readonly IInscriptioProcessor _inscriptioProcessor;
        private readonly IScribeSentinal _scribeSentinal;

        public InscriptioModel(IScribeSentinal scribeSentinal, IInscriptioProcessor inscriptioProcessor)
        {
            _inscriptioProcessor = inscriptioProcessor;
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

            if (user.IsRegistered)
            {
                await _inscriptioProcessor.ProcessCorporeal(user);
                return Redirect($"/Admin/Ingressus");
            }
            else
            {
                return Redirect($"/Admin/Inscriptio");
            }
        }
    }
}