///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using NovumArcanum.Models.Pages;

namespace NovumArcanum.Processors
{
    public interface ISecretLairProcessor
    {
        Task<SecretLairPageContent> GetSeceretLair();
    }
}