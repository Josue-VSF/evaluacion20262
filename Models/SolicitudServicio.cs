using System.ComponentModel.DataAnnotations;

namespace evaluacion20262.Models
{
    public class SolicitudServicio
    {
        public int Id { get; set; }
        [Required] public string Cliente { get; set; } = string.Empty;
        [Required] public string Telefono { get; set; } = string.Empty;
        [Required] public string Distrito { get; set; } = string.Empty;
        [Required] public string TipoServicio { get; set; } = string.Empty; // Instalación, Mantenimiento, Revisión, Fuga
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}