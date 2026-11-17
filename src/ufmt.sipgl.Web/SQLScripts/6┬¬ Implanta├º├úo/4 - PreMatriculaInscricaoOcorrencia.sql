ALTER TABLE sipgl.PreMatriculaInscricaoOcorrencia ADD 
tipoFormaIngressoUID tinyint, 
dataIngresso date, 
tipoPeriodoIngressoUID tinyint, 
tipoReservaVagasUID tinyint, 
periodo int, 
ip varchar(25);

ALTER TABLE sipgl.PreMatriculaInscricaoOcorrencia ADD CONSTRAINT PreMatriculaInscricaoOcorrencia_TipoFormaIngresso FOREIGN KEY (tipoFormaIngressoUID) REFERENCES sipgl.TipoFormaIngresso (tipoFormaIngressoUID);
ALTER TABLE sipgl.PreMatriculaInscricaoOcorrencia ADD CONSTRAINT PreMatriculaInscricaoOcorrencia_TipoPeriodoIngresso FOREIGN KEY (tipoPeriodoIngressoUID) REFERENCES sipgl.TipoPeriodoIngresso (tipoPeriodoIngressoUID);
ALTER TABLE sipgl.PreMatriculaInscricaoOcorrencia ADD CONSTRAINT PreMatriculaInscricaoOcorrencia_TipoReservaVagas FOREIGN KEY (tipoReservaVagasUID) REFERENCES sipgl.TipoReservaVagas (tipoReservaVagasUID);