
using _2023;
using _2023.Day02;
using _2023.Day3;
using _2023.Day4;

Console.WriteLine("BIENVENIDO AL ADVENT OF CODE 2023");
Console.WriteLine("DE YACO IBARS");


while (true)
{
    IDay day = null;
    Console.WriteLine("-- MENU DE OPCIONES --");
    Console.WriteLine("Si quiere algun dia en especifico marque el numero de dia");

    Console.WriteLine("DIA 1 - marq1");
    Console.WriteLine("DIA 2");
    Console.WriteLine("DIA 3");
    Console.WriteLine("DIA 4");

    Console.WriteLine("Si quiere salir marque 0");
    var input = Console.ReadLine();
    switch (input)
    {
        case "1":
            day = new Day01();
            Console.WriteLine("ELEGISTE EL DIA 1");
            break;
        case "2":
            day = new Day02();
            Console.WriteLine("ELEGISTE EL DIA 2");
            break;
        case "3":
            Console.WriteLine("ELEGISTE EL DIA 3");
            day = new Day3();
            Console.WriteLine("Buscando el numero para encontrar el engranaje");
            break;
        case "4":
            Console.WriteLine("ELEGISTE EL DIA 4");
            day = new Day4();
            break;
        case "0":
            Console.WriteLine("SALIENDO DEL PROGRAMA");
            return;
        default:
            Console.WriteLine("NO SE ENCONTRO EL DIA");
            Console.WriteLine("INGRESE UN NUEVO DIA");
            break;
    }

    if (day == null)
        continue;
    day.ex1();
    day.ex2();

}