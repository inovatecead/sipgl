ALTER TABLE Sipgl.PreMatriculaPessoa ADD passaporte VARCHAR(256);
ALTER TABLE Sipgl.PreMatriculaPessoa ADD tituloEleitoral VARCHAR(256);
ALTER TABLE Sipgl.PreMatriculaPessoa ADD zona VARCHAR(50);

ALTER TABLE Sipgl.PreMatriculaPessoa ADD tituloEleitoralUFUID VARCHAR(2);
ALTER TABLE Sipgl.PreMatriculaPessoa ADD tituloEleitoralMunicipioUID INT;

ALTER TABLE Sipgl.PreMatriculaPessoa ADD profissao VARCHAR(256);
ALTER TABLE Sipgl.PreMatriculaPessoa ADD localTrabalho VARCHAR(256);
ALTER TABLE Sipgl.PreMatriculaPessoa ADD celularComercial VARCHAR(50);
ALTER TABLE Sipgl.PreMatriculaPessoa ADD emailComercial VARCHAR(256);

ALTER TABLE Sipgl.PreMatriculaPessoa ALTER COLUMN tipoFaixaRendaFamiliarUID TINYINT;
ALTER TABLE Sipgl.PreMatriculaPessoa ALTER COLUMN tipoCorRacaUID TINYINT;

ALTER TABLE Sipgl.PreMatriculaPessoa ADD CONSTRAINT FK_PreMatriculaPessoa_TituloEleitoralUF FOREIGN KEY (tituloEleitoralUFUID) REFERENCES dbo.UF (UFUID);
ALTER TABLE Sipgl.PreMatriculaPessoa ADD CONSTRAINT FK_PreMatriculaPessoa_TituloEleitoralMunicipio FOREIGN KEY (tituloEleitoralMunicipioUID) REFERENCES dbo.Municipio (MunicipioUID);

ALTER TABLE Sipgl.PreMatriculaPessoa ALTER COLUMN graduacaoInstituicaoEnsinoUID INT;
