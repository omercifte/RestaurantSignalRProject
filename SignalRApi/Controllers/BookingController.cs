using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.BookingDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking=new Booking()
            {
                Mail=createBookingDto.Mail,
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                PersonCount = createBookingDto.PersonCount,
                Date = createBookingDto.Date,
                Description = createBookingDto.Description
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon başarılı şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok("Rezervasyon başarılı şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Mail = updateBookingDto.Mail,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount,
                Description = updateBookingDto.Description,
                Date = updateBookingDto.Date
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon başarılı şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon başarılı şekilde onaylandı");
        }
        [HttpGet("BookingStatusCancel/{id}")]
        public IActionResult BookingStatusCancel(int id)
        {
            _bookingService.TBookingStatusCancel(id);
            return Ok("Rezervasyon başarılı şekilde iptal edildi");
        }
    }
}
