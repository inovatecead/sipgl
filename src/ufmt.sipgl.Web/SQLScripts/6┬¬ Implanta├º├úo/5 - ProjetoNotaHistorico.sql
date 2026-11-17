CREATE TABLE sipgl.ProjetoNotaHistorico 
(
	projetoNotaHistoricoUID bigint not null identity(1,1) primary key,
	projetoNotaUID bigint not null,
	nota decimal(5,2),
	conceito varchar(1),
	descricaoTCC varchar(512),
	usuarioUID bigint not null,
	dataInclusao datetime,
	dataAlteracao datetime,
	ip varchar(25) not null
);

ALTER TABLE sipgl.ProjetoNotaHistorico ADD CONSTRAINT ProjetoNotaHistorico_ProjetoNota FOREIGN KEY (projetoNotaUID) REFERENCES sipgl.ProjetoNota(projetoNotaUID);
ALTER TABLE sipgl.ProjetoNotaHistorico ADD CONSTRAINT ProjetoNotaHistorico_Usuario FOREIGN KEY (usuarioUID) REFERENCES dbo.Usuario(usuarioUID);