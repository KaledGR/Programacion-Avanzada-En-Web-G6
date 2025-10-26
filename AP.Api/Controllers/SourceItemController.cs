using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceItemController(ISourceItemBusiness sourceItemBusiness) : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<SourceItem>> Get()
        {
            return await sourceItemBusiness.GetSourceItem(id: null);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SourceItem SourceItem)
        {
            var result = await sourceItemBusiness.SaveSourceItemAsync(SourceItem);
            if (result)
                return Ok("SourceIteme guardado correctamente.");
            return BadRequest("No se pudo guardar la categoría.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] SourceItem SourceItem)
        {

            var result = await sourceItemBusiness.SaveSourceItemAsync(SourceItem);
            if (result)
                return Ok("SourceIteme actualizado correctamente.");
            return BadRequest("No se pudo actualizar el SourceIteme.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await sourceItemBusiness.DeleteSourceItemAsync(id);
            if (result)
                return Ok("SourceIteme eliminado correctamente.");
            return NotFound("No se encontro el SourceIteme para eliminar.");
        }


    }
}
