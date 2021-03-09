using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using MangoWebApi.Redis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.WEBAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductControler : ControllerBase
    {
        private readonly IProductService _productService;
        
        private readonly IDistributedCache _cache;
        public ProductControler(IProductService productService,
             
              IDistributedCache cache)
        {
            _productService = productService;
            _cache = cache;
            
        }
        #region APIs
        [HttpPost]
        public  async Task<IActionResult> Create(Product product)
        {
            var result =await _productService.AddProduct(product);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            if (await _cache.GetRecordAsync<IEnumerable<Product>>(typeof(Product).Name + "Get") is null)
            {
                var result = await _productService.Get();
                await _cache.SetRecordAsync<IEnumerable<Product>>(typeof(Product).Name+"Get", result);
                return new JsonResult(result);
           }
            else
            {
                return new JsonResult(await _cache.GetRecordAsync<IEnumerable<Product>>(typeof(Product).Name + "Get"));
           }  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string recordKey = "Products" + id;
          
            var result = await _productService.GetById(id);

            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            var result = await _productService.Update(id, product);

            return new JsonResult(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);

            return new JsonResult(result);
        }
        #endregion
    }
}
