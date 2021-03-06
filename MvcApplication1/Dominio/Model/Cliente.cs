using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace Hilvilla.Dominio.Model
{
	[Serializable]
	public partial class Cliente
	{
		public Cliente()
		{
			Cotizacions = new HashedSet<Cotizacion>();
			Telefonos = new HashedSet<Telefono>();		
		}
       
        [DataType(DataType.Text)]
        [DisplayName("Apellido")]
		public virtual string Apellido
		{
			get;
			set;
		}
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Direccion")]
		public virtual string Direccion
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
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Rif o Cedula")]
		public virtual Int32 RifCedula
		{
			get;
			set;
		}
        [Required]
        [DataType(DataType.Text)]
        [DisplayName("Tipo")]
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
		public virtual ISet<Telefono> Telefonos
		{
			get;
			set;
		}
		
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
				
			return Equals(obj as Cliente);
		}
		
		public virtual bool Equals(Cliente obj)
		{
			if (obj == null) return false;

			if (Equals(Apellido, obj.Apellido) == false)
				return false;

			if (Equals(Direccion, obj.Direccion) == false)
				return false;

			if (Equals(Nombre, obj.Nombre) == false)
				return false;

			if (Equals(RifCedula, obj.RifCedula) == false)
				return false;

			if (Equals(Tipo, obj.Tipo) == false)
				return false;

			return true;
		}
		
		public override int GetHashCode()
		{
			int result = 1;

			result = (result * 397) ^ (Apellido != null ? Apellido.GetHashCode() : 0);
			result = (result * 397) ^ (Direccion != null ? Direccion.GetHashCode() : 0);
			result = (result * 397) ^ (Nombre != null ? Nombre.GetHashCode() : 0);
			result = (result * 397) ^ (RifCedula != null ? RifCedula.GetHashCode() : 0);
			result = (result * 397) ^ (Tipo != null ? Tipo.GetHashCode() : 0);			
			return result;
		}
	}
}