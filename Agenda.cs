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
    internal static class Agenda
    {
        private static void AgendaLogo()
        {
            Console.WriteLine(@"


         █████╗  ██████╗ ███████╗███╗   ██╗██████╗  █████╗                                      
        ██╔══██╗██╔════╝ ██╔════╝████╗  ██║██╔══██╗██╔══██╗                                     
        ███████║██║  ███╗█████╗  ██╔██╗ ██║██║  ██║███████║                                     
        ██╔══██║██║   ██║██╔══╝  ██║╚██╗██║██║  ██║██╔══██║                                     
        ██║  ██║╚██████╔╝███████╗██║ ╚████║██████╔╝██║  ██║                                         
        ╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝╚═════╝ ╚═╝  ╚═╝                                     ", Color.BlueViolet);
        }

        public static bool Menu(ConsoleKeyInfo key)
        {
            bool success = false;

            do
            {
                Console.Title = "[Task/Agenda]";
                Console.CursorVisible = false;

                string[] options = { "Contactos", "Eventos" };
                Menu menuAgenda = new Menu("", options);

                int selectedOption = menuAgenda.Run(AgendaLogo);

                
                //AgendaLogo();
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
                                success = Contacto.Menu(key);
                            } while (!success);
                            
                            break;

                        case 1:
                            do
                            {
                                success = Contacto.Menu(key);
                            } while (!success);
                            break;

                        default:
                            
                            break;
                    }
                }
            } while (!success);

            return false;
        }
    }
}