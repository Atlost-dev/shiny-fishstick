using DSW_3P_PR02.Models;
using DSW_3P_PR02.Data;

namespace DSW_3P_PR02.Repositories;

public class EventoSQLRepository : IEventoRepository
{
  private readonly AppDbContext _context;

  public EventoSQLRepository(AppDbContext context)
  {
    _context = context;
  }

  public List<Evento> ObtenerEventos()
  {
    return _context.Eventos.ToList();
  }

  public Evento? ObtenerPorId(int id)
  {
    return _context.Eventos.Find(id);
  }

  public Evento AgregarEvento(Evento evento)
  {
    evento.Id = 0;

    _context.Eventos.Add(evento);
    _context.SaveChanges();

    return evento;
  }

  public bool ActualizarEvento(int id, Evento evento)
  {
    var actual = _context.Eventos.Find(id);

    if (actual == null)
      return false;
    actual.Nombre = evento.Nombre;
    actual.Categoria = evento.Categoria;
    actual.Fecha = evento.Fecha;
    actual.Lugar = evento.Lugar;
    actual.CupoMax = evento.CupoMax;
    actual.Activo = evento.Activo;

    _context.SaveChanges();

    return true;
  }

  public bool EliminarEvento(int id)
  {
    var eventos = _context.Eventos.Find(id);

    if (eventos == null)
      return false;

    _context.Eventos.Remove(eventos);
    _context.SaveChanges();

    return true;
  }
}