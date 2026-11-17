ALTER TABLE Sipgl.ProjetoDiscente ADD preMatriculaInscricaoUID bigint not null;
ALTER TABLE Sipgl.ProjetoDiscente ADD CONSTRAINT FK_ProjetoDiscente_PreMatriculaInscricao FOREIGN KEY (preMatriculaInscricaoUID) REFERENCES Sipgl.PreMatriculaInscricao(preMatriculaInscricaoUID);
ALTER TABLE Sipgl.ProjetoDiscente DROP CONSTRAINT FK_ProjetoDiscente_Pessoa;
ALTER TABLE Sipgl.ProjetoDiscente DROP COLUMN pessoaUID;

ALTER TABLE Sipgl.ProjetoDiscente alter column dataIngresso date not null;
