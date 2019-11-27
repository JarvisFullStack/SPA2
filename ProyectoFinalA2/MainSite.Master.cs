using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2
{
    public partial class MainSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			LabelNombreEmpresa.Text= HttpContext.Current.Request.Cookies.Get("EmpresaNombre").Value;
			LabelNombreUsuario.Text= HttpContext.Current.Request.Cookies.Get("UsuarioNombre").Value;
		}

		protected void CerrarSesionButton_Click(object sender, EventArgs e)
		{
			FormsAuthentication.SignOut();
			Utils.LimpiarCookies(this.Page);
			Response.Redirect("~/publicf/Login/Login.aspx");
			//FormsAuthentication.RedirectToLoginPage();
		}
	}
}