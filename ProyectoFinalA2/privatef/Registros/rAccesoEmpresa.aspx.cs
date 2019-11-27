using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalA2.Registros
{
	public partial class rAccesoEmpresa : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
			Utils.VerificarAccesoEmpresa(this);
	}
}
}