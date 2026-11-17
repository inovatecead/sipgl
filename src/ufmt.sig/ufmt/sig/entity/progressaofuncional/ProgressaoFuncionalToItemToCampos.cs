using System;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class ProgressaoFuncionalToItemToCampos : IEntidade
{
	public virtual int Id { get; set; }

	public virtual int ProgressaoFuncionalToItemId { get; set; }

	public virtual int CamposId { get; set; }

	public virtual ProgressaoFuncionalToItem ProgressaoFuncionalToItem { get; set; }

	public virtual Campos Campo { get; set; }

	public virtual string Valor { get; set; }
}
