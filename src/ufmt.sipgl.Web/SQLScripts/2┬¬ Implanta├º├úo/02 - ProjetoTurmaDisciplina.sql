EXEC sp_RENAME 'sipgl.ProjetoTurmaDisciplina.docenciaUID', 'projetoCorpoDocenteUID', 'COLUMN';
EXEC sp_RENAME 'sipgl.ProjetoTurmaDisciplina.turmaUID', 'projetoTurmaUID', 'COLUMN';
EXEC sp_RENAME 'sipgl.ProjetoTurmaDisciplina.disciplinaUID', 'projetoDisciplinaUID', 'COLUMN';
EXEC sp_RENAME 'sipgl.ProjetoTurmaDisciplina.turmaDisciplinaUID', 'projetoTurmaDisciplinaUID', 'COLUMN';

ALTER TABLE Sipgl.ProjetoTurmaDisciplina ADD projetoCorpoDocenteSecundarioUID bigint;

ALTER TABLE Sipgl.ProjetoTurmaDisciplina ADD CONSTRAINT FK_ProjetoTurmaDisciplina_ProjetoCorpoDocente_Secundario FOREIGN KEY (projetoCorpoDocenteSecundarioUID) REFERENCES Sipgl.ProjetoCorpoDocente (projetoCorpoDocenteUID);

ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD possuiRemuneracaoDocentePrincipal int;
ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD possuiRemuneracaoDocenteSecundario int;
ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD tipoRemuneracaoDocentePrincipal int;
ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD tipoRemuneracaoDocenteSecundario int;
ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD descricaoOutrosTiposRemuneracaoPrincipal varchar(1024);
ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD descricaoOutrosTiposRemuneracaoSecundario varchar(1024);
ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD dataInicio DATETIME;
ALTER TABLE sipgl.ProjetoTurmaDisciplina ADD dataTermino DATETIME;