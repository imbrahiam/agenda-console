using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Final
{
    internal partial class Conversor
    {

        private static void MonedasLogo()
        {
            Console.WriteLine(@"


        ███╗   ███╗ ██████╗ ███╗   ██╗███████╗██████╗  █████╗ ▄▄███▄▄·                                          
        ████╗ ████║██╔═══██╗████╗  ██║██╔════╝██╔══██╗██╔══██╗██╔════╝                                          
        ██╔████╔██║██║   ██║██╔██╗ ██║█████╗  ██║  ██║███████║███████╗                                          
        ██║╚██╔╝██║██║   ██║██║╚██╗██║██╔══╝  ██║  ██║██╔══██║╚════██║                                      
        ██║ ╚═╝ ██║╚██████╔╝██║ ╚████║███████╗██████╔╝██║  ██║███████║                                      
        ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝╚═════╝ ╚═╝  ╚═╝╚═▀▀▀══╝                                      ", Color.BlueViolet);
        }

        private static bool MoneyOptions(ConsoleKeyInfo key)
        {
            Console.Title = "[Task/Utilities/Conversor/Exchange]";
            Console.CursorVisible = false;

            string[] options = { "DOP$", "USD$", "EUR$" };
            Menu menuMonedas = new Menu("Moneda inicial", options);

            int selectedOption = menuMonedas.Run(MonedasLogo);

            
            //Program.Clear();
            //MonedasLogo();
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
                        MoneyConversion(0);
                        break;

                    case 1:
                        MoneyConversion(1);
                        break;

                    case 2:
                        MoneyConversion(2);
                        break;

                    default:

                        break;
                }
            }

            return false;
        }

        private static bool MoneyConversion(int selectedOption)
        {
            /*HttpClient client = new HttpClient();
            var responseObj = client.GetAsync("https://v6.exchangerate-api.com/v6/de9545a84866be089dc6285e/latest/USD");

            responseObj.Wait();

            if(responseObj.IsCompleted)
            {
                var response = responseObj.Result;

                if (response.IsSuccessStatusCode)
                {
                    var awaitingString = response.Content.ReadAsStringAsync();
                    awaitingString.Wait();

                    var msg = awaitingString.Result;

                    dynamic r = JObject.Parse(msg);

                    Console.WriteLine(r.USD);

                    Console.ReadKey();
                }
            }*/

            Console.Title = "[Task/Utilities/Conversor/Exchange/DOP";
            Console.CursorVisible = false;

            double value = 0;
            double result = 0;

            
            Program.Clear();
            MonedasLogo();

            if (selectedOption == 0)
            {
                Console.CursorVisible = false;

                string[] options = { "DOP$ a USD$", "DOP$ a EUR$" };
                Menu menuMonedas = new Menu("Moneda final", options);

                selectedOption = menuMonedas.Run(MonedasLogo);

                
                Program.Clear();
                MonedasLogo();
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
                        MonedasLogo();

                        Console.CursorVisible = true;

                        Prefix();
                        Console.Write($"Introduzca la cantidad en peso dominicano: ");

                        converted = double.TryParse(Console.ReadLine(), out value);
                        Console.CursorVisible = false;

                    } while (!converted || value < 0);
                }

                if (selectedOption == 0)
                {
                    result = Math.Round((value * 0.0183024), 2);

                    
                    Program.Clear();
                    MonedasLogo();

                    Prefix('✓');
                    Console.WriteLine($"${value} dop son: ${result} usd");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para regresar...");

                    Console.ReadKey();

                    return true;
                }
                else
                {
                    result = Math.Round((value * 0.016687552), 2);

                    
                    Program.Clear();
                    MonedasLogo();

                    Prefix('✓');
                    Console.WriteLine($"${value} dop son: ${result} euros");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para regresar...");

                    Console.ReadKey();

                    return true;
                }
            }
            else if (selectedOption == 1)
            {
                Console.CursorVisible = false;

                string[] options = { "USD$ a DOP$", "USD$ a EUR$" };
                Menu menuMonedas = new Menu("Moneda final", options);

                selectedOption = menuMonedas.Run(MonedasLogo);

                
                Program.Clear();
                MonedasLogo();
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
                        MonedasLogo();

                        Prefix();
                        Console.Write($"Introduzca la cantidad en dolares estadounidenses: ");

                        Console.CursorVisible = true;
                        converted = double.TryParse(Console.ReadLine(), out value);
                        Console.CursorVisible = false;

                    } while (!converted || value < 0);
                }

                if (selectedOption == 0)
                {
                    result = Math.Round(value / 0.0183008, 2);

                    
                    Program.Clear();
                    MonedasLogo();

                    Prefix('✓');
                    Console.WriteLine($"[✓] ${value} usd: ${result} dop");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para regresar...");

                    Console.ReadKey();

                    return true;
                }
                else
                {
                    result = Math.Round(value * 0.91258195, 2);

                    
                    Program.Clear();
                    MonedasLogo();

                    Prefix('✓');
                    Console.WriteLine($"${value} usd: ${result} euros");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para regresar...");

                    Console.ReadKey();

                    return true;
                }
            }
            else if (selectedOption == 2)
            {

                Console.CursorVisible = false;

                string[] options = { "EUR$ a DOP$", "EUR$ a USD$" };
                Menu menuMonedas = new Menu("Moneda final", options);

                selectedOption = menuMonedas.Run(MonedasLogo);

                
                Program.Clear();
                MonedasLogo();
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
                        MonedasLogo();

                        Prefix();
                        Console.Write($"Introduzca la cantidad en euros: ");

                        Console.CursorVisible = true;
                        converted = double.TryParse(Console.ReadLine(), out value);
                        Console.CursorVisible = false;

                    } while (!converted || value < 0);
                }

                if (selectedOption == 0)
                {
                    result = Math.Round(value * 59.9182, 2);

                    
                    Program.Clear();
                    MonedasLogo();

                    Prefix('✓');
                    Console.WriteLine($"${value} euros: ${result} dop");
                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para regresar...");

                    Console.ReadKey();

                    return true;
                }
                else
                {
                    result = Math.Round(value * 1.09646, 2);

                    
                    Program.Clear();
                    MonedasLogo();

                    Prefix('✓');
                    Console.WriteLine($"${value} euros: ${result} usd");

                    Prefix();
                    Console.WriteLine($"Presione cualquier tecla para regresar...");

                    Console.ReadKey();

                    return true;
                }
            }
            else
            {
                Prefix('!');
                Console.WriteLine("Conversor monedas options error");
            }

            return false;
        }
    }
}