using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Serializable]
	public class Acceso_Empresa
	{
		[Key]
		public int Id_Acceso_Empresa { get; set; }
		[Required]
		public int Id_Usuario { get; set; }
		[Required]
		public int Id_Empresa { get; set; }
		public bool Activo { get; set; }
		public DateTime Fecha { get; set; }

		public Acceso_Empresa()
		{
			this.Fecha = DateTime.Now;
		}
	}
}
