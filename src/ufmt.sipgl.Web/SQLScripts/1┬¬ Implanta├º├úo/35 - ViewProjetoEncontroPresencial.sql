USE [idbufmt]
GO

/****** Object:  View [Sipgl].[[ViewProjetoEncontroPresencial]    Script Date: 09/04/2019 10:46:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [Sipgl].[ViewProjetoEncontroPresencial] AS 

SELECT 

	ep.projetoEncontroPresencialUID as projetoEncontroPresencialUID,
	ep.dataEncontro as dataEncontro,
	ep.isObrigatorio as isObrigatorio,

	e.enderecoUID as enderecoUID,
	e.identificacaoEndereco as identificacaoEndereco,
 
	t.projetoTurmaUID as projetoTurmaUID,
	t.nome as nomeTurma,

	d.projetoDisciplinaUID as projetoDisciplinaUID,
	d.nome as nomeDisciplina

FROM sipgl.ProjetoEncontroPresencial ep

INNER JOIN sipgl.ProjetoDisciplina d ON ep.projetoDisciplinaUID = d.projetoDisciplinaUID
INNER JOIN sipgl.ProjetoTurmaPolo tp ON ep.projetoTurmaPoloUID= tp.projetoTurmaPoloUID
INNER JOIN sipgl.ProjetoTurma t ON tp.projetoTurmaUID= t.projetoTurmaUID
INNER JOIN sipgl.EnderecoPoloApoioPresencialEAD e ON tp.enderecoUID = e.enderecoUID

GO