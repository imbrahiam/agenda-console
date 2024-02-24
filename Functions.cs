using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    internal partial class Contacto
    {
        public static bool ContactoMenu(ConsoleKeyInfo key, int index = 0)
        {
            bool success = false;

            Console.Title = $"[Task/Agenda/Contactos/{Program.contacts[index].Name} {Program.contacts[index].Apellido}]";
            Console.CursorVisible = false;

            string[] options = { "Editar contacto", "Eliminar contacto" };
            Menu menuContactoDeep = new Menu("", options, true);

            int selectedOption = menuContactoDeep.Run(ContactosLogo, 0, index);

            
            //ContactosLogo();
            Console.WriteLine("");

            if (selectedOption == -2)
            {
                return true;
            }
            else if(selectedOption == 0)
            {
                EditarContacto(index);
            }
            else
            {
                Program.contacts.RemoveAt(index);
                return true;
            }

            return false;
        }
    }
}
