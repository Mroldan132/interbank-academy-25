using Prueba_Tecnica.Models;
using Prueba_Tecnica.Services;

class Program
{
    static void Main(string[] args)
    {
        // Cargar las transacciones desde el archivo CSV
        var rutaCsv = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "data.csv");
        var transaccioncsv = new TransaccionCsvLoader(rutaCsv);

        // Cargar las transacciones
        List<Transaccion> transacciones = transaccioncsv.CargarTransacciones();

        if (transacciones.Count() > 0)
        {
            // Generar el reporte
            var reporteGenerador = new ReporteGenerador();

            // Obtener el balance final, la transacción de mayor monto y el conteo por tipo
            decimal balanceFinal = reporteGenerador.ObtenerBalanceFinal(transacciones);
            Transaccion transaccionMayor = reporteGenerador.ObtenerTransaccionMayor(transacciones);
            Dictionary<TipoTransaccion, int> conteoPorTipo = reporteGenerador.ObtenerConteoTransaccionesPorTipo(transacciones);

            // Imprimir el reporte
            Console.WriteLine("Reporte de Transacciones");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Balance Final: {balanceFinal:F2}");
            Console.WriteLine($"Transacción de Mayor Monto: ID {transaccionMayor.Id} - {transaccionMayor.Monto:F2}");
            string conteoTransacciones = "Conteo de Transacciones:";
            foreach (var item in conteoPorTipo)
            {
                string tipoTransaccion = Enum.GetName(typeof(TipoTransaccion), item.Key);
                conteoTransacciones += $" {tipoTransaccion}: {item.Value}";
            }
            Console.WriteLine(conteoTransacciones);
        }
        else
        {
            Console.WriteLine("No se encontraron transacciones válidas en el archivo.");
        }
    }
}
