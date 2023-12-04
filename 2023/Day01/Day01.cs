using _2023;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023.Day3;

public class Day01 : IDay
{
    List<string> text;
    public Day01()
    {
        Helpers helpers = new Helpers();

        text = helpers.ReadTxt("2023\\Day01\\Day01Input.txt");
    }
    public void ex1()
    {
        int total = 0;
        foreach (var item in text)
        {
            string initial = string.Empty;
            string finish = string.Empty;
            int lenght = item.Length - 1;
            for (int i = 0; i <= lenght; i++)
            {
                if (char.IsDigit(item[i]) == true && string.IsNullOrEmpty(initial))
                {
                    initial = item[i].ToString();
                }
                if (char.IsDigit(item[lenght - i]) == true && string.IsNullOrEmpty(finish))
                {
                    finish = item[lenght - i].ToString();
                }
                if (!string.IsNullOrEmpty(initial) && !string.IsNullOrEmpty(finish))
                {
                    var result = int.Parse(initial + finish);

                    total += result;
                    break;
                }
            }
        }
        Console.WriteLine(total);

    }

    

    

    public void ex2()
    {
        List<string> numbers = new List<string>()
        {
            "one","two","three","four","five","six","seven","eight","nine"
        };
        int total = 0;
        foreach (var word in text)
        {
            string initial = string.Empty;
            string oldNumber = string.Empty;
            
            int lenght = word.Length - 1;
            string[] numbersString = Array.Empty<string>();
            foreach (char character in word)
            {
                if (char.IsDigit(character) == true)
                {
                    if (string.IsNullOrEmpty(initial))
                        initial = character.ToString();
                    oldNumber = character.ToString();
                    numbersString = Array.Empty<string>();
                    
                }
                else
                {
                    numbersString = numbersString.Where(x => numbers.Any(y => y.StartsWith(x + character.ToString()))).ToArray();

                    for (int i = 0; i < numbersString.Length; i++)
                    {
                        numbersString[i] = numbersString[i] + character.ToString();
                        if (numbers.Any(x => x.StartsWith(numbersString[i])))
                        {
                            if (numbers.Any(x => x.Equals(numbersString[i])))
                            {
                                var index = numbers.FindIndex(x => x.Equals(numbersString[i]));
                                var number = index + 1;

                                if (string.IsNullOrEmpty(initial))
                                    initial = number.ToString();
                                oldNumber = number.ToString();

                                numbersString = Array.Empty<string>();
                                break;
                            }
                        }
                        
                    }
                    numbersString = numbersString.Append(character.ToString()).ToArray();
                }
            }
            var prueba = word;
            var result = int.Parse(initial + oldNumber);
            total += result;
        }
        Console.WriteLine(total);


    }
}
