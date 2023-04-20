///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Microsoft.Azure.Cosmos;

namespace MechanistTower.Clients
{
    public class CosmosTomeScryer : ICosmosTomeScryer
    {
        private readonly CosmosClient _cosmosClient;

        public CosmosClient Scryer() => _cosmosClient;

        public CosmosTomeScryer(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }
    }
}
