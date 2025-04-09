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
            var reporteGenerador = new ReporteGenerador();

            var reporte = new Reporte
            {
                BalanceFinal = reporteGenerador.ObtenerBalanceFinal(transacciones),
                TransaccionMayor = reporteGenerador.ObtenerTransaccionMayor(transacciones),
                ConteoTransaccionesPorTipo = reporteGenerador.ObtenerConteoTransaccionesPorTipo(transacciones)
            };

            var printer = new ReportePrinter();
            printer.ImprimirReporte(reporte);
        }
        else
        {
            Console.WriteLine("No se encontraron transacciones válidas en el archivo.");
        }
    }
}
