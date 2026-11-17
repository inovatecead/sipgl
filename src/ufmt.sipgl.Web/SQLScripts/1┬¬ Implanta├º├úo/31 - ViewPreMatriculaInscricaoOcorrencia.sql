USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewPreMatriculaInscricaoOcorrencia]    Script Date: 31/01/2019 10:46:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [Sipgl].[ViewPreMatriculaInscricaoOcorrencia] AS 

	select 
		pmp.preMatriculaPessoaUID as preMatriculaPessoaUID, 
		pmp.nome as nome,

		pmi.preMatriculaInscricaoUID as preMatriculaInscricaoUID,
 
		pmo.preMatriculaIncricaoOcorrenciaUID as preMatriculaIncricaoOcorrenciaUID,
		pmo.dataHoraOcorrencia as dataHoraOcorrencia,
		pmo.observacao as observacao,

		tsi.nome as tipoSituacaoInscricao,

		p.nome as usuario

	from sipgl.PreMatriculaInscricaoOcorrencia pmo
		INNER JOIN sipgl.PreMatriculaInscricao pmi ON pmo.preMatriculaInscricaoUID = pmi.preMatriculaInscricaoUID
		INNER JOIN sipgl.PreMatriculaPessoa pmp ON pmi.preMatriculaPessoaUID = pmp.preMatriculaPessoaUID
		INNER JOIN sipgl.TipoSituacaoInscricao tsi ON pmo.tipoSituacaoInscricaoUID = tsi.tipoSituacaoInscricaoUID
		INNER JOIN dbo.Usuario u ON pmo.usuarioUID = u.usuarioUID
		INNER JOIN dbo.Pessoa p ON u.pessoaUID = p.pessoaUID;
	
GO