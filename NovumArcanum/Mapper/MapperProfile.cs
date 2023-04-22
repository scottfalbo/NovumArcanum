///---------------------------------------
/// Novum Arcanum: Studio Arcanum Seattle
/// --------------------------------------

using AutoMapper;
using NovumArcanum.Models;
using NovumArcanum.Models.Pages;
using NovumArcanum.Models.StorageContracts;

namespace NovumArcanum.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            SecretLairMapping();
            WizardStorageMapping();
        }

        public void SecretLairMapping()
        {
            CreateMap<Wizard, WizardSecretLairDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName));
        }

        public void WizardStorageMapping()
        {
            CreateMap<Wizard, WizardInfernalContract>()
                .ForMember(dest => dest.PartitionKey, opt => opt.MapFrom(src => src.Id));

            CreateMap<WizardInfernalContract, Wizard>();
        }
    }
}