using AutoMapper;
using SignalRDtoLayer.SocialMediaDto;
using SignalRDtoLayer.TestimonialDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();

        }
    }
}
