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
    public class ValuesController:ControllerBase
    {
        private readonly IValuesService _valueService;
        private readonly IDistributedCache _cache;
        public ValuesController(IValuesService valueService,
        IDistributedCache cache)
        {
            _valueService = valueService;
            _cache = cache;
        }

        #region APIs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           if (await _cache.GetRecordAsync<IEnumerable<Values>>(typeof(Values).Name + "Get") is null)
            {
                var result = await _valueService.Get();
                await _cache.SetRecordAsync<IEnumerable<Values>>(typeof(Values).Name+"Get", result);
                return new JsonResult(result);
           }
            else
            {
                return new JsonResult(await _cache.GetRecordAsync<IEnumerable<Values>>(typeof(Values).Name + "Get"));
           } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _valueService.GetById(id);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Values values)
        {
            var result = await _valueService.Add(values);
            return new JsonResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _valueService.Delete(id);
            return new JsonResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Values values)
        {
            var result =await _valueService.Update(id, values);
            return new JsonResult(result);
        }
        #endregion
    }
}
