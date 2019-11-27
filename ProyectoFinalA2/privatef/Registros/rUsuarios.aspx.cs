using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Registros
{
	public partial class rUsuarios : System.Web.UI.Page
{
		protected void Page_Load(object sender, EventArgs e)
		{
			Utils.VerificarAccesoEmpresa(this);
			LabelFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");
			this.textboxId.ReadOnly = true;
			if (!IsPostBack)
			{
				
				ViewState["data"] = new Usuario();
				int id = Request.QueryString["id"].ToInt();
				if (id > 0)
				{
					BLL.RepositorioBase<Usuario> repositorio = new BLL.RepositorioBase<Usuario>();
					Usuario data = repositorio.Get(id);
					if (data == null)
					{
						Utils.ShowToastr(this, "Usuario no encontrada!", "Advertencia", "warning");
						return;
					}

					LlenaCampos(data);
					Utils.ShowToastr(this, "Usuario Encontrada", "Exito!");
					textboxId.ReadOnly = true;
				}
			}
			else
			{
				Usuario data = (Usuario)ViewState["data"];
			}



		}

		public Usuario LlenaClase()
		{
			Usuario data = new Usuario();
			data.Id_Usuario = textboxId.Text.ToInt();
			data.Id_Empresa = HttpContext.Current.Request.Cookies.Get("EmpresaId").Value.ToInt();
			data.Nombre = textboxNombre.Text;
			data.Correo = textboxEmail.Text;
			data.Apellido = textboxApellido.Text;
			data.Password = textboxPassword.Text;
			data.Nivel = Enums.NivelUsuario.NORMAL;

			return data;
		}

		public void LlenaCampos(Usuario data)
		{
			LabelFecha.Text = data.Fecha.ToString("dd/MM/yy");
			textboxNombre.Text = data.Nombre;
			textboxId.Text = data.Id_Usuario.ToString();
			textboxEmail.Text = data.Correo;
			textboxApellido.Text = data.Apellido;
			textboxPassword.Text = data.Password;
		}

		protected void buttonBusqueda_Click(object sender, EventArgs e)
		{
			int id = textboxId.Text.ToInt();
			if (id == 0)
			{
				Utils.ShowToastr(this, "Debes ingresar los datos de busqueda correctamente", "Advertencia", "warning");
				return;
			}

			Usuario data = new BLL.RepositorioBase<Usuario>().Get(id);
			if (data == null)
			{
				Utils.ShowToastr(this, "No se encontro ninguna data con este id", "Advertencia", "warning");
				return;
			}

			LlenaCampos(data);
			Utils.ShowToastr(this, "Usuario Encontrada", "Exito!");
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
			Usuario data = LlenaClase();
			if(!EsValido(data))
			{
				Utils.ShowToastr(this, $"{data.Correo} ya ha sido registrado!", "Advertencia", "warning");
				return;
			}

			if(!textboxPassword.Text.Equals(textboxPasswordConfirm.Text))
			{
				Utils.ShowToastr(this, $"Las claves que ha introducido no coinciden", "Advertencia", "warning");
				return;
			}
			bool paso = true;
			if (data.Id_Usuario > 0)
			{
				paso = new BLL.RepositorioBase<Usuario>().Modify(data);
			}
			else
			{
				paso = new BLL.RepositorioBase<Usuario>().Save(data);
				Usuario last = new BLL.RepositorioBase<Usuario>().GetList(x => true).LastOrDefault();
				Acceso_Empresa acceso = new Acceso_Empresa();
				acceso.Id_Usuario = last.Id_Usuario;
				acceso.Id_Empresa = HttpContext.Current.Request.Cookies.Get("EmpresaId").Value.ToInt();
				new BLL.RepositorioBase<Acceso_Empresa>().Save(acceso);
				//new BLL.RepositorioBase<Acceso_Usuario>().Save(new Acceso_Usuario());
			}
			if (!paso)
			{
				Utils.ShowToastr(this, "Error al intentar guardar la data!", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Registro Guardado Correctamete!", "Exito", "success");
			return;
		}

		private bool EsValido(Usuario usuario)
		{
			List<Usuario> lista = new BLL.RepositorioBase<Usuario>().GetList(x=>x.Correo == usuario.Correo && x.Nivel == Enums.NivelUsuario.NORMAL);
			if(lista.Count > 0)
			{
				return false;
			}

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
			BLL.RepositorioBase<Usuario> repositorio = new BLL.RepositorioBase<Usuario>();
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