using AutoMapper;
using DTOs;
using Entities;

namespace Bakery
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

      //      CreateMap<Product, ProductDto>()
      //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CatgoryName));
            CreateMap<Product, ProductDto>().ForCtorParam("CategoryName", opt => opt.MapFrom(src => src.Category.CatgoryName));

            CreateMap<Catgory, CategoryDto>();
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<LoginUserDto, User>();
            CreateMap<RegisterUserDto, User>();
            CreateMap<OrderItemDto, OrderItem>().ReverseMap();


        }

    }
}
