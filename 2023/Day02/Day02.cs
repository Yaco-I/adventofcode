using _2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
namespace _2023.Day02;

public class Day02 : IDay
{
    string[] Juegos;
    public Day02()
    {
        Helpers helpers = new Helpers();

        Juegos = helpers.ReadTxt("2023\\Day02\\Day02Input.txt").ToArray();

    }
    public void ex2()
    {
        int suma = 0;
        
        for (int i = 0; i < Juegos.Length; i++)
        {
            var Juego = Juegos[i].Split(":");

            var sacadas = Juego[1];

            var sacada = sacadas.Split(";");

            bool flag = true;

                var redCantidad = 0;
                var greenCantidad = 0;
                var blueCantidad = 0;
            foreach (var mov in sacada)
            {
                var colorYcantidad = mov.Split(",");
                foreach (var color in colorYcantidad)
                {
                    var colorCantidad = color.Split(" ");
                    var cantidad = int.Parse(colorCantidad[1]);
                    if (colorCantidad[2] == "red" && cantidad > redCantidad )
                    {
                        redCantidad = cantidad;
                    }
                    else if (colorCantidad[2] == "green" && cantidad > greenCantidad)
                    {
                        greenCantidad = cantidad;
                    }
                    else if (colorCantidad[2] == "blue" && cantidad > blueCantidad)
                    {
                        blueCantidad = cantidad;
                    }
                }


                

            }
                suma += redCantidad * greenCantidad * blueCantidad;
            
        }
        Console.WriteLine("La suma de los id es: ");
        Console.WriteLine(suma);
    }
    public void ex1()
    { 
        int suma = 0;  
        int red = 12;
        int green = 13;
        int blue = 14;


        for (int i = 0; i < Juegos.Length; i++)
        {
            var Juego = Juegos[i].Split(":");

            var sacadas = Juego[1];

            var sacada = sacadas.Split(";");

            bool flag = true;

            foreach (var mov in sacada)
            {
                var redCantidad = 0;
                var greenCantidad = 0;
                var blueCantidad = 0;
                var colorYcantidad = mov.Split(",");
                foreach (var color in colorYcantidad)
                {
                    var colorCantidad = color.Split(" ");
                    if (colorCantidad[2] == nameof(red))
                    {
                        redCantidad += int.Parse(colorCantidad[1]);
                    }
                    if (colorCantidad[2] == nameof(green))
                    {
                        greenCantidad += int.Parse(colorCantidad[1]);
                    }
                    if (colorCantidad[2] == nameof(blue))
                    {
                        blueCantidad += int.Parse(colorCantidad[1]);
                    }
                }


                if(redCantidad > red || greenCantidad > green || blueCantidad > blue)
                {
                    flag = false;
                    break;
                }

            }
            if(flag)
                suma += i + 1;
        }
        Console.WriteLine("La suma de los id es: ");
        Console.WriteLine(suma);
    }

    
}
