using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.Negocio;

namespace LINQ
{
    class Program
    {           
        static void Main(string[] args)
        {
            UsuariosCRUD Usuarios = new UsuariosCRUD();
            string confirmar = string.Empty;
            int opcion_menu = 0;
            do
            {
                Console.WriteLine("Que desea hacer con la lista Usuario:");
                Console.WriteLine("1. Buscar:");
                Console.WriteLine("2. Eliminar:");
                Console.WriteLine("3. Agregar:");
                Console.WriteLine("4. Actualizar");
                opcion_menu = Convert.ToInt32(Console.ReadLine());
                switch (opcion_menu)
                {
                    case 1:
                        Usuarios.Menu_Buscar();                        
                        break;
                    case 2:
                        Usuarios.Menu_Eliminar();
                        break;
                    case 3:
                        Usuarios.Menu_Insertar();
                        break;
                    case 4:
                        Usuarios.Menu_Actualizar();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Desea realizar otra operacion? s/n");
                confirmar = Console.ReadLine();
            }
            while (confirmar == "s");           
        }
            }
}
