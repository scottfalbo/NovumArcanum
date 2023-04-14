///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.Azure.Cosmos;

namespace MechanistTower.Clients
{
    public interface ICosmosTomeScryer
    {
        CosmosClient Scryer();
    }
}
