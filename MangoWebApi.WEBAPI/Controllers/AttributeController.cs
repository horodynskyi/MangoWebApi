using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace MangoWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttributeController:ControllerBase
    {
        private readonly IAttributeService _attributeService;
        public AttributeController(IAttributeService attributeService)
        {
            _attributeService = attributeService;
        }

        #region APIs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _attributeService.Get();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _attributeService.GetById(id);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Attribute attribute)
        {
            var result = await _attributeService.Add(attribute);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _attributeService.Delete(id);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Attribute attribute)
        {
            var result = await _attributeService.Update(id, attribute);
            return new JsonResult(result);
        }
        #endregion
    }
}
