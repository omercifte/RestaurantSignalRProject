using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.NotificationDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _notificationService.TGetListAll();
            //return Ok(_notificationService.TGetListAll());
            return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
        }
        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }

        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }

        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            createNotificationDto.Status = false;
            var notification = _mapper.Map<Notification>(createNotificationDto);
            //Notification notification = new Notification()
            //{
            //    Description = createNotificationDto.Description,
            //    Status = false,
            //    Type = createNotificationDto.Type,
            //    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            //};
            _notificationService.TAdd(notification);
            return Ok("Ekleme İşlemi Başarıyla Yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Silme İşlemi Başarıyla Yapıldı");

        }

        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var notification = _mapper.Map<Notification>(updateNotificationDto);
            //Notification notification = new Notification()
            //{
            //    NotificationID = updateNotificationDto.NotificationID,
            //    Description = updateNotificationDto.Description,
            //    Status = updateNotificationDto.Status,
            //    Type = updateNotificationDto.Type,
            //    Date = updateNotificationDto.Date
            //};
            _notificationService.TUpdate(notification);
            return Ok("Güncelleme İşlemi Başarıyla Yapıldı");
        }
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }
    }
}
