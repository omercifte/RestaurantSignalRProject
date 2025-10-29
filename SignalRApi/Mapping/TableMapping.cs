using AutoMapper;
using SignalRDtoLayer.TableDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class TableMapping:Profile
    {
        public TableMapping()
        {
            CreateMap<Table, ResultTableDto>().ReverseMap();
            CreateMap<Table, CreateTableDto>().ReverseMap();
            CreateMap<Table, UpdateTableDto>().ReverseMap(); 
        }
    }
}
