using Prueba_Tecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Services
{
    public class ReportePrinter
    {
        public void ImprimirReporte(Reporte reporte)
        {
            Console.WriteLine("Reporte de Transacciones");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Balance Final: {reporte.BalanceFinal:F2}");
            Console.WriteLine($"Transacción de Mayor Monto: ID {reporte.TransaccionMayor.Id} - {reporte.TransaccionMayor.Monto:F2}");
            
            string conteoTransacciones = "Conteo de Transacciones:";
            foreach (var item in reporte.ConteoTransaccionesPorTipo)
            {
                string tipoTransaccion = Enum.GetName(typeof(TipoTransaccion), item.Key);
                conteoTransacciones += $" {tipoTransaccion}: {item.Value}";
            }
            Console.WriteLine(conteoTransacciones);
        }
    }
}
