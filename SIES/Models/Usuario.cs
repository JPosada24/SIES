using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SIES.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El documento es obligatorio.")]
        public long Documento { get; set; }
        public string TipoDoc { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; }
        public long Celular { get; set; }
        [Required(ErrorMessage = "Ingrese un correo válido.")]
        public string Email { get; set; }
        [RegularExpression("[MmFf]", ErrorMessage = "Solo puede ingresar una M o F")]
        public string Genero { get; set; }
        public string Aprendiz { get; set; }
        public string Egresado { get; set; }
        public string AreaFormacion { get; set; }
        public DateTime FechaEgresado { get; set; }
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}