using MangoWebApi.BLL.Interfaces;
using MangoWebApi.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MangoWebApi.WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController:ControllerBase
    {
        private readonly IValuesService _valueService;
        public ValuesController(IValuesService valueService)
        {
            _valueService = valueService;
        }

        #region APIs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _valueService.Get();
            return Ok(result);
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
