using System;
using System.Collections.Generic;
using ufmt.sig.entity.sisvote;

namespace ufmt.sig.business.sisvote;

public interface ICargoBO : IDisposable
{
	IList<Cargo> GetCargos(long eleicaoUID, long? unidadeUID, string descricaoParcial, int? firstRowIndex, int? maximumRows);

	Cargo GetCargo(long cargoUID);
}
