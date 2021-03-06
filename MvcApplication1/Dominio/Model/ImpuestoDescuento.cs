using System;
using Iesi.Collections.Generic;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class ImpuestoDescuento
	{
		public ImpuestoDescuento()
		{
			Cotizacions = new HashedSet<Cotizacion>();		
		}
		public virtual int IdImpuestoDescuento
		{
			get;
			set;
		}
		public virtual int Porcentaje
		{
			get;
			set;
		}
		public virtual string Tipo
		{
			get;
			set;
		}
		public virtual ISet<Cotizacion> Cotizacions
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as ImpuestoDescuento);
		}
		
		public virtual bool Equals(ImpuestoDescuento obj)
		{
			if (obj == null) return false;

			if (Equals(IdImpuestoDescuento, obj.IdImpuestoDescuento) == false)
				return false;

			if (Equals(Porcentaje, obj.Porcentaje) == false)
				return false;

			if (Equals(Tipo, obj.Tipo) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (IdImpuestoDescuento != null ? IdImpuestoDescuento.GetHashCode() : 0);
			result = (result * 397) ^ (Porcentaje != null ? Porcentaje.GetHashCode() : 0);
			result = (result * 397) ^ (Tipo != null ? Tipo.GetHashCode() : 0);			
			return result;
		}
	}
}