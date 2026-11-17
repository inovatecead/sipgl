execute sp_RENAME 'sipgl.EnderecoPoloApoioPresencialEAD.identificacaoEndereco', 'logradouro' , 'COLUMN';

ALTER TABLE sipgl.EnderecoPoloApoioPresencialEAD ADD identificacaoEndereco varchar(1024);

ALTER TABLE sipgl.EnderecoPoloApoioPresencialEAD ADD tipoUnidadeEnsino int;

ALTER TABLE sipgl.EnderecoPoloApoioPresencialEAD ADD enderecoUFUID VARCHAR(2);

ALTER TABLE sipgl.EnderecoPoloApoioPresencialEAD ALTER COLUMN projetoCursoUID BIGINT;