USE [idbufmt]
GO

SET IDENTITY_INSERT sipgl.ProjetoRecurso ON

INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (61 ,'Discentes_IncluirLote');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (62 ,'IncluirLote_Salvar');



SET IDENTITY_INSERT sipgl.ProjetoRecurso OFF

INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 61);
INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 62);
