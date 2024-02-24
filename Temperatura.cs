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
    internal partial class Conversor
    {

        private static void TemperaturasLogo()
        {
            Console.WriteLine(@"


        ████████╗███████╗███╗   ███╗██████╗ ███████╗██████╗  █████╗ ████████╗██╗   ██╗██████╗  █████╗ ███████╗
        ╚══██╔══╝██╔════╝████╗ ████║██╔══██╗██╔════╝██╔══██╗██╔══██╗╚══██╔══╝██║   ██║██╔══██╗██╔══██╗██╔════╝
           ██║   █████╗  ██╔████╔██║██████╔╝█████╗  ██████╔╝███████║   ██║   ██║   ██║██████╔╝███████║███████╗
           ██║   ██╔══╝  ██║╚██╔╝██║██╔═══╝ ██╔══╝  ██╔══██╗██╔══██║   ██║   ██║   ██║██╔══██╗██╔══██║╚════██║
           ██║   ███████╗██║ ╚═╝ ██║██║     ███████╗██║  ██║██║  ██║   ██║   ╚██████╔╝██║  ██║██║  ██║███████║
           ╚═╝   ╚══════╝╚═╝     ╚═╝╚═╝     ╚══════╝╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝", Color.BlueViolet);
        }

        private static bool TemperatureOptions(ConsoleKeyInfo key)
        {
            Console.Title = "[Task/Utilities/Conversor/Temperatures]";
            Console.CursorVisible = false;

            string[] options = { "Fahrenheit°", "Celsius°", "Kelvin°" };
            Menu menuTemperatures = new Menu("", options);

            int selectedOption = menuTemperatures.Run(TemperaturasLogo);

            
            //TemperaturasLogo();
            Console.WriteLine("");

            if (selectedOption == -2)
            {
                return true;
            }
            else
            {
                switch (selectedOption)
                {
                    case 0:
                        TemperatureConversion(0);
                        break;

                    case 1:
                        TemperatureConversion(1);
                        break;

                    case 2:
                        TemperatureConversion(2);
                        break;

                    default:

                        break;
                }
            }

            return false;
        }

        private static bool TemperatureConversion(int selectedOption)
        {

            Console.Title = "[Task/Utilities/Conversor/Temperatures/]";

            double value = 0;
            double result = 0;

            
            Program.Clear();
            TemperaturasLogo();

            if (selectedOption == 0)
            {

                Console.CursorVisible = false;

                string[] options = { "Fahrenheit° a Celsius°", "Fahrenheit° a Kelvin°" };
                Menu menuTemperatures = new Menu("", options);

                selectedOption = menuTemperatures.Run(TemperaturasLogo);

                
                Program.Clear();
                TemperaturasLogo();
                Console.WriteLine("");

                bool converted = false;

                if (selectedOption == -2)
                {
                    return true;
                }
                else
                {
                    do
                    {
                        
                        Program.Clear();
                        TemperaturasLogo();

                        Prefix();
                        Console.Write($"Introduzca los grados Fahrenheit: ");

                        Console.CursorVisible = true;
                        converted = double.TryParse(Console.ReadLine(), out value);
                        Console.CursorVisible = false;

                    } while (!converted);
                }

                
                Program.Clear();
                TemperaturasLogo();

                if (selectedOption == 0)
                {
                    result = Math.Round((value - 32) * 5 / 9, 2);

                    Prefix('✓');
                    Console.WriteLine($"{value}° Fahrenheit son: {result}° Celsius");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para regresar ");

                    Console.ReadKey();

                    return true;
                }
                else
                {
                    result = Math.Round((value - 32) * 5/9 + 273.15, 2);

                    Prefix('✓');
                    Console.WriteLine($"{value}° Fahrenheit son: {result}° Kelvin");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para al menú de conversión ");

                    Console.ReadKey();

                    return true;
                }
            } 
            else if (selectedOption == 1)
            {
                Console.CursorVisible = false;

                string[] options = { "Celsius° a Fahrenheit°", "Celsius° a Kelvin°" };
                Menu menuTemperatures = new Menu("", options);

                selectedOption = menuTemperatures.Run(TemperaturasLogo);

                bool converted = false;

                if (selectedOption == -2)
                {
                    return true;
                }
                else
                {
                    do
                    {
                        
                        Program.Clear();
                        TemperaturasLogo();

                        Prefix();
                        Console.Write($"Introduzca los grados Celsius: ");

                        Console.CursorVisible = true;
                        converted = double.TryParse(Console.ReadLine(), out value);
                        Console.CursorVisible = false;

                    } while (!converted);
                }

                
                Program.Clear();
                TemperaturasLogo();

                if (selectedOption == 1)
                {
                    result = Math.Round((value * 9/5) + 32, 2);

                    Prefix('✓');
                    Console.WriteLine($"{value}° Celsius son: {result}° Fahrenheit");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para al menú de conversión ");

                    Console.ReadKey();

                    return true;
                }
                else
                {
                    result = Math.Round(value + 273.15, 2);

                    Prefix('✓');
                    Console.WriteLine($"{value}° Celsius son: {result}° Kelvin");
                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para al menú de conversión ");

                    Console.ReadKey();

                    return true;
                }
            }
            else if (selectedOption == 2)
            {
                string[] options = { "Kelvin° a Fahrenheit°", "Kelvin° a Celsius°" };
                Menu menuTemperatures = new Menu("", options);

                selectedOption = menuTemperatures.Run(TemperaturasLogo);

                bool converted = false;

                if (selectedOption == -2)
                {
                    return true;
                }
                else
                {
                    do
                    {
                        
                        Program.Clear();
                        TemperaturasLogo();

                        Prefix();
                        Console.Write($"Introduzca los grados Kelvin: ");

                        Console.CursorVisible = true;
                        converted = double.TryParse(Console.ReadLine(), out value);
                        Console.CursorVisible = false;

                    } while (!converted);
                }

                
                Program.Clear();
                TemperaturasLogo();

                if (selectedOption == 0)
                {
                    result = Math.Round((value - 273.15) * 9/5 + 32, 2);

                    Prefix('✓');
                    Console.WriteLine($"{value}° Kelvin son: {result}° Fahrenheit");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para al menú de conversión ");

                    Console.ReadKey();

                    return true;
                }
                else
                {
                    result = Math.Round(value - 273.15, 2);

                    Prefix('✓');
                    Console.WriteLine($"{value}° Kelvin son: {result}° Celsius");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para al menú de conversión ");

                    Console.ReadKey();

                    return true;
                }
            }
            else
            {
                Prefix('!');
                Console.WriteLine("Conversor options error");
            }

            return false;
        }

        private static void Prefix(char character = '>')
        {
            Console.Write($"\n\t[");
            Console.Write($"{character}", Color.BlueViolet);
            Console.Write($"] ");
        }

    }
}