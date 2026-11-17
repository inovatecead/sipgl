ALTER TABLE Sipgl.ProjetoDisciplina ADD projetoCursoUID bigint;

ALTER TABLE Sipgl.ProjetoDisciplina ADD CONSTRAINT FK_ProjetoDisciplina_ProjetoCurso FOREIGN KEY (projetoCursoUID) REFERENCES Sipgl.ProjetoCurso (projetoCursoUID);