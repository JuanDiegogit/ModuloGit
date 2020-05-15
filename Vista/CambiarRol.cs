using API.Models;
using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class CambiarRol : Form
    {
        public Users USUARIO { set; get; }
        public CambiarRol()
        {
            InitializeComponent();
        }
        private async void llenarComboBoxConRoles(ComboBox  comboBox)
        {
            Respuesta<IEnumerable<Roles>> respuesta = await Respuesta<IEnumerable<Roles>>.GetRespuesta<IEnumerable<Roles>>(await Crud.Get("api/roles"));
            comboBox.DataSource = respuesta.Objeto;
            comboBox.DisplayMember = "Title";
            comboBox.ValueMember = "ID";
            comboBox.SelectedValue = USUARIO.ID;
        }
        private async void CambiarRol_Load(object sender, EventArgs e)
        {
          llenarComboBoxConRoles(comboBox1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public async Task<Users> GetUserAsync(int ID)
        {
            Respuesta<Users> respuesta = await Respuesta<Users>.GetRespuesta<Users>(await Crud.Get("api/users", ID));

            return respuesta.Objeto;
        }
        private async Task<bool> CambiarRolAsync(int ID)
        {
            Users users = await GetUserAsync(ID);
            users.RoleID =(int) comboBox1.SelectedValue;
            users.Roles = null;
            Respuesta<Users> respuesta = await Respuesta<Users>.GetRespuesta<Users>(await Crud.Put<Users>("api/users", ID, users));
            if (respuesta.Mensaje.Equals(HttpStatusCode.NoContent.ToString()))
            {

                return true;
            }

            return false;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
  
           if ( await CambiarRolAsync(USUARIO.ID)) {
                MessageBox.Show("Se cambio el rol exitosamente");
                this.Close();
            }
            this.Close();
        }
    }
}
