using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.privatef.Registros
{
	public partial class rClientes : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Utils.VerificarAccesoEmpresa(this);
			LabelFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");
			this.textboxId.ReadOnly = true;
			if (!IsPostBack)
			{

				ViewState["data"] = new Cliente();
				int id = Request.QueryString["id"].ToInt();
				if (id > 0)
				{
					BLL.RepositorioBase<Cliente> repositorio = new BLL.RepositorioBase<Cliente>();
					Cliente data = repositorio.Get(id);
					if (data == null)
					{
						Utils.ShowToastr(this, "Cliente no encontrado!", "Advertencia", "warning");
						return;
					}

					LlenaCampos(data);
					Utils.ShowToastr(this, "Cliente Encontrada", "Exito!");
					textboxId.ReadOnly = true;
				}
			}
			else
			{
				Cliente data = (Cliente)ViewState["data"];
			}



		}

		public Cliente LlenaClase()
		{
			Cliente data = new Cliente();
			data.Id_Cliente = textboxId.Text.ToInt();
			data.Id_Empresa = HttpContext.Current.Request.Cookies.Get("EmpresaId").Value.ToInt();
			data.Id_Usuario_Creador = HttpContext.Current.Request.Cookies.Get("UsuarioId").Value.ToInt();
			data.Nombre = textboxNombre.Text;
			data.Cedula = textboxCedula.Text;
			data.Apellido = textboxApellido.Text;
			data.Direccion = textboxDireccion.Text;
			data.Balance = textboxBalance.Text.ToDecimal();

			return data;
		}

		public void LlenaCampos(Cliente data)
		{
			LabelFecha.Text = data.Fecha.ToString("dd/MM/yy");
			textboxNombre.Text = data.Nombre;
			textboxId.Text = data.Id_Cliente.ToString();
			textboxApellido.Text = data.Apellido;
			textboxCedula.Text = data.Cedula;
			textboxDireccion.Text = data.Direccion;
			textboxBalance.Text = data.Balance.ToString();
		}

		protected void buttonBusqueda_Click(object sender, EventArgs e)
		{
			int id = textboxId.Text.ToInt();
			if (id == 0)
			{
				Utils.ShowToastr(this, "Debes ingresar los datos de busqueda correctamente", "Advertencia", "warning");
				return;
			}

			Cliente data = new BLL.RepositorioBase<Cliente>().Get(id);
			if (data == null)
			{
				Utils.ShowToastr(this, "No se encontro ninguna data con este id", "Advertencia", "warning");
				return;
			}

			LlenaCampos(data);
			Utils.ShowToastr(this, "Cliente Encontrada", "Exito!");
			textboxId.ReadOnly = true;
			return;

		}

		protected void NuevoButton_Click(object sender, EventArgs e)
		{
			Utils.ClearControls(formRegistro, new List<Type>() { typeof(TextBox) });
			textboxId.ReadOnly = false;
		}

		protected void GuardarButton_Click(object sender, EventArgs e)
		{
			Cliente data = LlenaClase();
			
			bool paso = true;
			if (data.Id_Cliente > 0)
			{
				paso = new BLL.RepositorioBase<Cliente>().Modify(data);
			}
			else
			{
				paso = new BLL.RepositorioBase<Cliente>().Save(data);
				Cliente last = new BLL.RepositorioBase<Cliente>().GetList(x => true).LastOrDefault();
			}
			if (!paso)
			{
				Utils.ShowToastr(this, "Error al intentar guardar la data!", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Registro Guardado Correctamete!", "Exito", "success");
			return;
		}

		private bool EsValido(Cliente usuario)
		{			
			return true;
		}

		protected void EliminarButton_Click(object sender, EventArgs e)
		{
			int id = textboxId.Text.ToInt();
			if (id < 0)
			{
				Utils.ShowToastr(this, "Id invalido", "Advertencia", "warning");
				return;
			}
			BLL.RepositorioBase<Cliente> repositorio = new BLL.RepositorioBase<Cliente>();
			if (repositorio.Get(id) == null)
			{
				Utils.ShowToastr(this, "Registro no encontrado", "Advertencia", "warning");
				return;
			}

			bool paso = repositorio.Delete(id);
			if (!paso)
			{
				Utils.ShowToastr(this, "Error al intentar eliminar el registro", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Registro eliminado correctamente!", "exito", "success");
			return;
		}
	}
}