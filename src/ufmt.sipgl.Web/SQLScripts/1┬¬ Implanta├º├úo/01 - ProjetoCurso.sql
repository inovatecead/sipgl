-- Alterar tabela ProjetoCurso para adicionar relacionamento com CNPqSubAreaConhecimento
ALTER TABLE Sipgl.ProjetoCurso ADD CNPqSubAreaConhecimentoUID BIGINT NULL;

ALTER TABLE Sipgl.ProjetoCurso ADD CONSTRAINT FK_ProjetoCurso_CNPqSubAreaConhecimento FOREIGN KEY (CNPqSubAreaConhecimentoUID) REFERENCES CNPqSubAreaConhecimento (CNPqSubAreaConhecimentoUID);