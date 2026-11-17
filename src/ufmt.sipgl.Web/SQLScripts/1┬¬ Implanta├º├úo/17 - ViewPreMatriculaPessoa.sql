ALTER TABLE sipgl.PreMatriculaPessoa ADD 
enderecoUFUID varchar(2) not null default 'MT',
graduacaoUFUID varchar(2) not null default 'MT',
naturalidadeUFUID varchar(2) not null default 'MT'


USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewPreMatriculaPessoa]    Script Date: 01/10/2018 10:05:32 ******/
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
			  ,pmp.telefoneComercial
			  ,pmp.diplomaGraduacaoExterior
			  ,pmp.numeroRegistroApostilaRevalidacao
			  ,pmp.graduacaoInstituicaoEnsinoUID
			  ,pmp.graduacaoDataColacaoGrau
			  ,pmp.tipoFaixaRendaFamiliarUID
			  ,pmp.tipoCorRacaUID
			  ,pmp.dataHoraCadastro
			  ,pmp.dataHoraUltimaAtualizacao

			  ,estc.nome AS nomeTipoEstadoCivil
			  
			  ,p.nome nomeNascimentoPais
			  
			  ,nm.Nome AS naturalidadeNomeMunicipio
			  ,nm.UF  AS graduacaoUfInstituicaoEnsino

			  ,em.Nome AS enderecoNomeMunicipio
			  
			  ,ie.nome AS graduacaoNomeInstituicaoEnsino
			  
			  ,tfrf.nome AS nomeTipoFaixaRendaFamiliar
			  
			  ,tcr.nome AS nomeTipoCorRaca
			  
			  ,senha
		  FROM Sipgl.PreMatriculaPessoa pmp 

			LEFT JOIN dbo.Municipio nm ON pmp.naturalidadeMunicipioUID = nm.MunicipioUID 
			INNER JOIN dbo.Municipio em ON pmp.enderecoMunicipioUID = em.MunicipioUID 
			INNER JOIN dbo.InstituicaoEnsino ie ON pmp.graduacaoInstituicaoEnsinoUID = ie.instituicaoEnsinoUID 
			INNER JOIN dbo.TipoFaixaRendaFamiliar tfrf ON pmp.tipoFaixaRendaFamiliarUID = tfrf.tipoFaixaRendaFamiliarUID 
			INNER JOIN dbo.TipoCorRaca tcr ON pmp.tipoCorRacaUID = tcr.tipoCorRacaUID 
			INNER JOIN dbo.TipoEstadoCivil estc ON pmp.tipoEstadoCivilUID = estc.tipoEstadoCivilUID 
			LEFT JOIN Pais p ON pmp.nascimentoPaisUID = p.paisUID
GO


