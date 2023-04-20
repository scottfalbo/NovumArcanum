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

        public Task DestroyWizard(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InscribeWizard(Wizard wizard)
        {
            var wizardInfernalContract = _mapper.Map<WizardInfernalContract>(wizard);
            var result = await _container.CreateItemAsync(wizardInfernalContract);
            return result.StatusCode == HttpStatusCode.OK;
        }

        public Task RebirthWizard(Wizard wizard)
        {
            throw new NotImplementedException();
        }

        public Task SummonWizard(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Wizard>> SummonAllWizards()
        {
            throw new NotImplementedException();
        }
    }
}