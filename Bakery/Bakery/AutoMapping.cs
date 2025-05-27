using AutoMapper;
using DTOs;
using Entities;


namespace Bakery
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Product, ProductDTO>().ForMember("CategoryName",opts=>opts.MapFrom(src=>src.Category.CategoryName)).ReverseMap();
            CreateMap<LoginUserDTO, User>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();
        }
    }
}
