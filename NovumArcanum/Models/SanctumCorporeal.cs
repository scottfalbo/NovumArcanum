///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

namespace NovumArcanum.Models
{
    public class SanctumCorporeal
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
        public bool IsRegistered { get; set; }
        public List<string> RegistrationErrors { get; set; }

        public SanctumCorporeal()
        {
            RegistrationErrors = new();
        }
    }
}