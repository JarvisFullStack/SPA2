using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Serializable]
	public class Cuota
	{
		[Key]
		public int Id_Cuota { get; set; }
		[Required]
		public int Id_Prestamo { get; set; }
		[Required]
		public int Numero { get; set; }
		[Required]
		public decimal Mora { get; set; }
		[Required]
		public decimal Interes { get; set; }
		public DateTime Fecha_Pago { get; set; }
		[Required]
		public decimal Monto_Capital { get; set; }
		[Required]
		public decimal Monto_Total { get; set; }
		[Required]
		public decimal Balance_Cuota { get; set; }
		public bool Activo { get; set; }
		public DateTime Fecha { get; set; }

		public Cuota()
		{
			this.Fecha = DateTime.Now;
		}
	}
}
