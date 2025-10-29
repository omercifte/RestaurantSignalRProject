using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.AboutDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            //return Ok(values);
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            var value = _mapper.Map<About>(createAboutDto); //automapper ile alttaki kısım yapılıyor.yeni entity eklendiğinde otomatik olarak ekleniyor

            //About about = new About
            //{
            //    ImageUrl = createAboutDto.ImageUrl,
            //    Title = createAboutDto.Title,
            //    Description = createAboutDto.Description
            //};

            _aboutService.TAdd(value);
            return Ok("Hakkında kısmı başarılı şekilde eklendi");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok("Hakkında kısmı başarılı şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var value = _mapper.Map<About>(updateAboutDto); 

            //About about = new About
            //{
            //    AboutID = updateAboutDto.AboutID,
            //    ImageUrl = updateAboutDto.ImageUrl,
            //    Title = updateAboutDto.Title,
            //    Description = updateAboutDto.Description
            //};

            _aboutService.TUpdate(value);
            return Ok("Hakkında kısmı başarılı şekilde güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            //return Ok(values);
            return Ok(_mapper.Map<GetAboutDto>(values));
        }

    }
}
