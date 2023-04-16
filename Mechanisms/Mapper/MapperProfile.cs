///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using Mechanisms.Models;
using Mechanisms.Models.StorageContracts;

namespace Mechanisms.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            WizardStorageMapping();
        }

        public void WizardStorageMapping()
        {
            CreateMap<Wizard, WizardInfernalContract>();
            CreateMap<WizardInfernalContract, Wizard>();
        }
    }
}
