USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewPreMatriculaPessoa]    Script Date: 10/02/2021 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [Sipgl].[ViewPreMatriculaPessoa]
		AS 
		
				SELECT pmp.preMatriculaPessoaUID
			  ,pmp.nome COLLATE Latin1_General_CI_AI AS nomeCandidato
			  ,pmp.sexo
			  ,pmp.nascimentoData
			  ,pmp.nomeMae
			  ,pmp.nomePai
			  ,pmp.cpf
			  ,pmp.rgNumero
			  ,pmp.rgUFUID
			  ,pmp.rgOrgaoExpedidor
			  ,pmp.rgDataExpedicao
			  ,pmp.tipoEstadoCivilUID
			  ,pmp.nacionalidade
			  ,pmp.nascimentoPaisUID
			  ,pmp.naturalidadeMunicipioUID
			  ,pmp.email
			  ,pmp.enderecoLogradouro
			  ,pmp.enderecoNumero
			  ,pmp.enderecoComplemento
			  ,pmp.enderecoBairro
			  ,pmp.enderecoCEP
			  ,pmp.enderecoMunicipioUID
			  ,pmp.enderecoUFUID
			  ,pmp.graduacaoUFUID
			  ,pmp.naturalidadeUFUID
			  ,pmp.telefoneFixo
			  ,pmp.telefoneMovel
			  ,pmp.diplomaGraduacaoExterior
			  ,pmp.numeroRegistroApostilaRevalidacao
			  ,pmp.graduacaoInstituicaoEnsinoUID
			  ,pmp.graduacaoDataColacaoGrau
			  ,pmp.tipoFaixaRendaFamiliarUID
			  ,pmp.tipoCorRacaUID
			  ,pmp.dataHoraCadastro
			  ,pmp.dataHoraUltimaAtualizacao
			  ,pmp.cursoGraduacao
			  ,pmp.numeroRegistroDiploma
			  ,pmp.tituloEleitoral
			  ,pmp.zona
			  ,pmp.tituloEleitoralUFUID
			  ,pmp.tituloEleitoralMunicipioUID
			  ,pmp.passaporte
			  ,pmp.profissao
			  ,pmp.localTrabalho
			  ,pmp.telefoneComercial
			  ,pmp.celularComercial
			  ,pmp.emailComercial

			  ,estc.nome AS nomeTipoEstadoCivil
			  
			  ,p.nome nomeNascimentoPais
			  
			  ,nm.Nome AS naturalidadeNomeMunicipio
			  ,nm.UF  AS graduacaoUfInstituicaoEnsino

			  ,em.Nome AS enderecoNomeMunicipio
			  
			  ,ie.nome AS graduacaoInstituicaoEnsino
			  
			  ,senha

			  ,ptg.projetoTipoGraduacaoUID as projetoTipoGraduacaoUID 
			  ,ptg.descricao as tipoGraduacao

		  FROM Sipgl.PreMatriculaPessoa pmp 

			LEFT JOIN dbo.Municipio nm ON pmp.naturalidadeMunicipioUID = nm.MunicipioUID 
			LEFT JOIN dbo.Municipio em ON pmp.enderecoMunicipioUID = em.MunicipioUID 
			LEFT JOIN dbo.InstituicaoEnsino ie ON pmp.graduacaoInstituicaoEnsinoUID = ie.instituicaoEnsinoUID 
			LEFT JOIN dbo.TipoEstadoCivil estc ON pmp.tipoEstadoCivilUID = estc.tipoEstadoCivilUID 
			LEFT JOIN Pais p ON pmp.nascimentoPaisUID = p.paisUID
			LEFT JOIN  Sipgl.ProjetoTipoGraduacao ptg ON ptg.projetoTipoGraduacaoUID = pmp.projetoTipoGraduacaoUID

			
GO
