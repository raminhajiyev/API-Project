using AutoMapper;
using WebAPI.DTOs.CategoryDTO;
using WebAPI.DTOs.ChefDTO;
using WebAPI.DTOs.EventSlideDTO;
using WebAPI.DTOs.FeatureDTO;
using WebAPI.DTOs.MessageDTO;
using WebAPI.DTOs.NotificationDTO;
using WebAPI.DTOs.ProductDTO;
using WebAPI.DTOs.ServiceDTO;
using WebAPI.DTOs.TestimonialDTO;
using WebAPI.Entities;

namespace WebAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {

            CreateMap<Category, CategoryResultDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();

            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();

            CreateMap<Message, GetByIdMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, ResultMessageDTO>().ReverseMap();

            CreateMap<Product, ProductResultWithCategoryDTO>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();

            CreateMap<Service, ServiceResultDTO>().ReverseMap();

            CreateMap<Testimonial, TestimonialResultDTO>().ReverseMap();

            CreateMap<EventSlide, EventResultDTO>().ReverseMap();
            CreateMap<EventSlide, CreateEventDTO>().ReverseMap();

            CreateMap<Chef, ChefResultDTO>().ReverseMap();
            CreateMap<Chef, ChefCreateDTO>().ReverseMap();

            CreateMap<Notification, NotificationResultDTO>().ReverseMap();
            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();

        }
    }
}
