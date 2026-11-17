USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewProjetoTurmaPolo]    Script Date: 07/02/2019 10:46:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [Sipgl].[ViewProjetoTurmaPolo] AS 

	SELECT 
	
		m.Nome as municipio,
		
		e.tipoUnidadeEnsino as tipoUnidadeEnsino,
		e.identificacaoEndereco as identificacaoEndereco,
		e.bairroEndereco as bairroEndereco,
		e.logradouro as logradouro,

		pt.projetoTurmaUID as projetoTurmaUID,
		pt.projetoCursoUID as projetoCursoUID,
		
		ptp.enderecoUID as enderecoUID,
		ptp.quantidadeVagas as quantidadeVagas
		
	FROM sipgl.ProjetoTurmaPolo ptp
		INNER JOIN Sipgl.EnderecoPoloApoioPresencialEAD e  ON ptp.enderecoUID = e.enderecoUID
		INNER JOIN Sipgl.ProjetoTurma pt  ON ptp.projetoTurmaUID = pt.projetoTurmaUID
		INNER JOIN dbo.Municipio m ON e.municipioEnderecoUID = m.MunicipioUID;

GO