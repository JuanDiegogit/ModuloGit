using API.Models;
using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class verIntentos : Form
    {
        public  verIntentos(Users users)
        {
            InitializeComponent();

            label1.Text = String.Format("Hola {0}, Bienvenido al sistema automaticado\nde Amonic airlines", users.FirstName);
            cantidadDeIntentos(users);
        }

        public async void cantidadDeIntentos(Users users)
        {
            Respuesta<IEnumerable<intentosFallido>> respuesta = await Respuesta<IEnumerable<intentosFallido>>.GetRespuesta<IEnumerable<intentosFallido>>(await Crud.Get("api/intentofallidos"));

            label2.Text = String.Format("tuvo {0} intentos fallidos", respuesta.Objeto.Count(T => T.UsuarioID == users.ID));

           
        }
        private void verIntentos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CambiarContraseña() { StartPosition = FormStartPosition.CenterScreen }.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
