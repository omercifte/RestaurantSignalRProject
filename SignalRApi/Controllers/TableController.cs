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

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
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
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTable(SignalRDtoLayer.TableDto.CreateTableDto createTableDto)

        {
            Table table = new Table()
            {
                Name = createTableDto.Name,
                TableStatus = false
            };

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
            Table table = new Table()
            {
                TableID = updateTableDto.TableID,
                Name = updateTableDto.Name,
                TableStatus = updateTableDto.TableStatus
            };
            _tableService.TUpdate(table);
            return Ok("Masa başarılı şekilde güncellendi");
        }


        [HttpGet("{id}")]
        public IActionResult GetTable(int id)
        {
            var values = _tableService.TGetByID(id);
            return Ok(values);
        }
    }
}
