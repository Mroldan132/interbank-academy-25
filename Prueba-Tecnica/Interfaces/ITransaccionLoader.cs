using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Interfaces
{
    interface ITransaccionLoader
    {
        List<Transaccion> CargarTransacciones();
    }
}
