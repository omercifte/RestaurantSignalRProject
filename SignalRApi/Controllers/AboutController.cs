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

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {
            About about = new About
            {
                ImageUrl = createAboutDto.ImageUrl,
                Title = createAboutDto.Title,
                Description = createAboutDto.Description
            };

            _aboutService.TAdd(about);
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
            About about = new About
            {
                AboutID = updateAboutDto.AboutID,
                ImageUrl = updateAboutDto.ImageUrl,
                Title = updateAboutDto.Title,
                Description = updateAboutDto.Description
            };

            _aboutService.TUpdate(about);
            return Ok("Hakkında kısmı başarılı şekilde güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }

    }
}
