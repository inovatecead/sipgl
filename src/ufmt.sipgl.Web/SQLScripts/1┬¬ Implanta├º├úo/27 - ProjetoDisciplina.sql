ALTER TABLE sipgl.ProjetoDisciplina ADD possuiRemuneracaoDocentePrincipal int;

ALTER TABLE sipgl.ProjetoDisciplina ADD possuiRemuneracaoDocenteSecundario int;

ALTER TABLE sipgl.ProjetoDisciplina ADD tipoRemuneracaoDocentePrincipal int;

ALTER TABLE sipgl.ProjetoDisciplina ADD tipoRemuneracaoDocenteSecundario int;

ALTER TABLE sipgl.ProjetoDisciplina ADD descricaoOutrosTiposRemuneracaoPrincipal varchar(1024);

ALTER TABLE sipgl.ProjetoDisciplina ADD descricaoOutrosTiposRemuneracaoSecundario varchar(1024);