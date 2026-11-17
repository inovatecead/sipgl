using System;
using System.Collections.Generic;
using ufmt.sig.entity;
using ufmt.sig.entity.sge;

namespace ufmt.sig.business;

public interface ILocalizacaoBO : IDisposable
{
	IList<Campus> GetCampi();

	Unidade GetUnidade(long unidadeUID);

	IList<Unidade> GetUnidades(int? campusUID, long? unidadeSuperiorUID, string nomeParcial, string siglaParcial, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows);

	IList<Unidade> GetUnidadesSuperiores(int? campusUID, string nomeParcial, string siglaParcial, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows);

	void InserirUnidade(Unidade novaUnidade);

	ResponsavelUnidade DefinaResponsavel(long unidadeUID, long pessoaUID, DateTime dataInicio);

	void InserirUnidadeEResponsavel(Unidade novaUnidade, ResponsavelUnidade novoResponsavel);

	void RemovaResponsavel(long unidadeUID);

	IList<ResponsavelUnidade> GetResponsaveis(string nomeResponsavelParcial, string nomeUnidadeParcial, string siglaUnidadeParcial, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows);

	IList<ResponsavelUnidade> GetResponsaveis(int? campusUID, long? unidadeSuperiorUID, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows);

	IList<Unidade> GetUnidadesPorResponsavel(long pessoaResponsavelUID, long? unidadeSuperiorUID, TipoUnidadeEnum? tipoUnidade, int? firstRowIndex, int? maximumRows);

	ResponsavelUnidade GetResponsavel(long unidadeUID);

	Uf getUf(string sigla);

	IList<Uf> getUfs(string nomeParcial);

	Municipio getMunicipio(int municipioUID);

	IList<Municipio> getMunicipios(string uf);

	UnidadeAlocadora getUnidadeAlocadora(long unidadeUID);
}
