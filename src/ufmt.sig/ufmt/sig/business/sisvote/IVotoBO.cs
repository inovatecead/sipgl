using System;
using System.Collections.Generic;
using ufmt.sig.entity;
using ufmt.sig.entity.sisvote;

namespace ufmt.sig.business.sisvote;

public interface IVotoBO : IDisposable
{
	void Votar(Candidato candidato, ufmt.sig.entity.sisvote.Cargo cargo, Servidor servidorVotante, TipoVoto tipoVoto, string ip);

	void RemoverVoto(long? candidatoUID, long cargoUID, long servidorVotanteUID, long tipoVotoUID);

	IList<Voto> GetVotos(long candidatoUID, int? firstRowIndex, int? maximumRows);

	IList<Voto> GetVotos(long cargoUID, TipoVoto tipoVoto, int? firstRowIndex, int? maximumRows);

	TipoVoto GetTipoVoto(long tipoVotoUID);

	Voto GetVoto(long servidorUID, long cargoUID);

	Eleicao GetEleicao(long eleicaoUID);

	void atualizarSituacaoEleicao(long eleicaoUID, SituacaoEleicaoEnum situacao);
}
