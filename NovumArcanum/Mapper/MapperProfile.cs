///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using NovumArcanum.Models;
using NovumArcanum.Models.StorageContracts;

namespace NovumArcanum.Mapper
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