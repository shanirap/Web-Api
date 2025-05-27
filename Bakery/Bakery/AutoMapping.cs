using AutoMapper;
using DTOs;
using Entities;

namespace Bakery
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDto>().ForMember("CategoryName",
                    opts => opts.MapFrom(src => src.Category.Products));
            CreateMap<Catgory, CategoryDto>();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<LoginUserDto, User>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();


        }

    }
}
