using AutoMapper;
using todo_clean.domain.entities;
using todo_clean.domain.value_objects;
using todo_clean.infra.models;

namespace todo_clean.infra.profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, CustomerEntity>()
            .ForMember(v => v.document, map => map.MapFrom(src => new DocumentVo(src.documentNumber)))
            .ForMember(v => v.email, map => map.MapFrom(src => new EmailVo(src.emailAddress)));

            CreateMap<CustomerEntity, CustomerModel>()
            .ForMember(v => v.documentNumber, map => map.MapFrom(src => src.document.number))
            .ForMember(v => v.emailAddress, map => map.MapFrom(src => src.email.address));
        }
    }
}