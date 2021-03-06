using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class Detalle
	{
		public Detalle()
		{
			CotizacionDetalles = new HashedSet<CotizacionDetalle>();		
		}
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Precio")]
		public virtual int Costo
		{
			get;
			set;
		}
		public virtual string Descripcion
		{
			get;
			set;
		}
        public virtual string Tipo
        {
            get;
            set;
        }
		public virtual int IdDetalle
		{
			get;
			set;
		}
		public virtual ISet<CotizacionDetalle> CotizacionDetalles
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Detalle);
		}
		
		public virtual bool Equals(Detalle obj)
		{
			if (obj == null) return false;

			if (Equals(Costo, obj.Costo) == false)
				return false;

			if (Equals(Descripcion, obj.Descripcion) == false)
				return false;

			if (Equals(IdDetalle, obj.IdDetalle) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Costo != null ? Costo.GetHashCode() : 0);
			result = (result * 397) ^ (Descripcion != null ? Descripcion.GetHashCode() : 0);
			result = (result * 397) ^ (IdDetalle != null ? IdDetalle.GetHashCode() : 0);			
			return result;
		}
	}
}