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
    internal class Utilities
    {

        private static void UtilitiesLogo()
        {
            Console.WriteLine(@"


        ██╗   ██╗████████╗██╗██╗     ██╗████████╗██╗███████╗███████╗                                    
        ██║   ██║╚══██╔══╝██║██║     ██║╚══██╔══╝██║██╔════╝██╔════╝                                    
        ██║   ██║   ██║   ██║██║     ██║   ██║   ██║█████╗  ███████╗                                    
        ██║   ██║   ██║   ██║██║     ██║   ██║   ██║██╔══╝  ╚════██║                                    
        ╚██████╔╝   ██║   ██║███████╗██║   ██║   ██║███████╗███████║                                    
         ╚═════╝    ╚═╝   ╚═╝╚══════╝╚═╝   ╚═╝   ╚═╝╚══════╝╚══════╝                                    ", Color.BlueViolet);
        }

        public static bool Menu(ConsoleKeyInfo key)
        {
            bool success = false;

            Console.Title = "[Task/Utilities]";
            Console.CursorVisible = false;

            string[] options = { "Conversor de unidades", "Calculadora" };
            Menu menuUtilities = new Menu("", options);

            int selectedOption = menuUtilities.Run(UtilitiesLogo);

            
            //UtilitiesLogo();
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
                            success = Conversor.ConversorOptions(key);
                        } while (!success);

                        break;

                    case 1:
                        do
                        {
                            success = Calculadora.Menu(key);
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