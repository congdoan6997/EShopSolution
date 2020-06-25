using eShopSolution.Application.catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManageProductService _manageProductService;
        public ProductController(IManageProductService manageProductService)
        {
            _manageProductService = manageProductService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _manageProductService.GetAllPaging(new ViewModels.Catalog.Products.GetMaganeProductPagingRequest()
            {
                PageIndex = 1,
                PageSize = 100,
                CategoryIds = new System.Collections.Generic.List<int>()
            }) ;
            return Ok(list);
        }
    }
}