using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using API.Models;
using Controlador;
using Vista.TablaView;

namespace Vista
{
    public partial class FormularioAdmin : Form
    {
        private int CANTIDAD_DE_FORMULARIO_ABIERTO { set; get; }
        public FormularioAdmin()
        {
            InitializeComponent();
        }
        public async Task<Users> GetUserAsync(int ID)
        {
            Respuesta<Users> respuesta = await Respuesta<Users>.GetRespuesta<Users>(await Crud.Get("api/users", ID));

            return respuesta.Objeto;
        }

        private void setHabilitar(bool activo, List<Control> controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = activo;
            }
        }
        private async Task<bool> CambiarEstadoAsync(int ID, bool activo)
        {
            Users users = await GetUserAsync(ID);
            users.Active = activo?1:0;
            Respuesta<Users> respuesta = await Respuesta<Users>.GetRespuesta<Users>(await Crud.Put<Users>("api/users", ID, users));
            if (respuesta.Mensaje.Equals(HttpStatusCode.NoContent.ToString()))
            {

                return true;
            }
            await MostrarAlerta(respuesta.Mensaje, Color.DarkGreen);
            return false;
        }
     
        private async Task suspenderCuenta() {


            setHabilitar(false,new List<Control>() {btnSuspender,TablaUsuario });

            int ID=0;
            int.TryParse(TablaUsuario.CurrentRow.Cells["ID"].Value.ToString(),  out ID);

           

            if ( await CambiarEstadoAsync(ID,false))
            {
                await InsertarUsuarioBloqueado(await GetUserAsync(ID));

                setHabilitar(true, new List<Control>() { btnSuspender, TablaUsuario });

                await filtrar();
                await MostrarAlerta("Se suspendio correctamente", Color.DarkGreen);

                return;
            }

            setHabilitar(true, new List<Control>() { btnSuspender, TablaUsuario });


            return;

           
        }

        private static async Task InsertarUsuarioBloqueado(Users users)
        {
            UsuarioBloqueados usuarioBloqueado = new UsuarioBloqueados
            {
                adminitradorID = Login.USUARIO_ACTIVO.ID,
                UsuarioID = users.ID,
                fechaYHora = DateTime.Now

            };
            await Crud.Post<UsuarioBloqueados>("api/UsuarioBloqueados", usuarioBloqueado);
        }

        private async Task RestablecerCuenta()
        {
            setHabilitar(false, new List<Control> { btnRestablecer, TablaUsuario });
         
            int ID = 0;
            int.TryParse(TablaUsuario.CurrentRow.Cells["ID"].Value.ToString(), out ID);

           
            if (await CambiarEstadoAsync(ID,true))
            {


                Respuesta<IEnumerable<UsuarioBloqueados>> respuestaUB = await Respuesta<IEnumerable<UsuarioBloqueados>>.GetRespuesta<IEnumerable<UsuarioBloqueados>>(await Crud.Get("api/usuarioBloqueados"));

                IEnumerable<UsuarioBloqueados> listaUsuarioBloqueados = respuestaUB.Objeto.Where(T=>T.UsuarioID == ID);
                foreach (UsuarioBloqueados usuarioB in listaUsuarioBloqueados)
                {
                    await Crud.Delete("api/usuarioBloqueados",usuarioB.ID);
                }

                setHabilitar(true, new List<Control> { btnRestablecer, TablaUsuario });

                await filtrar();
                await MostrarAlerta("Se restablecio correctamente", Color.DarkGreen);
              
                return;
            }

            setHabilitar(true, new List<Control> { btnRestablecer, TablaUsuario });

            return;


        }
        private async Task MostrarAlerta(string mensaje,Color? color = null)
        {
            lblAlerta.Visible = true;
            lblAlerta.ForeColor = (Color) color;
            if (color == null)
            {
                lblAlerta.ForeColor = Color.DarkGreen;
            }
            lblAlerta.Text = mensaje;
           
            lblAlerta.Visible = await Task<bool>.Run(() =>
            {
                Thread.Sleep(5000);

                return false;

            });
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
                Estado = e.Active != null ? (int)e.Active : 1
            }).ToList();
            tabla.DataSource = listaUsuario;
            tabla.Columns["ID"].Visible = false;
            tabla.Columns["Estado"].Visible = false;
            comboOficina.Enabled = true;

        }
        private async void FormularioAdmin_Load(object sender, EventArgs e)
        {
            btnSuspender.Enabled = false;
            btnRestablecer.Enabled = false;
            await llenarComboOficina(comboOficina);
        }

        private async void comboOficina_SelectedIndexChanged(object sender, EventArgs e)
        {
            await filtrar();
        }

        private async Task filtrar()
        {
            if (comboOficina.SelectedIndex == null)
            {
                return;
            }
            comboOficina.Enabled = false;
            if (comboOficina.SelectedIndex == 0)
            {
                await llenarTabla(TablaUsuario);
            }
            else
            {
                await llenarTabla(TablaUsuario, (int)comboOficina.SelectedValue);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   

        private void SetHabilitarControlesDeSuspensionORestablecimientos()
        {
            try
            {

                btnSuspender.Enabled = false;
                btnRestablecer.Enabled = false;
                if (TablaUsuario.CurrentRow.Cells["Estado"].Value.ToString().Equals(1.ToString()))
                {
                    btnSuspender.Enabled = true;
                    
                }
                else
                {
                    btnRestablecer.Enabled = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void TablaUsuario_SelectionChanged(object sender, EventArgs e)
        {
            SetHabilitarControlesDeSuspensionORestablecimientos();

        }

        private async void btnSuspender_Click(object sender, EventArgs e)
        {
            await suspenderCuenta();
        }

        private void TablaUsuario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (TablaUsuario.Rows[e.RowIndex].Cells["Estado"].Value.ToString().Equals(0.ToString()))
            {
                TablaUsuario.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;

            }
        }

        private async void btnRestablecer_Click(object sender, EventArgs e)
        {
            await RestablecerCuenta();
        }

        private async void timerSegundoPlano_Tick(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == CANTIDAD_DE_FORMULARIO_ABIERTO)
            {
                if (!this.Enabled)
                {
                    timerSegundoPlano.Enabled = false;
                    this.Enabled = true;
                    this.Focus();
                    await filtrar();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CANTIDAD_DE_FORMULARIO_ABIERTO = Application.OpenForms.Count;
            timerSegundoPlano.Enabled = true;
            new AgregarUsuario() {StartPosition =FormStartPosition.CenterScreen }.Show();
            this.Enabled = false;
        }

       
        private async void btnCambiarRol_Click(object sender, EventArgs e)
        {
            if(TablaUsuario.CurrentRow == null)
            {
                return;
            }
            int ID = 0;
            int.TryParse(TablaUsuario.CurrentRow.Cells["ID"].Value.ToString(), out ID);
            Respuesta<Users> respuesta = await Respuesta<Users>.GetRespuesta<Users>(await Crud.Get("api/users", ID));

            Users users = respuesta.Objeto;

            CANTIDAD_DE_FORMULARIO_ABIERTO = Application.OpenForms.Count;
            timerSegundoPlano.Enabled = true;
            new CambiarRol() { StartPosition = FormStartPosition.CenterScreen, USUARIO = users }.Show();
            this.Enabled = false;
        }
    }
}
