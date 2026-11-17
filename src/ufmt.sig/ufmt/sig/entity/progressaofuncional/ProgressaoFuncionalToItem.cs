using System;
using System.Collections.Generic;
using System.Linq;
using ufmt.sig.business;
using ufmt.sig.business.implementation.progressaofuncional;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class ProgressaoFuncionalToItem : IEntidade
{
	private int tempoDeValidadeDeUmaAtividadeEmDias = 1096;

	private IList<ProgressaoFuncionalToItemToCampos> progressaoFuncionalToItemToCampos = new List<ProgressaoFuncionalToItemToCampos>();

	public virtual int Id { get; set; }

	public virtual int ItemId { get; set; }

	public virtual int ProgressaoFuncionalId { get; set; }

	public virtual ProgressaoFuncional ProgressaoFuncional { get; set; }

	public virtual Item Item { get; set; }

	public virtual IList<ProgressaoFuncionalToItemToCampos> ProgressaoFuncionalToItemToCampos
	{
		get
		{
			return progressaoFuncionalToItemToCampos;
		}
		set
		{
			progressaoFuncionalToItemToCampos = value;
		}
	}

	public virtual double Pontuacao => (double)(carga.HasValue ? carga.Value : 0) / double.Parse(Item.Passo.Value.ToString()) * Item.Pontos.Value;

	public virtual string status { get; set; }

	public virtual int? carga { get; set; }

	public virtual DateTime? dataInicio { get; set; }

	public virtual DateTime? dataFim { get; set; }

	public virtual bool ehPrescrito
	{
		get
		{
			if (!dataFim.HasValue || !dataFim.HasValue)
			{
				return true;
			}
			return DateTime.Now.Subtract(dataFim.Value).Days > tempoDeValidadeDeUmaAtividadeEmDias;
		}
	}

	public virtual bool ehValida
	{
		get
		{
			ProgressaoFuncionalBO progressaoFuncionalBO = new ProgressaoFuncionalBO();
			List<ProgressaoFuncional> list = progressaoFuncionalBO.SelecionarProgressaoFuncionalPorPessoaUID(ProgressaoFuncional.PessoaUID);
			if (list.Count == 0)
			{
				return true;
			}
			IEnumerable<ProgressaoFuncional> source = list.Where((ProgressaoFuncional progAux) => progAux.dataAprovacao < dataInicio && progAux.dataAprovacao.HasValue);
			if (source.Count() == 0)
			{
				return true;
			}
			return false;
		}
	}
}
