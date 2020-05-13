using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vista.TablaView
{
    class UserView
    {
        
        public int ID { set; get; }
        public String Nombre { set; get; }
        public String Apellido { set; get; }
        public int Edad { set; get; }

        public String Rol { set; get; }
        [DisplayName("Direccion de correo")]
        public String Correo { set; get; }
        public String Oficina { set; get; }
        public int Estado { set; get; }
    }
}
