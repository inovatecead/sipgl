ALTER TABLE sipgl.PreMatriculaPessoa ADD 
	projetoTipoGraduacaoUID bigint,
	cursoGraduacao varchar (256),
	numeroRegistroDiploma varchar (256)
;


ALTER TABLE sipgl.PreMatriculaPessoa ADD CONSTRAINT preMatriculaPessoa_projetoTipoGraduacao FOREIGN KEY (projetoTipoGraduacaoUID) REFERENCES sipgl.ProjetoTipoGraduacao (projetoTipoGraduacaoUID);
