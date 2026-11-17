ALTER TABLE sipgl.PreMatriculaInscricaoOcorrencia ADD usuarioUID bigint;

ALTER TABLE sipgl.PreMatriculaInscricaoOcorrencia ADD CONSTRAINT PreMatriculaInscricaoOcorrencia_Usuario FOREIGN KEY (usuarioUID) REFERENCES dbo.Usuario (usuarioUID);