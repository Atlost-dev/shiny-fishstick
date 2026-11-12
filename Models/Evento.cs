namespace DSW_3P_PR02.Models;

public class Evento
{
  public int Id { get; set; } // Identificador único
  public string Nombre { get; set; } = string.Empty; // Nombre de la misión
  public string Categoria { get; set; } = string.Empty; // Fácil, Media o Difícil
  public string Fecha { get; set; } = string.Empty; // Fecha de inicio
  public string Lugar { get; set; } = string.Empty; // Lugar de realización
  public int CupoMax { get; set; } // Cupo máximo
  public bool Activo { get; set; }
}