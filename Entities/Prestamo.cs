using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Serializable]
	public class Prestamo
	{
		[Key]
		public int Id_Prestamo { get; set; }
		[Required]
		public int Id_Usuario_Creador { get; set; }
		[Required]
		public int Id_Cliente { get; set; }
		[Required]
		public int Id_Empresa { get; set; }
		[Required]
		public decimal P_Interes { get; set; }
		[Required]
		public decimal P_Mora { get; set; }		
		[Required]
		public int Semanas_Atraso_Mora { get; set; }
		[Required]
		public decimal Monto_Capital { get; set; }
		public decimal Monto_Total_Prestado { get; set; }
		private decimal _balance;
		public decimal Balance { 
		get {
				return this._balance - this.Cobros.Sum(x=>x.Monto_Total);
			}

			set
			{
				_balance = value;
			}
		}
		public DateTime Fecha_Vencimiento { get; set; }
		public bool Activo { get; set; }
		public bool Pausar_Mora { get; set; }
		public DateTime Fecha { get; set; }

		public virtual List<Cuota> Cuotas { get; set; }
		public virtual List<Cobro> Cobros { get; set; }

		public Prestamo()
		{
			this.Fecha = DateTime.Now;
			this.Cuotas = new List<Cuota>();
			this.Cobros = new List<Cobro>();
			this.Fecha_Vencimiento = DateTime.Now.AddDays(91);
		}
	}
}
