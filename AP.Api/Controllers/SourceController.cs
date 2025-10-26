using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController(ISourceBusiness sourceBusiness) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Source>> Get()
        {
            return await sourceBusiness.GetSource(id: null);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Source Source)
        {
            var result = await sourceBusiness.SaveSourceAsync(Source);
            if (result)
                return Ok("Sourcee guardado correctamente.");
            return BadRequest("No se pudo guardar la categoría.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Source Source)
        {

            var result = await sourceBusiness.SaveSourceAsync(Source);
            if (result)
                return Ok("Sourcee actualizado correctamente.");
            return BadRequest("No se pudo actualizar el Sourcee.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await sourceBusiness.DeleteSourceAsync(id);
            if (result)
                return Ok("Sourcee eliminado correctamente.");
            return NotFound("No se encontro el Sourcee para eliminar.");
        }
    }
}
