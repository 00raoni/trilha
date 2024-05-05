using AutoMapper;
using trilha_net.Domain.Arguments.ViewModels;
using trilha_net.Domain.Models;

namespace trilha_net.Application.AutoMapper;
public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Usuario, RequestUsuario>();
        CreateMap<RequestUsuario, Usuario>();
        
        CreateMap<Usuario, ResponseUsuario>();
        CreateMap<ResponseUsuario, Usuario>();
    }
}
