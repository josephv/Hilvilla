using System;
using Iesi.Collections.Generic;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class Cotizacion
	{
		public Cotizacion()
		{
			CotizacionDetalles = new HashedSet<CotizacionDetalle>();
			ImpuestoDescuentos = new HashedSet<ImpuestoDescuento>();		
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
		public virtual string Tipo
		{
			get;
			set;
		}
        public virtual string Control
        {
            get;
            set;
        }
		public virtual Cliente Cliente
		{
			get;
			set;
		}
		public virtual ISet<CotizacionDetalle> CotizacionDetalles
		{
			get;
			set;
		}
		public virtual ISet<ImpuestoDescuento> ImpuestoDescuentos
		{
			get;
			set;
		}
		public virtual Motor Motor
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Cotizacion);
		}
		
		public virtual bool Equals(Cotizacion obj)
		{
			if (obj == null) return false;

			if (Equals(Fecha, obj.Fecha) == false)
				return false;

			if (Equals(IdCotizacion, obj.IdCotizacion) == false)
				return false;

			if (Equals(Tipo, obj.Tipo) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Fecha != null ? Fecha.GetHashCode() : 0);
			result = (result * 397) ^ (IdCotizacion != null ? IdCotizacion.GetHashCode() : 0);
			result = (result * 397) ^ (Tipo != null ? Tipo.GetHashCode() : 0);			
			return result;
		}
	}
}