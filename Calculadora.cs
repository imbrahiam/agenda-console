using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace Final
{
    internal class Calculadora
    {
        private static void Calc()
        {
            Console.WriteLine(@"


         ██████╗ █████╗ ██╗      ██████╗██╗   ██╗██╗      █████╗ ██████╗  ██████╗ ██████╗  █████╗ 
        ██╔════╝██╔══██╗██║     ██╔════╝██║   ██║██║     ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██╔══██╗
        ██║     ███████║██║     ██║     ██║   ██║██║     ███████║██║  ██║██║   ██║██████╔╝███████║
        ██║     ██╔══██║██║     ██║     ██║   ██║██║     ██╔══██║██║  ██║██║   ██║██╔══██╗██╔══██║
        ╚██████╗██║  ██║███████╗╚██████╗╚██████╔╝███████╗██║  ██║██████╔╝╚██████╔╝██║  ██║██║  ██║
         ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝", Color.BlueViolet);
        }

        public static bool Menu(ConsoleKeyInfo key)
        {
            Console.Title = "[Task/Utilities/Conversor/]";

            bool converted, converted2;
            double firstVal, secondVal = 0;
            bool pass = true;

            do
            {

                do
                {
                    
                    Program.Clear();
                    Calc();
                    Prefix();
                    Console.Write($"Ingrese el primer valor: ");

                    Console.CursorVisible = true;
                    converted = double.TryParse(Console.ReadLine(), out firstVal);
                    Console.CursorVisible = false;

                    if (converted)
                    {
                        do
                        {
                            
                            Program.Clear();
                            Calc();
                            Prefix();
                            Console.Write($"Ingrese el primer valor: {firstVal}");
                            Prefix();
                            Console.Write($"Ingrese el segundo valor: ");

                            Console.CursorVisible = true;
                            converted2 = double.TryParse(Console.ReadLine(), out secondVal);
                            Console.CursorVisible = false;

                        } while (!converted2);
                    }

                } while (!converted);

                
                Program.Clear();
                Calc();

                Console.Title = "[Task/Utilities/Conversor/Temperatures]";

                do
                {

                    
                    //Program.Clear();
                    //Calc();

                    string[] options = { "Sumar", "Restar", "Multiplicar", "Dividir", "Elevar" };

                    Menu calculadora = new Menu("¿Qué operación desea realizar?", options);

                    int selectedOperation = calculadora.Run(Calc);

                    
                    Program.Clear();
                    Calc();

                    Prefix();

                    switch (selectedOperation)
                    {
                        case 0:
                            Console.WriteLine($"{firstVal} + {secondVal} = {Math.Round(firstVal + secondVal)}");
                            break;

                        case 1:
                            Console.WriteLine($"{firstVal} - {secondVal} = {Math.Round(firstVal - secondVal)}");
                            break;

                        case 2:
                            Console.WriteLine($"{firstVal} x {secondVal} = {Math.Round(firstVal * secondVal)}");
                            break;

                        case 3:
                            Console.WriteLine($"{firstVal} ÷ {secondVal} = {Math.Round(firstVal / secondVal)}");
                            break;

                        case 4:
                            Console.WriteLine($"{firstVal} ^ {secondVal} = {Math.Round(Math.Pow(firstVal, secondVal), 2)}");
                            break;

                        default:
                            return false;
                    }
                    Prefix('<');
                    Console.WriteLine("Realizar otra operación");
                    Prefix2();
                    Console.WriteLine("Presione cualquier tecla para volver al menú");

                } while (Console.ReadKey(true).Key == ConsoleKey.LeftArrow);

            } while (!pass);

            return true;
        }

        private static void Prefix(char character = '>')
        {
            Console.Write($"\n\t[");
            Console.Write($"{character}", Color.BlueViolet);
            Console.Write($"] ");
        }
        private static void Prefix2(char character = '>')
        {
            Console.Write($"\t[");
            Console.Write($"{character}", Color.BlueViolet);
            Console.Write($"] ");
        }
    }
}