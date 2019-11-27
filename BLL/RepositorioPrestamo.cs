using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class RepositorioPrestamo : RepositorioBase<Prestamo>
	{
		public override Prestamo Get(int id)
		{
			Prestamo Prestamo = new Prestamo();
			Contexto contexto = new Contexto();
			try
			{
				Prestamo = contexto.Prestamo.Where(x => x.Id_Prestamo == id).AsNoTracking().FirstOrDefault();
			}
			catch (Exception)
			{

				throw;

			}
			finally
			{

				contexto.Dispose();

			}
			return Prestamo;
		}
		




		public override bool Modify(Prestamo entity)
		{
			bool paso = false;
			Prestamo Anterior = Get(entity.Id_Prestamo);
			Contexto context = new Contexto();
			//entity.Detalle = new List<PrestamoDetalle>();
			//context.Prestamo.Attach(entity);
			try
			{
				using (Contexto contexto = new Contexto())
				{
					foreach (var item in Anterior.Cuotas.ToList())
					{
						if (!entity.Cuotas.Exists(x => x.Id_Cuota == item.Id_Cuota))
						{
							contexto.Entry(item).State = EntityState.Deleted;
						}
					}
					contexto.SaveChanges();

				}

				using (Contexto contexto = new Contexto())
				{
					foreach (var item in Anterior.Cobros.ToList())
					{
						if (!entity.Cobros.Exists(x => x.Id_Cobro == item.Id_Cobro))
						{
							contexto.Entry(item).State = EntityState.Deleted;
						}
					}
					contexto.SaveChanges();

				}


				foreach (var item in entity.Cuotas.ToList())
				{
					var estado = EntityState.Unchanged;
					if (item.Id_Cuota == 0)
					{
						estado = EntityState.Added;
						context.Entry(item).State = estado;
					}

				}

				foreach (var item in entity.Cobros.ToList())
				{
					var estado = EntityState.Unchanged;
					if (item.Id_Cobro == 0)
					{
						estado = EntityState.Added;
						context.Entry(item).State = estado;
					}

				}

				context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
				paso = context.SaveChanges() > 0;

			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				context.Dispose();
			}
			return paso;
		}
	}
}
