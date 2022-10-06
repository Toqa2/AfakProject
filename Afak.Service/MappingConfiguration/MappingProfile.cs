using Afak.Service.Dto;
using AfakProject.Data.DatabaseModels;

namespace Afak.Service.MappingConfiguration
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserCertifications, opt => opt.MapFrom(src => src.CertificationList.Select(e=> new UserCertification
                {
                    CertificationId = e
                })));

            CreateMap<ApplicationUser, UserListDto>()
                .ForMember(dest => dest.CertificationCount, opt => opt.MapFrom(src => src.UserCertifications.Count));
        }
    }
}
