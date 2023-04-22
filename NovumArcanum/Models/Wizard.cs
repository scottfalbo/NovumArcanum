///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

namespace NovumArcanum.Models
{
    public class Wizard
    {
        public string Id { get; set; }
        public string IdentityUserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Intro { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsDisplay { get; set; }
        public ImageSource ImageSource { get; set; }
        public List<Social> Social { get; set; }
        public List<GalleryImage> Gallery { get; set; }

        public Wizard()
        { }

        public Wizard(string id, string userName, string email, IList<string> roles)
        {
            Id = id;
            IdentityUserName = userName;
            Email = email;

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            FirstName = "First Name";
            LastName = "Last Name";
            Intro = "add short intro";
            DisplayOrder = 0;
            IsDisplay = false;

            ImageSource = new();
            Gallery = new();
            Social = new();
        }
    }
}