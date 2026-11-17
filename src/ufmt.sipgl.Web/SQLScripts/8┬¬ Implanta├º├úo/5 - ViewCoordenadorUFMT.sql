USE [idbufmt]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [Sipgl].[ViewCoordenadorUFMT] AS 

SELECT 

			p.pessoaUID AS pessoaUID,
			p.nome AS nome,

			s.servidorUID AS servidorUID,
			s.registro AS siape,
			s.registroDV AS siapeDV,

			tt.tipoTitulacaoUID AS tipoTitulacaoUID,
			tt.descricao AS nomeTitulacao

			FROM dbo.Pessoa p

			INNER JOIN dbo.Servidor s ON s.pessoaUID = p.pessoaUID
			INNER JOIN dbo.TipoTitulacao tt ON tt.tipoTitulacaoUID = p.tipoTitulacaoUID

			WHERE 1=1 AND tt.tipoTitulacaoUID IN (7, 8, 9, 10) AND s.situacaoServidorUID = 1;

GO