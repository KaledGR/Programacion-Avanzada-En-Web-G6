using AP.Core.BusinessLogic;
using AP.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = AP.Data.Models.Task;

namespace AP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskBusiness taskBusiness) : ControllerBase
    {
        // GET: api/<ProductApiController>
        [HttpGet]
        public async Task<IEnumerable<Task>> Get()
        {
            return await taskBusiness.GetTask(id: null);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Task Task)
        {
            var result = await taskBusiness.SaveTaskAsync(Task);
            if (result)
                return Ok("Tarea guardada correctamente.");
            return BadRequest("No se pudo guardar la Tarea.");
        }


        //No pude hacerlo servir
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Task Task)
        {

            var result = await taskBusiness.SaveTaskAsync(Task);
            if (result)
                return Ok("Tarea actualizada correctamente.");
            return BadRequest("No se pudo actualizar la Tarea.");
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await taskBusiness.DeleteTaskAsync(id);
            if (result)
                return Ok("Tarea eliminada correctamente.");
            return NotFound("No se encontró la Tarea para eliminar.");
        }
    }
}
