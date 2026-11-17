ALTER TABLE sipgl.ProjetoCurso ADD secretarioUID bigint;
ALTER TABLE sipgl.ProjetoCurso ADD celularSecretario varchar(50);
ALTER TABLE sipgl.ProjetoCurso ADD emailSecretario varchar(255);

ALTER TABLE Sipgl.ProjetoCurso ADD CONSTRAINT FK_ProjetoCurso_Pessoa FOREIGN KEY (secretarioUID) REFERENCES dbo.Pessoa (pessoaUID);