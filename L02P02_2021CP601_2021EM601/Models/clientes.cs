using System.ComponentModel.DataAnnotations;

namespace L02P02_2021CP601_2021EM601.Models
{
    public class clientes
    {
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string? nombre { get; set; }
        [Display(Name = "Descripción")]
        public string? apellido { get; set; }
        [Display(Name = "Descripción")]
        public string? email { get; set; }
        [Display(Name = "Descripción")]
        public string? direccion { get; set; }
        [Display(Name = "Descripción")]
        public string? genero { get; set; }
        [Display(Name = "Descripción")]
        public int? id_departamento { get; set; }
        [Display(Name = "departamento")]
        public int? id_puesto { get; set; }
        [Display(Name = "puesto")]
        public string? estado_registro { get; set; }
        [Display(Name = "Registro")]

        public DateTime? created_at { get; set; }
        [Display(Name = "Created")]
        public DateTime? updated_at { get; set; }
    }
}
