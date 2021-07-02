using AutoMapper;
using MessageService.Common.ExtraModels;
using MessageService.Resources.Api.Models;

namespace MessageService.Send.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SendModelDto, SendModel>()
                .ForMember(dest => dest.PhoneNumberFrom, opt => opt.MapFrom(src => src.PhoneNumberFrom))
                .ForMember(dest => dest.PhoneNumberTo, opt => opt.MapFrom(src => src.PhoneNumberTo))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.AccountSid, opt => opt.MapFrom(src => src.AccountSid))
                .ForMember(dest => dest.AuthToken, opt => opt.MapFrom(src => src.AuthToken));
        }
    }
}
