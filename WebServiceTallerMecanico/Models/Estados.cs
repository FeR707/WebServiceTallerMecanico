using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTallerMecanico.Models
{
    public class Estados
    {
        public int ID { get; set; }
        public bool EntregarVehiculo { get; set; }
        public bool PrepararCoche { get; set; }
        public bool DarMantenimiento { get; set; }
        public bool Finalizar { get; set; }
        public bool RecogerVehiculo { get; set; }
    }

    public class EstadosDTO
    {
        public int ID { get; set; }
        public bool EntregarVehiculo { get; set; }
        public bool PrepararCoche { get; set; }
        public bool DarMantenimiento { get; set; }
        public bool Finalizar { get; set; }
        public bool RecogerVehiculo { get; set; }
    }
}