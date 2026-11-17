USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewProjetoCursoEADPolo]    Script Date: 17/09/2018 16:43:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [Sipgl].[ViewProjetoDocente] AS
SELECT 
pcd.projetoCorpoDocenteUID as projetoCorpoDocenteUID,

s.servidorUID as servidorUID,

p.pessoaUID as pessoaUID,
p.nome as nome,
p.mail as email,

s.registro as registro,
s.registroDV as registroDV

from sipgl.ProjetoCorpoDocente pcd
join dbo.Servidor s on pcd.servidorUID = s.servidorUID
join dbo.Pessoa p on p.pessoaUID = s.pessoaUID
GO


