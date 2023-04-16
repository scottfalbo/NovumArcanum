///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

namespace Mechanisms.Models.StorageContracts
{
    internal class WizardInfernalContract
    {
        public string Id { get; set; }
        public string PartitionKey { get; set; }
        public string IdentityUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Intro { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }
        public List<string> Roles { get; set; }
        public ImageSource ImageSource { get; set; }
        public List<Social> Social { get; set; }
        public List<GalleryImage> Gallery { get; set; }
    }
}
