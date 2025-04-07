using System.Collections.Generic;

namespace Prueba_Tecnica.Models
{
    public class Reporte
    {
        public decimal BalanceFinal { get; set; }
        public Transaccion TransaccionMayor { get; set; }
        public Dictionary<TipoTransaccion, int> ConteoTransaccionesPorTipo { get; set; }
    }
}
