using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using MangoWebApi.Redis;
using System.Collections.Generic;

namespace MangoWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController:ControllerBase
    {
        #region Propertirs
        private readonly ICategoryService _categoryService;
        private readonly IDistributedCache _cache;
        #endregion

        #region Constructors
        public CategoryController(ICategoryService categoryService,
        IDistributedCache cache)
        {
            _categoryService = categoryService;
            _cache = cache;
        }

        #endregion

        #region #APIs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (await _cache.GetRecordAsync<IEnumerable<Categories>>(typeof(Categories).Name + "Get") is null)
            {
                var result = await _categoryService.Get();
                await _cache.SetRecordAsync<IEnumerable<Categories>>(typeof(Categories).Name+"Get", result);
                return new JsonResult(result);
           }
            else
            {
                return new JsonResult(await _cache.GetRecordAsync<IEnumerable<Categories>>(typeof(Categories).Name + "Get"));
           } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (await _cache.GetRecordAsync<IEnumerable<Categories>>(typeof(Categories).Name + "GetById"+id) is null)
            {
            var result = await _categoryService.GetById(id);
            await _cache.SetRecordAsync<Categories>(typeof(Categories).Name+"GetById"+id,result);
            return new JsonResult(result);
            }
            else{
                return new JsonResult(await _cache.GetRecordAsync<Categories>(typeof(Categories).Name + "GetById"+id));
            }
        }

        [HttpPost]
        public async Task<IActionResult>  Create(Categories categories)
        {
            var result = await _categoryService.Add(categories);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _categoryService.Delete(id);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Categories categories)
        {

            var result =await _categoryService.Update(id,categories);
            return new JsonResult(result);
        }
        #endregion
    }
}
