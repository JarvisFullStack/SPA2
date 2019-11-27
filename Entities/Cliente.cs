using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Serializable]
	public class Cliente
	{
		[Key]
		public int Id_Cliente { get; set; }
		[Required]
		public int Id_Usuario_Creador { get; set; }
		[Required]
		public int Id_Empresa { get; set; }
		[Required]
		[MaxLength(60)]
		public string Nombre { get; set; }
		[Required]
		[MaxLength(60)]
		public string Apellido { get; set; }
		[Required]
		[MaxLength(14)]
		public string Cedula { get; set; }
		[Required]
		[MaxLength(120)]
		public string Direccion { get; set; }
		public decimal Balance { get; set; }
		public bool Activo { get; set; }
		public DateTime Fecha { get; set; }

		public Cliente()
		{
			this.Fecha = DateTime.Now;
		}
	}
}
