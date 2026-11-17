using System;

namespace ufmt.sig.entity;

[Serializable]
public class PlanoPedagogico
{
	private long planoPedagogicoUID;

	private MatrizCurricular matrizCurricular;

	private string nomeArquivo;

	private string tipoConteudo;

	private byte[] arquivo;

	private DateTime dataModificacao;

	public virtual long PlanoPedagogicoUID
	{
		get
		{
			return planoPedagogicoUID;
		}
		set
		{
			planoPedagogicoUID = value;
		}
	}

	public virtual MatrizCurricular MatrizCurricular
	{
		get
		{
			return matrizCurricular;
		}
		set
		{
			matrizCurricular = value;
		}
	}

	public virtual string NomeArquivo
	{
		get
		{
			return nomeArquivo;
		}
		set
		{
			nomeArquivo = value;
		}
	}

	public virtual string TipoConteudo
	{
		get
		{
			return tipoConteudo;
		}
		set
		{
			tipoConteudo = value;
		}
	}

	public virtual byte[] Arquivo
	{
		get
		{
			return arquivo;
		}
		set
		{
			arquivo = value;
		}
	}

	public virtual DateTime DataModificacao
	{
		get
		{
			return dataModificacao;
		}
		set
		{
			dataModificacao = value;
		}
	}
}
