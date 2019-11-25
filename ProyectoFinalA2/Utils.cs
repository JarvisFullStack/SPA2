using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2
{
    public static class Utils
    {
        public static Int32 ToInt(String value)
        {
            int retorno = 0;
            int.TryParse(value, out retorno);

            return retorno;
        }

        public static decimal ToDecimal(string valor)
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
				}
			}
		}




    }
}