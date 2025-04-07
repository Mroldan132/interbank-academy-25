using Prueba_Tecnica.Models;

namespace Prueba_Tecnica.Interfaces
{
    public interface IReporteGenerador
    {
        decimal ObtenerBalanceFinal(List<Transaccion> transacciones);
        Transaccion ObtenerTransaccionMayor(List<Transaccion> transacciones);
        Dictionary<TipoTransaccion, int> ObtenerConteoTransaccionesPorTipo(List<Transaccion> transacciones);
    }
}
