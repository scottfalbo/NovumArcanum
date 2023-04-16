///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Mechanisms.Models
{
    public class SanctumInitiate
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public IList<string> Roles { get; set; }
    }
}
