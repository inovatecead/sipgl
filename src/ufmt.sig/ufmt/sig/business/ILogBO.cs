using System;
using ufmt.sig.entity;

namespace ufmt.sig.business;

public interface ILogBO : IDisposable
{
	void inserirLog(Aplicacao aplicacao, Usuario usuario, Log.OperacaoLog operacao, string ip, string valorAntigo, string valorNovo, string detalhes);
}
