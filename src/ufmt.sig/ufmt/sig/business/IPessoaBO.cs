using System;
using System.Collections.Generic;
using ufmt.sig.entity;

namespace ufmt.sig.business;

public interface IPessoaBO : IDisposable
{
	Pessoa GetPessoa(string cpf);

	Pessoa GetPessoa(long pessoaUID);

	IList<Pessoa> GetPessoas(string Nome);

	IList<Pessoa> GetPessoas(string Nome, int? firstRowIndex, int? maximumRows);

	int CountPessoas(string Nome, int? firstRowIndex, int? maximumRows);

	void SalvePessoa(Pessoa pessoa);

	Servidor GetServidor(string registro, char tipoRegistro);

	Servidor GetServidor(long servidorUID);

	Servidor GetServidorAtivo(long pessoaUID);

	IList<Servidor> GetServidores(string nomeParcial, string registro, bool? apenasDocente, int? firstRowIndex, int? maximumRows);

	IList<Servidor> GetServidores(string nomeParcial, string registro, bool apenasAtivos, bool? apenasDocente, int? firstRowIndex, int? maximumRows);

	int CountGetServidores(string nomeParcial, string registro, bool? apenasDocente, int? firstRowIndex, int? maximumRows);

	int CountGetServidores(string nomeParcial, string registro, bool apenasAtivos, bool? apenasDocente, int? firstRowIndex, int? maximumRows);

	IList<Servidor> GetServidoresPorUnidadeLotacional(long unidadeLotacionalUID, string nomeParcial, string registro, bool? apenasDocente, int? firstRowIndex, int? maximumRows);

	IList<Servidor> GetServidoresPorUnidadeLotacional(long unidadeLotacaoUID, string nomeParcial, string registro, bool apenasAtivos, bool? apenasDocente, int? firstRowIndex, int? maximumRows);

	IList<Servidor> GetVinculosDocenciaPorPessoa(long pessoaUID);

	IList<Servidor> GetVinculosPorPessoa(long pessoaUID, bool apenasAtivos);

	void SalveServidor(Servidor servidor);

	void AltereLotacaoServidor(long servidorUID, long? unidadeLotacionalUID);

	IList<TipoOcorrenciaServidor> GetTiposOcorrenciaServidor(CategoriaOcorrenciaEnum? categoriaOcorrencia);

	TipoOcorrenciaServidor GetTipoOcorrenciaServidor(long tipoOcorrenciaServidorUID);

	IList<TipoTitulacao> GetTiposTitulacao();

	List<OcorrenciaServidor> GetOcorrenciaServidor(long servidorUID, long? idOcorrencia);

	List<OcorrenciaServidor> GetOcorrenciaServidor(long servidorUID);

	void AlteraStatusServidorAluno(long servidorUID, bool status);

	SituacaoServidor GetSituacaoServidor(string situacaoServidor);

	IList<TipoNecessidadeEspecial> getTiposNecessidadeEspecial();

	IList<NecessidadeEspecial> getNecessidadesEspeciais(long pessoaUID);

	void setNecessidadeEspecial(long pessoaUID, string tipoNecessidadeEspecialUID);

	void removerNecessidadeEspecial(long pessoaUID, string tipoNecessidadeEspecialUID);
}
