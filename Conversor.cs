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
        private static void ConversorL()
        {
            Console.WriteLine(@"


         ██████╗ ██████╗ ███╗   ██╗██╗   ██╗███████╗██████╗ ███████╗ ██████╗ ██████╗                                    
        ██╔════╝██╔═══██╗████╗  ██║██║   ██║██╔════╝██╔══██╗██╔════╝██╔═══██╗██╔══██╗                                   
        ██║     ██║   ██║██╔██╗ ██║██║   ██║█████╗  ██████╔╝███████╗██║   ██║██████╔╝                                   
        ██║     ██║   ██║██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██╔══██╗╚════██║██║   ██║██╔══██╗                                   
        ╚██████╗╚██████╔╝██║ ╚████║ ╚████╔╝ ███████╗██║  ██║███████║╚██████╔╝██║  ██║                                   
         ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝                                   ", Color.BlueViolet);
        }

        public static bool ConversorOptions(ConsoleKeyInfo key)
        {
            bool success;

            Console.Title = "[Task/Utilities/Conversor/]";

            Console.CursorVisible = false;

            string[] options = { "Temperatura", "Monedas" };
            Menu menuConversor = new Menu("", options);

            int selectedOption = menuConversor.Run(ConversorL);

            
            Program.Clear();
            //ConversorL();
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
                        do
                        {
                            success = TemperatureOptions(key);
                        } while (!success);

                        break;

                    case 1:
                        do
                        {
                            success = MoneyOptions(key);
                        } while (!success);
                        break;

                    default:

                        break;
                }
            }

            return false;
        }
    }
}
