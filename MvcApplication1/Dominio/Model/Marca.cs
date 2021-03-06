using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class Marca
	{
		public Marca()
		{
			Motors = new HashedSet<Motor>();		
		}
		public virtual int IdMarca
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
		public virtual ISet<Motor> Motors
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Marca);
		}
		
		public virtual bool Equals(Marca obj)
		{
			if (obj == null) return false;

			if (Equals(IdMarca, obj.IdMarca) == false)
				return false;

			if (Equals(Nombre, obj.Nombre) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (IdMarca != null ? IdMarca.GetHashCode() : 0);
			result = (result * 397) ^ (Nombre != null ? Nombre.GetHashCode() : 0);			
			return result;
		}
	}
}