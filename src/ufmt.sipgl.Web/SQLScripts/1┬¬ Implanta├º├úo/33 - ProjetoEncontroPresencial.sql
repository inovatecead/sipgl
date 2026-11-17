CREATE TABLE sipgl.ProjetoEncontroPresencial (
	projetoEncontroPresencialUID BIGINT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	projetoDisciplinaUID BIGINT NOT NULL,
	projetoTurmaPoloUID BIGINT NOT NULL,
	dataEncontro DATETIME NOT NULL,
	isObrigatorio bit not null default 0
);

ALTER TABLE sipgl.ProjetoEncontroPresencial ADD CONSTRAINT FK_projetoEncontroPresencial_disciplina FOREIGN KEY (projetoDisciplinaUID) REFERENCES sipgl.ProjetoDisciplina (projetoDisciplinaUID);
ALTER TABLE sipgl.ProjetoEncontroPresencial ADD CONSTRAINT FK_projetoEncontroPresencial_turmaPolo FOREIGN KEY (projetoTurmaPoloUID) REFERENCES sipgl.ProjetoTurmaPolo (projetoTurmaPoloUID);