using System;

namespace ufmt.sig.entity;

[Serializable]
public class CoordenadorCurso
{
	private Pessoa pessoa;

	private Curso curso;

	private DateTime dataInicial;

	private DateTime? dataFinal;

	public virtual Pessoa Pessoa
	{
		get
		{
			return pessoa;
		}
		set
		{
			pessoa = value;
		}
	}

	public virtual Curso Curso
	{
		get
		{
			return curso;
		}
		set
		{
			curso = value;
		}
	}

	public virtual DateTime DataInicial
	{
		get
		{
			return dataInicial;
		}
		set
		{
			dataInicial = value;
		}
	}

	public virtual DateTime? DataFinal
	{
		get
		{
			return dataFinal;
		}
		set
		{
			dataFinal = value;
		}
	}

	public override bool Equals(object obj)
	{
		CoordenadorCurso coordenadorCurso = obj as CoordenadorCurso;
		if (coordenadorCurso.curso.Equals(curso) && coordenadorCurso.pessoa.Equals(pessoa))
		{
			return coordenadorCurso.dataInicial.Equals(dataInicial);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return curso.GetHashCode() ^ pessoa.GetHashCode() ^ dataInicial.GetHashCode();
	}
}
