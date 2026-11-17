ALTER TABLE sipgl.ProjetoCorpoDocente ADD tipoTitulacaoUID int;
ALTER TABLE sipgl.ProjetoCorpoDocente ADD nome varchar(256);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD sexo char(1);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD dataNascimento date;
ALTER TABLE sipgl.ProjetoCorpoDocente ADD nomeMae varchar(256);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD nomePai varchar(256);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD cpf varchar(20);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD rg varchar(20);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD orgaoExpedidorUID smallint;
ALTER TABLE sipgl.ProjetoCorpoDocente ADD orgaoExpedidorUFUID varchar(2);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD dataExpedicao date;
ALTER TABLE sipgl.ProjetoCorpoDocente ADD telefoneFixo varchar(10);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD celular varchar(11);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD email varchar(256);


ALTER TABLE sipgl.ProjetoCorpoDocente ADD CONSTRAINT PROJETO_CORPO_DOCENTE_TIPO_TITULACAO FOREIGN KEY (tipoTitulacaoUID) REFERENCES dbo.TipoTitulacao (tipoTitulacaoUID);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD CONSTRAINT PROJETO_CORPO_DOCENTE_ORGAO_EXPEDIDOR FOREIGN KEY (orgaoExpedidorUID) REFERENCES dbo.TipoOrgaoExpedidorRg (tipoOrgaoExpedidorRgUID);
ALTER TABLE sipgl.ProjetoCorpoDocente ADD CONSTRAINT PROJETO_CORPO_DOCENTE_ORGAO_EXPEDIDOR_UF FOREIGN KEY (orgaoExpedidorUFUID) REFERENCES dbo.UF (UFUID);

ALTER TABLE sipgl.ProjetoCorpoDocente ALTER COLUMN servidorUID BIGINT;