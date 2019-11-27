using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.privatef.Registros
{
	public partial class rCobros : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Utils.VerificarAccesoEmpresa(this);
			LabelFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");
			this.textboxId.ReadOnly = true;
			if (!IsPostBack)
			{
				System.Linq.Expressions.Expression<Func<Cliente, bool>> filtro = x => true;
				Utils.LlenarDropDownList<Cliente>(dropdownlistClientes, new BLL.RepositorioBase<Cliente>(), filtro, "Id_Cliente", "Nombre");
				ViewState["data"] = new Cobro();
				int id = Request.QueryString["id"].ToInt();
				if (id > 0)
				{
					BLL.RepositorioBase<Cobro> repositorio = new BLL.RepositorioBase<Cobro>();
					Cobro data = repositorio.Get(id);
					if (data == null)
					{
						Utils.ShowToastr(this, "Cobro no encontrado!", "Advertencia", "warning");
						return;
					}

					LlenaCampos(data);
					Utils.ShowToastr(this, "Cobro Encontrada", "Exito!");
					textboxId.ReadOnly = true;
				}
			}
			else
			{
				Cobro data = (Cobro)ViewState["data"];
			}



		}

		public Cobro LlenaClase()
		{
			Cobro data = new Cobro();
			data.Id_Cobro = textboxId.Text.ToInt();
			data.Id_Prestamo = dropdownlistPrestamos.SelectedValue.ToInt();
			data.Mora = textboxMora.Text.ToDecimal();
			data.Interes = textboxInteres.Text.ToDecimal();
			data.Monto_Capital = textboxCobroCapital.Text.ToDecimal();
			data.Monto_Total = textboxMontoCobro.Text.ToDecimal();		

			return data;
		}

		public void LlenaCampos(Cobro data)
		{
			LabelFecha.Text = data.Fecha.ToString("dd/MM/yy");
			dropdownlistPrestamos.SelectedValue = data.Id_Prestamo.ToString();
			textboxId.Text = data.Id_Cobro.ToString();
			textboxMora.Text = data.Mora.ToString();
			textboxInteres.Text = data.Interes.ToString();
			textboxCobroCapital.Text = data.Monto_Capital.ToString();
			textboxMontoCobro.Text = data.Monto_Total.ToString();
		}

		protected void buttonBusqueda_Click(object sender, EventArgs e)
		{
			int id = textboxId.Text.ToInt();
			if (id == 0)
			{
				Utils.ShowToastr(this, "Debes ingresar los datos de busqueda correctamente", "Advertencia", "warning");
				return;
			}

			Cobro data = new BLL.RepositorioBase<Cobro>().Get(id);
			if (data == null)
			{
				Utils.ShowToastr(this, "No se encontro ninguna data con este id", "Advertencia", "warning");
				return;
			}

			LlenaCampos(data);
			Utils.ShowToastr(this, "Cobro Encontrada", "Exito!");
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
			Cobro data = LlenaClase();
					
			bool paso = true;
			if (data.Id_Cobro > 0)
			{
				paso = new BLL.RepositorioBase<Cobro>().Modify(data);
			}
			else
			{
				paso = new BLL.RepositorioBase<Cobro>().Save(data);
				Cobro last = new BLL.RepositorioBase<Cobro>().GetList(x => true).LastOrDefault();
			}
			if (!paso)
			{
				Utils.ShowToastr(this, "Error al intentar guardar la data!", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Registro Guardado Correctamete!", "Exito", "success");
			return;
		}

		private bool EsValido(Cobro usuario)
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
			BLL.RepositorioBase<Cobro> repositorio = new BLL.RepositorioBase<Cobro>();
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

		protected void dropdownlistPrestamos_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id = dropdownlistPrestamos.SelectedValue.ToInt();
			Prestamo prestamo = new BLL.RepositorioBase<Prestamo>().Get(id);
			Utils.FillGrid<Cobro>(GridViewCobrosRealizados, prestamo.Cobros);
		}

		protected void dropdownlistClientes_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id = dropdownlistClientes.SelectedValue.ToInt();
			LlenarDropDownPrestamos(id);
		}

		private void LlenarDropDownPrestamos(int id)
		{
			System.Linq.Expressions.Expression<Func<Prestamo, bool>> filtro = x => x.Id_Cliente == id;
			Utils.LlenarDropDownList<Prestamo>(dropdownlistPrestamos, new BLL.RepositorioBase<Prestamo>(), filtro, "Id_Prestamo", "Id_Prestamo");
		}
	}
}