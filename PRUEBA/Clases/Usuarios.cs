using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBA.Clases
{
    public class Usuarios
    {
        private string id_usuario;
        private string nombre_usuario;
        private string contraseña;



        public Usuarios()
        {
            id_usuario = string.Empty;
            nombre_usuario = string.Empty;
            contraseña = string.Empty;



        }

        public string ID_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre_usuario { get => nombre_usuario; set => nombre_usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }


    }
}
