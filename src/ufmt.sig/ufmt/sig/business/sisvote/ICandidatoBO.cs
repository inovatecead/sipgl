using System;
using System.Collections.Generic;
using ufmt.sig.entity.sisvote;

namespace ufmt.sig.business.sisvote;

public interface ICandidatoBO : IDisposable
{
	Candidato GetCandidato(long candidatoUID);

	IList<Candidato> GetCandidatos(long eleicaoUID, long? cargoUID, int? firstRowIndex, int? maximumRows);
}
