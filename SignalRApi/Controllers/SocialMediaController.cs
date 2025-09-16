using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.SocialMediaDto;
using SignalRDtoLayer.TestimonialDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialmediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialmediaService, IMapper mapper)
        {
            _socialmediaService = socialmediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialmediaService.TGetListAll());
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialmediaService.TAdd(new SocialMedia()
            {
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
                Icon = createSocialMediaDto.Icon

            });
            return Ok("Sosyal Medya bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialmediaService.TGetByID(id);
            _socialmediaService.TDelete(value);
            return Ok("Sosyal Medya bilgisi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialmediaService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _socialmediaService.TUpdate(new SocialMedia()
            {
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Title = updateSocialMediaDto.Title,
                Url = updateSocialMediaDto.Url,
                Icon = updateSocialMediaDto.Icon

            });
            return Ok("Sosyal Medya bilgisi güncellendi");
        }
    }
}
