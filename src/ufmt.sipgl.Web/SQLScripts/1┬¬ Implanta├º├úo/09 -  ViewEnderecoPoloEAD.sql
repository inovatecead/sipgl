CREATE VIEW [Sipgl].[ViewEnderecoPoloEAD] AS
SELECT  
e.enderecoUID as enderecoUID,
e.CEP as CEP,
e.identificacaoEndereco as logradouro,
e.numeroEndereco as numeroEndereco,
e.complementoBairro as complementoBairro,
e.bairroEndereco as bairroEndereco,
e.informacoesReferenciaEndereco as informacoesReferenciaEndereco,
e.telefone as telefone,
e.fax as fax,
e.email as email,
e.site as site,

m.Nome as municipio

from sipgl.EnderecoPoloApoioPresencialEAD e 
join Municipio m on m.MunicipioUID = e.municipioEnderecoUID;