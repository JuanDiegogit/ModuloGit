using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;
using API.Models;
using System.Threading;

namespace Vista
{
    public partial class Login : Form
    {

        private int NUMERO_DE_INTENTOS = 0;
        public static Users USUARIO_ACTIVO {  private set; get; }
        public Login()
        {
            InitializeComponent();
        }

        public void MostrarContraseña(bool visible = true)
        {
            txtContraseña.UseSystemPasswordChar = visible;
        }
        private async Task RegistrarIntento(Users users)
        {
            intentosFallido intentosFallido = new intentosFallido() {
                UsuarioID = users.ID,
                fechaYHora=DateTime.Now
            };
          await  Crud.Post<intentosFallido>("api/intentosFallidos",intentosFallido);
        }
        public async void AumentarIntento(Users users = null)
        {
            NUMERO_DE_INTENTOS++;
            if (users != null)
            {
             await  RegistrarIntento(users);
            }
           
            if (NUMERO_DE_INTENTOS==3)
            {
               await BloquearLogin(10);
                NUMERO_DE_INTENTOS = 0;
            }
        }
        
        private async Task BloquearLogin(int duracion)
        {
           
            btnCancelar.Enabled = false;
            btnIniciarSeccion.Enabled = false;
            txtContraseña.Enabled = false;
            txtUsuario.Enabled = false;
            checkMostrarContraseña.Enabled = false;
            for (int i = duracion; i >=0 ; i--)
            {
            
                lblMensaje.Text = await Task<String>.Run(()=> {
                    Thread.Sleep(1000);
                    return String.Format("falta {0} segundos para volver a intentarlo",i);
                });
    
            }
            lblMensaje.Text = "";
            btnCancelar.Enabled = true;
            btnIniciarSeccion.Enabled = true;
            txtContraseña.Enabled = true;
            txtUsuario.Enabled = true;
            checkMostrarContraseña.Enabled = true;
        }
        private async Task<Users> ObtenerAdminitradorQueBloqueo(Users users)
        {
            Respuesta<IEnumerable<UsuarioBloqueados>> respuestaUB = await Respuesta<IEnumerable<UsuarioBloqueados>>.GetRespuesta<IEnumerable<UsuarioBloqueados>>(await Crud.Get("api/usuarioBloqueados"));

            Users admin = new Users { FirstName = "el Sistema" };

            if (respuestaUB.Objeto.Count() !=0) {
                IEnumerable<UsuarioBloqueados> listaDeUsuarioBloqueados = respuestaUB.Objeto;

               admin = listaDeUsuarioBloqueados.First(T => T.UsuarioID == users.ID).Admin;
            }

            return admin;
        }

        private async void IniciarSesion(String usuario , String contraseña)
        {
            btnIniciarSeccion.Enabled = false;
            String mensaje = "";
            if(usuario.Equals("") || contraseña.Equals(""))
            {
                mensaje = "Debe llenar todos los campos";
                lblMensaje.Text = mensaje;
                AumentarIntento();
                btnIniciarSeccion.Enabled = true;
                return;
            }
            Respuesta<IEnumerable<Users>> respuesta = await Respuesta<IEnumerable<Users>>.GetRespuesta<IEnumerable<Users>>(await Crud.Get("api/users"));

            IEnumerable<Users> listaDeUsuario = respuesta.Objeto;
            if (listaDeUsuario.Count() == 0)
            {
                mensaje = "No hay usuarios en la base de dato";
                lblMensaje.Text = mensaje;
                btnIniciarSeccion.Enabled = true;
                return;
            }
            if(listaDeUsuario.Count(E=>E.Email == usuario) == 0)
            {
                mensaje = "No Existe un Usuario registrado con este correo "+usuario;
                lblMensaje.Text = mensaje;
                AumentarIntento();
                btnIniciarSeccion.Enabled = true;
                return;
            }
            else
            {
                if(listaDeUsuario.Count(E => E.Email == usuario && E.Password == contraseña) == 0)
                {
                    mensaje = "La contraseña es Incorrecta";
                    lblMensaje.Text = mensaje;
                    AumentarIntento(listaDeUsuario.First(E => E.Email == usuario));
                    btnIniciarSeccion.Enabled = true;
                    return;
                }
                else
                {

                    USUARIO_ACTIVO = listaDeUsuario.First(E => E.Email == usuario && E.Password == contraseña);

                    if (USUARIO_ACTIVO.Active == 0)
                    {
                       
                        Users admin = await ObtenerAdminitradorQueBloqueo(USUARIO_ACTIVO);
                        mensaje = String.Format("el usuario Esta inactivo por {0}",admin.FirstName);
                        lblMensaje.Text = mensaje;
                        AumentarIntento();
                        btnIniciarSeccion.Enabled = true;
                        return;
                    }
                    else
                    {
                        timerSegundoPlano.Enabled = true;
                        if (USUARIO_ACTIVO.RoleID == 1)
                        {
                            new FormularioAdmin() { StartPosition  = FormStartPosition.CenterScreen }.Show();
                        }
                        else
                        {
                            new CambiarContraseña() { StartPosition = FormStartPosition.CenterScreen }.Show();
                        }
                       this.Hide();
                    }
          
                }
            }
           



         
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void checkMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            MostrarContraseña(!checkMostrarContraseña.Checked);
        }

        private void btnIniciarSeccion_Click(object sender, EventArgs e)
        {
            IniciarSesion(txtUsuario.Text,txtContraseña.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                if (Application.OpenForms.Count == 1)
                {
                    btnIniciarSeccion.Enabled = true;
                    timerSegundoPlano.Enabled = false;
                    txtContraseña.Text = "";
                    txtUsuario.Text = "";
                    this.Show();
                   // this.Focus();
                }
            }
        }
    }
}
