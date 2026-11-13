using DSW_3P_PR02.Models;
using DSW_3P_PR02.Repositories;

namespace DSW_3P_PR02.Services;

public class EventoService : IEventoService
{
  private readonly IEventoRepository _repository;

  public EventoService(IEventoRepository repository)
  {
    _repository = repository;
  }

  public List<Evento> ObtenerEventos()
  {
    return _repository.ObtenerEventos();
  }

  public Evento? ObtenerPorId(int id)
  {
    return _repository.ObtenerPorId(id);
  }

  public Evento AgregarEvento(Evento nuevoEvento)
  {
    Validar(nuevoEvento);
    return _repository.AgregarEvento(nuevoEvento);
  }

  public bool ActualizarEvento(int id, Evento eventoActualizado)
  {
    Validar(eventoActualizado);
    return _repository.ActualizarEvento(id, eventoActualizado);
  }

  public bool EliminarEvento(int id)
  {
    return _repository.EliminarEvento(id);
  }

  // Reglas de negocio: el controlador debe atrapar ArgumentException y responder BadRequest
  private static void Validar(Evento evento)
  {
    if (string.IsNullOrWhiteSpace(evento.Nombre))
      throw new ArgumentException("El nombre es obligatorio.");

    if (evento.CupoMax <= 0)
      throw new ArgumentException("El cupo debe ser mayor que cero.");

    if (!DateTime.TryParse(evento.Fecha, out _))
      throw new ArgumentException("La fecha no es válida.");
  }
}
