using System;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class SubCategoria : IEntidade
{
	public virtual int Id { get; set; }

	public virtual int CategoriaId { get; set; }

	public virtual Categoria Categoria { get; set; }

	public virtual string Nome { get; set; }

	public virtual string Descricao { get; set; }
}
