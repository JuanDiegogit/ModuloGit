using API.Models;
using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class CambiarContraseña : Form
    {
        public Users USUARIO { set; get; }
        public CambiarContraseña()
        {
            InitializeComponent();
            USUARIO = Login.USUARIO_ACTIVO;
          
        }

        private async void CambiarContraseña_Load(object sender, EventArgs e)
        {
            USUARIO = (await Respuesta<Users>.GetRespuesta<Users>(await Crud.Get("api/users", USUARIO.ID))).Objeto;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text ==""|| textBox3.Text=="")
            {
                MessageBox.Show("Debe llenar todas los campos");
                return;
            }
            
            if(USUARIO.Password != textBox1.Text)
            {
                MessageBox.Show("La contraseña Anterior no coincide con la guardada en la base de datos");
                return;
            }
            if (textBox1.Text == textBox2.Text)
            {
                MessageBox.Show("la contraseña nueva no debe ser igual a la anterior");
                return;
            }
            if (textBox2.Text!= textBox3.Text)
            {
                MessageBox.Show("La contraseña no coincide");
                return;
            }
            Users users = USUARIO;
            users.Admin = null;
            users.intentosFallido = null;
            users.User = null;
            users.Roles = null;
            users.Offices = null;
            users.Password = textBox2.Text;
            Respuesta<Users> respuesta = await Respuesta<Users>.GetRespuesta<Users>(await Crud.Put<Users>("api/users", users.ID, users));

            if (respuesta.Mensaje.Equals(HttpStatusCode.NoContent.ToString()))
            { 
                 
                new verIntentos(Login.USUARIO_ACTIVO).Show();
                this.Close();
                MessageBox.Show("Se cambio correctamente");
                return;
            }

            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            textBox3.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
