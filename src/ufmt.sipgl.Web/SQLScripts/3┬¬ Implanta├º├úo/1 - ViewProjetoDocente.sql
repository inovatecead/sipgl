USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewProjetoDocente]    Script Date: 26/06/2019 10:57:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [Sipgl].[ViewProjetoDocente] AS
SELECT 
pcd.projetoCorpoDocenteUID as projetoCorpoDocenteUID,

s.servidorUID as servidorUID,

p.pessoaUID as pessoaUID,
p.nome as nome,
p.mail as email,

s.registro as registro,
s.registroDV as registroDV,

tt.descricao as titulacao

from sipgl.ProjetoCorpoDocente pcd
join dbo.Servidor s on pcd.servidorUID = s.servidorUID
join dbo.Pessoa p on p.pessoaUID = s.pessoaUID
left join dbo.TipoTitulacao tt on tt.tipoTitulacaoUID = p.tipoTitulacaoUID;
GO


