using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023.Day4
{
    public class Day4 : IDay
    {
        private string path = "2023\\Day04\\Day4Input.txt";

        private string[] input = Array.Empty<string>();

        public Day4()
        {
            Helpers helpers = new Helpers();
            input = helpers.ReadTxt(path).ToArray();
        }


        public void ex1()
        {
            
            int suma = 0;

            foreach (var item in input)
            {
                var split = item.Split(" | ");
                var ganadoreString = split[0].Substring(10);
                var ganadores = ganadoreString.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();
                var numerosSacados = split[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();
                int puntos = 0;
                foreach (var ganador in ganadores)
                {
                    foreach (var numero in numerosSacados)
                    {
                        if (ganador == numero)
                            puntos = puntos == 0 ? 1 : puntos * 2;
                    }
                }
                suma += puntos;

            }

            Console.WriteLine($"La suma total de puntos es {suma}");
        }

        public void ex2()
        {
            
            int suma = 0;
            int[] tarjetasRepetidas = new int[input.Count()];
            for (int h = 0; h < input.Length; h++)
            {
                var item = input[h];
                var split = item.Split(" | ");
                var ganadoreString = split[0].Substring(10);

                var ganadores = ganadoreString.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();
                var numerosSacados = split[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x => int.Parse(x)).ToList();
                //int puntos = 0;

                var ganadas = h;
                tarjetasRepetidas[h] += 1;
                for (int i = 0; i < ganadores.Count(); i++)
                {
                    foreach (var numero in numerosSacados)
                    {
                        if (ganadores[i] == numero)
                        {
                            ganadas++;
                            tarjetasRepetidas[ganadas] += tarjetasRepetidas[h];
                        }

                    }
                }

            }
            suma = tarjetasRepetidas.Sum();

            Console.WriteLine($"La cantidad de tarjetas es {suma}");
        }
    }
}
