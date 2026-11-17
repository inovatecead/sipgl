CREATE TABLE sipgl.ProjetoFrequenciaHistorico 
(
	projetoFrequenciaHistoricoUID bigint not null identity(1,1) primary key,
	projetoFrequenciaUID bigint not null,
	isPresente bit,
	usuarioUID bigint not null,
	dataInclusao datetime,
	dataAlteracao datetime,
	ip varchar(25) not null
);

ALTER TABLE sipgl.ProjetoFrequenciaHistorico ADD CONSTRAINT ProjetoFrequenciaHistorico_ProjetoFrequencia FOREIGN KEY (projetoFrequenciaUID) REFERENCES sipgl.ProjetoFrequencia(projetoFrequenciaUID);
ALTER TABLE sipgl.ProjetoFrequenciaHistorico ADD CONSTRAINT ProjetoFrequenciaHistorico_Usuario FOREIGN KEY (usuarioUID) REFERENCES dbo.Usuario(usuarioUID);