using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using Colorful;
using Console = Colorful.Console;

namespace Final
{
    internal partial class Contacto
    {
        //public static int AmountOfContacts { get; private set; } = 0;
        public string Name { get; private set; }
        public string Apellido { get; private set; }
        public string Telefono { get; private set; }
        public string Direccion { get; private set; }
        public string Email { get; private set; }

        public Contacto(string name, string apellido, string telefono, string direccion, string email)
        {
            this.Name = name;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Email = email;
        }

        public override string ToString()
        {
            return @$"{Name} {Apellido}, {Telefono}, {Direccion}, {Email}";
        }

        private static void ContactosLogo()
        {
            Console.WriteLine(@"


         ██████╗ ██████╗ ███╗   ██╗████████╗ █████╗  ██████╗████████╗ ██████╗ ███████╗
        ██╔════╝██╔═══██╗████╗  ██║╚══██╔══╝██╔══██╗██╔════╝╚══██╔══╝██╔═══██╗██╔════╝
        ██║     ██║   ██║██╔██╗ ██║   ██║   ███████║██║        ██║   ██║   ██║███████╗
        ██║     ██║   ██║██║╚██╗██║   ██║   ██╔══██║██║        ██║   ██║   ██║╚════██║
        ╚██████╗╚██████╔╝██║ ╚████║   ██║   ██║  ██║╚██████╗   ██║   ╚██████╔╝███████║
         ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚══════╝", Color.BlueViolet);
        }

        public static bool Menu(ConsoleKeyInfo key)
        {
            bool wentBack = false;

            do
            {
                Console.Title = "[Task/Agenda/Contactos]";

                string[] options = { "Nuevo contacto", "Lista de contactos", "Buscar Contacto" };
                Menu menuContactos = new Menu("", options);

                int selectedOption = menuContactos.Run(ContactosLogo);

                
                //ContactosLogo();
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
                            NuevoContacto();
                            break;

                        case 1:
                            do
                            {
                                wentBack = ListaContactos(key);
                            } while (!wentBack);
                            break;

                        case 2:
                            do
                            {
                                wentBack = BuscarContactos(key);
                            } while (!wentBack);
                            break;

                        default:

                            break;
                    }
                }

            } while (!wentBack);

            return false;
        }

        private static void BusquedaLogo()
        {
            Console.WriteLine(@"


        ██████╗ ██╗   ██╗███████╗ ██████╗ ██╗   ██╗███████╗██████╗  █████╗                          
        ██╔══██╗██║   ██║██╔════╝██╔═══██╗██║   ██║██╔════╝██╔══██╗██╔══██╗                         
        ██████╔╝██║   ██║███████╗██║   ██║██║   ██║█████╗  ██║  ██║███████║                         
        ██╔══██╗██║   ██║╚════██║██║▄▄ ██║██║   ██║██╔══╝  ██║  ██║██╔══██║                         
        ██████╔╝╚██████╔╝███████║╚██████╔╝╚██████╔╝███████╗██████╔╝██║  ██║                         
        ╚═════╝  ╚═════╝ ╚══════╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝╚═════╝ ╚═╝  ╚═╝                         ", Color.BlueViolet);
        }

        public static bool BuscarContactos(ConsoleKeyInfo key)
        {
            Console.Title = "[Task/Agenda/Contactos/Search]";

            string search;

            do
            {

                Program.Clear();
                ContactosLogo();

                Prefix();
                Console.Write($"Busca lo que recuerdes del contacto: ");

                Console.CursorVisible = true;
                search = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(search));

            if(Program.contacts.Count != 0)
            {
                Type myType = Program.contacts[0].GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                bool match = false;
                int i = 0;

                foreach (var contact in Program.contacts)
                {
                    foreach (PropertyInfo prop in props)
                    {
                        object propValue = prop.GetValue(contact, null)!;
                        string val = Convert.ToString(propValue)!;

                        if (val == search || val.Contains(search))
                        {
                            match = true;
                            i++;

                            Prefix('✓');
                            Menu matched = new Menu($"[{i} Resultados encontrados]");

                            int selectedOption = matched.Run(BusquedaLogo);

                            if (selectedOption == -2)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                }

                if (!match)
                {
                    
                }
            }
            else
            {
                Prefix('!');
                Console.WriteLine($"No se ha encontrado ningun resultado para su busqueda...");
            }

            Console.ReadKey();

            return true;
        }


        public static bool ListaContactos(ConsoleKeyInfo key)
        {
            Console.Title = "[Task/Agenda/Contactos/Lista]";
            
            Program.Clear();
            ContactosLogo();

            bool success = false;

            Menu listaContactos = new Menu($"[Actualmente tienes {Program.contacts.Count} contactos]");
            int selectedOption = listaContactos.Run(ContactosLogo);

            if (selectedOption == -2)
            {
                return true;
            }
            else
            {
                do
                {
                    success = Contacto.ContactoMenu(key, selectedOption);
                } while (!success);
            }

            return false;
        }

        public static void NuevoContacto()
        {

            Console.CursorVisible = false;

            string name = "a", apellido = "e", telefono = "i", direccion = "o", email = "u";

            do
            {
                
                Program.Clear();
                ContactosLogo();

                Prefix();
                Console.Write($"Nombre: ");

                Console.CursorVisible = true;
                name = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(name));

            name = Regex.Replace(name, "[^a-zA-Z ]", ""); //^
            //name = Regex.Replace(name, "[0-9]", ""); //^

            
            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");

            do
            {
                if (String.IsNullOrEmpty(apellido))
                {
                    
                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                }

                Prefix2();
                Console.Write($"Apellido: ");

                Console.CursorVisible = true;
                apellido = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(apellido));

            apellido = Regex.Replace(apellido, "[^a-zA-Z ]", ""); //^

            
            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");
            Prefix2('✓');
            Console.WriteLine($"Apellido: {apellido}");

            do
            {
                if (String.IsNullOrEmpty(telefono) || telefono.Length != 10)
                {
                    
                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                    Prefix2('✓');
                    Console.WriteLine($"Apellido: {apellido}");
                }

                Prefix2();
                Console.Write($"Telefono: ");

                Console.CursorVisible = true;
                telefono = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(telefono) || telefono.Length != 10);

            //telefono = Regex.Replace(telefono, "[^0-9]", ""); //^

            
            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");
            Prefix2('✓');
            Console.WriteLine($"Apellido: {apellido}");
            Prefix2('✓');
            Console.WriteLine($"Telefono: {telefono}");

            do
            {
                if (String.IsNullOrEmpty(direccion))
                {
                    
                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                    Prefix2('✓');
                    Console.WriteLine($"Apellido: {apellido}");
                    Prefix2('✓');
                    Console.WriteLine($"Telefono: {telefono}");
                }

                Prefix2();
                Console.Write($"Direccion: ");

                Console.CursorVisible = true;
                direccion = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(direccion));

            
            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");
            Prefix2('✓');
            Console.WriteLine($"Apellido: {apellido}");
            Prefix2('✓');
            Console.WriteLine($"Telefono: {telefono}");
            Prefix2('✓');
            Console.WriteLine($"Direccion: {direccion}");

            do
            {
                if (String.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.'))
                {
                    
                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                    Prefix2('✓');
                    Console.WriteLine($"Apellido: {apellido}");
                    Prefix2('✓');
                    Console.WriteLine($"Telefono: {telefono}");
                    Prefix2('✓');
                    Console.WriteLine($"Direccion: {direccion}");
                }

                Prefix2();
                Console.Write("Email: ");

                Console.CursorVisible = true;
                email = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.'));

            Program.contacts.Add(new Contacto(name, apellido, telefono, direccion, email));
        }

        public static void EditarContacto(int index)
        {

            Console.CursorVisible = false;

            string name = "a", apellido = "e", telefono = "i", direccion = "o", email = "u";

            do
            {

                Program.Clear();
                ContactosLogo(); Console.CursorVisible = true;

                Prefix();
                Console.Write($"Nombre: ");

                Console.CursorVisible = true;
                name = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(name));

            name = Regex.Replace(name, "[^a-zA-Z]", ""); //^
                                                         //name = Regex.Replace(name, "[0-9]", ""); //^


            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");

            do
            {
                if (String.IsNullOrEmpty(apellido))
                {

                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                }

                Prefix2();
                Console.Write($"Apellido: ");

                Console.CursorVisible = true;
                apellido = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(apellido));

            apellido = Regex.Replace(apellido, "[^a-zA-Z]", ""); //^


            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");
            Prefix2('✓');
            Console.WriteLine($"Apellido: {apellido}");

            do
            {
                if (String.IsNullOrEmpty(telefono) || telefono.Length != 10)
                {

                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                    Prefix2('✓');
                    Console.WriteLine($"Apellido: {apellido}");
                }

                Prefix2();
                Console.Write($"Telefono: ");

                Console.CursorVisible = true;
                telefono = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(telefono) || telefono.Length != 10);

            //telefono = Regex.Replace(telefono, "[^0-9]", ""); //^


            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");
            Prefix2('✓');
            Console.WriteLine($"Apellido: {apellido}");
            Prefix2('✓');
            Console.WriteLine($"Telefono: {telefono}");

            do
            {
                if (String.IsNullOrEmpty(direccion))
                {

                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                    Prefix2('✓');
                    Console.WriteLine($"Apellido: {apellido}");
                    Prefix2('✓');
                    Console.WriteLine($"Telefono: {telefono}");
                }

                Prefix2();
                Console.Write($"Direccion: ");

                Console.CursorVisible = true;
                direccion = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(direccion));


            Program.Clear();
            ContactosLogo();

            Prefix('✓');
            Console.WriteLine($"Nombre: {name}");
            Prefix2('✓');
            Console.WriteLine($"Apellido: {apellido}");
            Prefix2('✓');
            Console.WriteLine($"Telefono: {telefono}");
            Prefix2('✓');
            Console.WriteLine($"Direccion: {direccion}");

            do
            {
                if (String.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.'))
                {

                    Program.Clear();
                    ContactosLogo();

                    Prefix('✓');
                    Console.WriteLine($"Nombre: {name}");
                    Prefix2('✓');
                    Console.WriteLine($"Apellido: {apellido}");
                    Prefix2('✓');
                    Console.WriteLine($"Telefono: {telefono}");
                    Prefix2('✓');
                    Console.WriteLine($"Direccion: {direccion}");
                }

                Prefix2();
                Console.Write("Email: ");

                Console.CursorVisible = true;
                email = Console.ReadLine()!;
                Console.CursorVisible = false;

            } while (String.IsNullOrEmpty(email) || !email.Contains('@') || !email.Contains('.'));

            Program.contacts[index].Name = name;
            Program.contacts[index].Apellido = apellido;
            Program.contacts[index].Telefono = telefono;
            Program.contacts[index].Direccion = direccion;
            Program.contacts[index].Email = email;
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
