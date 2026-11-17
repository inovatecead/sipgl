USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewDocenteUFMT]    Script Date: 24/10/2019 16:34:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

		CREATE VIEW [Sipgl].[ViewDocenteUFMT]
		AS
			SELECT 

			p.pessoaUID AS pessoaUID,
			p.nome AS nome,

			s.servidorUID AS servidorUID,
			s.registro AS siape,
			s.registroDV AS siapeDV,

			c.cargoUID AS cargoUID,
			c.nome AS nomeCargo,

			tt.tipoTitulacaoUID AS tipoTitulacaoUID,
			tt.descricao AS nomeTitulacao


			FROM dbo.Pessoa p

			INNER JOIN dbo.Servidor s ON s.pessoaUID = p.pessoaUID
			INNER JOIN dbo.Cargo c ON c.cargoUID = s.cargoUID
			INNER JOIN dbo.TipoTitulacao tt ON tt.tipoTitulacaoUID = p.tipoTitulacaoUID

			WHERE c.cargoUID IN (2,6,642) 
			AND tt.tipoTitulacaoUID IN (7, 8, 9, 10)

			ORDER BY p.nome;

GO