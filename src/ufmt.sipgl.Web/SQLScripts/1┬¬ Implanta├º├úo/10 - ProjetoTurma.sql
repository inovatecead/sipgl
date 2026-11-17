ALTER TABLE sipgl.ProjetoTurma drop Constraint FK_ProjetoTurma_Polo;

ALTER TABLE sipgl.ProjetoTurma drop column poloUID;
ALTER TABLE sipgl.ProjetoTurma drop column matrizCurricularUID;

EXEC sp_RENAME 'sipgl.ProjetoTurma.cursoUID', 'projetoCursoUID', 'COLUMN';
EXEC sp_RENAME 'sipgl.ProjetoTurma.turmaUID', 'projetoTurmaUID', 'COLUMN';

--ALTER TABLE sipgl.ProjetoTurma ADD DataInicio DATE not null default CURRENT_TIMESTAMP;
--ALTER TABLE sipgl.ProjetoTurma ADD DataFim DATE not null default CURRENT_TIMESTAMP;

ALTER TABLE sipgl.ProjetoTurma ADD DataInicio DATE;
ALTER TABLE sipgl.ProjetoTurma ADD DataFim DATE;