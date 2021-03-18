using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIES.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string TipoDoc { get; set; }
        public string Nombre { get; set; }
        public int Celular { get; set; }
        public string Email { get; set; }
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