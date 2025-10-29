using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.MessageDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            //return Ok(values);
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.Status = false;
            createMessageDto.MessageSendDate = DateTime.Now;
            var message = _mapper.Map<Message>(createMessageDto);
            //Message message = new Message()
            //{
            //    NameSurname = createMessageDto.NameSurname,
            //    Mail = createMessageDto.Mail,
            //    Phone = createMessageDto.Phone,
            //    Subject = createMessageDto.Subject,
            //    MessageContent = createMessageDto.MessageContent,
            //    MessageSendDate = DateTime.Now,
            //    Status = false
            //};
            _messageService.TAdd(message);
            return Ok("Mesaj Başarılı Şekilde Gönderildi");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            _messageService.TDelete(values);
            return Ok("Mesaj Silindi");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            updateMessageDto.Status = false;
            updateMessageDto.MessageSendDate = DateTime.Now;
            var message = _mapper.Map<Message>(updateMessageDto);

            //Message message = new Message()
            //{
            //    NameSurname = updateMessageDto.NameSurname,
            //    Mail = updateMessageDto.Mail,
            //    Phone = updateMessageDto.Phone,
            //    Subject = updateMessageDto.Subject,
            //    MessageContent = updateMessageDto.MessageContent,
            //    MessageSendDate = updateMessageDto.MessageSendDate,
            //    MessageID = updateMessageDto.MessageID,
            //    Status = false
            //};

            _messageService.TUpdate(message);
            return Ok("Mesaj Bilgisi Güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            return Ok(values);
        }
    }
}
