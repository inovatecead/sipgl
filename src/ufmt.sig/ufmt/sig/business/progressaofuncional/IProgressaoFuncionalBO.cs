using System;
using System.Collections.Generic;
using ufmt.sig.entity.progressaofuncional;

namespace ufmt.sig.business.progressaofuncional;

public interface IProgressaoFuncionalBO : IDisposable
{
	int Inserir(object obj);

	List<T> SelecionarTodos<T>() where T : IEntidade;

	void Deletar<T>(int cod) where T : IEntidade;

	int Atualizar(object obj);

	List<ProgressaoFuncional> SelecionarProgressaoFuncionalPorPessoaUID(long pessoaUID);
}
