using DSW_3P_PR02.Models;

namespace DSW_3P_PR02.Services;

public interface IEventoService
{
  List<Evento> ObtenerEventos();
  Evento? ObtenerPorId(int id);
  Evento AgregarEvento(Evento nuevoEvento);
  bool ActualizarEvento(int id, Evento eventoActualizado);
  bool EliminarEvento(int id);
}
