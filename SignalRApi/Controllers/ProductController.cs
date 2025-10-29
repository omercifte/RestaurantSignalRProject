using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalRBusinessLayer.Abstract;
using SignalRDataAccessLayer.Concrete;
using SignalRDtoLayer.BookingDto;
using SignalRDtoLayer.CategoryDto;
using SignalRDtoLayer.ProductDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);

        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }
        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }


        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                Price = y.Price,
                ImageUrl = y.ImageUrl,
                Description = y.Description,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());

        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            //_productService.TAdd(new Product()
            //{
            //    ProductName = createProductDto.ProductName,
            //    Description = createProductDto.Description,
            //    Price = createProductDto.Price,
            //    ImageUrl = createProductDto.ImageUrl,
            //    ProductStatus = createProductDto.ProductStatus,
            //    CategoryID = createProductDto.CategoryID

            //});
            return Ok("Ürün bilgisi eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün bilgisi silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            //return Ok(value);
            return Ok(_mapper.Map<GetProductDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            //_productService.TUpdate(new Product()
            //{
            //    ProductID = updateProductDto.ProductID,
            //    ProductName = updateProductDto.ProductName,
            //    Description = updateProductDto.Description,
            //    Price = updateProductDto.Price,
            //    ImageUrl = updateProductDto.ImageUrl,
            //    ProductStatus = updateProductDto.ProductStatus,
            //    CategoryID = updateProductDto.CategoryID

            //});
            return Ok("Ürün bilgisi güncellendi");
        }

        [HttpGet("GetLast9Products")]
        public IActionResult GetLast9Products()
        {
            var values = _productService.TGetLast9Products();
            return Ok(values);
        }
    }
}
