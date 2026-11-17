USE [idbufmt]
GO

SET IDENTITY_INSERT sipgl.ProjetoRecurso ON

INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (59 ,'MenuDiscentes_ImportarCandidatos');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (60 ,'ImportarCandidatos_Importar');



SET IDENTITY_INSERT sipgl.ProjetoRecurso OFF

INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 59);
INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 60);
