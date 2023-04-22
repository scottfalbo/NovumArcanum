///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using NovumArcanum.Models;
using NovumArcanum.Models.Constants;
using NovumArcanum.Models.StorageContracts;
using NovumArcanum.Clients;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace NovumArcanum.Repository
{
    public class WizardRepository : IWizardRepository
    {
        private readonly Container _container;
        private readonly IMapper _mapper;

        public WizardRepository(ICosmosTomeScryer cosmosTomeScryer, IMapper mapper)
        {
            var client = cosmosTomeScryer.Scryer();
            _container = client.GetContainer(Cosmos.Database.Arcanum, Cosmos.Container.Wizard);

            _mapper = mapper;
        }

        public Task<bool> DestroyWizard(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InscribeWizard(Wizard wizard)
        {
            var wizardInfernalContract = _mapper.Map<WizardInfernalContract>(wizard);
            var result = await _container.CreateItemAsync(wizardInfernalContract);
            return result.StatusCode == HttpStatusCode.OK;
        }

        public async Task<bool> ReCombobulateWizard(Wizard wizard)
        {
            var wizardInfernalContract = _mapper.Map<WizardInfernalContract>(wizard);
            var result = await _container.UpsertItemAsync(wizardInfernalContract);
            return result.StatusCode == HttpStatusCode.OK;
        }

        public async Task<Wizard> SummonWizard(string id)
        {
            var wizard = new Wizard();
            var query = $"SELECT * FROM c WHERE c.partitionKey = \"{id}\"";
            var queryDefinition = new QueryDefinition(query);

            using var resultIterator = _container.GetItemQueryIterator<Wizard>(queryDefinition);

            while (resultIterator.HasMoreResults)
            {
                var feedResponse = await resultIterator.ReadNextAsync();

                foreach (var summon in feedResponse)
                {
                    wizard = summon;
                }
            }

            return wizard;
        }

        public async Task<IEnumerable<Wizard>> SummonAllWizards()
        {
            var wizards = new List<Wizard>();
            using var resultIterator = _container.GetItemQueryIterator<Wizard>();

            while (resultIterator.HasMoreResults)
            {
                var feedResponse = await resultIterator.ReadNextAsync();

                foreach (var wizard in feedResponse)
                {
                    wizards.Add(wizard);
                }
            }

            return wizards;
        }
    }
}