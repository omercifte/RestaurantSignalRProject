using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.TableDtos
{
    public class UpdateTableDto
    {
        public int TableID { get; set; }
        public string Name { get; set; }
        public bool TableStatus { get; set; }
    }
}
