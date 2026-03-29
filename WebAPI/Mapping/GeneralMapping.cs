using AutoMapper;
using WebAPI.DTOs.AboutDTO;
using WebAPI.DTOs.CategoryDTO;
using WebAPI.DTOs.ChefDTO;
using WebAPI.DTOs.EventSlideDTO;
using WebAPI.DTOs.FeatureDTO;
using WebAPI.DTOs.MessageDTO;
using WebAPI.DTOs.NotificationDTO;
using WebAPI.DTOs.ProductDTO;
using WebAPI.DTOs.ReservationDTO;
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
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();

            CreateMap<Message, GetByIdMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();
            CreateMap<Message, ResultMessageDTO>().ReverseMap();

            CreateMap<Product, ProductResultWithCategoryDTO>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
            CreateMap<Product, GetByIdProductDTO>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDTO>().ReverseMap();

            CreateMap<Service, ServiceResultDTO>().ReverseMap();
            CreateMap<Service, CreateServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateServiceDTO>().ReverseMap();
            CreateMap<Service, GetByIdServiceDTO>().ReverseMap();


            CreateMap<Testimonial, TestimonialResultDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();

            CreateMap<EventSlide, EventResultDTO>().ReverseMap();
            CreateMap<EventSlide, CreateEventDTO>().ReverseMap();

            CreateMap<Chef, ChefResultDTO>().ReverseMap();
            CreateMap<Chef, ChefCreateDTO>().ReverseMap();
            CreateMap<Chef, UpdateChefDTO>().ReverseMap();
            CreateMap<Chef, GetByIdChefDTO>().ReverseMap();

            CreateMap<Notification, NotificationResultDTO>().ReverseMap();
            CreateMap<Notification, CreateNotificationDTO>().ReverseMap();

            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();
            CreateMap<About, GetByIdAboutDTO>().ReverseMap();

            CreateMap<Reservation, ReservationResultDTO>().ReverseMap();
            CreateMap<Reservation, UpdateReservationDTO>().ReverseMap();
            CreateMap<Reservation, CreateReservationDTO>().ReverseMap();
            CreateMap<Reservation, GetByIdReservationDTO>().ReverseMap();

        }
    }
}
