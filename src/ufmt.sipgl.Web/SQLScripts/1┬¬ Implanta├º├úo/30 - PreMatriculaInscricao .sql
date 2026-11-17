ALTER TABLE [Sipgl].[PreMatriculaInscricao] ADD projetoTurmaPoloUID bigint;

ALTER TABLE [Sipgl].[PreMatriculaInscricao] ADD CONSTRAINT FK_PreMatriculaInscricao_TurmaPolo FOREIGN KEY (projetoTurmaPoloUID) REFERENCES Sipgl.ProjetoTurmaPolo (projetoTurmaPoloUID);