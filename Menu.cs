using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;


namespace Final
{
    internal class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        private bool Lista;
        private bool ContactDetails;

        public Menu(string prompt, string[] options, bool ContactDetails = false)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
            this.ContactDetails = ContactDetails;
        }

        public Menu(string prompt, bool ContactDetails = false)
        {
            Prompt = prompt;
            SelectedIndex = 0;
            Lista = true;
            this.ContactDetails = ContactDetails;
        }

        public int Run(Action Logo, int salir = 0, int index = 0)
        {
            ConsoleKeyInfo keyPressed;
            Console.CursorVisible = false;
            //Program.Clear();

            if (ContactDetails == true)
            {
                do
                {
                    string telefono = Program.contacts[index].Telefono;
                    
                    Program.Clear();
                    Logo();

                    Prefix();
                    Console.WriteLine($"Nombre: {Program.contacts[index].Name}");
                    Prefix2();
                    Console.WriteLine($"Apellido: {Program.contacts[index].Apellido}");
                    Prefix2();
                    Console.WriteLine($"Teléfono: +1 {telefono.Substring(0,3)}-{telefono.Substring(3,3)}-{telefono.Substring(6,4)}");
                    Prefix2();
                    Console.WriteLine($"Dirección: {Program.contacts[index].Direccion}");
                    Prefix2();
                    Console.WriteLine($"Email: {Program.contacts[index].Email}");

                    DisplayOptions(salir);

                    keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Program.Clear();
                        return -1;
                    }
                    else if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        Program.Clear();
                        return -2;
                    }
                    else if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        Program.Clear();
                        SelectedIndex--;

                        if (SelectedIndex < 0)
                        {
                            SelectedIndex = Options.Length - 1;
                        }
                    }
                    else if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        Program.Clear();
                        SelectedIndex++;

                        if (SelectedIndex == Options.Length || SelectedIndex == 0)
                        {
                            SelectedIndex = 0;
                        }
                    }
                } while (keyPressed.Key != ConsoleKey.Enter && keyPressed.Key != ConsoleKey.Escape);

                Program.Clear();
            }
            else if (!Lista)
            {
                do
                {
                    
                    Program.Clear();
                    Logo();

                    DisplayOptions(salir);

                    keyPressed = Console.ReadKey(true);

                    if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Program.Clear();
                        return -1;
                    }
                    else if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        Program.Clear();
                        return -2;
                    }
                    else if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        Program.Clear();
                        SelectedIndex--;

                        if (SelectedIndex < 0)
                        {
                            SelectedIndex = Options.Length - 1;
                        }
                    }
                    else if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        Program.Clear();
                        SelectedIndex++;

                        if (SelectedIndex == Options.Length || SelectedIndex == 0)
                        {
                            SelectedIndex = 0;
                        }
                    }
                } while (keyPressed.Key != ConsoleKey.Enter && keyPressed.Key != ConsoleKey.Escape);

                Program.Clear();
            }
            else
            {
                do
                {
                    
                    Program.Clear();
                    Logo();
                    DisplayLista();

                    keyPressed = Console.ReadKey(true);

                    if (Program.contacts.Count == 0)
                    {
                        Program.Clear();
                        return -2;
                    }
                    else if (keyPressed.Key == ConsoleKey.Escape)
                    {
                        Program.Clear();
                        return -1;
                    }
                    else if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        Program.Clear();

                        return -2;
                    }
                    else if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        Program.Clear();
                        SelectedIndex--;

                        if (SelectedIndex < 0)
                        {
                            SelectedIndex = Program.contacts.Count - 1;
                        }
                    }
                    else if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        Program.Clear();
                        SelectedIndex++;

                        if (SelectedIndex == Program.contacts.Count || SelectedIndex == 0)
                        {
                            SelectedIndex = 0;
                        }
                    }
                } while (keyPressed.Key != ConsoleKey.Enter && keyPressed.Key != ConsoleKey.Escape && keyPressed.Key != ConsoleKey.LeftArrow);

                Program.Clear();
            }

            ////Program.Clear();

            return SelectedIndex;
        }

        private void DisplayOptions(int salir = 0, string character = " ")
        {
            Console.CursorVisible = false;

            ////Program.Clear();
            //Program.Clear();

            if (Prompt != "")
            {
                Prefix();
                Console.WriteLine($"{Prompt}                        \n");
            }
            else
            {
                Console.WriteLine($"{Prompt}                        ");
            }

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];

                if (Options[i].Contains('['))
                {
                    character = string.Empty;
                }

                if (i == SelectedIndex)
                {
                    Console.Write($"\t[");
                    Console.Write("→", Color.BlueViolet);
                    Console.Write($"] ");
                    Console.WriteLine($"{currentOption}                             ", Color.BlueViolet);
                }
                else
                {
                    Console.WriteLine($"\t[{character}] {currentOption}                                 ");
                }
            }

            if (salir == 0)
            {
                Prefix('<');
                Console.WriteLine($"Retroceder                                              ");
            }
            else if (salir == 1)
            {
                Prefix('・');
                Console.WriteLine($"Escape para salir                                       ");
            }
        }

        private void DisplayLista(string character = " ")
        {
            Console.CursorVisible = false;

            if (Prompt != "")
            {
                Prefix();
                Console.WriteLine($"{Prompt}\n");
            }
            else
            {
                Console.WriteLine($"{Prompt}");
            }

            int i = 0;

            foreach (var c in Program.contacts)
            {
                string currentOption = $"{Program.contacts[i].Name} {Program.contacts[i].Apellido}";

                if (i == SelectedIndex)
                {
                    Console.Write($"\t[");
                    Console.Write("→", Color.BlueViolet);
                    Console.Write($"] ");
                    Console.WriteLine($"{currentOption}                                             ", Color.BlueViolet);
                }
                else
                {
                    Console.WriteLine($"\t[{character}] {currentOption}                                     ");
                }

                i++;
            }

            Prefix('<');
            Console.WriteLine($"Retroceder");
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