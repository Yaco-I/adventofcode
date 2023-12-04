using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _2023.Day3
{
    public class Day3 : IDay
    {
        //D:\Cursos\Desing Patterns\Repositorio\State\AdventOfCode\2023\Day03\Day3Input.txt
        private string path = "2023\\Day03\\Day3Input.txt";

        private string[] input = Array.Empty<string>();
        
        public Day3()
        {
            Helpers helpers = new Helpers();
            input = helpers.ReadTxt(path).ToArray();
        }
        public void ex1()
        {
            string number = string.Empty;
            bool flag = false;
            int suma = 0;
            for (int i = 0; i < input.Length; i++)
            {
                number = string.Empty;
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (char.IsDigit(input[i][j]))
                    {
                        number += input[i][j];
                        if (!flag)
                        {
                            //Validamos fila actual
                            // ...
                            // *4.
                            // ...
                            if (j > 0 && specialChar(input[i][j - 1]))
                                flag = true;

                            // ...
                            // .4*
                            // ...
                            else if (j < input[i].Length - 1 && specialChar(input[i][j + 1]))
                                flag = true;

                            //Validamos fila de arriba
                            if (i > 0)
                            {
                                //Arriba del numero
                                // .*.
                                // .4.
                                // ...
                                if (specialChar(input[i - 1][j]))
                                    flag = true;

                                //Arriba a la izquierda
                                // *..
                                // .4.
                                // ...
                                if (j > 0 && specialChar(input[i - 1][j - 1]))
                                    flag = true;


                                //Arriba a la derecha
                                // ..*
                                // .4.
                                // ...
                                if (j < input[i].Length - 1 && specialChar(input[i - 1][j + 1]))
                                    flag = true;
                            }
                            //Validamos fila de abajo
                            if (i < input.Length - 1)
                            {
                                //Abajo del numero
                                if (specialChar(input[i + 1][j]))
                                    flag = true;

                                //Abajo a la izquierda
                                if (j > 0 && specialChar(input[i + 1][j - 1]))
                                    flag = true;

                                //Abajo a la derecha
                                if (j < input[i].Length - 1 && specialChar(input[i + 1][j + 1]))
                                    flag = true;
                            }
                        }
                    }
                    else
                    {
                        if (flag)
                        {
                            suma += string.IsNullOrEmpty(number) ? 0 : int.Parse(number);
                            flag = false;
                        }
                        number = string.Empty;
                    }
                }
                if (number.Length > 0 && flag)
                    suma += int.Parse(number);
            }

            Console.WriteLine("El numero que se encontro es: " + suma);
            //throw new NotImplementedException();
        }

        public void ex2()
        {
            Console.WriteLine("Todavia no esta implementado");
        }
        private bool specialChar(char c)
        {
            return !char.IsDigit(c) && c != '.';
        }
    }
}
