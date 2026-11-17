ALTER TABLE sipgl.ProjetoDisciplina DROP CONSTRAINT FK_ProjetoDisciplina_ProjetoCorpoDocente;
ALTER TABLE sipgl.ProjetoDisciplina DROP CONSTRAINT FK_ProjetoDisciplina_ProjetoCorpoDocente_Secundario;

ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN ProjetoCorpoDocenteUID;
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN ProjetoCorpoDocenteSecundarioUID; 
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN dataInicio; 
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN dataTermino;
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN possuiRemuneracaoDocentePrincipal;
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN possuiRemuneracaoDocenteSecundario;
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN tipoRemuneracaoDocentePrincipal;
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN tipoRemuneracaoDocenteSecundario;
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN descricaoOutrosTiposRemuneracaoPrincipal;
ALTER TABLE sipgl.ProjetoDisciplina DROP COLUMN descricaoOutrosTiposRemuneracaoSecundario;

