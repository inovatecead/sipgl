using System;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class ItemToCampos : IEntidade
{
	public virtual int Id { get; set; }

	public virtual int ItemId { get; set; }

	public virtual int CamposId { get; set; }

	public virtual Item Item { get; set; }

	public virtual Campos Campos { get; set; }
}
