CREATE TABLE sipgl.ProjetoRecurso(
	projetoRecursoUID bigint not null identity(1,1) primary key,
	nome varchar(256) not null,
);

CREATE TABLE sipgl.ProjetoPermissaoRecurso (
	projetoPermissaoRecursoUID bigint not null identity(1,1) primary key,
	permissaoUID bigint not null,
	projetoRecursoUID bigint not null
);

ALTER TABLE sipgl.ProjetoPermissaoRecurso ADD CONSTRAINT projetoPermissaoRecurso_permissao FOREIGN KEY (permissaoUID) REFERENCES dbo.Permissao(permissaoUID);
ALTER TABLE sipgl.ProjetoPermissaoRecurso ADD CONSTRAINT projetoPermissaoRecurso_recurso FOREIGN KEY (projetoRecursoUID) REFERENCES sipgl.ProjetoRecurso(projetoRecursoUID);

SET IDENTITY_INSERT sipgl.ProjetoRecurso ON

INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (1, 'MenuCursos');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (2, 'MenuCursos_NovoCurso');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (3 ,'MenuCursos_EditarCurso');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (4 ,'MenuCursos_Turmas');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (5 ,'MenuCursos_Disciplinas');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (6 ,'Turma_NovaTurma');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (7 ,'Turma_EditarTurma');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (8 ,'Turma_VincularUnidades');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (9 ,'Turma_Discentes');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (10 ,'Turma_GerenciarDisciplinas');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (11 ,'Turma_Notas');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (12 ,'Turma_Frequencia');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (13 ,'VincularUnidades_VincularNovaUnidade');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (14 ,'VincularUnidades_Editar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (15 ,'VincularUnidades_Excluir');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (16 ,'Discentes_IncluirDiscente')
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (17 ,'Discentes_RelatorioPDF');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (18 ,'Discentes_RelatorioXLS');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (19 ,'Discentes_VisualizarHistorico');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (20 ,'Discentes_EditarSituacao');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (21 ,'Discentes_ExcluirDiscente');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (22 ,'IncluirDiscente_CadastrarDiscente');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (23 ,'IncluirDiscente_IncluirCandidato');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (24 ,'GerenciarDisciplinas_ExportarRelatorioPDF');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (25 ,'GerenciarDisciplinas_VincularDocentes');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (26 ,'GerenciarDisciplinas_EncontroPresencial');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (27 ,'VincularDocentes_Salvar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (28 ,'EncontroPresencial_NovoEncontro');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (29 ,'EncontroPresencial_Editar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (30 ,'EncontroPresencial_Excluir');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (31 ,'Nota_GerarRelatorioPDF');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (32 ,'Nota_ImportarLote');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (33 ,'Nota_Salvar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (34 ,'Frequencia_GerarRelatorio');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (35 ,'Frequencia_Salvar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (36 ,'Disciplinas_NovaDisciplina');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (37 ,'Disciplinas_Editar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (38 ,'Disciplinas_Excluir');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (39 ,'MenuUnidades');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (40 ,'MenuUnidades_NovaUnidade');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (41 ,'MenuUnidades_Editar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (42 ,'MenuUnidades_Excluir');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (43 ,'MenuDiscentes');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (44 ,'MenuDiscentes_NovoDiscente');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (45 ,'MenuDiscentes_Editar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (46 ,'MenuDiscentes_VisualizarMatriculas');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (47 ,'MenuDocentes');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (48 ,'MenuDocentes_NovoDocenteInterno');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (49 ,'MenuDocentes_NovoDocenteExterno');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (50 ,'MenuDocentes_Editar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (51 ,'MenuPermissoes');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (52 ,'MenuPermissoes_VincularPermissoes');

SET IDENTITY_INSERT sipgl.ProjetoRecurso OFF

INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) SELECT 58, projetoRecursoUID FROM sipgl.ProjetoRecurso;