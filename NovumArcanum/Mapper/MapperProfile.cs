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
            CreateMap<Wizard, WizardInfernalContract>()
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Id));

            CreateMap<WizardInfernalContract, Wizard>();
        }
    }
}