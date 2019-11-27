using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Serializable]
	public class Empresa
	{
		[Key]
		public int Id_Empresa { get; set; }
		[Required]
		public int Id_Usuario_Creador { get; set; }
		[MaxLength(60)]
		[Required]
		public string Nombre { get; set; }
		[Required]
		[MaxLength(100)]
		public string Eslogan { get; set; }
		[Required]
		public decimal P_Interes { get; set; }
		[Required]
		public decimal P_Mora { get; set; }
		[Required]
		public decimal Semanas_Atraso { get; set; }
		public bool Activo { get; set; }
		public DateTime Fecha { get; set; }

		public Empresa()
		{
			this.Fecha = DateTime.Now;
		}
	}
}
