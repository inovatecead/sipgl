--USE [idbufmt]
--GO
--/****** Object:  StoredProcedure [Sipgl].[ProcedureManterPreMatriculaInscricao]    Script Date: 24/07/2018 15:18:16 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO





----SELECT * FROM Sipgl.Especialidade
----SELECT * FROM Sipgl.EstruturaCurricular
----SELECT * FROM Sipgl.PreMatriculaPessoa
----SELECT * FROM Sipgl.PreMatriculaInscricaoOcorrencia
----SELECT * FROM Sipgl.PreMatriculaInscricao
----SELECT * FROM Sipgl.ViewPreMatriculaInscricao

--									 /****************
--									 **** A FAZER ****
--									 ****************/

--	 ALTER PROCEDURE [Sipgl].[ProcedureManterPreMatriculaInscricao]
--					 @Operacao TINYINT -- 1 = INSERIR NOVO REGISTRO DE INSCRIÇÃO
--									   -- 2 = ALTERAR UM REGISTRO EXISTENTE
--									   -- 3 = HOMOLOGA INSCRIÇÃO
--									   -- 4 = SOLICITA CORREÇÃO DE DADOS DO DISCENTE
--									   -- 5 = CANCELAMENTO DE INSCRIÇÃO PELO CANDIDATO
--									   -- 6 = CANCELAMENTO DE INSCRIÇÃO PELO COORDENADOR
--									   -- 7 = CONFIRMA CORRECAO DE CorrecaoPreMatriculaInscricao
--									   -- 8 = DESFAZER CANCELAMENTO DE INSCRIÇÃO PELO COORDENADOR
--					,@PreMatriculaPessoaUID BIGINT				-- PARA INSCRIÇÃO
--					,@ProjetoCursoUID BIGINT					-- PARA INSCRIÇÃO/ALTERAÇÃO
--					,@PreMatriculaInscricaoUID BIGINT			-- PARA ALTERAÇÃO/HOMOLOGAÇÃO/CORREÇÃO(Solicitação e Confirmação)
--					,@TipoFormaIngressoUID TINYINT				-- PARA HOMOLOGAÇÃO
--					,@TipoPeriodoIngressoUID TINYINT			-- PARA HOMOLOGAÇÃO
--					,@TipoReservaVagasUID TINYINT				-- PARA HOMOLOGAÇÃO
--					,@DataHoraUltimaAtualizacao SMALLDATETIME	-- PARA HOMOLOGAÇÃO
--					,@DescricaoCorrecao VARCHAR(MAX)			-- PARA CORREÇÃO
--					,@ServidorUID BIGINT						-- PARA SOLICITAÇÃO CORREÇÃO
--					,@NumeroInscricaoSaida BIGINT OUTPUT		-- Valor de Saída -- QNDO GERA INSCRIÇÃO
--					,@RegistroDiscenteSaida BIGINT OUTPUT		-- Valor de Saída -- QNDO OCORRE HOMOLOGAÇÃO INSCRIÇÃO
--					,@ErroSaida VARCHAR(1000) OUTPUT			-- Valor de Saída -- QNDO OCORRE ALGUM ERRO
--					,@enderecoPoloEADUID INT
--AS

--BEGIN TRANSACTION

--BEGIN TRY

--	DECLARE @MensagemErro VARCHAR(1000)
--		   ,@EstruturaCurricularUID BIGINT
--		   ,@PessoaUID BIGINT
--		   ,@CPF VARCHAR(11)
--		   ,@DiscenteUID BIGINT
--		   ,@PreMatriculaInscricaoUIDSaida BIGINT
--		   ,@CodigoCurso VARCHAR(10)
--		   ,@NumeroInscricao BIGINT
--		   ,@RegistroDiscente BIGINT
--		   ,@DataIngressoDiscente DATE
		   
--	-- Verifica se preMatrículaInscricaoUID informada para atualização existe na tabela de PreMatricula,
--	-- se não exitir, dispara mensagem de erro.	
--	IF @Operacao IN (2,3,4,7)
--		IF NOT EXISTS(SELECT preMatriculaInscricaoUID
--						FROM Sipgl.PreMatriculaInscricao
--					   WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID) 
--			RAISERROR('Registro de inscrição informado não foi encontrado na base de dados',16,1)

--	IF @Operacao IN (5,6)
--		IF EXISTS(SELECT preMatriculaInscricaoUID
--					FROM Sipgl.PreMatriculaInscricao
--				   WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--				     AND tipoSituacaoInscricaoUID IN (3))
--			RAISERROR('Inscrição Homologada, não é possível cancelar inscrição.',16,1)

--	--IF @Operacao = (3)
--	--	SET @EspecialidadeUID = (SELECT especialidadeUID 
--	--							   FROM Sipgl.PreMatriculaInscricao
--	--							  WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID)
	
--	--SET @EstruturaCurricularUID = (SELECT estruturaCurricularUID
--	--								 FROM Sipgl.Especialidade
--	--								WHERE especialidadeUID = @EspecialidadeUID)	   

--/*###############################################################################################################*/

--	-- INSERE UM NOVO REGISTRO DE PreMatriculaInscricao.
--	IF @Operacao = 1
--	BEGIN
------------------------------------------------------------------------------------------------------------------
--		-- VERIFICA SE A PESSOA JÁ POSSUI INSCRIÇÃO PARA O CURSO SOLICITADO.
--		-- SE SIM, LANÇA ERRO.
--		--IF @PreMatriculaInscricaoUID IN (SELECT pmi.preMatriculaInscricaoUID FROM Sipgl.PreMatriculaInscricao pmi
										   
--										--WHERE pmi.ProjetoCursoUID = @ProjetoCursoUID
--										  --AND pmi.tipoSituacaoInscricaoUID != 4)	
--			--RAISERROR('Já existe uma matrícula cadastrada para o Curso com o CPF informado. Não é possível realizar mais de uma matrícula em um Curso.',16,1)

----SELECT * FROM Sipgl.TipoSituacaoInscricao
----1	Aguardando Homologação.
----2	Solicitado correção pelo Coordenador.
----3	Homologada.
----4	Inscrição cancelada pelo Candidato.
----5	Inscrição cancelada pelo Coordenador.
------------------------------------------------------------------------------------------------------------------			
			
--		-- Gera o Número de Inscrição, com base no ano corrente mais valor incremental
--		-- (Ex.: Ano: 2011 - Número inscrição gerado: 201100001, 201100002...)
--		EXEC Sipgl.ProcedureGerarNumeroPreMatriculaInscricao @NumeroInscricaoSaida OUTPUT
--		--SET @NumeroInscricaoSaida = @NumeroInscricao
--		SET @NumeroInscricao = @NumeroInscricaoSaida

------------------------------------------------------------------------------------------------------------------

--		-- INSERE OS DADOS DE preMatriculaInscricao
		
--		INSERT INTO Sipgl.PreMatriculaInscricao (preMatriculaPessoaUID, numeroInscricao, tipoSituacaoInscricaoUID, projetoCursoUID, enderecoPoloEADUID)
--		VALUES									(@PreMatriculaPessoaUID, @NumeroInscricaoSaida, 1, @ProjetoCursoUID, @enderecoPoloEADUID)
		
--		SET @PreMatriculaInscricaoUIDSaida = SCOPE_IDENTITY()
		
--		INSERT INTO Sipgl.PreMatriculaInscricaoOcorrencia (preMatriculaInscricaoUID, tipoSituacaoInscricaoUID, dataHoraOcorrencia)
--												   VALUES (@PreMatriculaInscricaoUIDSaida, 1, GETDATE())
--	END
------------------------------------------------------------------------------------------------------------------
--/*###############################################################################################################*/
--/*###############################################################################################################*/
	
--	-- ALTERA UM REGISTRO DE PreMatriculaInscricao JÁ EXISTENTE.
--	IF @Operacao = 2
--	BEGIN
-----------------------------------------------------------------------------------------------------------------
--		-- Verifica se a inscrição já está homologada ou foi cancelada pelo Candidato ou pelo Coordenador do
--		-- Curso.
--		IF EXISTS(SELECT preMatriculaInscricaoUID
--					FROM Sipgl.PreMatriculaInscricao
--				   WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--					 AND tipoSituacaoInscricaoUID IN (3, 4, 5))
--			RAISERROR('Registro de inscrição já Homologado ou Cancelado, não é possível realizar alteração.',16,1)
------------------------------------------------------------------------------------------------------------------
--		-- Verifica se o curso possui mais de uma Especialidade, se não possuir, não permite realizar alteração
--		-- devido este ser o único dado passível de alteração na inscrição e por o curso não apresentar
--		-- tal necessidade.
--		--IF (SELECT COUNT(*)
--		--	  FROM Sipgl.ProjetoEspecialidade
--		--	 WHERE especialidadeUID = @EspecialidadeUID) < 2
--		--	RAISERROR('Não é possível realizar alteração de Especialidade para o Curso informado.',16,1)
------------------------------------------------------------------------------------------------------------------
--		-- Realiza alteração de inscrição. (SOMENTE É POSSÍVEL ALTERAR A ESPECIALIDADE ESCOLHIA PARA O CURSO,
--		-- SE O CURSO POSSUIR ESPECIALIDADES)
--		--BEGIN
--		--	-- Verificar se a especialidade passada pertence ao curso previamente cadastrado para a inscrição.
--		--	-- Se não pertencer indica que se está tentando alterar um curso de uma inscrição, o que não é
--		--	-- permitido, e então é lançado um erro.
--		--	IF ISNULL((SELECT e.estruturaCurricularUID
--		--				 FROM Sipgl.ProjetoEspecialidade e INNER JOIN Sipgl.PreMatriculaInscricao pmi
--		--				   ON e.especialidadeUID = pmi.especialidadeUID
--		--				WHERE pmi.preMatriculaInscricaoUID = @PreMatriculaInscricaoUID), 0) != ISNULL(@EstruturaCurricularUID,-1)
--		--		RAISERROR('Não é possível vincular uma especialidade que não pertence ao curso.',16,1)
			
--		--	-- Atulaliza dados na tabela PreMatriculaInscricao referente ao registro preMatriculaInscricaoUID informado.		
--		--	-- Somente é permitido ao candidato alterar a  epecialidade do curso (Quando houver mais de uma especialidade)
--		--	BEGIN
--		--		UPDATE Sipgl.PreMatriculaInscricao
--		--		   SET especialidadeUID = @EspecialidadeUID
--		--		 WHERE preMatriculaInscricaoUID	= @PreMatriculaInscricaoUID
--		--	END
--		--END
------------------------------------------------------------------------------------------------------------------
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--	-- HOMOLOGA PreMatriculaInscricao

----	IF @Operacao = 3
----	BEGIN
		
----		SET @PreMatriculaPessoaUID = (SELECT preMatriculaPessoaUID
----										FROM Sipgl.PreMatriculaInscricao
----									   WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID)
		
----		-- Verificar se a situação da inscrição é diferente de  "Aguardando Homologação", se sim lança erro.
----		IF EXISTS(SELECT preMatriculaInscricaoUID
----					FROM Sipgl.PreMatriculaInscricao
----				   WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
----					 AND tipoSituacaoInscricaoUID != 1)
----			RAISERROR('Não é possível homologadar a inscrição, situação atual do candidato não permite sua homologação.',16,1)
----		-- Verfica se o candidato realizou altuma alteração em seus dados cadastrais (PreMatriculaPessoa),
----		-- se sim lança erro, para forçar o Homologador verificar se os dasdos estão consistentes.
----		IF NOT EXISTS(SELECT preMatriculaPessoaUID
----						FROM Sipgl.PreMatriculaPessoa
----					   WHERE preMatriculaPessoaUID = @PreMatriculaPessoaUID
----						 AND dataHoraUltimaAtualizacao = @DataHoraUltimaAtualizacao)
----			RAISERROR('Os dados do Candidato a ser Homologado podem ter sofrido alguma alteração após a abertura da tela de homologação, por favor, realize o processo novamente.',16,1)
		
----		-- Recupera o CPF
----		SET @CPF = (SELECT cpf
----					  FROM Sipgl.PreMatriculaPessoa
----					 WHERE preMatriculaPessoaUID = @PreMatriculaPessoaUID)
		
----		-- Verifica se já existe uma pessoa cadastrada na base idbufmt com mesmo CPF
----		-- se não, insere os dados da pessoa na base idbufmt
----		-- se sim, somente atualiza alguns dados na tabelea de pessoa na base de dados idbufmt.
----		IF NOT EXISTS(SELECT pessoaUID
----						FROM dbo.Pessoa
----					   WHERE cpf = @CPF)
----		-- NÃO EXISTE PESSOA COM MESMO CPF NO BANCO IDBUFMT
----		BEGIN
----			INSERT INTO dbo.Pessoa (nome, sexo, nascimentoData, nomeMae, nomePai, cpf
----								   ,rg, rgUF, rgOrgaoExpedidor, rgDataExpedicao, tipoEstadoCivilUID
----								   ,nacionalidade, nascimentoPaisUID, naturalidadeMunicipioUID, mail
----								   ,enderecoLogradouro, enderecoNumero, enderecoComplemento, enderecoBairro, enderecoCEP
----								   ,enderecoMunicipioUID, telefonePrimario, telefoneSecundario, telefoneComercial)
								   
----							 SELECT nome, sexo, nascimentoData, nomeMae, nomePai, cpf
----								   ,rgNumero, rgUFUID, rgOrgaoExpedidor, rgDataExpedicao, tipoEstadoCivilUID
----								   ,nacionalidade, nascimentoPaisUID, naturalidadeMunicipioUID, email
----								   ,enderecoLogradouro, enderecoNumero, enderecoComplemento, enderecoBairro, enderecoCEP
----								   ,enderecoMunicipioUID, telefoneFixo, telefoneMovel, telefoneComercial
----							   FROM Sipgl.PreMatriculaPessoa
----							  WHERE preMatriculaPessoaUID = @PreMatriculaPessoaUID
			
----			SET @PessoaUID = SCOPE_IDENTITY()
----		END
----		-- JÁ EXISTE PESSOA COM MESMO CPF NO BANCO IDBUFMT
----		ELSE
----		BEGIN
----			SET @PessoaUID = (SELECT pessoaUID
----							    FROM dbo.Pessoa
----							   WHERE cpf = @CPF)
							   
----			-- Verificar questões de update (fazer ou não?), não atualizar email nunca!,
----			-- quais dados atualizar?
----			UPDATE idbufmt.dbo.Pessoa
----			   SET nomePai = pmp.nomePai
----				  ,tipoEstadoCivilUID = pmp.tipoEstadoCivilUID
----				  ,nacionalidade = pmp.nacionalidade
----				  ,nascimentoPaisUID = pmp.nascimentoPaisUID
----				  ,naturalidadeMunicipioUID = pmp.naturalidadeMunicipioUID
----				  ,enderecoMunicipioUID = pmp.enderecoMunicipioUID
----			  FROM dbo.Pessoa p INNER JOIN Sipgl.PreMatriculaPessoa pmp
----			    ON p.cpf = pmp.cpf
----			 WHERE pessoaUID = @PessoaUID
----		END	
		
----		-- Insere os dados de pessoa em idbufmt.dbo.DadoSocioeconomico
		
----		IF NOT EXISTS(SELECT DadoSocioeconomicoUID
----						FROM dbo.DadoSocioeconomico
----					   WHERE pessoaUID = @PessoaUID)
----			INSERT INTO dbo.DadoSocioeconomico(pessoaUID, tipoFaixaRendaFamiliarUID, tipoCorRacaUID)
----			SELECT							   @PessoaUID, tipoFaixaRendaFamiliarUID, tipoCorRacaUID
----			  FROM Sipgl.PreMatriculaPessoa
----			 WHERE preMatriculaPessoaUID = @PreMatriculaPessoaUID
----		ELSE
----			UPDATE dbo.DadoSocioeconomico
----			   SET tipoFaixaRendaFamiliarUID	= pmp.tipoFaixaRendaFamiliarUID
----			      ,tipoCorRacaUID				= pmp.tipoCorRacaUID
----			  FROM Sipgl.PreMatriculaPessoa pmp
----			 WHERE preMatriculaPessoaUID = @PreMatriculaPessoaUID
----------------------------------------------------------------------------------------------------------------
----		-- Gera o Registro para o Discente, com base no Código do Curso
----		-- (Ex.: Código do Curso: 2011001 - Número inscrição gerado: 2011001001, 2011001002...)
----		EXEC Sipgl.ProcedureGerarRegistroDiscente @EstruturaCurricularUID, @RegistroDiscenteSaida OUTPUT
----		--SET @RegistroDiscenteSaida = @RegistroDiscente
-----------------------------------------------------------------------------------------------------------------
----		SET @DataIngressoDiscente = (SELECT dataInicio
----									   FROM Sipgl.EstruturaCurricular
----									  WHERE estruturaCurricularUID = @EstruturaCurricularUID)
		
----		-- Insere os dados de Discente em idbufmt.Sipgl.Discente
----		INSERT INTO Sipgl.Discente (pessoaUID, registro, especialidadeUID, tipoFormaIngressoUID, dataIngresso
----								   ,tipoPeridoIngressoUID, tipoReservaVagasUID)
----		--,
----		SELECT						@PessoaUID, @RegistroDiscenteSaida, especialidadeUID, @TipoFormaIngressoUID, @DataIngressoDiscente
----								   ,@TipoPeriodoIngressoUID, @TipoReservaVagasUID
----		  FROM Sipgl.PreMatriculaInscricao
----		 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
			
----		   SET @DiscenteUID = SCOPE_IDENTITY()
		   
		   
----		   -- select * from titulacaoPessoa
----		   -- select * from TipoTitulacao										
		
----		-- Iserere IES de graduação do discente na tabela idbufmt.Sipgl.GraduacaoDiscente
----		IF NOT EXISTS(SELECT titulacaoPessoaUID
----						FROM dbo.TitulacaoPessoa
----					   WHERE pessoaUID = @PessoaUID
----					     AND tipoTitulacaoUID = 5)
----		BEGIN
----			INSERT INTO dbo.TitulacaoPessoa(pessoaUID, nomeCurso, tipoTitulacaoUID,instituicaoEnsinoUID, dataColacaoGrau)
----			SELECT							@PessoaUID, 'Não Informado',5, graduacaoInstituicaoEnsinoUID, graduacaoDataColacaoGrau
----			  FROM Sipgl.PreMatriculaPessoa
----			 WHERE preMatriculaPessoaUID = @PreMatriculaPessoaUID
----		END
		
----		-- Altera a situação da inscrição para "Homologada"	
----		UPDATE Sipgl.PreMatriculaInscricao
----		   SET tipoSituacaoInscricaoUID	= 3
----		 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
----		   AND tipoSituacaoInscricaoUID = 1
	
----		INSERT INTO Sipgl.PreMatriculaInscricaoOcorrencia (preMatriculaInscricaoUID, tipoSituacaoInscricaoUID, dataHoraOcorrencia)
----												   VALUES (@PreMatriculaInscricaoUID, 3, GETDATE())

	
----	END

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	select * from Sipgl.TipoSituacaoInscricao
--	-- SOLICITA CORREÇÃO DE DADOS DO DISCENTE
--	IF @Operacao = 4
--	BEGIN
--		IF LTRIM(RTRIM(ISNULL(@DescricaoCorrecao,''))) != ''
--		BEGIN
--			INSERT INTO Sipgl.CorrecaoPreMatriculaInscricao(preMatriculaInscricaoUID, responsavelServidorUID, descricao, dataHora, correcaoConfirmada)
--												    VALUES (@PreMatriculaInscricaoUID, @ServidorUID, @DescricaoCorrecao, GETDATE(), 0)
		
--			INSERT INTO Sipgl.PreMatriculaInscricaoOcorrencia (preMatriculaInscricaoUID, tipoSituacaoInscricaoUID, dataHoraOcorrencia)
--													   VALUES (@PreMatriculaInscricaoUID, 2, GETDATE())
			
--			UPDATE Sipgl.PreMatriculaInscricao
--			   SET tipoSituacaoInscricaoUID = 2
--			 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
													  
--		END
--		ELSE
--			RAISERROR('Não é permitido conteúdo em branco no campo de descrição de correção.',16,1)
--	END

--/*###############################################################################################################*/
--/*###############################################################################################################*/

--	-- CANCELAMENTO DE INSCRIÇÃO PELO CANDIDATO
--	IF @Operacao = 5
--	BEGIN
--		-- Atualiza situação da isncrição para "Inscrição cancelada pelo Candidato"
--		UPDATE Sipgl.PreMatriculaInscricao
--		   SET tipoSituacaoInscricaoUID = 4
--		 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--		   AND tipoSituacaoInscricaoUID IN (1,2)
		   
--		-- Cadastra nova ocorrência para inscrição "Inscrição cancelada pelo Candidato"
--		INSERT INTO Sipgl.PreMatriculaInscricaoOcorrencia (preMatriculaInscricaoUID, tipoSituacaoInscricaoUID, dataHoraOcorrencia)
--												   VALUES (@PreMatriculaInscricaoUID, 4, GETDATE())
--	END

--/*###############################################################################################################*/
--/*###############################################################################################################*/

--	-- CANCELAMENTO DE INSCRIÇÃO PELO COORDENADOR
--	IF @Operacao = 6
--	BEGIN
--		-- Atualiza situação da isncrição para "Inscrição cancelada pelo Coordenador"
--		UPDATE Sipgl.PreMatriculaInscricao
--		   SET tipoSituacaoInscricaoUID = 5
--		 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--		   AND tipoSituacaoInscricaoUID IN (1,2)
		   
--		-- Cadastra nova ocorrência para inscrição "Inscrição cancelada pelo Coordenador"
--		INSERT INTO Sipgl.PreMatriculaInscricaoOcorrencia (preMatriculaInscricaoUID, tipoSituacaoInscricaoUID, dataHoraOcorrencia)
--												   VALUES (@PreMatriculaInscricaoUID, 5, GETDATE())
--	END

--/*###############################################################################################################*/

--	-- CONFIRMA CORRECAO DE CorrecaoPreMatriculaInscricao
--	IF @Operacao = 7
--	BEGIN
--		-- Verifica se inscrição já foi Homologada ou Cancelada pelo Candidato ou Coordenador.
--		IF EXISTS(SELECT preMatriculaInscricaoUID
--					FROM Sipgl.PreMatriculaInscricao
--				   WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--				     AND tipoSituacaoInscricaoUID IN (3, 4, 5))
--			RAISERROR('Registro de inscrição já homologado ou cancelado, não é possível confirmar correção.',16,1)
		
--		-- Verifica se a inscrição está com situação "Solicitado correção pelo Coordenador"
--		IF EXISTS(SELECT preMatriculaInscricaoUID
--					FROM Sipgl.PreMatriculaInscricao
--				   WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--					 AND tipoSituacaoInscricaoUID = 2)
--		BEGIN
--			-- Atualiza situação da isncrição para "Aguardando Homologação"
--			UPDATE Sipgl.PreMatriculaInscricao
--			   SET tipoSituacaoInscricaoUID = 1
--			 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--			   AND tipoSituacaoInscricaoUID = 2
			
--			-- Atualiza condição da correção da inscrição para "Confirmada"
--			UPDATE Sipgl.CorrecaoPreMatriculaInscricao
--			   SET correcaoConfirmada = 1
--				  ,dataHoraConfirmacaoCorrecao = GETDATE()
--			 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--			   AND correcaoConfirmada = 0
			
--			-- Cadastra nova ocorrência para inscrição "Aguardando Homologação"
--			INSERT INTO Sipgl.PreMatriculaInscricaoOcorrencia (preMatriculaInscricaoUID, tipoSituacaoInscricaoUID, dataHoraOcorrencia)
--													   VALUES (@PreMatriculaInscricaoUID, 1, GETDATE())

--		END
--		ELSE
--			RAISERROR('Não foi possível confirmar a correção.',16,1)
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--	-- CANCELAMENTO DE INSCRIÇÃO PELO COORDENADOR
--	IF @Operacao = 8
--	BEGIN
--		-- Atualiza situação da isncrição para "Inscrição cancelada pelo Coordenador"
--		UPDATE Sipgl.PreMatriculaInscricao
--		   SET tipoSituacaoInscricaoUID = 1
--		 WHERE preMatriculaInscricaoUID = @PreMatriculaInscricaoUID
--		   AND tipoSituacaoInscricaoUID IN (4,5)
		   
--		-- Cadastra nova ocorrência para inscrição "Inscrição cancelada pelo Coordenador"
--		INSERT INTO Sipgl.PreMatriculaInscricaoOcorrencia (preMatriculaInscricaoUID, tipoSituacaoInscricaoUID, dataHoraOcorrencia)
--												   VALUES (@PreMatriculaInscricaoUID, 1, GETDATE())
--	END

--/*###############################################################################################################*/


--/*###############################################################################################################*/

--END TRY

--BEGIN CATCH

--IF @@TRANCOUNT > 0
--		ROLLBACK TRANSACTION

--EXEC Sipgl.ProcedureRetornarInformacaoErro @MensagemErro OUTPUT
--SET @ErroSaida = @MensagemErro

--END CATCH

--IF @@TRANCOUNT > 0
--	COMMIT TRANSACTION





