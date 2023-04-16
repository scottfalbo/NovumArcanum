
using Newtonsoft.Json;
///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

namespace Mechanisms.Models.StorageContracts
{
    internal class WizardInfernalContract
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "partitionKey")]
        public string PartitionKey { get; set; }

        [JsonProperty(PropertyName = "identityUserName")]
        public string IdentityUserName { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "intro")]
        public string Intro { get; set; }

        [JsonProperty(PropertyName = "displayOrder")]
        public int DisplayOrder { get; set; }

        [JsonProperty(PropertyName = "isDisplay")]
        public bool IsDisplay { get; set; }

        [JsonProperty(PropertyName = "roles")]
        public List<string> Roles { get; set; }

        [JsonProperty(PropertyName = "imageSource")]
        public ImageSource ImageSource { get; set; }

        [JsonProperty(PropertyName = "social")]
        public List<Social> Social { get; set; }

        [JsonProperty(PropertyName = "gallery")]
        public List<GalleryImage> Gallery { get; set; }
    }
}
