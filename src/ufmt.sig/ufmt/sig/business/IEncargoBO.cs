using System;
using System.Collections.Generic;
using ufmt.sig.entity;

namespace ufmt.sig.business;

public interface IEncargoBO : IDisposable
{
	float CoeficientePreparacaoAula { get; }

	float MinimoCargaHorariaEnsino { get; }

	float MinimoCargaHorariaEnsinoGraduacao { get; }

	float CargaHorariaOrientacaoGraducao { get; }

	float CargaHorariaOrientacaoPosGraduacaoStricto { get; }

	float CargaHorariaOrientacaoPosGraduacaoLato { get; }

	float LimiteOrientacaoEnsino { get; }

	float LimitePesquisa { get; }

	float LimiteExtensao { get; }

	float GetCargaHorariaOrientacao(MatrizDisciplinar matrizDisciplinar);

	ResumoEncargoServidor GetResumoEncargoServidor(long servidorUID, int ano, short? periodo);

	ResumoEncargoServidor GetResumoEncargoServidor(long servidorUID, int ano, short? periodo, bool recDisciplinasAnuaisPrimeiroPeriodo);

	TipoEncargoServidor GetTipoEncargoServidor(int tipoEncargoServidorUID);

	IList<TipoEncargoServidor> GetTiposEncargosServidor(CategoriaEncargoEnum? categoriaEncargo);

	EncargoServidor GetEncargoServidor(long encargoServidorUID);

	IList<EncargoServidor> GetEncargosServidor(int ano, short? periodo, long? servidorUID, CategoriaEncargoEnum? categoriaEncargo, int? firstRowIndex, int? maximumRows);

	void SalveEncargoServidor(EncargoServidor encargoServidor);

	void RemovaEncargoServidor(long encargoServidorUID);

	IList<int> GetAnosDeclaracaoEncargos();

	IList<short> GetPeriodosDeclaracaoEncargos(int ano);

	Afastamento getAfastamento(long afastamentoUID);

	IList<Afastamento> getAfastamentos(long servidorUID, int ano, short? periodo);

	void addAfastamento(long servidorUID, int ano, short periodo, DateTime dataInicial, DateTime? dataFinal, string justificativa, string documentoComprobatorio);

	void atualizeAfastamento(long afastamentoUID, DateTime dataInicial, DateTime? dataFinal, string justificativa, string documentoComprobatorio);

	void removaAfastamento(long afastamentoUID);

	void SalvePiaAprovadoServidor(int ano, short periodo, Servidor servidorDocente, Servidor serividorAprovador, bool avaliacaoAprovador, string justificativa, string observacaoDocente);

	void SalvePiaHomologadoServidor(int ano, short periodo, Servidor servidorDocente, Servidor serividorHomologador, bool avaliacaoHomologador, string justificativa, string observacaoDocente);

	HomologacaoPia GetHomologacaoPia(int ano, int periodo, long servidorUID);
}
