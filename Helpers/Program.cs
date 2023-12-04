using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;

//create main
class Program
{
    static void Main(string[] args)
    {
        
    }
}
public class Helpers
{
    public  List<string> ReadTxt(string ruta)
    {
        List<string> lines = new List<string>();
        try
        {
            // Ruta del archivo a leer
            string rutaArchivo = "..\\..\\..\\..\\" + ruta;
            string directory = Directory.GetCurrentDirectory();
            string rutaCompleta = Path.GetFullPath(Path.Combine(directory, rutaArchivo));
           
            // Comprobación de existencia del archivo
            if (File.Exists(rutaCompleta))
            {
                // Crear un lector para el archivo
                using (StreamReader lector = new StreamReader(rutaArchivo))
                {
                    // Leer el contenido del archivo línea por línea
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        lines.Add(linea);
                        //Console.WriteLine(linea); // Mostrar cada línea en la consola
                    }
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocurrió un error: " + ex.Message);
        }
        return lines;
    }
}

