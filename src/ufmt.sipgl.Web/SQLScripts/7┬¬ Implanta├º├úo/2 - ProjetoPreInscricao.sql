CREATE TABLE sipgl.ProjetoPreInscricao (
	projetoPreInscricaoUID BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	preMatriculaPessoaUID BIGINT NOT NULL,
	situacaoPreInscricaoEnum INT NOT NULL,
	projetoTurmaUID BIGINT NOT NULL,
	dataSolicitacao DATETIME NOT NULL,
	preMatriculaInscricaoUID BIGINT,
	dataAtuacao DATETIME,
	usuarioAtuacaoUID BIGINT,
	ipUsuarioAtuacao varchar(25)
);

ALTER TABLE Sipgl.ProjetoPreInscricao ADD CONSTRAINT FK_PROJETO_PRE_INSCRICAO_PRE_MATRICULA_PESSOA FOREIGN KEY (preMatriculaPessoaUID) REFERENCES sipgl.PreMatriculaPessoa (preMatriculaPessoaUID);
ALTER TABLE Sipgl.ProjetoPreInscricao ADD CONSTRAINT FK_PROJETO_PRE_INSCRICAO_PROJETO_TURMA FOREIGN KEY (projetoTurmaUID) REFERENCES sipgl.ProjetoTurma (projetoTurmaUID);
ALTER TABLE Sipgl.ProjetoPreInscricao ADD CONSTRAINT FK_PROJETO_PRE_INSCRICAO_PRE_MATRICULA_INSCRICAO FOREIGN KEY (preMatriculaInscricaoUID) REFERENCES sipgl.PreMatriculaInscricao (preMatriculaInscricaoUID);
ALTER TABLE Sipgl.ProjetoPreInscricao ADD CONSTRAINT FK_PROJETO_PRE_INSCRICAO_USUARIO FOREIGN KEY (usuarioAtuacaoUID) REFERENCES dbo.Usuario(usuarioUID);