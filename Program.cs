using Colorful;
using Console = Colorful.Console;
using System.Drawing;

namespace Final
{
    internal class Program
    {
        public static List<Contacto> contacts = new List<Contacto>();
        public static List<Evento> events = new List<Evento>();

        public static void Clear()
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(@"                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        
                                                                                                                                                                                                        ");
            Console.SetCursorPosition(0, 0);
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true)
            {
                var key = new ConsoleKeyInfo();
                bool success = false;

                Console.Title = "[Task]";

                Console.CursorVisible = false;

                string[] options = { "Agenda", "Utilities" };
                Menu main = new Menu("", options);

                int selectedOption = main.Run(PrintLogo, 1);

                //Program.Clear();
                //PrintLogo();
                Console.WriteLine("");

                if (selectedOption == -1)
                {
                    Environment.Exit(0);
                }

                switch (selectedOption)
                {
                    case 0:
                        do
                        {
                            success = Agenda.Menu(key);
                        } while (!success);
                        break;

                    case 1:
                        do
                        {
                            success = Utilities.Menu(key);
                        } while (!success);
                        break;

                    default:

                        break;
                }
            }
            
        }

        public static void PrintLogo()
        {
            Console.WriteLine(@"


        ███████╗██╗███╗   ██╗ █████╗ ██╗                                                                
        ██╔════╝██║████╗  ██║██╔══██╗██║                                                        
        █████╗  ██║██╔██╗ ██║███████║██║                                                            
        ██╔══╝  ██║██║╚██╗██║██╔══██║██║                                                                    
        ██║     ██║██║ ╚████║██║  ██║███████╗                                                               
        ╚═╝     ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝                                                   ", Color.BlueViolet);

        }
    }
}