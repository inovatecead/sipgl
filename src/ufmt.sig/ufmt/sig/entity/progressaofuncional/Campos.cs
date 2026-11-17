using System;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class Campos : IEntidade
{
	public virtual int Id { get; set; }

	public virtual string NomeCampo { get; set; }

	public virtual int Tamanho { get; set; }

	public virtual string Tipo { get; set; }
}
