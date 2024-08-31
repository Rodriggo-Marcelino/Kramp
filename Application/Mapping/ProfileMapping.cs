using Application.ManagerCQ.Commands;
using Application.ManagerCQ.ViewModels;
using AutoMapper;
using Domain.Entity;

namespace Application.Mapping
{
    public class ProfileMappings : Profile
    {
        public ProfileMappings()
        {
            CreateMap<CreateManagerCommand, Manager>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TypeDocument, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<Manager, ManagerInfoViewModel>();
        }
    }
}
