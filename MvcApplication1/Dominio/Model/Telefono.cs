using System;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class Telefono
	{
		public Telefono()
		{		
		}
		public virtual int Codigo
		{
			get;
			set;
		}
		public virtual int IdTelefono
		{
			get;
			set;
		}
		public virtual int Nro
		{
			get;
			set;
		}
		public virtual Cliente Cliente
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Telefono);
		}
		
		public virtual bool Equals(Telefono obj)
		{
			if (obj == null) return false;

			if (Equals(Codigo, obj.Codigo) == false)
				return false;

			if (Equals(IdTelefono, obj.IdTelefono) == false)
				return false;

			if (Equals(Nro, obj.Nro) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Codigo != null ? Codigo.GetHashCode() : 0);
			result = (result * 397) ^ (IdTelefono != null ? IdTelefono.GetHashCode() : 0);
			result = (result * 397) ^ (Nro != null ? Nro.GetHashCode() : 0);			
			return result;
		}
	}
}