///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

namespace NovumArcanum.Models
{
    public class GalleryImage
    {
        public string Creator { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AltText { get; set; }
        public ImageSource ImageSource { get; set; }
        public bool IsDisplay { get; set; }
    }
}