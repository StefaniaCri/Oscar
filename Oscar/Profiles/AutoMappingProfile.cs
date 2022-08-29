using AutoMapper;
using Oscar.Models.DTO;
using Oscar.Models.Entities;

namespace Oscar.Profiles
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile(){
            CreateMap<Customer, CreateClient>().ReverseMap();
            CreateMap<Order, AddOrder>().ReverseMap();
            CreateMap<Adress, AdressDTO>();
            CreateMap<Customer, CustomerDTO>().ForMember(dest => dest.Name, obt => obt.MapFrom(src=>src.FirstName+" "+src.LastName))
                .ForMember(dest=> dest.Adress, obt => obt.MapFrom(src=>src.Adress));
            
            CreateMap<Order, OrderDTO>().ForMember(dest => dest.CustomerDto, opt =>
            {
                opt.PreCondition(src => src.Customer != null);
                opt.MapFrom(src => src.Customer);
            });
            CreateMap<Product, ProductDTO>().ForMember(d => d.Price, opt => opt.ConvertUsing(new CurrencyFormatter()));
            CreateMap<Product, CreateProductDTO>().ReverseMap();
        }

    }
}
