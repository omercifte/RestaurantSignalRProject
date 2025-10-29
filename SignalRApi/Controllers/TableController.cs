using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.TableDto;
using SignalREntityLayer.Entities;



namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;
        private readonly IMapper _mapper;

        public TableController(ITableService tableService, IMapper mapper)
        {
            _tableService = tableService;
            _mapper = mapper;
        }

        [HttpGet("TableCount")]
        public IActionResult TableCount()
        {

            return Ok(_tableService.TTableCount());
        }

        [HttpGet]
        public IActionResult TableList()
        {
            var values = _tableService.TGetListAll();
            //return Ok(values);
            return Ok(_mapper.Map<List<ResultTableDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateTable(SignalRDtoLayer.TableDto.CreateTableDto createTableDto)

        {
            createTableDto.TableStatus = false;
            var table = _mapper.Map<Table>(createTableDto);

            //Table table = new Table()
            //{
            //    Name = createTableDto.Name,
            //    TableStatus = false
            //};

            _tableService.TAdd(table);
            return Ok("Masa başarılı şekilde eklendi");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTable(int id)
        {
            var values = _tableService.TGetByID(id);
            _tableService.TDelete(values);
            return Ok("Masa başarılı şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateTable(UpdateTableDto updateTableDto)
        {
            var table = _mapper.Map<Table>(updateTableDto);

            //Table table = new Table()
            //{
            //    TableID = updateTableDto.TableID,
            //    Name = updateTableDto.Name,
            //    TableStatus = updateTableDto.TableStatus
            //};
            _tableService.TUpdate(table);
            return Ok("Masa başarılı şekilde güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetTable(int id)
        {
            var values = _tableService.TGetByID(id);
            return Ok(values); 
        }

        [HttpGet("ChangeTableStatusToTrue")]
        public IActionResult ChangeTableStatusToTrue(int id)
        {
            _tableService.TChangeTableStatusToTrue(id);
            return Ok("İşlem Başarılı");
        }

        [HttpGet("ChangeTableStatusToFalse")]
        public IActionResult ChangeTableStatusToFalse(int id)
        {
            _tableService.TChangeTableStatusToFalse(id);
            return Ok("İşlem Başarılı");
        }
    }
}
