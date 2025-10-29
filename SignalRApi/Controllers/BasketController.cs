using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRApi.Models;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.BasketDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet]
        public IActionResult GetBasketByTableID(int id)
        {
            var values = _basketService.TGetBasketByTableNumber(id);
            return Ok(values);
        }

        [HttpGet("BasketListByTableWithProductName")]
        public IActionResult BasketListByTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values=context.Baskets.Include(x=>x.Product).Where(y => y.TableID == id).Select(z=>new ResultBasketListWithProducts
            {
                BasketID = z.BasketID,
                Price = z.Price,
                Count = z.Count,
                TotalPrice = z.TotalPrice,
                ProductID = z.ProductID,
                TableID = z.TableID,
                ProductName = z.Product.ProductName

            }).ToList();
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductID=createBasketDto.ProductID,
                TableID = createBasketDto.TableID,
                Count = 1,
                Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
                TotalPrice=createBasketDto.TotalPrice,
            });
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {

            var values = _basketService.TGetByID(id);
            _basketService.TDelete(values);
            return Ok("Sepetteki Ürün Silindi");
        }
    }
}
