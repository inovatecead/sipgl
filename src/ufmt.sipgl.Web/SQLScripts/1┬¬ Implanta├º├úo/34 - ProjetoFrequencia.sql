CREATE TABLE sipgl.ProjetoFrequencia (
	projetoFrequenciaUID bigint not null identity(1,1) primary key,
	preMatriculaInscricaoUID bigint not null,
	projetoEncontroPresencialUID bigint not null,
	isPresente bit
);

ALTER TABLE sipgl.ProjetoFrequencia ADD CONSTRAINT FK_projetoFrequencia_preMatriculaInscricao FOREIGN KEY (preMatriculaInscricaoUID) REFERENCES sipgl.preMatriculaInscricao (preMatriculaInscricaoUID);
ALTER TABLE sipgl.ProjetoFrequencia ADD CONSTRAINT FK_projetoFrequencia_encontroPresencial FOREIGN KEY (projetoEncontroPresencialUID) REFERENCES sipgl.projetoEncontroPresencial (projetoEncontroPresencialUID);