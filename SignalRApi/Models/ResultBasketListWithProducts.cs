using SignalREntityLayer.Entities;

namespace SignalRApi.Models
{
    public class ResultBasketListWithProducts
    {
        public int BasketID { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int TableID { get; set; }
        public string ProductName { get; set; }

    }
}
