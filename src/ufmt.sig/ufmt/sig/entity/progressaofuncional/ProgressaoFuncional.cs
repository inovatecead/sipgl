using System;
using System.Collections.Generic;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class ProgressaoFuncional : IEntidade
{
	private IList<Ocorrencia> ocorrencias = new List<Ocorrencia>();

	private IList<ProgressaoFuncionalToItem> progressaoFuncionalToItems = new List<ProgressaoFuncionalToItem>();

	public IList<Ocorrencia> Ocorrencias
	{
		get
		{
			return ocorrencias;
		}
		set
		{
			ocorrencias = value;
		}
	}

	public virtual IList<ProgressaoFuncionalToItem> ProgressaoFuncionalToItems
	{
		get
		{
			return progressaoFuncionalToItems;
		}
		set
		{
			progressaoFuncionalToItems = value;
		}
	}

	public virtual int Id { get; set; }

	public virtual long PessoaUID { get; set; }

	public virtual string periodo { get; set; }

	public virtual string situacao { get; set; }

	public virtual DateTime? dataEnvio { get; set; }

	public virtual DateTime? dataAprovacao { get; set; }

	public virtual DateTime? dataCriacao { get; set; }

	public virtual double? totalPontos
	{
		get
		{
			double num = 0.0;
			foreach (ProgressaoFuncionalToItem progressaoFuncionalToItem in progressaoFuncionalToItems)
			{
				num += progressaoFuncionalToItem.Pontuacao;
			}
			return num;
		}
	}

	public virtual double? totalPontosValidos
	{
		get
		{
			double num = 0.0;
			foreach (ProgressaoFuncionalToItem progressaoFuncionalToItem in progressaoFuncionalToItems)
			{
				if (!progressaoFuncionalToItem.ehPrescrito && progressaoFuncionalToItem.ehValida)
				{
					num += progressaoFuncionalToItem.Pontuacao;
				}
			}
			return num;
		}
	}

	public virtual double? totalPontosPrescritos
	{
		get
		{
			double num = 0.0;
			foreach (ProgressaoFuncionalToItem progressaoFuncionalToItem in progressaoFuncionalToItems)
			{
				if (progressaoFuncionalToItem.ehPrescrito || !progressaoFuncionalToItem.ehValida)
				{
					num += progressaoFuncionalToItem.Pontuacao;
				}
			}
			return num;
		}
	}

	public virtual Pessoa Pessoa { get; set; }
}
