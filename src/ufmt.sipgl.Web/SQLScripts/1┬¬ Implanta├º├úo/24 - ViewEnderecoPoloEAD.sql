USE [idbufmt]
GO

/****** Object:  View [Sipgl].[ViewEnderecoPoloEAD]    Script Date: 06/11/2018 15:03:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [Sipgl].[ViewEnderecoPoloEAD] AS
SELECT  
e.enderecoUID as enderecoUID,
e.CEP as CEP,
e.identificacaoEndereco as identificacaoEndereco,
e.logradouro as logradouro,
e.numeroEndereco as numeroEndereco,
e.complementoBairro as complementoBairro,
e.bairroEndereco as bairroEndereco,
e.informacoesReferenciaEndereco as informacoesReferenciaEndereco,
e.telefone as telefone,
e.fax as fax,
e.email as email,
e.site as site,
e.tipoUnidadeEnsino as tipoUnidadeEnsino,
e.enderecoUFUID as enderecoUFUID,
m.Nome as municipio

from sipgl.EnderecoPoloApoioPresencialEAD e 
join Municipio m on m.MunicipioUID = e.municipioEnderecoUID;
GO

