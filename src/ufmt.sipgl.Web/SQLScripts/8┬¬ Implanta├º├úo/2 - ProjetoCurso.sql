USE [idbufmt]
GO

ALTER TABLE sipgl.ProjetoCurso ADD usuarioCriacaoUID BIGINT; 
ALTER TABLE sipgl.ProjetoCurso ADD dataCriacao DATETIME;


ALTER TABLE Sipgl.ProjetoCurso ADD CONSTRAINT FK_PROJETO_CURSO_USUARIO FOREIGN KEY (usuarioCriacaoUID) REFERENCES dbo.Usuario(usuarioUID);