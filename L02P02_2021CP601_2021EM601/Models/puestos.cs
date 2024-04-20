using System.ComponentModel.DataAnnotations;

namespace L02P02_2021CP601_2021EM601.Models
{
    public class puestos
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Nombre_puesto")]
        public string? puesto { get; set; }
        [Display(Name = "Estado")]
        public string? estado { get; set; }
        [Display(Name = "Fecha")]
        public DateTime? created_at { get; set; }
    }
}
