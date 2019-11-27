using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Registros
{
	public partial class rEmpresas : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			LabelFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");	
			this.textboxId.ReadOnly = true;
			if (!IsPostBack)
			{
				if (Utils.ToInt(Request.QueryString["requerido"]) == 1)
				{
					Utils.ShowToastr(this, "Debe crear una empresa antes de operar en el sistema!", "Registro de Empresa Requerido", "warning");
				}
				ViewState["empresa"] = new Empresa();
				int id = Request.QueryString["id"].ToInt();
				if(id>0)
				{
					BLL.RepositorioBase<Empresa> repositorio = new BLL.RepositorioBase<Empresa>();
					Empresa empresa = repositorio.Get(id);
					if(empresa == null)
					{						
						Utils.ShowToastr(this, "Empresa no encontrada!", "Advertencia", "warning");
						return;
					}

					LlenaCampos(empresa);
					Utils.ShowToastr(this, "Empresa Encontrada", "Exito!");
					textboxId.ReadOnly = true;
				}
			}
			else
			{
				Empresa empresa = (Empresa)ViewState["empresa"];		
				
			}



		}

		public Empresa LlenaClase()
		{
			Empresa empresa = new Empresa();
			empresa.Id_Empresa = textboxId.Text.ToInt();
			empresa.Id_Usuario_Creador = HttpContext.Current.Request.Cookies.Get("UsuarioId").Value.ToInt();
			empresa.Nombre = textboxNombre.Text;
			empresa.Eslogan = textboxEslogan.Text;
			empresa.P_Interes = textboxInteres.Text.ToDecimal();
			empresa.P_Mora = textboxMora.Text.ToDecimal();
			empresa.Semanas_Atraso = textboxSemanasAtraso.Text.ToInt();						

			return empresa;
		}

		public void LlenaCampos(Empresa empresa)
		{
			LabelFecha.Text = empresa.Fecha.ToString("dd/MM/yy");
			textboxNombre.Text = empresa.Nombre;
			textboxId.Text = empresa.Id_Empresa.ToString();
			textboxEslogan.Text = empresa.Eslogan;
			textboxInteres.Text = empresa.P_Interes.ToString();
			textboxMora.Text = empresa.P_Mora.ToString();
			textboxSemanasAtraso.Text = empresa.Semanas_Atraso.ToString();			

		}

		protected void buttonBusqueda_Click(object sender, EventArgs e)
		{
			int id = textboxId.Text.ToInt();
			if(id == 0)
			{
				Utils.ShowToastr(this, "Debes ingresar los datos de busqueda correctamente", "Advertencia", "warning");
				return;
			}

			Empresa empresa = new BLL.RepositorioBase<Empresa>().Get(id);
			if(empresa == null)
			{
				Utils.ShowToastr(this, "No se encontro ninguna empresa con este id", "Advertencia", "warning");
				return;
			}

			LlenaCampos(empresa);
			Utils.ShowToastr(this, "Empresa Encontrada", "Exito!");
			textboxId.ReadOnly = true;
			return;

		}

		protected void NuevoButton_Click(object sender, EventArgs e)
		{
			Utils.ClearControls(formRegistro, new List<Type>() { typeof(TextBox)});
			textboxId.ReadOnly = false;
		}

		protected void GuardarButton_Click(object sender, EventArgs e)
		{
			Empresa empresa = LlenaClase();
			bool paso = true;
			if(empresa.Id_Empresa > 0)
			{
				paso = new BLL.RepositorioBase<Empresa>().Modify(empresa);
			} else
			{
				paso = new BLL.RepositorioBase<Empresa>().Save(empresa);
				empresa = new BLL.RepositorioBase<Empresa>().GetList(x => true).LastOrDefault();
				Acceso_Empresa acceso = new Acceso_Empresa();
				acceso.Id_Empresa = empresa.Id_Empresa;
				acceso.Id_Usuario = HttpContext.Current.Request.Cookies.Get("UsuarioId").Value.ToInt();
				new BLL.RepositorioBase<Acceso_Empresa>().Save(acceso);
				//new BLL.RepositorioBase<Acceso_Empresa>().Save(new Acceso_Empresa());
			}
			if(!paso)
			{
				Utils.ShowToastr(this, "Error al intentar guardar la empresa!", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Registro Guardado Correctamete!", "Exito", "success");
			
			return;
		}

		protected void EliminarButton_Click(object sender, EventArgs e)
		{
			int id = textboxId.Text.ToInt();
			if(id < 0)
			{
				Utils.ShowToastr(this, "Id invalido", "Advertencia", "warning");
				return;
			}
			BLL.RepositorioBase<Empresa> repositorio = new BLL.RepositorioBase<Empresa>();
			if (repositorio.Get(id) == null)
			{
				Utils.ShowToastr(this, "Registro no encontrado", "Advertencia", "warning");
				return;
			}

			bool paso = repositorio.Delete(id);
			if(!paso)
			{
				Utils.ShowToastr(this, "Error al intentar eliminar el registro", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Registro eliminado correctamente!", "exito", "success");
			return;
		}
	}
}