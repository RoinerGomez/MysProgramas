using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.Modelo;

namespace LINQ.Negocio
{
    class UsuariosCRUD
    {
        string buscarvalor = string.Empty;
        int tipovalor = 0;
        List<Usuario> Usuarios = new List<Usuario>();
        public UsuariosCRUD()
        {            
            Usuarios.Add(new Usuario { cedula = 123, nombres = "Leonardo", apellidos = "Torres", correo = "latorres505@misena.edu.co" });
            Usuarios.Add(new Usuario { cedula = 124, nombres = "Rosa", apellidos = "Nuñez", correo = "rnunez505@misena.edu.co" });
            Usuarios.Add(new Usuario { cedula = 125, nombres = "Jose", apellidos = "Hernandez", correo = "jhernandez505@misena.edu.co" });
            Usuarios.Add(new Usuario { cedula = 126, nombres = "Roiner", apellidos = "Gomez", correo = "rgomez505@misena.edu.co" });            
        }
        public void BuscarLista(string valorstring, int valorentero)
        { 
            var UsuariosList = from u in Usuarios                              
                               select u;
            switch (valorentero)
            { 
                case 1:
                    UsuariosList = from u in Usuarios
                                       where u.cedula == Convert.ToInt32(valorstring)
                                       select u;
                    break;
                case 2:
                    UsuariosList = from u in Usuarios
                                       where u.nombres.Contains(valorstring)
                                       select u;
                    break;
                case 3:
                    UsuariosList = from u in Usuarios
                                       where u.apellidos.Contains(valorstring)
                                       select u;
                    break;
                case 4:
                    UsuariosList = from u in Usuarios
                                       where u.correo.Contains(valorstring)
                                       select u;
                    break;
                default:
                    break;
                }            
            foreach (var usu in UsuariosList)
            {
                Console.WriteLine("Cedula {0}, Nombres {1}, Apellidos {2}, Correo {3}", usu.cedula, usu.nombres, usu.apellidos, usu.correo);
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();            
        }
        public void EliminarUsuario(string valorstring, int valorentero)
        {
            List<Usuario> list = Usuarios.ToList();
            switch (valorentero)
                {                    
                    case 1:
                    foreach (var UsuariosC in list.Where(s => s.cedula == Convert.ToInt32(valorstring)))
                    {
                        Usuarios.Remove(UsuariosC);
                    }
                    break;                    
                case 2:
                    foreach (var UsuariosN in list.Where(s => s.nombres.Contains(valorstring)))
                    {
                        Usuarios.Remove(UsuariosN);
                    }
                    break;
                    case 3:
                    foreach (var UsuariosA in list.Where(s => s.apellidos.Contains(valorstring)))
                    {
                        Usuarios.Remove(UsuariosA);
                    }
                    break;
                case 4:
                    foreach (var UsuariosC in list.Where(s => s.correo == valorstring))
                    { 
                        Usuarios.Remove(UsuariosC);
                    }
                    break;
                default:
                        break;
                }               
            foreach (var usu in Usuarios)
                {
                    Console.WriteLine("Cedula {0}, Nombres {1}, Apellidos {2}, Correo {3}", usu.cedula, usu.nombres, usu.apellidos, usu.correo);
                }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void InsertarUsuario(int pcedula, string pnombre, string papellido, string pcorreo)
        {
            Usuarios.Add(new Usuario
            {
                cedula = pcedula,
                nombres = pnombre,
                apellidos = papellido,
                correo = pcorreo
            });
            foreach (var usu in Usuarios)
            {
                Console.WriteLine("Cedula {0}, Nombres {1}, Apellidos {2}, Correo {3}", usu.cedula, usu.nombres, usu.apellidos, usu.correo);
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void ActualizarUsuario(int pcedula)
        {
            int vcedula;
            Dictionary<int,string> Datos_Valores = new Dictionary<int, string>();
            Datos_Valores.Add(1,"Cedula");
            Datos_Valores.Add(2,"Nombres");
            Datos_Valores.Add(3,"Apellidos");
            Datos_Valores.Add(4,"Correo");            
            string vnombre;
            string vapellido;
            string vcorreo;
            string confirmar="s";
            string vdicc = string.Empty;
            var validarusuario = from c in Usuarios
                                 where c.cedula == pcedula
                                 select c;
            if (validarusuario.Count() >= 1)
            {
                for (int i=1; i<=4; i++)
                {
                    if (confirmar == "s")
                    { 
                                        
                    switch (i)
                    {
                        case 1:
                            Console.WriteLine("Digite la Cedula: ");
                            vcedula = Convert.ToInt32(Console.ReadLine());
                            foreach (var item in Usuarios.Where(w => w.cedula == pcedula ))
                            {
                                item.cedula = vcedula;
                                    pcedula = vcedula;
                            }                                                     
                            break;
                        case 2:
                            Console.WriteLine("Digite los nombres: ");
                            vnombre = Console.ReadLine();
                            foreach (var item1 in Usuarios.Where(w => w.cedula == pcedula))
                            {
                                item1.nombres = vnombre;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Digite los apellidos: ");
                            vapellido = Console.ReadLine();
                            foreach (var item2 in Usuarios.Where(w => w.cedula == pcedula))
                            {
                                    item2.apellidos = vapellido;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Digite el correo: ");
                            vcorreo = Console.ReadLine();
                            foreach (var item3 in Usuarios.Where(w => w.cedula == pcedula))
                            {
                                item3.correo = vcorreo;
                            }
                            break;
                        default:
                            break;
                    }
                    }
                    if (i<4)
                    { 
                        vdicc = Datos_Valores[i + 1];
                        Console.WriteLine("Dese actualizar {0} s/n,", vdicc);
                        confirmar = Console.ReadLine();
                    }
                }                
            }
            foreach (var usu in Usuarios)
            {
                Console.WriteLine("Cedula {0}, Nombres {1}, Apellidos {2}, Correo {3}", usu.cedula, usu.nombres, usu.apellidos, usu.correo);
            }
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }
        public void Menu_Buscar()
        {
            //Menu Buscar//
            Console.WriteLine("Desea buscar por:  1. Cedula, 2. Nombres, 3. Apellidos, 4. Correo");
            tipovalor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite el valor a buscar");
            buscarvalor = Console.ReadLine();
            BuscarLista(buscarvalor, tipovalor);
            //Fin Menu Buscar//
        }
        public void Menu_Eliminar()
        {
            //Menu Buscar//
            Console.WriteLine("Desea eliminar por:  1. Cedula, 2. Nombres, 3. Apellidos, 4. Correo");
            tipovalor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite el valor a eliminar");
            buscarvalor = Console.ReadLine();
            EliminarUsuario(buscarvalor, tipovalor);
            //Fin Menu Buscar//
        }
        public void Menu_Insertar()
        {            
            int cedula;
            string nombre;
            string apellido;
            string correo;
            Console.WriteLine("A continuacion digite los datos del usuario a agregar.");
            Console.WriteLine("Digite la Cedula: ");
            cedula = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite el Nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Digite el Apellido: ");
            apellido = Console.ReadLine();
            Console.WriteLine("Digite el Correo: ");
            correo = Console.ReadLine();            
            InsertarUsuario(cedula,nombre,apellido,correo);
            //Fin Menu Buscar//
        }
        public void Menu_Actualizar()
        {
            int cedula;
            Console.WriteLine("Digite la cedula del usuario a actualizar.");
            cedula = Convert.ToInt32(Console.ReadLine());           
            ActualizarUsuario(cedula);
            //Fin Menu Buscar//
        }
    }
}
