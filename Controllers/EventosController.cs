using Microsoft.AspNetCore.Mvc;
using DSW_3P_PR02.Models;
using DSW_3P_PR02.Services;

namespace DSW_3P_PR02.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
  private readonly IEventoService _service;

  public EventosController(IEventoService service)
  {
    _service = service;
  }

  //GET - Obtener todos los eventos
  [HttpGet]
  public IActionResult ObtenerEventos()
  {
    return Ok(_service.ObtenerEventos());
  }

  //GET - Obtener evento por ID
  [HttpGet("{id:int}")]
  public IActionResult ObtenerPorId(int id)
  {
    var evento = _service.ObtenerPorId(id);

    if (evento == null)
      return NotFound(new { mensaje = $"No se encontró el evento con Id {id}" });

    return Ok(evento);
  }

  //POST - Registrar nuevo evento (valida nombre, cupo y fecha)
  [HttpPost]
  public IActionResult AgregarEvento(Evento nuevo)
  {
    try
    {
      var creado = _service.AgregarEvento(nuevo);

      return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }
    catch (ArgumentException ex)
    {
      return BadRequest(new { mensaje = ex.Message });
    }
  }

  //PUT - Actualizar evento (valida nombre, cupo y fecha)
  [HttpPut("{id:int}")]
  public IActionResult ActualizarEvento(int id, Evento actualizado)
  {
    try
    {
      if (!_service.ActualizarEvento(id, actualizado))
        return NotFound(new { mensaje = $"No se encontró el evento con Id {id}" });

      return NoContent();
    }
    catch (ArgumentException ex)
    {
      return BadRequest(new { mensaje = ex.Message });
    }
  }

  //DELETE - Eliminar evento
  [HttpDelete("{id:int}")]
  public IActionResult EliminarEvento(int id)
  {
    if (!_service.EliminarEvento(id))
      return NotFound(new { mensaje = $"No se encontró el evento con Id {id}" });

    return NoContent();
  }
}
