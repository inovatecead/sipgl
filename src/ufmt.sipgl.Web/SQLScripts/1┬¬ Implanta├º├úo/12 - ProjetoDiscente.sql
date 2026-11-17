ALTER TABLE sipgl.ProjetoDiscente ALTER COLUMN registro VARCHAR(15);
--ALTER TABLE sipgl.ProjetoDiscente ADD CONSTRAINT UC_Registro UNIQUE (registro);
ALTER TABLE sipgl.PreMatriculaInscricaoOcorrencia ADD observacao VARCHAR(2048);

ALTER TABLE sipgl.ProjetoDiscente ADD periodo INT NOT NULL default 1;