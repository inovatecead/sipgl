-- Não executar o código Comentado.

--ALTER TABLE [Sipgl].[PreMatriculaInscricao] ADD projetoPoloCursoUID bigint;

--ALTER TABLE [Sipgl].[PreMatriculaInscricao] ADD CONSTRAINT FK_PreMatriculaInscricao_PoloCurso FOREIGN KEY (projetoPoloCursoUID) REFERENCES Sipgl.ProjetoPoloCurso (projetoPoloCursoUID);

--ALTER TABLE [Sipgl].[PreMatriculaInscricao] DROP CONSTRAINT FK_PreMatriculaInscricao_ProjetoCurso;

--ALTER TABLE [Sipgl].[PreMatriculaInscricao] DROP COLUMN projetoCursoUID;




--ALTER TABLE [Sipgl].[PreMatriculaInscricao] ADD projetoTurmaPoloUID bigint;

--ALTER TABLE [Sipgl].[PreMatriculaInscricao] ADD CONSTRAINT FK_PreMatriculaInscricao_TurmaPolo FOREIGN KEY (projetoTurmaPoloUID) REFERENCES Sipgl.ProjetoTurmaPolo (projetoTurmaPoloUID);



-- ALTER TABLE [Sipgl].[PreMatriculaInscricao] DROP CONSTRAINT FK_PreMatriculaInscricao_ProjetoCurso;

--ALTER TABLE [Sipgl].[PreMatriculaInscricao] DROP COLUMN projetoCursoUID;

ALTER TABLE [Sipgl].[PreMatriculaInscricao] ALTER COLUMN projetoCursoUID BIGINT;
