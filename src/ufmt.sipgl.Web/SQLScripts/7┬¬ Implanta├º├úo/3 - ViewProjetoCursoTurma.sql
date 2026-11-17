USE [idbufmt]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [Sipgl].[ViewProjetoCursoTurma]
		AS 
		SELECT

	pc.projetoCursoUID,
	pc.nomeCurso,

	pt.projetoTurmaUID,
	pt.nome as descricaoTurma,
	pt.DataInicio as dataInicioTurma,
	pt.DataFim as dataFimTurma, 
	pt.isAtivo as isTurmaAtiva

	FROM sipgl.ProjetoCurso pc

	INNER JOIN sipgl.ProjetoTurma pt on pc.projetoCursoUID = pt.projetoCursoUID

GO