using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTallerMecanico.Models
{
    public class Citas
    {
        public int ID { get; set; }
        public string Vehiculo { get; set; }
        public string Servicio { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estatus { get; set; }
        
        public int EstadosID { get; set; }
        public virtual Estados Estados { get; set; }
    }

    public class CitasDTO
    {
        public int ID { get; set; }
        public string Vehiculo { get; set; }
        public string Servicio { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estatus { get; set; }

        public int EstadosID { get; set; }
        public virtual EstadosDTO Estados { get; set; }
    }
}