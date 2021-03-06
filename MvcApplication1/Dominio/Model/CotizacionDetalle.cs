using System;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class CotizacionDetalle
	{
		public CotizacionDetalle()
		{		
		}
		public virtual int Cantidad
		{
			get;
			set;
		}
		public virtual DateTime Fecha
		{
			get;
			set;
		}
		public virtual int IdCotizacion
		{
			get;
			set;
		}
		public virtual int IdDetalle
		{
			get;
			set;
		}
		public virtual Cotizacion Cotizacion
		{
			get;
			set;
		}
		public virtual Detalle Detalle
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as CotizacionDetalle);
		}
		
		public virtual bool Equals(CotizacionDetalle obj)
		{
			if (obj == null) return false;

			if (Equals(Cantidad, obj.Cantidad) == false)
				return false;

			if (Equals(Fecha, obj.Fecha) == false)
				return false;

			if (Equals(IdCotizacion, obj.IdCotizacion) == false)
				return false;

			if (Equals(IdDetalle, obj.IdDetalle) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Cantidad != null ? Cantidad.GetHashCode() : 0);
			result = (result * 397) ^ (Fecha != null ? Fecha.GetHashCode() : 0);
			result = (result * 397) ^ (IdCotizacion != null ? IdCotizacion.GetHashCode() : 0);
			result = (result * 397) ^ (IdDetalle != null ? IdDetalle.GetHashCode() : 0);			
			return result;
		}
	}
}