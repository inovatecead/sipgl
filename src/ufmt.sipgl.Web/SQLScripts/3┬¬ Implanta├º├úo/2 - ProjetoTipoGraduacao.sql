CREATE TABLE sipgl.ProjetoTipoGraduacao (
	projetoTipoGraduacaoUID bigint not null identity(1,1) primary key,
	descricao varchar(256) not null
);


INSERT INTO sipgl.ProjetoTipoGraduacao (descricao) values ('Bacharelado');
INSERT INTO sipgl.ProjetoTipoGraduacao (descricao) values ('Licenciatura');