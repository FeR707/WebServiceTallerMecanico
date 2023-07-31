using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTallerMecanico.Models
{
    public class Registro
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set;}
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public bool Permiso { get; set; }

        public virtual List<Citas> Citas { get; set; }
    }

    public class RegistroDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set;}
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contrasena { get; set; }
        public bool Permiso { get; set; }

        public virtual List<CitasDTO> Citas { get; set; }
    }
}