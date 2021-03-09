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
    public class AttributeController:ControllerBase
    {
        private readonly IAttributeService _attributeService;
        private readonly IDistributedCache _cache;
        public AttributeController(IAttributeService attributeService,
                IDistributedCache cache
)
        {
            _attributeService = attributeService;
            _cache = cache;
        }

        #region APIs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (await _cache.GetRecordAsync<IEnumerable<Attribute>>(typeof(Attribute).Name + "Get") is null)
            {
                var result = await _attributeService.Get();
                await _cache.SetRecordAsync<IEnumerable<Attribute>>(typeof(Attribute).Name+"Get", result);
                return new JsonResult(result);
           }
            else
            {
                return new JsonResult(await _cache.GetRecordAsync<IEnumerable<Attribute>>(typeof(Attribute).Name + "Get"));
           }  
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
