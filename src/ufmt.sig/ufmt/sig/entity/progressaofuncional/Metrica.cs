using System;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class Metrica : IEntidade
{
	public virtual int Id { get; set; }

	public virtual string Descricao { get; set; }
}
