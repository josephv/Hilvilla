using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class Motor
	{
		public Motor()
		{
			Cotizacions = new HashedSet<Cotizacion>();		
		}
		public virtual DateTime? Anio
		{
			get;
			set;
		}
		public virtual int IdMotor
		{
			get;
			set;
		}
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Nombre")]
        public virtual string Nombre
        {
            get;
            set;
        }
		public virtual ISet<Cotizacion> Cotizacions
		{
			get;
			set;
		}
		public virtual Marca Marca
		{
			get;
			set;
		}
        public virtual Tipo Tipo
        {
            get;
            set;
        }
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Motor);
		}
		
		public virtual bool Equals(Motor obj)
		{
			if (obj == null) return false;

			if (Equals(Anio, obj.Anio) == false)
				return false;

			if (Equals(IdMotor, obj.IdMotor) == false)
				return false;

			if (Equals(Nombre, obj.Nombre) == false)
				return false;

			

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Anio != null ? Anio.GetHashCode() : 0);
			result = (result * 397) ^ (IdMotor != null ? IdMotor.GetHashCode() : 0);
			result = (result * 397) ^ (Nombre != null ? Nombre.GetHashCode() : 0);
			
			return result;
		}
	}
}