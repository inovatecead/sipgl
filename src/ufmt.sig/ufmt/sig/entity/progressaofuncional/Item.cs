using System;
using System.Collections.Generic;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class Item : IEntidade
{
	private IList<ItemToCampos> itemToCampos = new List<ItemToCampos>();

	public virtual int Id { get; set; }

	public virtual SubCategoria SubCategoria { get; set; }

	public virtual Metrica Metrica { get; set; }

	public virtual IList<ItemToCampos> ItemToCampos
	{
		get
		{
			return itemToCampos;
		}
		set
		{
			itemToCampos = value;
		}
	}

	public virtual int MetricaId { get; set; }

	public virtual int SubCategoriaId { get; set; }

	public virtual string Descricao { get; set; }

	public virtual int? Passo { get; set; }

	public virtual double? Pontos { get; set; }
}
