using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.privatef.Registros
{
	public partial class rPrestamos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			Utils.VerificarAccesoEmpresa(this);
			LabelFecha.Text = DateTime.Now.Date.ToString("dd/MM/yy");
			this.textboxId.ReadOnly = true;
			if (!IsPostBack)
			{
				int idCliente= HttpContext.Current.Request.Cookies.Get("EmpresaId").Value.ToInt();
				System.Linq.Expressions.Expression<Func<Cliente, bool>> filtro = x => x.Id_Empresa == idCliente;
				Utils.LlenarDropDownList<Cliente>(dropdownlistClientes, new RepositorioBase<Cliente>(), filtro, "Id_Cliente", "Nombre");
				if (dropdownlistClientes.Items.Count <= 0)
				{
					Response.Redirect("~/privatef/Registros/rClientes.aspx");
				}

				ViewState["data"] = new Prestamo();
				int id = Request.QueryString["id"].ToInt();
				if (id > 0)
				{
					BLL.RepositorioBase<Prestamo> repositorio = new BLL.RepositorioBase<Prestamo>();
					Prestamo data = repositorio.Get(id);
					if (data == null)
					{
						Utils.ShowToastr(this, "Prestamo no encontrada!", "Advertencia", "warning");
						return;
					}

					LlenaCampos(data);
					Utils.ShowToastr(this, "Prestamo Encontrada", "Exito!");
					textboxId.ReadOnly = true;
				}
			}
			else
			{
				Prestamo data = (Prestamo)ViewState["data"];
			}



		}

		public Prestamo LlenaClase()
		{
			Prestamo data = new Prestamo();
			data.Id_Prestamo = textboxId.Text.ToInt();
			data.Id_Empresa = HttpContext.Current.Request.Cookies.Get("EmpresaId").Value.ToInt();
			data.Id_Usuario_Creador = HttpContext.Current.Request.Cookies.Get("UsuarioId").Value.ToInt();
			data.Id_Cliente = dropdownlistClientes.SelectedValue.ToInt();
			data.P_Interes = textboxInteres.Text.ToDecimal();
			data.P_Mora = textboxMora.Text.ToDecimal();
			data.Semanas_Atraso_Mora = textboxSemanasAtraso.Text.ToInt();
			data.Balance = textboxBalance.Text.ToDecimal();
			data.Monto_Capital = textboxMontoPrestado.Text.ToDecimal();

			return data;
		}

		public void LlenaCampos(Prestamo data)
		{
			LabelFecha.Text = data.Fecha.ToString("dd/MM/yy");
			textboxInteres.Text = data.P_Interes.ToString();
			textboxId.Text = data.Id_Prestamo.ToString();
			textboxMora.Text = data.P_Mora.ToString();
			textboxSemanasAtraso.Text = data.Semanas_Atraso_Mora.ToString();
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

			Prestamo data = new BLL.RepositorioBase<Prestamo>().Get(id);
			if (data == null)
			{
				Utils.ShowToastr(this, "No se encontro ningun prestamo con este id", "Advertencia", "warning");
				return;
			}

			LlenaCampos(data);
			Utils.ShowToastr(this, "Prestamo Encontrada", "Exito!");
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
			Prestamo data = LlenaClase();
			

			
			bool paso = true;
			if (data.Id_Prestamo > 0)
			{
				if (data.Cobros.Count > 0)
				{
					Utils.ShowToastr(this, "El prestamo no puede ser modificado porque posee cobros realizados!", "Advertencia", "warning");
					return;
				}
				paso = new BLL.RepositorioBase<Prestamo>().Modify(data);
			}
			else
			{
				List<Cuota> listaCuotas = GetListCuotas(data);
				data.Cuotas = listaCuotas;				
				paso = new BLL.RepositorioPrestamo().Save(data);
				Prestamo last = new BLL.RepositorioBase<Prestamo>().GetList(x => true).LastOrDefault();
			}
			if (!paso)
			{
				Utils.ShowToastr(this, "Error al intentar guardar el presatmo!", "Error", "error");
				return;
			}

			Utils.ShowToastr(this, "Registro Guardado Correctamete!", "Exito", "success");
			return;
		}

		private List<Cuota> GetListCuotas(Prestamo prestamo)
		{
			decimal montoTotal = prestamo.Monto_Capital + (prestamo.Monto_Capital * prestamo.P_Interes / 100);
			decimal montoCapitalSemanal = prestamo.Monto_Capital / 13;
			decimal montoInteresSemanal = (prestamo.Monto_Capital * (prestamo.P_Interes / 100)) / 13;
			List<Cuota> listaCuotas = new List<Cuota>();
			for(int i =0;i<13;i++)
			{
				Cuota cuota = new Cuota();
				cuota.Monto_Total = montoCapitalSemanal + montoInteresSemanal;
				cuota.Monto_Capital = montoCapitalSemanal;
				cuota.Interes = montoInteresSemanal;
				cuota.Id_Prestamo = prestamo.Id_Prestamo;
				cuota.Numero = i+1;
				cuota.Mora = cuota.Monto_Capital * prestamo.P_Mora;
				cuota.Balance_Cuota = cuota.Monto_Total;
				cuota.Fecha_Pago = (i == 0) ? DateTime.Now : listaCuotas[i - 1].Fecha_Pago.AddDays(7);
				listaCuotas.Add(cuota);
			}

			return listaCuotas;
		}

		private bool EsValido(Prestamo usuario)
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
			BLL.RepositorioBase<Prestamo> repositorio = new BLL.RepositorioBase<Prestamo>();
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

		protected void buttonCalcularCuotas_Click(object sender, EventArgs e)
		{
			Prestamo prestamo = LlenaClase();
			List<Cuota> listaCuotas = GetListCuotas(prestamo);

			Utils.FillGrid<Cuota>(GridViewDistribucionCuotas, listaCuotas);

		}



		
	}
}