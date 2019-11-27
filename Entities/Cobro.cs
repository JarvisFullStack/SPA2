using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Serializable]
	public class Cobro
	{
		[Key]
		public int Id_Cobro { get; set; }
		[Required]
		public int Id_Prestamo { get; set; }
		[Required]
		public int Id_Usuario_Creador { get; set; }
		[Required]
		public decimal Mora { get; set; }
		[Required]
		public decimal Interes { get; set; }
		[Required]
		public decimal Monto_Capital { get; set; }
		[Required]
		public decimal Monto_Total { get; set; }
		public bool Activo { get; set; }
		public DateTime Fecha { get; set; }

		public Cobro()
		{
			this.Fecha = DateTime.Now;
		}
	}
}
