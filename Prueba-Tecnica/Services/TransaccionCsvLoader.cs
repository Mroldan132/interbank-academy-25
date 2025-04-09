using Prueba_Tecnica.Interfaces;
using Prueba_Tecnica.Models;
using System.Globalization;

public class TransaccionCsvLoader : ITransaccionLoader
{
    private readonly string _filePath;

    public TransaccionCsvLoader(string filePath)
    {
        _filePath = filePath;
    }

    public List<Transaccion> CargarTransacciones()
    {
        var transacciones = new List<Transaccion>();
        // Verificar si el archivo existe
        if (!File.Exists(_filePath))
        {
            Console.WriteLine($"El archivo {_filePath} no existe.");
            return transacciones;
        }

        // Leer el archivo CSV
        var lines = File.ReadAllLines(_filePath).Skip(1); 

        foreach (var line in lines)
        {
            // Ignorar líneas vacías
            var values = line.Split(',');


            //Validar que la línea tenga el número correcto de campos
            if (values.Length != 3)
            {
                Console.WriteLine($"Línea inválida (falta un campo): {line}");
                continue;
            }

            // Validar que los campos tengan el formato correcto
            // Validar que el tipo de transacción sea válido
            // Validar que el monto sea un número decimal válido
            if(!int.TryParse(values[0], out int id) ||
               !Enum.TryParse(values[1], out TipoTransaccion tipo) ||
               !decimal.TryParse(values[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal monto)){
                Console.WriteLine($"Línea inválida: {line}");
                continue;
            }

            transacciones.Add(new Transaccion
            {
                Id = id,
                Tipo = tipo, 
                Monto = monto
            });
        }

        return transacciones;
    }
}
