--Não Executar o código comentado

--CREATE TABLE Sipgl.ProjetoPoloCurso (
--projetoPoloCursoUID bigint not null identity(1,1) primary key,
--projetoCursoUID bigint not null,
--enderecoUID int not null
--)

--ALTER TABLE Sipgl.ProjetoPoloCurso ADD CONSTRAINT FK_ProjetoPoloCurso_Polo FOREIGN KEY (enderecoUID) REFERENCES Sipgl.EnderecoPoloApoioPresencialEAD (enderecoUID);
--ALTER TABLE Sipgl.ProjetoPoloCurso ADD CONSTRAINT FK_ProjetoPoloCurso_Curso FOREIGN KEY (projetoCursoUID) REFERENCES Sipgl.ProjetoCurso (projetoCursoUID);
