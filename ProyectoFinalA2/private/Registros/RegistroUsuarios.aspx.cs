using Entities;
using ProyectoFinalA2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Mantenimientos
{
    public partial class RegistroUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {       

                //si llego in id
                int id = Utils.ToInt(Request.QueryString["id"]);
                if (id > 0)
                {
                    BLL.RepositorioBase<Usuario> repositorio = new BLL.RepositorioBase<Usuario>();
                    var user = repositorio.Get(id);

                    if (user == null)
                    {
                        MostrarMensaje("error", "Registro no encontrado");
                    }
                    else
                    {
                        LlenaCampos(user);                       
                    }
                }
            } 
            

            

            /*void MostrarMensaje(TiposMensaje tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == TiposMensaje.Success)
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }*/
        }

        protected void GuadarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Usuario> repositorio = new BLL.RepositorioBase<Usuario>();
            Usuario user = new Usuario();
            bool paso = false;
            
            LlenaClase(user);

            bool esUnico = true;
            if (user.Id_Usuario == 0)
                paso = repositorio.Save(user);
            else
            {
                var ant = new BLL.RepositorioBase<Usuario>().Get(user.Id_Usuario);
                esUnico = new BLL.RepositorioBase<Usuario>().GetList(x => x.Correo == x.Correo).Count() <= 0 || user.Correo == ant.Correo;
                if(esUnico)
                {
                    user.Password = ant.Password;
                    paso = repositorio.Modify(user);
                } else
                {
                    paso = false;
                }
                
            }
                

            if (paso)
            {
                MostrarMensaje("success", "Transaccion Exitosa!");
                Limpiar();
            }
            else
            {
                string mensaje = "No fue posible terminar la transacción";
                if(!esUnico)
                {
                    mensaje += " porque el nombre de usuario esta en uso.";
                }
                MostrarMensaje("error", mensaje);
            }

            

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            BLL.RepositorioBase<Usuario> repositorio = new BLL.RepositorioBase<Usuario>();
            int id = Utils.ToInt(IdTextBox.Text);

            var User = repositorio.Get(id);

            if (User == null)
            {
                MostrarMensaje("error", "Registro no encontrado");
            }                
            else
            {
                repositorio.Delete(id);
            }
                
        }

        private void LlenaClase(Usuario user)
        {
            user.Id_Usuario = Utils.ToInt(IdTextBox.Text);
            user.Nombre = NombresTextBox.Text;
            user.Correo = CorreoTextBox.Text;
            user.Apellido = ApellidosTextBox.Text;
            user.Password = PasswordTextBox.Text;
            user.Nivel = (Enums.NivelUsuario)this.TipoUsuarioDropDownList.SelectedIndex;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            Utils.ShowToastr(this.Page, "Hello world!", "Hello");
        }

        private void Limpiar()
        {
            this.IdTextBox.Text = "";
            this.NombresTextBox.Text = "";
            this.ApellidosTextBox.Text = "";
            this.TipoUsuarioDropDownList.SelectedIndex = 0;
            this.PasswordTextBox.Text = "";
            this.CorreoTextBox.Text = "";
        }

        private void LlenaCampos(Usuario user)
        {
            this.IdTextBox.Text = user.Id_Usuario.ToString();
            this.NombresTextBox.Text = user.Nombre;
            this.ApellidosTextBox.Text = user.Apellido;
            this.TipoUsuarioDropDownList.SelectedIndex = (int)user.Nivel;
            this.PasswordTextBox.Text = user.Password;            
            this.PasswordLabel.Visible = false;
            this.PasswordTextBox.Visible = false;
            this.RequiredFieldValidator3.Enabled = false;            
            this.CorreoTextBox.Text = user.Correo;            

        }

        void MostrarMensaje(string tipo, string mensaje)
        {
            ErrorLabel.Text = mensaje;

            if (tipo == "success")
                ErrorLabel.CssClass = "alert-success";
            else
                ErrorLabel.CssClass = "alert-danger";
        }

    }
}
