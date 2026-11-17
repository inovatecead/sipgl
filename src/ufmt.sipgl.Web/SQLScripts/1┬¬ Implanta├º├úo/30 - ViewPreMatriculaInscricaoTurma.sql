USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewPreMatriculaInscricao]    Script Date: 30/01/2019 10:46:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [Sipgl].[ViewPreMatriculaInscricaoTurma]
		AS 

		SELECT  pmi.preMatriculaInscricaoUID as preMatriculaInscricaoUID,
				pmp.preMatriculaPessoaUID as preMatriculaPessoaUID,
				
				d.discenteUID as projetoDiscenteUID,
				d.registro as RGA,
				
				pmp.nome as nome,
				pmp.cpf as CPF,
				pmp.email as email,
				
				si.nome as tipoSituacaoInscricao,
				si.tipoSituacaoInscricaoUID as tipoSituacaoInscricaoUID,
				
				tp.projetoTurmaPoloUID as projetoTurmaPoloUID,
				tp.enderecoUID as enderecoUID,
				tp.projetoTurmaUID as projetoTurmaUID,
				
				e.identificacaoEndereco as identificacaoEndereco

		FROM    sipgl.PreMatriculaInscricao pmi

		INNER JOIN sipgl.PreMatriculaPessoa pmp ON pmp.preMatriculaPessoaUID = pmi.preMatriculaPessoaUID
		INNER JOIN sipgl.ProjetoDiscente d ON d.preMatriculaInscricaoUID = pmi.preMatriculaInscricaoUID
		INNER JOIN sipgl.TipoSituacaoInscricao si ON si.tipoSituacaoInscricaoUID = pmi.tipoSituacaoInscricaoUID
		INNER JOIN sipgl.ProjetoTurmaPolo tp ON tp.projetoTurmaPoloUID = pmi.projetoTurmaPoloUID
		INNER JOIN sipgl.EnderecoPoloApoioPresencialEAD e ON e.enderecoUID = tp.enderecoUID;

GO