using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_AT.Servicios
{
    public interface IAlmacenadorArchivo
    {
        Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contenType);
        Task BorrarArchivo(string ruta, string contenedor);
        Task<string> GuardarArchivo(byte[] contenido, string extension, string contenedor, string contenType);
    }
}
