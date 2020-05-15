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
    public partial class AgregarUsuario : Form
    {
        public AgregarUsuario()
        {
            InitializeComponent();
        }
        private async void llenarComboBoxConRoles(ComboBox comboBox)
        {
            Respuesta<IEnumerable<Roles>> respuesta = await Respuesta<IEnumerable<Roles>>.GetRespuesta<IEnumerable<Roles>>(await Crud.Get("api/roles"));
            comboBox.DataSource = respuesta.Objeto;
            comboBox.DisplayMember = "Title";
            comboBox.ValueMember = "ID";
        }
        private void AgregarUsuario_Load(object sender, EventArgs e)
        {
            llenarComboBoxConRoles(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool isValido(List<Control> controls)
        {

            foreach (Control item in controls)
            {
                if(item.Text == "")
                {
                    return false;
                }
            }


            return true;
        }
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (isValido(new List < Control > {textBox1,textBox2,textBox3,textBox4}))
            {
                Users usuario = new Users {
                    Birthdate = dateTimePicker1.Value,
                     Active = 1,
                     Email = textBox1.Text,
                     FirstName = textBox2.Text,
                     LastName = textBox3.Text,
                     OfficeID = null,
                     Password = textBox4.Text,
                     RoleID = (int)comboBox1.SelectedValue
                    
                     

                };
                Respuesta<Users> respuesta = await Respuesta<Users>.GetRespuesta<Users>(await Crud.Post<Users>("api/users",usuario));

                if (respuesta.Objeto.ID != 0)
                {
                    MessageBox.Show("Se guardo correctamente");
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
