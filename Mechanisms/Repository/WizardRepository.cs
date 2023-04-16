///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using Mechanisms.Models;
using Mechanisms.Models.Constants;
using MechanistTower.Clients;
using Microsoft.Azure.Cosmos;

namespace Mechanisms.Repository
{
    public class WizardRepository : IWizardRepository
    {
        private readonly Container _container;

        public WizardRepository(ICosmosTomeScryer cosmosTomeScryer)
        {
            var client = cosmosTomeScryer.Scryer();
            _container = client.GetContainer(Cosmos.Database.Arcanum, Cosmos.Container.Wizard);
        }

        public Task DestroyWizard(string id)
        {
            throw new NotImplementedException();
        }

        public Task InscribeWizard(Wizard wizard)
        {
            //var characterSheetStorageContract = _mapper.Map<CharacterSheetStorageContract>(characterSheet);
            //var result = await _container.CreateItemAsync(characterSheetStorageContract);
            //Console.Write(result);
            throw new NotImplementedException();
        }

        public Task RebirthWizard(Wizard wizard)
        {
            throw new NotImplementedException();
        }

        public Task SummonWizard(string id)
        {
            throw new NotImplementedException();
        }
    }
}
