using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebServiceTallerMecanico.Models;

namespace WebServiceTallerMecanico.Controllers
{
    public class RegistrosController : ApiController
    {
        Model1 DB = new Model1();

        /// <summary>
        /// RegistroUsuario: Crea un nuevo registro de usuario, Metodo POST
        /// </summary>
        /// <param name="registro">Recibe un objeto Registro (Completo)</param>
        /// <returns>True o False</returns>
        [ActionName("RegistroUsuario")]
        [HttpPost]
        public bool RegistroUsuario(Registro registro)
        {
            try
            {
                DB.Registro.Add(registro);
                DB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// VerficarCuenta: Verifica si existe el usuario, Metodo POST
        /// </summary>
        /// <param name="registro">Recibe un objeto Registro (Correo y Contraseña)</param>
        /// <returns>True o False</returns>
        [ActionName("VerficarCuenta")]
        [HttpPost]
        public bool VerficarCuenta(Registro registro)
        {
            try
            {
                var consulta = DB.Registro.Where(x => x.Correo == registro.Correo && x.Contrasena == registro.Contrasena).FirstOrDefault();
                if (consulta != null)
                {
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
        /// MostrarUsuarios: Muestra todos los usuarios registrados, Metodo GET
        /// </summary>
        /// <returns>Lista Registros</returns>
        [ActionName("MostrarUsuarios")]
        [HttpGet]
        public List<RegistroDTO> MostrarUsuarios()
        {
            try
            {
                var consulta = from registro in DB.Registro
                               select new RegistroDTO
                               {
                                   ID = registro.ID,
                                   Nombre = registro.Nombre,
                                   Apellidos = registro.Apellidos,
                                   Correo = registro.Correo,
                                   Telefono = registro.Telefono,
                                   Contrasena = registro.Contrasena,
                                   Permiso = registro.Permiso
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
