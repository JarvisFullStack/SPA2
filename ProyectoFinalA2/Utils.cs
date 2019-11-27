using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2
{
    public static class Utils
    {
        public static Int32 ToInt(this String value)
        {
            int retorno = 0;
            int.TryParse(value, out retorno);

            return retorno;
        }

        public static decimal ToDecimal(this string valor)
        {
            decimal retorno = 0;
            decimal.TryParse(valor, out retorno);

            return retorno;
        }
        public static void ShowToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);            
        }


		public static void CallJsFunction(Page page, Type type, string functionName)
		{
			page.ClientScript.RegisterStartupScript(type, "CallMyFunction", functionName, true);
		}

		public static void ClearControls(Control control, List<Type> controlsToClear)
		{
			foreach(Control c in control.Controls)
			{
				if(controlsToClear.Contains(c.GetType()))
				{
					if(c.GetType() == typeof(TextBox))
					{
						((TextBox)c).Text = string.Empty;
					}

					if (c.GetType() == typeof(DropDownList))
					{
						((DropDownList)c).SelectedIndex = 0;
					}
					
				}
			}
		}

		public static void LlenarDropDownList<T>(DropDownList dropDown, BLL.IRepository<T> repositorio, Expression<Func<T, bool>> expression, string dataValueField, string dataTextField) where T : class
		{
			dropDown.Items.Clear();
			dropDown.DataSource = repositorio.GetList(expression);
			dropDown.DataTextField = dataTextField;
			dropDown.DataValueField = dataValueField;
			dropDown.DataBind();
		}

		public static void VerificarAccesoEmpresa(Page page)
		{
			if (HttpContext.Current.Request.Cookies.Get("EmpresaId") == null || HttpContext.Current.Request.Cookies.Get("EmpresaId").Value == null || Utils.ToInt(HttpContext.Current.Request.Cookies.Get("EmpresaId").Value.ToString()) == 0)
			{
				page.Response.Redirect("~/privatef/Registros/rEmpresas.aspx?requerido=1");
			} 
			
		}

		public static void LlenarCookies(Page page, Usuario usuario)
		{		

			HttpCookie cookie;
			cookie = new HttpCookie("UsuarioNombre", usuario.Nombre);
			DateTime dtNow = DateTime.Now;
			TimeSpan tsMinute = new TimeSpan(2, 1, 1, 0);
			cookie.Expires = dtNow + tsMinute;
			page.Response.Cookies.Add(cookie);


			HttpCookie cookie2 = new HttpCookie("UsuarioId", usuario.Id_Usuario.ToString());
			cookie.Expires = dtNow + tsMinute;
			page.Response.Cookies.Add(cookie2);


		}

		public static void LlenarCookies(Page page, Empresa empresa)
		{
			HttpCookie cookie;
			cookie = new HttpCookie("EmpresaNombre", empresa.Nombre);
			DateTime dtNow = DateTime.Now;
			TimeSpan tsMinute = new TimeSpan(2, 1, 1, 0);
			cookie.Expires = dtNow + tsMinute;
			page.Response.Cookies.Add(cookie);


			HttpCookie cookie2 = new HttpCookie("EmpresaId", empresa.Id_Empresa.ToString());
			cookie.Expires = dtNow + tsMinute;
			page.Response.Cookies.Add(cookie2);
		}

		public static void LimpiarCookies(Page page)
		{
			page.Request.Cookies.Clear();
			page.Response.Cookies.Clear();
			page.Session.Abandon();
			page.Response.Cookies["EmpresaId"].Value = null;
			page.Response.Cookies["EmpresaNombre"].Value = null;
			page.Response.Cookies["UsuarioId"].Value = null;
			page.Response.Cookies["UsuarioNombre"].Value = null;

		}

		public static void FillGrid<T>(GridView gv, List<T> lista)
		{
			gv.DataSource = null;
			gv.DataBind();
			gv.DataSource = lista;
			gv.DataBind();
		}

		public static string Hash(string input) { var hash = (new SHA1Managed()).ComputeHash(Encoding.UTF8.GetBytes(input)); return string.Join("", hash.Select(b => b.ToString("x2")).ToArray()); }






	}
}