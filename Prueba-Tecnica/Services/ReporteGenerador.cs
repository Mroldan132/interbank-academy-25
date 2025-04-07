using Prueba_Tecnica.Models;
using Prueba_Tecnica.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Prueba_Tecnica.Services
{
    public class ReporteGenerador : IReporteGenerador
    {
        public decimal ObtenerBalanceFinal(List<Transaccion> transacciones)
        {
            decimal tipoDeb= transacciones
                .Where(t => t.Tipo == TipoTransaccion.Débito)
                .Sum(t => t.Monto);

            decimal tipoCred = transacciones
                .Where(t => t.Tipo == TipoTransaccion.Crédito)
                .Sum(t => t.Monto);

            return tipoCred - tipoDeb;
        }

        public Transaccion ObtenerTransaccionMayor(List<Transaccion> transacciones)=>
            transacciones.OrderByDescending(t => t.Monto).FirstOrDefault();

        public Dictionary<TipoTransaccion, int> ObtenerConteoTransaccionesPorTipo(List<Transaccion> transacciones)=>
            transacciones
                .GroupBy(t => t.Tipo)
                .ToDictionary(g => g.Key, g => g.Count());
    }
}
