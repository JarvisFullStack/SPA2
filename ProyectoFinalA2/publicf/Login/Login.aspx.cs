using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Login
{
	public partial class Login : System.Web.UI.Page
	{
		private RepositorioBase<Usuario> BLL = new RepositorioBase<Usuario>();
		protected void Page_Load(object sender, EventArgs e)
		{
			
		
			if (!IsPostBack)
			{
				Utils.LimpiarCookies(this);
				//Response.Cookies["EmpresaId"].Value = null;
				

			}
		}

		protected void LoginButton_Click(object sender, EventArgs e)
		{	
			Usuario usuario = new Usuario();
			Expression<Func<Usuario, bool>> filtrar = t => t.Correo.Equals(textboxEmail.Text) && t.Password.Equals(textboxPassword.Text);
			List<Usuario> lista = BLL.GetList(filtrar);
			if (lista.Count > 0)
			{
				usuario = lista.FirstOrDefault();				
				Utils.LlenarCookies(this, usuario);
				//FormsAuthentication.RedirectFromLoginPage(usuario.Correo, false);
				Response.Redirect("~/privatef/Herramientas/hSeleccionEmpresa.aspx");
			} else
			{
				Utils.ShowToastr(this, "Credenciales incorrectos", "Credenciales Incorrectos", "error");				
			}
		}

		
	}
}