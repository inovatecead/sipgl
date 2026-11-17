using System;
using System.Collections.Generic;
using System.Linq;

namespace ufmt.sig.entity;

[Serializable]
public class ResumoEncargoServidor
{
	private Servidor servidor;

	private short quantidadePeriodos;

	private IList<AlocacaoDisciplinar> alocacoesDisciplinares;

	private IList<EncargoServidor> encargosServidor;

	private float totalEnsino;

	private float encargoEnsino;

	private float encargoEnsinoSemPreparo;

	private float totalPesquisa;

	private float encargoPesquisa;

	private float totalExtensao;

	private float encargoExtensao;

	private float encargoAdministracao;

	private float totalOrientacao;

	private float encargoOrientacao;

	private IList<CriticaEncargo> criticasEncargo = new List<CriticaEncargo>();

	public short QuantidadePeriodos
	{
		get
		{
			return quantidadePeriodos;
		}
		set
		{
			quantidadePeriodos = value;
		}
	}

	public Servidor Servidor => servidor;

	public IList<AlocacaoDisciplinar> AlocacoesDisciplinares => alocacoesDisciplinares;

	public IList<AlocacaoDisciplinar> AlocacoesDisciplinaresGraduacao => alocacoesDisciplinares.Where((AlocacaoDisciplinar ad) => NivelCursoEnum.GRADUACAO.Equals(ad.MatrizDisciplinar.MatrizCurricular.Curso.NivelCurso.Nivel)).ToList();

	public IList<AlocacaoDisciplinar> AlocacoesDisciplinaresPosGraduacao => alocacoesDisciplinares.Where((AlocacaoDisciplinar ad) => NivelCursoEnum.POS_GRADUACAO.Equals(ad.MatrizDisciplinar.MatrizCurricular.Curso.NivelCurso.Nivel)).ToList();

	public IList<EncargoServidor> EncargosServidor => encargosServidor;

	public IList<EncargoServidor> EncargosPesquisa => encargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.PESQUISA.Equals(es.TipoEncargoServidor.CategoriaEncargo)).ToList();

	public IList<EncargoServidor> EncargosExtensao => encargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.EXTENSAO.Equals(es.TipoEncargoServidor.CategoriaEncargo)).ToList();

	public IList<EncargoServidor> EncargosAdministracao => encargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.ATIVIDADE_ADMINISTRATIVA.Equals(es.TipoEncargoServidor.CategoriaEncargo)).ToList();

	public IList<EncargoServidor> EncargosOrientacao => encargosServidor.Where((EncargoServidor es) => CategoriaEncargoEnum.ORIENTACAO.Equals(es.TipoEncargoServidor.CategoriaEncargo)).ToList();

	public float Encargo => encargoEnsino + encargoPesquisa + encargoExtensao + encargoAdministracao + encargoOrientacao;

	public float Total => totalEnsino + totalPesquisa + totalExtensao + encargoAdministracao + totalOrientacao;

	public float TotalEnsino
	{
		get
		{
			return totalEnsino;
		}
		set
		{
			totalEnsino = value;
		}
	}

	public float EncargoEnsino
	{
		get
		{
			return encargoEnsino;
		}
		set
		{
			encargoEnsino = value;
		}
	}

	public float EncargoEnsinoSemPreparo
	{
		get
		{
			return encargoEnsinoSemPreparo;
		}
		set
		{
			encargoEnsinoSemPreparo = value;
		}
	}

	public float TotalPesquisa
	{
		get
		{
			return totalPesquisa;
		}
		set
		{
			totalPesquisa = value;
		}
	}

	public float EncargoPesquisa
	{
		get
		{
			return encargoPesquisa;
		}
		set
		{
			encargoPesquisa = value;
		}
	}

	public float TotalExtensao
	{
		get
		{
			return totalExtensao;
		}
		set
		{
			totalExtensao = value;
		}
	}

	public float EncargoExtensao
	{
		get
		{
			return encargoExtensao;
		}
		set
		{
			encargoExtensao = value;
		}
	}

	public float EncargoAdministracao
	{
		get
		{
			return encargoAdministracao;
		}
		set
		{
			encargoAdministracao = value;
		}
	}

	public float TotalOrientacao
	{
		get
		{
			return totalOrientacao;
		}
		set
		{
			totalOrientacao = value;
		}
	}

	public float EncargoOrientacao
	{
		get
		{
			return encargoOrientacao;
		}
		set
		{
			encargoOrientacao = value;
		}
	}

	internal void SetServidor(Servidor servidor)
	{
		this.servidor = servidor;
	}

	internal void SetAlocacoesDisciplinares(IList<AlocacaoDisciplinar> alocacoesDisciplinares)
	{
		this.alocacoesDisciplinares = alocacoesDisciplinares;
	}

	internal void SetEncargosServidor(IList<EncargoServidor> encargosServidor)
	{
		this.encargosServidor = encargosServidor;
	}

	public CriticaEncargo[] GetCriticas(CategoriaCriticaEncargo? categoriaCriticaEncargo)
	{
		return criticasEncargo.Where((CriticaEncargo ce) => !categoriaCriticaEncargo.HasValue || ce.Categoria.Equals(categoriaCriticaEncargo.Value)).ToArray();
	}

	public void ClearCriticas()
	{
		criticasEncargo.Clear();
	}

	public void AddCritica(CategoriaCriticaEncargo categoriaCriticaEncargo, string descricao)
	{
		criticasEncargo.Add(new CriticaEncargo(categoriaCriticaEncargo, descricao));
	}
}
