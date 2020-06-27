using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IManageProductService _manageProductService;
        private readonly IPublicProductService _publicProductService;

        public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _manageProductService = manageProductService;
            _publicProductService = publicProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetMaganeProductPagingRequest request)
        {
            var list = await _manageProductService.GetAllPaging(request);
            return Ok(list);
        }   
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetByLanguageId(string languageId)
        {
            var list = await _publicProductService.GetAll(languageId);
            return Ok(list);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var list = await _publicProductService.GetAllByCategoryId(request);
            return Ok(list);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(int id,string languageId)
        {
            var pro = await _publicProductService.GetById(id,languageId);
            return Ok(pro);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product = await _publicProductService.GetById(productId,request.LanguageId);
            return CreatedAtAction(nameof(this.GetById), new { Id = productId }, product);
        }       
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] ProductUpdateRequest request)
        {
            var result = await _manageProductService.Update(request);
            if (result < 1)
            {
                return BadRequest();
            }
            return Ok();
        }        
        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var result = await _manageProductService.UpdatePrice(id,newPrice);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }        
        [HttpPut("stock/{id}/{newStock}")]
        public async Task<IActionResult> UpdateStock(int id, int newStock)
        {
            var result = await _manageProductService.UpdateStock(id,newStock);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var result = await _manageProductService.Delete(id);
            if (result < 1)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}