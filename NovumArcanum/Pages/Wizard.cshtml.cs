///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.AspNetCore.Mvc.RazorPages;
using NovumArcanum.Models;

namespace NovumArcanum.Pages
{
    public class WizardModel : PageModel
    {
        public Wizard Wizard { get; set; }

        public void OnGet(string wizardId)
        {

        }
    }
}