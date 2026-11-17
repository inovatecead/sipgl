CREATE TABLE Sipgl.ProjetoTurmaPolo (
	projetoTurmaPoloUID bigint not null identity(1,1) primary key,
	projetoTurmaUID bigint not null,
	enderecoUID int not null,
	quantidadeVagas int not null
)

ALTER TABLE Sipgl.ProjetoTurmaPolo ADD CONSTRAINT FK_TURMA_POLO_POLO FOREIGN KEY (enderecoUID) REFERENCES Sipgl.EnderecoPoloApoioPresencialEAD (enderecoUID);
ALTER TABLE sipgl.ProjetoTurmaPolo ADD CONSTRAINT FK_TURMA_POLO_TURMA FOREIGN KEY (projetoTurmaUID) REFERENCES Sipgl.ProjetoTurma (projetoTurmaUID);
