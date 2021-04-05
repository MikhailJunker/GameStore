using AutoMapper;
using GameStore.Client.DTO;
using GameStore.Client.Requests.Create;
using GameStore.Client.Requests.Update;
using GameStore.Domain.Models;

namespace GameStore.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<DataAccess.Entities.Game, Domain.Game>();
            CreateMap<DataAccess.Entities.Customer, Domain.Customer>();
            CreateMap<DataAccess.Entities.Order, Domain.Order>();

            CreateMap<Domain.Game, GameDTO>();
            CreateMap<Domain.Customer, CustomerDTO>()
                .ForMember(x => x.FullName, s => s.MapFrom(x => $"{x.FirstName} {x.LastName}"));
            CreateMap<Domain.Order, OrderDTO>();

            CreateMap<GameCreateDTO, GameUpdateModel>();
            CreateMap<GameUpdateDTO, GameUpdateModel>();
            CreateMap<GameUpdateModel, DataAccess.Entities.Game>();

            CreateMap<CustomerCreateDTO, CustomerUpdateModel>();
            CreateMap<CustomerUpdateDTO, CustomerUpdateModel>();
            CreateMap<CustomerUpdateModel, DataAccess.Entities.Customer>();

            CreateMap<OrderCreateDTO, OrderUpdateModel>();
            CreateMap<OrderUpdateDTO, OrderUpdateModel>();
            CreateMap<OrderUpdateModel, DataAccess.Entities.Order>();
        }
    }
}