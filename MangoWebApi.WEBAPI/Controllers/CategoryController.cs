using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController:ControllerBase
    {
        #region Propertirs
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion

        #region #APIs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetById(id);
            return new JsonResult(result);
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
