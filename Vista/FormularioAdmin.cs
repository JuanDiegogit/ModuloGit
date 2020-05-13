using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Models;
using Controlador;
using Vista.TablaView;

namespace Vista
{
    public partial class FormularioAdmin : Form
    {
        public FormularioAdmin()
        {
            InitializeComponent();
        }
        private async Task llenarComboOficina(ComboBox  comboBox)
        {
            comboBox.DataSource = null;
            Respuesta<IEnumerable<Offices>> respuesta =await Respuesta < IEnumerable < Offices >>.GetRespuesta<IEnumerable<Offices>> (await Crud.Get("api/offices"));
            IEnumerable<Offices> offices = respuesta.Objeto;
            List<Offices> listaDeOficinas = offices.ToList();
            listaDeOficinas.Insert(0,new Offices() { Title = "Todas"});
            comboBox.DataSource = listaDeOficinas;
            comboBox.DisplayMember = "Title";
            comboBox.ValueMember = "ID";
       
        }
        public async Task llenarTabla(DataGridView tabla,int? filtro = null)
        {

            tabla.DataSource = null;
            Respuesta<IEnumerable<Users>> respuesta = await Respuesta<IEnumerable<Users>>.GetRespuesta<IEnumerable<Users>>(await Crud.Get("api/users"));
            IEnumerable<Users> users = respuesta.Objeto;

            if (filtro != null)
            {
                users = users.Where(T=>T.OfficeID == (int) filtro );

            }
           
            List<UserView> listaUsuario = users.Select(e => new UserView()
            {
                ID = e.ID,
                Nombre = e.FirstName,
                Apellido = e.LastName,
                Correo = e.Email,
                Oficina = e.Offices != null ? e.Offices.Title : "",
                Rol = e.Roles != null ? e.Roles.Title : "",
                Edad = DateTime.Now.Year - e.Birthdate.Value.Year,
                Estado = e.Active != null ? (int)e.Active : 0
            }).ToList();
            tabla.DataSource = listaUsuario;
            tabla.Columns["ID"].Visible = false;
            tabla.Columns["Estado"].Visible = false;
            comboOficina.Enabled = true;

        }
        private async void FormularioAdmin_Load(object sender, EventArgs e)
        {
           await llenarComboOficina(comboOficina);
        }

        private async void comboOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboOficina.Enabled = false;
            if(comboOficina.SelectedIndex == 0)
            {
              await  llenarTabla(TablaUsuario);
            }
            else
            {
                await llenarTabla(TablaUsuario,(int)comboOficina.SelectedValue);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
