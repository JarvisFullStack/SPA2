using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.privatef.Herramientas
{
	public partial class hSeleccionEmpresa : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				int id = HttpContext.Current.Request.Cookies.Get("UsuarioId").Value.ToInt();
				System.Linq.Expressions.Expression<Func<Acceso_Empresa, bool>> filtro = x => x.Id_Usuario == id;
				Utils.LlenarDropDownList<Acceso_Empresa>(dropdownlistEmpresas, new RepositorioBase<Acceso_Empresa>(), filtro, "Id_Empresa", "Id_Empresa");
				if(dropdownlistEmpresas.Items.Count <= 0)
				{
					Response.Redirect("~/privatef/Registros/rEmpresas.aspx");
				}
			}
		}
		

		protected void buttonSeleccionrEmpresa_Click(object sender, EventArgs e)
		{
			int id = Utils.ToInt(dropdownlistEmpresas.SelectedValue);
			if(id > 0) {
				Empresa empresa = new RepositorioBase<Empresa>().Get(id);
				Utils.LlenarCookies(this, empresa);
				Response.Redirect("~/Index.aspx");

			} else
			{
				Utils.ShowToastr(this, "Error al intentar ingresar a la empresa", "Error", "error");
			}
		}
	}
}