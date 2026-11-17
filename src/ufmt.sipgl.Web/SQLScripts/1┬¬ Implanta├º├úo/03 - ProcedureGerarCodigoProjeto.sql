USE [idbufmt]
GO
/****** Object:  StoredProcedure [Sipgl].[ProcedureGerarCodigoProjeto]    Script Date: 18/07/2018 16:33:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Sipgl].[ProcedureGerarCodigoProjeto]
						 @ProjetoCodigoSaida INT OUTPUT		
AS

		DECLARE @Data SMALLINT
		SET @Data = YEAR(GETDATE())
		IF EXISTS(SELECT projetoControleCodigoUID
				    FROM Sipgl.ProjetoControleCodigo
				   WHERE ano = @Data)
		BEGIN
			IF (SELECT SUBSTRING(CAST(MAX(codigoAtual) AS VARCHAR(7)),5,3)
				  FROM Sipgl.ProjetoControleCodigo
				 WHERE ano = @Data) = 999
			BEGIN
				RAISERROR('Valor máximo de código de projeto, para o ano, foi alcançado. Favor entrar em contado com os administradores do sistema.',16,1)
			END
			ELSE
			BEGIN
				SET @ProjetoCodigoSaida = (SELECT MAX(codigoAtual) + 1 
										   FROM Sipgl.ProjetoControleCodigo
										  WHERE ano = @Data)
				UPDATE Sipgl.ProjetoControleCodigo
				   SET codigoAtual = @ProjetoCodigoSaida
				 WHERE ano = @Data
			END
		END
		ELSE
		BEGIN
			   SET @ProjetoCodigoSaida = (CAST(@Data AS VARCHAR(4)) + '001')
			INSERT INTO Sipgl.ProjetoControleCodigo
			VALUES (@Data, CAST(@Data AS VARCHAR(4)) + '001')
		END
GO