using Microsoft.Azure.Cosmos;

namespace MechanistTower.Clients
{
    public interface ICosmosTomeScryer
    {
        CosmosClient Scryer();
    }
}
