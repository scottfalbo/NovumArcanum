///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models.Constants;
using MechanistTower.Clients;
using Microsoft.Azure.Cosmos;

namespace Mechanisms.Repository
{
    public class InscriptioRepository : IInscriptioRepository
    {
        private readonly Container _container;

        public InscriptioRepository(ICosmosTomeScryer cosmosTomeScryer)
        {
            var client = cosmosTomeScryer.Scryer();
            _container = client.GetContainer(Cosmos.Database.Arcanum, Cosmos.Container.Wizard);
        }


    }
}
