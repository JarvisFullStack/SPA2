using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
	[Serializable]
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
		[MaxLength(60)]
		[Required]
        public string Nombre { get; set; }
		[MaxLength(60)]
		[Required]
		public string Apellido { get; set; }
		[MaxLength(150)]
		[Required]	
		public string Correo { get; set; }
		[MaxLength(300)]
		[Required]
		public string Password { get; set; }
        public Enums.NivelUsuario Nivel { get; set; }		
		public bool Activo { get; set; }
		public DateTime Fecha { get; set; }

        public Usuario()
        {
            this.Nivel = Enums.NivelUsuario.NORMAL;
            this.Fecha = DateTime.Now;
			this.Activo = true;
        }

		public Usuario(int id_Usuario, string nombre, string apellido, string correo, string password, Enums.NivelUsuario nivel, bool activo, DateTime createdAt)
		{
			Id_Usuario = id_Usuario;
			Nombre = nombre;
			Apellido = apellido;
			Correo = correo;
			Password = password;
			Nivel = nivel;
			Activo = activo;
			Fecha = createdAt;
		}
	}
}
