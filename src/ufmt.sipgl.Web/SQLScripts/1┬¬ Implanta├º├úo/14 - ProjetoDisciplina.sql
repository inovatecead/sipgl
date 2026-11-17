ALTER TABLE Sipgl.ProjetoDisciplina ADD projetoCorpoDocenteUID bigint;
ALTER TABLE Sipgl.ProjetoDisciplina ADD projetoCorpoDocenteSecundarioUID bigint;

ALTER TABLE Sipgl.ProjetoDisciplina ADD CONSTRAINT FK_ProjetoDisciplina_ProjetoCorpoDocente FOREIGN KEY (projetoCorpoDocenteUID) REFERENCES Sipgl.ProjetoCorpoDocente (projetoCorpoDocenteUID);
ALTER TABLE Sipgl.ProjetoDisciplina ADD CONSTRAINT FK_ProjetoDisciplina_ProjetoCorpoDocente_Secundario FOREIGN KEY (projetoCorpoDocenteSecundarioUID) REFERENCES Sipgl.ProjetoCorpoDocente (projetoCorpoDocenteUID);