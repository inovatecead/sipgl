using System;
using System.Collections.Generic;
using ufmt.sig.entity.cineclube;

namespace ufmt.sig.business.cineclube;

public interface IFilmeBO : IDisposable
{
	Filme getFilme(long filmeUID);

	IList<Filme> getFilmes(long? generoUID, string titulo, int? firstRowIndex, int? maximumRows);

	IList<Agenda> getAgenda(DateTime DataInicial, DateTime DataFinal, int? firstRowIndex, int? maximumRows);

	IList<Agenda> getAgendas(long filmeUID);

	Agenda getAgenda(int agendaUID);

	Genero getGenero(long generoUID);

	IList<Genero> getGeneros(int? firstRowIndex, int? maximumRows);

	void salvarFilme(Filme filme);

	void salvarAgenda(Agenda ag);

	void salvarGenero(Genero genero);

	void removeFilme(Filme filme);

	void removeAgenda(Agenda agenda);
}
