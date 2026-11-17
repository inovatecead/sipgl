USE [idbufmt]
GO

SET IDENTITY_INSERT sipgl.ProjetoRecurso ON

INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (56 ,'MenuGerenciarUsuarios');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (57 ,'MenuGerenciarUsuarios_VincularPermissao');
INSERT INTO sipgl.ProjetoRecurso (projetoRecursoUID, nome) VALUES (58 ,'MenuGerenciarUsuarios_VincularUnidadeAcademica');


SET IDENTITY_INSERT sipgl.ProjetoRecurso OFF

INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 56);
INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 57);
INSERT INTO sipgl.ProjetoPermissaoRecurso (permissaoUID, projetoRecursoUID) VALUES (58, 58);