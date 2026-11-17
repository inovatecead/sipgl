SET IDENTITY_INSERT sipgl.ProjetoRecurso ON

INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (53 ,'Discentes_GerenciarPreInscricao');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (54 ,'GerenciarPreInscricao_Aprovar');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (55 ,'GerenciarPreInscricao_Cancelar');


SET IDENTITY_INSERT sipgl.ProjetoRecurso OFF

INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 53);
INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 54);
INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 55);