UPDATE Sipgl.TipoSituacaoInscricao SET nome = 'Aprovado no Processo Seletivo' WHERE tipoSituacaoInscricaoUID = 1;
UPDATE Sipgl.TipoSituacaoInscricao SET nome = 'Correção Solicitada pelo Coordenador' WHERE tipoSituacaoInscricaoUID = 2;
UPDATE Sipgl.TipoSituacaoInscricao SET nome = 'Cursando' WHERE tipoSituacaoInscricaoUID = 3;
UPDATE Sipgl.TipoSituacaoInscricao SET nome = 'Desistente' WHERE tipoSituacaoInscricaoUID = 4;
UPDATE Sipgl.TipoSituacaoInscricao SET nome = 'Desvinculado' WHERE tipoSituacaoInscricaoUID = 5;

INSERT INTO Sipgl.TipoSituacaoInscricao (nome) values ('Transferido');
INSERT INTO Sipgl.TipoSituacaoInscricao (nome) values ('Formado');
INSERT INTO Sipgl.TipoSituacaoInscricao (nome) values ('Falecido');