--CREATE TABLE sipgl.ProjetoNota (
--	projetoNotaUID bigint not null identity(1,1) primary key,
--	projetoDiscenteUID bigint not null,
--	projetoDisciplinaUID bigint not null,
--	nota decimal(4,2)
--);

--ALTER TABLE sipgl.ProjetoNota ADD CONSTRAINT projetoNota_discente FOREIGN KEY (projetoDiscenteUID) REFERENCES sipgl.ProjetoDiscente (discenteUID);
--ALTER TABLE sipgl.ProjetoNota ADD CONSTRAINT projetoNota_disciplina FOREIGN KEY (projetoDisciplinaUID) REFERENCES sipgl.ProjetoDisciplina (projetoDisciplinaUID);

CREATE TABLE sipgl.ProjetoNota (
	projetoNotaUID bigint not null identity(1,1) primary key,
	preMatriculaInscricaoUID bigint not null,
	projetoDisciplinaUID bigint not null,
	nota decimal(4,2)
);

ALTER TABLE sipgl.ProjetoNota ADD CONSTRAINT projetoNota_preMatriculaInscricao FOREIGN KEY (preMatriculaInscricaoUID) REFERENCES sipgl.preMatriculaInscricao (preMatriculaInscricaoUID);
ALTER TABLE sipgl.ProjetoNota ADD CONSTRAINT projetoNota_disciplina FOREIGN KEY (projetoDisciplinaUID) REFERENCES sipgl.ProjetoDisciplina (projetoDisciplinaUID);