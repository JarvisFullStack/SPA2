using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Register
{
	public partial class Register : System.Web.UI.Page
	{
		private RepositorioBase<Usuario> BLL = new RepositorioBase<Usuario>();
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void RegisterButton_Click(object sender, EventArgs e)
		{
			
			Usuario usuario = LlenaClase();
			if(usuario!=null)
			{
				if(!EsCorreoUnico(usuario.Correo))
				{
					Utils.ShowToastr(this, $"{usuario.Correo} ya ha sido registrado!", "Error", "error");
					return;
				}

				if (BLL.Save(usuario))
				{
					Utils.ShowToastr(this, $"Registro Completado!", "Correcto!", "success");
					Utils.ClearControls(formRegistro, new List<Type>() { typeof(TextBox)});
					return;
				}

				Utils.ShowToastr(this, $"Error de registro!", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Datos Invalidos", "Revisar", "warning");
			return;
		}

		private bool EsCorreoUnico(string correo)
		{
			return BLL.GetList(x=>x.Correo == correo).Count <= 0;	
		}

		private Usuario LlenaClase()
		{
			if (textboxPassword.Text != textboxConfirmPassword.Text) return null;
			Usuario usuario = new Usuario();
			usuario.Nivel = Enums.NivelUsuario.ADMINISTRADOR;
			usuario.Correo = textboxEmail.Text;
			usuario.Nombre = textboxNombre.Text;
			usuario.Apellido = textboxApellido.Text;
			usuario.Password = textboxPassword.Text;
			usuario.Fecha = DateTime.Now;
			return usuario;
			
		}
	}
}