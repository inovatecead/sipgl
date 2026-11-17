using System;
using System.Collections.Generic;
using ufmt.sig.entity;

namespace ufmt.sig.business;

public interface IAplicacaoBO : IDisposable
{
	Aplicacao getAplicacao(long aplicacaoUID);

	IList<Aplicacao> getAplicacoes(string situacao, string sigla, string nome, int? firstRowIndex, int? maximumRows);

	void salvaAplicacao(Aplicacao app);
}
