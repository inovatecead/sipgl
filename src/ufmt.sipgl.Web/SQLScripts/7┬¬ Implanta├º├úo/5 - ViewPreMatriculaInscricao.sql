USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewPreMatriculaInscricao]    Script Date: 27/06/2020 16:18:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER VIEW [Sipgl].[ViewPreMatriculaInscricao]
		AS 
		SELECT pmi.preMatriculaInscricaoUID
			  ,pmi.preMatriculaPessoaUID
			  ,pmi.numeroInscricao
			  
			  ,pmp.nome AS pessoaNome
			  ,pmp.cpf as cpf
			  ,pmp.email
			  ,pmp.dataHoraUltimaAtualizacao
			  
			  ,tsi.tipoSituacaoInscricaoUID
			  ,tsi.nome tipoSituacaoInscricaoNome

			  ,pd.discenteUID as discenteUID
			  ,pd.registro as RGA

			  ,pt.projetoTurmaUID as projetoTurmaUID
			  ,pt.nome as descricaoTurma
			  ,pt.isAtivo as isTurmaAtiva
			  ,pt.DataInicio as projetoTurmaDataInicio
			  ,pt.DataFim as projetoTurmaDataFim

			  ,ptp.projetoTurmaPoloUID as projetoTurmaPoloUID
			  ,ptp.quantidadeVagas as quantidadeVagas

			  ,pc.projetoCursoUID as projetoCursoUID
			  ,pc.nomeCurso AS cursoNome
			  
			  ,m.Nome as municipio
			  
			  ,ep.enderecoUID as enderecoUID
			  ,ep.identificacaoEndereco as identificacaoEndereco

		  FROM Sipgl.PreMatriculaInscricao pmi 
			
			INNER JOIN Sipgl.PreMatriculaPessoa pmp ON pmp.preMatriculaPessoaUID = pmi.preMatriculaPessoaUID

		    INNER JOIN Sipgl.TipoSituacaoInscricao tsi ON tsi.tipoSituacaoInscricaoUID = pmi.tipoSituacaoInscricaoUID

		    INNER JOIN Sipgl.ProjetoTurmaPolo ptp ON ptp.projetoTurmaPoloUID = pmi.projetoTurmaPoloUID

			INNER JOIN Sipgl.ProjetoTurma pt ON pt.projetoTurmaUID = ptp.projetoTurmaUID

			INNER JOIN Sipgl.ProjetoCurso pc ON pc.projetoCursoUID = pt.projetoCursoUID

			INNER JOIN Sipgl.EnderecoPoloApoioPresencialEAD ep ON ep.enderecoUID = ptp.enderecoUID

			INNER JOIN dbo.Municipio m ON m.MunicipioUID = ep.municipioEnderecoUID

			LEFT JOIN Sipgl.ProjetoDiscente pd ON pd.preMatriculaInscricaoUID = pmi.preMatriculaInscricaoUID;



GO