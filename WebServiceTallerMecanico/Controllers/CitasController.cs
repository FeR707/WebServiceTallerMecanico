using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceTallerMecanico.Models;

namespace WebServiceTallerMecanico.Controllers
{
    public class CitasController : ApiController
    {
        Model1 DB =new Model1();

        /// <summary>
        /// AgendarCitas: Crea un nuevo registro de citas, Metodo POST
        /// </summary>
        /// <param name="citas">Recibe un objeto Citas (Completo)</param>
        /// <returns>True o False</returns>
        [ActionName("AgendarCitas")]
        [HttpPost]
        public bool AgendarCitas(Citas citas)
        {
            try
            {
                DB.Citas.Add(citas);
                DB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// ActualizarCitas: Actualiza el estatus de las citas, Metodo POST
        /// </summary>
        /// <param name="citas">Recibe un objeto Citas (ID)</param>
        /// <returns></returns>
        [ActionName("ActualizarCitas")]
        [HttpPost]
        public bool ActualizarCitas(Citas citas)
        {
            try
            {
                var consulta = DB.Citas.Where(x => x.ID == citas.ID).FirstOrDefault();
                if (consulta != null)
                {
                    consulta.Estatus = citas.Estatus;
                    consulta.Estados.EntregarVehiculo = citas.Estados.EntregarVehiculo;
                    consulta.Estados.PrepararCoche = citas.Estados.PrepararCoche;
                    consulta.Estados.DarMantenimiento = citas.Estados.DarMantenimiento;
                    consulta.Estados.Finalizar = citas.Estados.Finalizar;
                    consulta.Estados.RecogerVehiculo = citas.Estados.RecogerVehiculo;
                    DB.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false; 
            }
        }

        /// <summary>
        /// MostrarCitas: Muestra las citas por ID, Metodo POST
        /// </summary>
        /// <param name="citas">Recibe un objeto Citas (ID)</param>
        /// <returns></returns>
        [ActionName("MostrarCitas")]
        [HttpPost]
        public List<CitasDTO> MostrarCitas(Citas citas)
        {
            try
            {
                var consulta = from cita in DB.Citas
                               where cita.ID == citas.ID
                               select new CitasDTO
                               {
                                   ID = cita.ID,
                                   Vehiculo = cita.Vehiculo,
                                   Servicio = cita.Servicio,
                                   Fecha = cita.Fecha,
                                   Estatus = cita.Estatus,
                                   EstadosID = cita.ID,
                                   Estados = new EstadosDTO
                                   {
                                       ID = cita.Estados.ID,
                                       EntregarVehiculo = cita.Estados.EntregarVehiculo,
                                       PrepararCoche = cita.Estados.PrepararCoche,
                                       DarMantenimiento = cita.Estados.DarMantenimiento,
                                       Finalizar = cita.Estados.Finalizar,
                                       RecogerVehiculo = cita.Estados.RecogerVehiculo
                                   }
                               };

                return consulta.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
