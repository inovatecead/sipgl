--USE [idbufmt]
--GO
--/****** Object:  StoredProcedure [Sipgl].[ProcedureManterProjetoCurso]    Script Date: 21/06/2018 14:45:20 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO


--ALTER PROCEDURE [Sipgl].[ProcedureManterProjetoCurso]
--					 @Operacao TINYINT --> 1 = INSERE NOVO REGISTRO em Sipgl.ProjetoCurso --> 2 = ALTERA REGISTRO EXISTENTE em Sipgl.ProjetoCurso
--									   --> 3 = INSERE NOVO REGISTRO em Sipgl.ProjetoCorpoDocente --> 4 = ALTERA REGISTRO EXISTENTE em Sipgl.ProjetoCorpoDocente
--									   --> 5 = INSERE NOVO REGISTRO em Sipgl.ProjetoColegiadoCurso --> 6 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoColegiadoCurso 
--									   --> 7 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoColegiadoCurso
--									   --> 8 = INSERE NOVO REGISTRO em Sipgl.ProjetoBolsaEstagioLei_11788_2008 --> 9 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoBolsaEstagioLei_11788_2008 
--									   --> 10 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoBolsaEstagioLei_11788_2008
--									   --> 11 = INSERE NOVO REGISTRO em Sipgl.ProjetoBolsaoLei_8958_94 --> 12 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoBolsaoLei_8958_94 
--									   --> 13 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoBolsaoLei_8958_94
--									   --> 14 = INSERE NOVO REGISTRO em Sipgl.ProjetoMaterialPermanente --> 15 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoMaterialPermanente 
--									   --> 16 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoMaterialPermanente
--									   --> 17 = INSERE NOVO REGISTRO em Sipgl.ProjetoObras --> 18 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoObras 
--									   --> 19 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoObras
--									   --> 20 = INSERE NOVO REGISTRO em Sipgl.ProjetoDisciplina --> 21 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoDisciplina 
--									   --> 22 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoDisciplina
--									   --> 23 = INSERE NOVO REGISTRO em Sipgl.ProjetoDiarias --> 24 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoDiarias 
--									   --> 25 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoDiarias
--									   --> 26 = INSERE NOVO REGISTRO em Sipgl.ProjetoMaterialConsumo --> 27 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoMaterialConsumo 
--									   --> 28 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoMaterialConsumo
--									   --> 29 = INSERE NOVO REGISTRO em Sipgl.ProjetoPassagens --> 30 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoPassagens 
--									   --> 31 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoPassagens
--									   --> 32 = INSERE NOVO REGISTRO em Sipgl.ProjetoEquipamentos --> 33 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoEquipamentos
--									   --> 34 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoEquipamentos
--									   --> 35 = INSERE NOVO REGISTRO em Sipgl.ProjetoPessoalEncargos --> 36 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoPessoalEncargos
--									   --> 37 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoPessoalEncargos
--									   --> 38 = INSERE NOVO REGISTRO em Sipgl.ProjetoDespesas --> 39 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoDespesas
--									   --> 40 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoDespesas
--									   --> 41 = INSERE NOVO REGISTRO em Sipgl.ProjetoPrevisaoReceitas --> 42 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoPrevisaoReceitas
--									   --> 43 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoPrevisaoReceitas
--									   --> 44 = INSERE NOVO REGISTRO em Sipgl.ProjetoServicoTerceirosPessoJuridica --> 45 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoServicoTerceirosPessoJuridica
--									   --> 46 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoServicoTerceirosPessoJuridica
--									   --> 47 = INSERE NOVO REGISTRO em Sipgl.Sipgl.ProjetoCursoComplementoPresencial --> 48 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.Sipgl.ProjetoCursoComplementoPresencial
--									   --> 49 = DELETA REGISTRO INFORMADO em Sipgl.Sipgl.ProjetoCursoComplementoPresencial
--									   --> 50 = INSERE NOVO REGISTRO em Sipgl.ProjetoCursoVagas --> 51 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoCursoVagas
--									   --> 52 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoCursoVagas
--									   --> 53 = INSERE NOVO REGISTRO em Sipgl.ProjetoCursoComplementoPresencialVagas --> 54 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoCursoComplementoPresencialVagas
--									   --> 55 = INSERE NOVO REGISTRO em Sipgl.ProjetoCursoComplementoEad --> 56 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoCursoComplementoEad
--									   --> 57 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoCursoComplementoEad
--									   --> 58 = INSERE NOVO REGISTRO em Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad --> 59 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad
--									   --> 60 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad
--									   --> 61 = INSERE NOVO REGISTRO em Sipgl.ProjetoCursoComplementoEadEndereco --> 62 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoCursoComplementoEadEndereco
--									   --> 63 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoCursoComplementoEadEndereco
--									   --> 64 = INSERE NOVO REGISTRO em Sipgl.ProjetoCursoComplementoEadVagas --> 65 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoCursoComplementoEadVagas
--									   --> 66 = INSERE NOVO REGISTRO em Sipgl.ProjetoServicoTerceirosPessoaFisica --> 67 = ALTERA UM REGISTRO JÁ EXISTENTE em Sipgl.ProjetoServicoTerceirosPessoaFisica
--									   --> 68 = DELETA REGISTRO INFORMADO em Sipgl.ProjetoServicoTerceirosPessoaFisica

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCurso
--					,@ProjetoCursoUID BIGINT
--					,@CodigoProjetoCurso INT OUTPUT
--					,@TipoModalidadeUID TINYINT
--					,@NomeCurso VARCHAR(500)
--					,@CNPqAreaConhecimentoUID BIGINT -- * --
--					,@ProponenteUnidadeUID BIGINT
--					,@Telefone VARCHAR(50) -- * --
--					,@Fax VARCHAR(50) -- * --
--					,@Email VARCHAR(255)
--					,@SiteCurso VARCHAR(255)
--					,@CoordenadorServidorUID BIGINT
					
--					,@titulacaoCoordenadorUID INT
--					,@regimeTrabalhoCoordenadorUID INT
--					,@telefoneResidencialCoordenador VARCHAR(50)
--					,@telefoneCelularCoordenador VARCHAR(50)
--					,@emailCoordenador VARCHAR(255)
					
--					,@viceCoordenadorServidorUID BIGINT
					
--					,@titulacaoViceCoordenadorUID INT
--					,@regimeTrabalhoViceCoordenadorUID INT
--					,@telefoneResidencialViceCoordenador VARCHAR(50)
--					,@telefoneCelularViceCoordenador VARCHAR(50)
--					,@emailViceCoordenador VARCHAR(255)			
					
--					,@RealizacaoDataInicio SMALLDATETIME
--					,@realizacaoDataTermino SMALLDATETIME
--					,@CargahorariaTotal INT
					
					
--					, @turnoOfertaUID INT
--					, @periodicidadeUID INT
--					, @cargaHorariaDiario INT
--					, @cargaHorariaModular INT
--					, @nomeCursoModular VARCHAR(255)
					
--					,@PublicoAlvo VARCHAR(500) -- * --
--					,@DescricaoInstalacoes VARCHAR(MAX)
--					,@DescricaoEquipamentos VARCHAR(MAX)
--					,@DescricaoMaterialBibliografico VARCHAR(MAX)
--					,@JustificativaCurso VARCHAR(MAX)
--					,@ObjetivosCurso VARCHAR(MAX)
--					,@MinutaEdital VARBINARY(MAX)
--					,@FormasAvaliacao VARCHAR(MAX)
--					,@CaracteristicasMonografiaTcc VARCHAR(MAX)
--					,@NotaMinimaAprovacao INT
--					,@FrequenciaMinimaAprovacao INT
--					,@FinanciamentoCurso VARBINARY(MAX)
--					,@TermoConvenio varbinary(MAX)
--					,@TipoFinanciamentoUID TINYINT
--					,@TipoGestaoFinanceiraUID TINYINT
--					,@PlanoAplicacaoSuperavit varbinary(MAX)
					
--					,@QuantidadeEgresso	int	
--					,@QuantidadeVagas	int	
--					,@DataDocumentoRealizacaoCurso	smalldatetime	
--					,@DocumentoRealizacaoCurso	varbinary(MAX)	
--					,@VinculoCursoGraduacao	bit	
--					,@SigaCodCurso	int	
--					,@CEP	varchar(50)	
--					,@MunicipioEnderecoUID	int	
--					,@IdentificacaoEndereco	varchar(2000)	
--					,@NumeroEndereco	int	
--					,@ComplementoBairro	varchar(2000)	
--					,@BairroEndereco	varchar(2000)	
--					,@InformacoesReferenciaEndereco	varchar(MAX)
--					,@CNPqSubAreaConhecimentoUID BIGINT -- * --
					
					
--					,@ProjetoCursoUID_Saida BIGINT OUTPUT -- Valor de Saída
--					-- FIM Dados da Tabela Sipgl.ProjetoCurso
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCorpoDocente
--					,@ProjetocorpoDocenteUID BIGINT
--					-->,@projetoCursoUID BIGINT
--					,@ServidorUID BIGINT
--					-- FIM Dados da Tabela Sipgl.ProjetoCorpoDocente
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoColegiadoCurso
--					,@ProjetoColegiadoCursoUID BIGINT
--					-->,@projetoCursoUID BIGINT
--					-->,@ServidorUID BIGINT
--					,@TipoMembroColegiadoUID TINYINT
--					-- FIM Dados da Tabela Sipgl.ProjetoColegiadoCurso

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoBolsaEstagioLei_11788_2008
--					,@ProjetoBolsaEstagioLei_11788_2008 BIGINT
--					--@ProjetoCursoUID
--					,@PessoaUID BIGINT
--					,@Quantidade SMALLINT
--					,@ValorUnitario DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoBolsaEstagioLei_11788_2008

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoBolsaoLei_8958_94
--					,@ProjetoBolsaoLei_8958_94_UID BIGINT
--					--,@ProjetoCursoUID
--					--,@PessoaUID
--					,@AtividadeNaoRegular BIT
--					,@DataInicio DATE
--					,@DataFim DATE
--					,@CargaHorariaMensal SMALLINT
--					,@CargaHoraiaTotal SMALLINT
--					,@ValorUnitarioCargaHoraria DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoBolsaoLei_8958_94
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoMaterialPermanente
--					,@ProjetoMaterialPermanenteUID BIGINT
--					--,@projetoCursoUID
--					,@TipoMaterialPemanenteUID SMALLINT
--					,@QuantidadeMaterialPermanente SMALLINT
--					,@ValorUnitarioMaterialPermanente DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoMaterialPermanente

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoObras
--					,@ProjetoObrasUID BIGINT
--					--,@ProjetoCursoUID
--					,@TipoObraUID SMALLINT
--					,@QuantidadeObra SMALLINT
--					,@ValorUnitarioObra DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoObras
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoDisciplina
--					,@ProjetoDisciplinaUID BIGINT
--					--,@ProjetoCursoUID
--					--,@ProjetoCorpoDocenteUID BIGINT
--					,@NomeDisciplina VARCHAR(255)
--					,@CargaHorariaDisciplina SMALLINT
--					,@DataInicioDisciplina DATE
--					,@DataTerminoDisciplina DATE
--					,@Ementa VARCHAR(MAX)
--					,@Bibliografia VARCHAR(MAX)
--					-- FIM Dados da Tabela Sipgl.ProjetoDisciplina

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoDiarias
--					,@ProjetoDiariasUID BIGINT
--					--,@ProjetoCursoUID
--					--,@PessoaUID
--					,@MunicipioUID BIGINT
--					,@DataInicioDiarias SMALLDATETIME
--					,@DataFimDiarias SMALLDATETIME
--					,@QuantidadeDiarias DECIMAL(5,1)
--					,@ValorUnitarioDiarias DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoDiarias

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoMaterialConsumo
--					,@ProjetoMaterialConsumoUID BIGINT
--					--,@ProjetoCursoUID
--					,@TipoMaterialConsumoUID SMALLINT
--					,@QuantidadeMaterialConsumo SMALLINT
--					,@ValorUnitarioMaterialConsumo DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoMaterialConsumo


--					-- INÍCIO Dados da Tabela Sipgl.ProjetoPassagens
--					,@ProjetoPassagensUID BIGINT
--					--@ProjetoCursoUID
--					--,@PessoaUID
--					,@TipoPassagemUID TINYINT
--					,@Trecho VARCHAR(255)
--					,@QuantidadePassagens SMALLINT
--					,@ValorUnitarioPassagens DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoPassagens

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoEquipamentos
--					,@ProjetoEquipamentoUID BIGINT
--					--@ProjetoCursoUID
--					,@TipoEquipamentoUID SMALLINT
--					,@QuantidadeEquipamentos SMALLINT
--					,@ValorUnitarioEquipamentos DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoEquipamentos
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoPessoalEncargos
--					,@ProjetoPessoalEncargosUID BIGINT
--					--,projetoCursoUID 
--					--,pessoaUID
--					,@TipoAtividadeUID TINYINT
--					,@DataInicioPessoalEncargos DATE
--					,@DataFimPessoalEncargos DATE
--					,@ValorMensalPessoalEncargos DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoPessoalEncargos

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoDespesas
--					,@ProjetoDespesasUID BIGINT
--					--,ProjetoCursoUID
--					--,PessoaUID
--					,@TipoDespesaUID SMALLINT
--					,@QuantidadeDespesa SMALLINT
--					,@ValorUnitarioDespesa DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoDespesas

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoPrevisaoReceitas
--					,@ProjetoPrevisaoReceitasUID BIGINT
--					--,ProjetoCursoUID BIGINT
--					,@TipoReceitaUID SMALLINT
--					,@NumeroAlunos SMALLINT
--					,@NumeroParcelas SMALLINT
--					,@ValorUnitarioPrevisaoReceita DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoPrevisaoReceitas

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoServicoTerceirosPessoJuridica
--					,@ProjetoServicoTerceirosPessoJuridicaUID BIGINT
--					--projetoCursoUID
--					,@TipoServicoTerceirosPessoaJuridicaUID SMALLINT
--					,@QuantidadeServicoTerceirosPJ SMALLINT
--					,@ValorUnitarioServicoTerceirosPJ DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoServicoTerceirosPessoJuridica

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCursoComplementoPresencial
--					,@ProjetoCursoComplementoPresencialUID BIGINT
--					--projetoCursoUID
--					,@TipoTurnoOfertaUID TINYINT
--					,@TipoPeriodicidadeUID TINYINT
--					,@cargaHorariaPeriodicidade SMALLINT
--					,@EnderecoUID BIGINT
--					-- FIM Dados da Tabela Sipgl.ProjetoCursoComplementoPresencial

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCursoVagas
--					,@ProjetoCursoVagasUID BIGINT
--					,@NumeroVagas SMALLINT
--					,@TipoVagasUID TINYINT
--					-- FIM Dados da Tabela Sipgl.ProjetoCursoVagas
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCursoComplementoPresencialVagas
--					,@ProjetoCursoComplementoPresencialVagasUID BIGINT
--					--,@ProjetoCursoComplementoPresencialUID BIGINT
--					--,@ProjetoCursoVagasUID BIGINT
--					-- FIM Dados da Tabela Sipgl.ProjetoCursoComplementoPresencialVagas

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCursoComplementoEad
--					,@ProjetoCursoComplementoEadUID BIGINT
--					--,@ProjetoCursoUID 
--					,@DescricaoMaterialDidaticoTextualMultimidia VARCHAR(MAX)
--					,@DescricaoAmbienteVirtualAprendizagem VARCHAR(MAX)
--					,@DataInicioInscricao SMALLDATETIME
--					,@DataFimInscricao SMALLDATETIME
--					,@DataInicioSelecao SMALLDATETIME
--					,@DataFimSelecao SMALLDATETIME
--					,@DataInicioMatricula SMALLDATETIME
--					,@DataFimMatricula SMALLDATETIME
--					,@DataPrevisaoInicioAulas DATE
--					,@CriteriosSelecao VARCHAR(MAX)
--					,@CriteriosComprovacaoCarenciaFinanceira VARCHAR(MAX)
--					,@DescricaoSelecaoCandidatos VARCHAR(MAX)
--					,@ProcedimentoRecursoAdm VARCHAR(MAX)
--					,@ProcedimentoDivulgacaoResultadoFinal VARCHAR(MAX)
--					,@OrientacoesProcedimentoMatricula VARCHAR(MAX)
--					,@ProcedimentoRealizacaoSegundaChamada VARCHAR(MAX)
--					-- FIM Dados da Tabela Sipgl.ProjetoCursoComplementoEad

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad
--					,@ProjetoCorpoDocenteMaterialDidaticoEadUID BIGINT
--					--,@ProjetoCursoComplementoEadUID BIGINT
--					--,@ServidorUID BIGINT
--					,@DescricaoMaterial VARCHAR(MAX)
--					--,@ProjetoDisciplinaUID BIGINT
--					-- FIM Dados da Tabela Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad

--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCursoComplementoEadEndereco
--					,@ProjetoCursoComplementoEadEnderecoUID BIGINT
--					--projetoCursoComplementoEadUID
--					--,@EnderecoUID BIGINT
--					,@TipoEnderecoEadUID TINYINT
--					-- FIM Dados da Tabela Sipgl.ProjetoCursoComplementoEadEndereco
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoCursoComplementoEadVagas
--					,@ProjetoCursoComplementoEadVagasUID BIGINT
--					--,@ProjetoCursoComplementoEadUID BIGINT
--					--,@ProjetoCursoVagasUID BIGINT
--					,@PoloEadEnderecoUID BIGINT
--					-- FIM Dados da Tabela Sipgl.ProjetoCursoComplementoEadVagas
					
--					-- INÍCIO Dados da Tabela Sipgl.ProjetoServicoTerceirosPessoFisica
--					,@ProjetoServicoTerceirosPessoFisicaUID BIGINT
--					,@AtividadeNaoRegularServicoTerceirosPF BIT
--					,@DataInicioServicoTerceirosPF DATE
--					,@DataFimServicoTerceirosPF DATE
--					,@CargaHorariaMensalSevicoTerceirosPF SMALLINT
--					,@CargaHorariaTotalServicoTerceirosPF SMALLINT
--					,@ValorUnitarioCargaHorariaServicoTerceirosPF DECIMAL(16,2)
--					,@EncargosSociaisServicoTerceirosPF DECIMAL(16,2)
--					-- FIM Dados da Tabela Sipgl.ProjetoServicoTerceirosPessoFisica
				

--					,@ErroSaida VARCHAR(500) OUTPUT -- Valor de Saída
					

--AS

--BEGIN TRANSACTION

--BEGIN TRY
	
--	DECLARE @MensagemErro VARCHAR(500)

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
	
	
	
--	IF @Operacao = 1
--		BEGIN
			
--			EXEC Sipgl.ProcedureGerarCodigoProjeto @CodigoProjetoCurso OUTPUT
			
--			INSERT INTO Sipgl.ProjetoCurso (
			
--			  codigoProjetoCurso
--			, tipoModalidadeUID
--			, nomeCurso
--			, CNPqAreaConhecimentoUID
--			, proponenteUnidadeUID
--			, telefone
--			, fax
--			, email
--			, siteCurso
--			, coordenadorServidorUID
			
--			,titulacaoCoordenadorUID
--			,regimeTrabalhoCoordenadorUID
--			,telefoneResidencialCoordenador
--			,telefoneCelularCoordenador
--			,emailCoordenador	
			
			
--			, viceCoordenadorServidorUID
			
--			,titulacaoViceCoordenadorUID	
--			,regimeTrabalhoViceCoordenadorUID
--			,telefoneResidencialViceCoordenador
--			,telefoneCelularViceCoordenador
--			,emailViceCoordenador
			
--			, realizacaoDataInicio
--			, realizacaoDataTermino
--			, cargahorariaTotal
			
--			, turnoOfertaUID
--			, periodicidadeUID
--			, cargaHorariaDiario
--			, cargaHorariaModular
--			, nomeCursoModular
			
			
--			, publicoAlvo
--			, descricaoInstalacoes
--			, descricaoEquipamentos
--			, descricaoMaterialBibliografico
--			, justificativaCurso
--			, objetivosCurso
--			, minutaEdital
--			, formasAvaliacao
--			, caracteristicasMonografiaTcc
--			, notaMinimaAprovacao
--			, frequenciaMinimaAprovacao
--			, financiamentoCurso
--			, termoConvenio
--			, tipoFinanciamentoUID
--			, tipoGestaoFinanceiraUID
--			, planoAplicacaoSuperavit
--			, QuantidadeEgresso
--			, QuantidadeVagas
--			, DataDocumentoRealizacaoCurso
--			, DocumentoRealizacaoCurso
--			, VinculoCursoGraduacao
--			, SigaCodCurso
--			, CEP
--			, MunicipioEnderecoUID
--			, IdentificacaoEndereco
--			, NumeroEndereco
--			, ComplementoBairro
--			, BairroEndereco
--			, InformacoesReferenciaEndereco
--			, CNPqSubAreaConhecimentoUID
			
--			)
--			VALUES     (
--			@CodigoProjetoCurso
--			, @tipoModalidadeUID
--			, @nomeCurso
--			, @CNPqAreaConhecimentoUID
--			, @proponenteUnidadeUID
--			, @Telefone
--			, @Fax
--			, @email
--			, @siteCurso
--			, @coordenadorServidorUID
			
--			, @titulacaoCoordenadorUID
--			, @regimeTrabalhoCoordenadorUID
--			, @telefoneResidencialCoordenador
--			, @telefoneCelularCoordenador
--			, @emailCoordenador	
			
			
--			, @viceCoordenadorServidorUID
			
--			, @titulacaoViceCoordenadorUID
--			, @regimeTrabalhoViceCoordenadorUID
--			, @telefoneResidencialViceCoordenador
--			, @telefoneCelularViceCoordenador
--			, @emailViceCoordenador	
			
--			, @realizacaoDataInicio
--			, @realizacaoDataTermino
--			, @cargahorariaTotal
			
--			, @turnoOfertaUID
--			, @periodicidadeUID
--			, @cargaHorariaDiario
--			, @cargaHorariaModular
--			, @nomeCursoModular			
			
--			, @PublicoAlvo
--			, @descricaoInstalacoes
--			, @descricaoEquipamentos
--			, @descricaoMaterialBibliografico
--			, @justificativaCurso
--			, @objetivosCurso
--			, @minutaEdital
--			, @formasAvaliacao
--			, @caracteristicasMonografiaTcc
--			, @notaMinimaAprovacao
--			, @frequenciaMinimaAprovacao
--			, @financiamentoCurso
--			, @termoConvenio
--			, @tipoFinanciamentoUID
--			, @tipoGestaoFinanceiraUID
--			, @planoAplicacaoSuperavit
--			, @QuantidadeEgresso
--			, @QuantidadeVagas
--			, @DataDocumentoRealizacaoCurso
--			, @DocumentoRealizacaoCurso
--			, @VinculoCursoGraduacao
--			, @SigaCodCurso
--			, @CEP
--			, @MunicipioEnderecoUID
--			, @IdentificacaoEndereco
--			, @NumeroEndereco
--			, @ComplementoBairro
--			, @BairroEndereco
--			, @InformacoesReferenciaEndereco
--			, @CNPqSubAreaConhecimentoUID
			
--			)

--		SET @ProjetoCursoUID_Saida = IDENT_CURRENT('Sipgl.ProjetoCurso')
		
--		END
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE.
--	IF @Operacao = 2
--	BEGIN
--		-- Verifica se projetoCursoUID informado para atualização existe na tabela de Sipgl.ProjetoCurso,
--		-- se não exitir, dispara mensagem de erro.	
--		IF NOT EXISTS(SELECT projetoCursoUID
--						FROM Sipgl.ProjetoCurso
--					   WHERE projetoCursoUID = @ProjetoCursoUID) 
--			RAISERROR('Registro de projeto de curso não foi encontrado na base de dados.',16,1)

--		BEGIN
--			-- Atulaliza dados na tabela Sipgl.ProjetoCurso referente ao registro projetoCursoUID informado.
--			UPDATE Sipgl.ProjetoCurso
--			   SET tipoModalidadeUID = @TipoModalidadeUID
--				  ,nomeCurso = @NomeCurso
--				  ,proponenteUnidadeUID = @ProponenteUnidadeUID
--				  ,CNPqAreaConhecimentoUID = @CNPqAreaConhecimentoUID
--				  ,email = @Email
--				  ,telefone = @Telefone
--				  ,fax = @Fax
--				  ,siteCurso = @SiteCurso
--				  ,coordenadorServidorUID = @CoordenadorServidorUID
				  
--				, titulacaoCoordenadorUID = @titulacaoCoordenadorUID
--				, regimeTrabalhoCoordenadorUID = @regimeTrabalhoCoordenadorUID
--				, telefoneResidencialCoordenador = @telefoneResidencialCoordenador
--				, telefoneCelularCoordenador = @telefoneCelularCoordenador
--				, emailCoordenador = @emailCoordenador	
				  
				  
--				  ,viceCoordenadorServidorUID = @viceCoordenadorServidorUID
				  
--				, titulacaoViceCoordenadorUID = @titulacaoViceCoordenadorUID
--				, regimeTrabalhoViceCoordenadorUID = @regimeTrabalhoViceCoordenadorUID
--				, telefoneResidencialViceCoordenador = @telefoneResidencialViceCoordenador
--				, telefoneCelularViceCoordenador = @telefoneCelularViceCoordenador
--				, emailViceCoordenador = @emailViceCoordenador				  
				  
				  
--				  ,realizacaoDataInicio = @RealizacaoDataInicio
--				  ,realizacaoDataTermino = @realizacaoDataTermino
--				  ,cargaHorariaTotal = @CargaHorariaTotal
				  
--			  	, turnoOfertaUID= @turnoOfertaUID
--			  	, periodicidadeUID = @periodicidadeUID
--				, cargaHorariaDiario = @cargaHorariaDiario
--				, cargaHorariaModular = @cargaHorariaModular
--				, nomeCursoModular	 = @nomeCursoModular		
				  
--				  ,publicoAlvo = @PublicoAlvo
--				  ,descricaoInstalacoes = @DescricaoInstalacoes
--				  ,descricaoEquipamentos = @DescricaoEquipamentos
--				  ,descricaoMaterialBibliografico = @DescricaoMaterialBibliografico
--				  ,justificativaCurso = @JustificativaCurso
--				  ,objetivosCurso = @ObjetivosCurso
--				  ,minutaEdital = @MinutaEdital
--				  ,formasAvaliacao = @FormasAvaliacao
--				  ,caracteristicasMonografiaTcc = @CaracteristicasMonografiaTcc
--				  ,notaMinimaAprovacao = @NotaMinimaAprovacao
--				  ,frequenciaMinimaAprovacao = @FrequenciaMinimaAprovacao
--				  ,financiamentoCurso = @FinanciamentoCurso
--				  ,termoConvenio = @TermoConvenio
--				  ,tipoFinanciamentoUID = @TipoFinanciamentoUID
--				  ,tipoGestaoFinanceiraUID = @TipoGestaoFinanceiraUID
--				  ,planoAplicacaoSuperavit = @PlanoAplicacaoSuperavit
--				  ,quantidadeEgresso= @QuantidadeEgresso
--				  ,quantidadeVagas = @QuantidadeVagas
--				  ,dataDocumentoRealizacaoCurso = @DataDocumentoRealizacaoCurso
--				  ,documentoRealizacaoCurso = @DocumentoRealizacaoCurso
--				  ,vinculoCursoGraduacao = @VinculoCursoGraduacao
--				  ,sigaCodCurso = @SigaCodCurso
--				  ,CEP = @CEP
--				  ,municipioEnderecoUID = @MunicipioEnderecoUID
--				  ,IdentificacaoEndereco = @IdentificacaoEndereco
--				  ,numeroEndereco = @NumeroEndereco
--				  ,complementoBairro = @ComplementoBairro
--				  ,bairroEndereco = @BairroEndereco
--				  ,InformacoesReferenciaEndereco = @InformacoesReferenciaEndereco
--				  ,CNPqSubAreaConhecimentoUID = @CNPqSubAreaConhecimentoUID
				  
				  
--			 WHERE projetoCursoUID = @ProjetoCursoUID
--		END
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 3
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCorpoDocente (servidorUID)

--		VALUES (@ServidorUID)

--	END
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 4
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCorpoDocente
--		 WHERE projetoCorpoDocenteUID = @ProjetocorpoDocenteUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 5
--	BEGIN

--		INSERT INTO Sipgl.ProjetoColegiadoCurso (projetoCursoUID, servidorUID, tipoMembroColegiadoUID)

--		VALUES (@projetoCursoUID, @ServidorUID, @TipoMembroColegiadoUID)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 6
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoColegiadoCurso
--		   SET tipoMembroColegiadoUID = @TipoMembroColegiadoUID
--		 WHERE projetoColegiadoCursoUID = @ProjetoColegiadoCursoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 7
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoColegiadoCurso
--		 WHERE projetoColegiadoCursoUID = @ProjetoColegiadoCursoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 8
--	BEGIN

--		INSERT INTO Sipgl.ProjetoBolsaEstagioLei_11788_2008 (projetoCursoUID, pessoaUID, quantidade, valorUnitario)

--		VALUES (@projetoCursoUID, @PessoaUID, @Quantidade, @ValorUnitario)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 9
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoBolsaEstagioLei_11788_2008
--		   SET quantidade = @Quantidade
--			  ,valorUnitario = @ValorUnitario
--		 WHERE projetoBolsaEstagioLei_11788_2008_UID = @ProjetoBolsaEstagioLei_11788_2008
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 10
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoBolsaEstagioLei_11788_2008
--		 WHERE projetoBolsaEstagioLei_11788_2008_UID = @ProjetoBolsaEstagioLei_11788_2008
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 11
--	BEGIN

--		INSERT INTO Sipgl.ProjetoBolsaoLei_8958_94 (projetoCursoUID, servidorUID, atividadeNaoRegular, dataInicio, dataFim, cargaHorariaMensal, cargaHoraiaTotal, valorUnitarioCargaHoraria)

--		VALUES (@ProjetoCursoUID, @PessoaUID, @AtividadeNaoRegular, @DataInicio, @DataFim, @CargaHorariaMensal, @CargaHoraiaTotal, @ValorUnitarioCargaHoraria)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 12
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoBolsaoLei_8958_94
--		   SET atividadeNaoRegular = @AtividadeNaoRegular
--			  ,dataInicio = @DataInicio
--			  ,dataFim = @DataFim
--			  ,cargaHorariaMensal = @CargaHorariaMensal
--			  ,cargaHoraiaTotal = @CargaHoraiaTotal
--			  ,valorUnitarioCargaHoraria = @ValorUnitarioCargaHoraria
--		 WHERE ProjetoBolsaoLei_8958_94_UID = @ProjetoBolsaoLei_8958_94_UID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 13
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoBolsaoLei_8958_94
--		 WHERE ProjetoBolsaoLei_8958_94_UID = @ProjetoBolsaoLei_8958_94_UID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 14
--	BEGIN

--		INSERT INTO Sipgl.ProjetoMaterialPermanente (projetoCursoUID, tipoMaterialPemanenteUID, quantidade, valorUnitario)

--		VALUES (@ProjetoCursoUID, @TipoMaterialPemanenteUID, @QuantidadeMaterialPermanente, @ValorUnitarioMaterialPermanente)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 15
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoMaterialPermanente
--		   SET quantidade = @QuantidadeMaterialPermanente
--			  ,valorUnitario = @ValorUnitarioMaterialPermanente
--		 WHERE projetoMaterialPermanenteUID = @ProjetoMaterialPermanenteUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 16
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoMaterialPermanente
--		 WHERE projetoMaterialPermanenteUID = @ProjetoMaterialPermanenteUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 17
--	BEGIN

--		INSERT INTO Sipgl.ProjetoObras (projetoCursoUID, tipoObraUID, quantidade, valorUnitario)

--		VALUES (@ProjetoCursoUID, @TipoObraUID, @QuantidadeObra, @ValorUnitarioObra)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 18
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoObras
--		   SET quantidade = @QuantidadeObra
--			  ,valorUnitario = @ValorUnitarioObra
--		 WHERE projetoObrasUID = @ProjetoObrasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 19
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoObras
--		 WHERE projetoObrasUID = @ProjetoObrasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 20
--	BEGIN

--		INSERT INTO Sipgl.ProjetoDisciplina (nome, cargaHoraria, dataInicio, dataTermino, ementa, bibliografia)

--		VALUES (@NomeDisciplina, @CargaHorariaDisciplina, @DataInicioDisciplina, @DataTerminoDisciplina, @Ementa, @Bibliografia)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 21
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoDisciplina
--		   SET nome = @NomeDisciplina
--			  ,cargaHoraria = @CargaHorariaDisciplina
--			  ,dataInicio = @DataInicioDisciplina
--			  ,dataTermino = @DataTerminoDisciplina
--			  ,ementa = @Ementa
--			  ,bibliografia = @Bibliografia
--		 WHERE projetoDisciplinaUID = @projetoDisciplinaUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 22
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoDisciplina
--		 WHERE projetoDisciplinaUID = @ProjetoDisciplinaUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 23
--	BEGIN

--		INSERT INTO Sipgl.ProjetoDiarias (projetoCursoUID, pessoaUID, municipioUID, dataInicio, dataFim, quantidade, valorUnitario)

--		VALUES (@ProjetoCursoUID, @PessoaUID, @MunicipioUID, @DataInicioDiarias, @DataFimDiarias, @QuantidadeDiarias, @ValorUnitarioDiarias)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 24
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoDiarias
--		   SET municipioUID = @MunicipioUID
--		      ,dataInicio = @DataInicioDiarias
--		      ,dataFim = @DataFimDiarias
--		      ,quantidade = @QuantidadeDiarias
--		      ,valorUnitario = @ValorUnitarioDiarias
--		 WHERE projetoDiariasUID = @ProjetoDiariasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 25
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoDiarias
--		 WHERE projetoDiariasUID = @ProjetoDiariasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 26
--	BEGIN

--		INSERT INTO Sipgl.ProjetoMaterialConsumo (projetoCursoUID, tipoMaterialConsumoUID, quantidade, valorUnitario)

--		VALUES (@ProjetoCursoUID, @TipoMaterialConsumoUID, @QuantidadeMaterialConsumo, @ValorUnitarioMaterialConsumo)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 27
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoMaterialConsumo
--		   SET quantidade = @QuantidadeMaterialConsumo
--			  ,valorUnitario = @ValorUnitarioMaterialConsumo
--		 WHERE projetoMaterialConsumoUID = @ProjetoMaterialConsumoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 28
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoMaterialConsumo
--		 WHERE projetoMaterialConsumoUID = @ProjetoMaterialConsumoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 29
--	BEGIN

--		INSERT INTO Sipgl.ProjetoPassagens (projetoCursoUID, pessoaUID, tipoPassagemUID, trecho, quantidade, valorUnitario)

--			 VALUES (@ProjetoCursoUID, @PessoaUID, @TipoPassagemUID, @Trecho, @QuantidadePassagens, @ValorUnitarioPassagens)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 30
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoPassagens
--		   SET pessoaUID = @PessoaUID
--			  ,tipoPassagemUID = @TipoPassagemUID
--			  ,trecho = @Trecho
--			  ,quantidade = @QuantidadePassagens
--			  ,valorUnitario = @ValorUnitarioPassagens
--		 WHERE projetoPassagensUID = @ProjetoPassagensUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 31
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoPassagens
--		 WHERE projetoPassagensUID = @ProjetoPassagensUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 32
--	BEGIN

--		INSERT INTO Sipgl.ProjetoEquipamento (projetoCursoUID, tipoEquipamentoUID, quantidade, valorUnitario)

--			 VALUES (@ProjetoCursoUID, @TipoEquipamentoUID, @QuantidadeEquipamentos, @ValorUnitarioEquipamentos)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 33
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoEquipamento
--		   SET tipoEquipamentoUID = @TipoEquipamentoUID
--			  ,quantidade = @QuantidadeEquipamentos
--			  ,valorUnitario = @ValorUnitarioEquipamentos
--		 WHERE projetoEquipamentoUID = @ProjetoEquipamentoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 34
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoEquipamento
--		 WHERE projetoEquipamentoUID = @ProjetoEquipamentoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 35
--	BEGIN

--		INSERT INTO Sipgl.ProjetoPessoalEncargos (projetoCursoUID, pessoaUID, tipoAtividadeUID, dataInicio, dataFim, valorMensal)

--			 VALUES (@ProjetoCursoUID, @PessoaUID, @TipoAtividadeUID, @DataInicioPessoalEncargos, @DataFimPessoalEncargos, @ValorMensalPessoalEncargos)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 36
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoPessoalEncargos
--		   SET pessoaUID = @PessoaUID
--			  ,tipoAtividadeUID = @TipoAtividadeUID
--			  ,dataInicio = @DataInicioPessoalEncargos
--			  ,dataFim = @DataFimPessoalEncargos
--			  ,valorMensal = @ValorMensalPessoalEncargos
--		 WHERE projetoPessoalEncargosUID = @ProjetoPessoalEncargosUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 37
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoPessoalEncargos
--		 WHERE projetoPessoalEncargosUID = @ProjetoPessoalEncargosUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 38
--	BEGIN

--		INSERT INTO Sipgl.ProjetoDespesas (projetoCursoUID, pessoaUID, tipoDespesaUID, quantidade, valorUnitario)

--			 VALUES (@ProjetoCursoUID, @PessoaUID, @TipoDespesaUID, @QuantidadeDespesa, @ValorUnitarioDespesa)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 39
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoDespesas
--		   SET pessoaUID = @PessoaUID
--			  ,tipoDespesaUID = @TipoDespesaUID
--			  ,quantidade = @QuantidadeDespesa
--			  ,valorUnitario = @ValorUnitarioDespesa
--		 WHERE projetoDespesasUID = @ProjetoDespesasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 40
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoDespesas
--		 WHERE projetoDespesasUID = @ProjetoDespesasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 41
--	BEGIN

--		INSERT INTO Sipgl.ProjetoPrevisaoReceitas (projetoCursoUID, tipoReceitaUID, numeroAlunos, numeroParcelas, valorUnitario)

--			 VALUES (@ProjetoCursoUID, @TipoReceitaUID, @NumeroAlunos, @NumeroParcelas, @ValorUnitarioPrevisaoReceita)
		

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 42
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoPrevisaoReceitas
--		   SET tipoReceitaUID = @TipoReceitaUID
--			  ,numeroAlunos = @NumeroAlunos
--			  ,numeroParcelas = @NumeroParcelas
--			  ,valorUnitario = @ValorUnitarioPrevisaoReceita
--		 WHERE projetoPrevisaoReceitasUID = @ProjetoPrevisaoReceitasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 43
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoPrevisaoReceitas
--		 WHERE projetoPrevisaoReceitasUID = @ProjetoPrevisaoReceitasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 44
--	BEGIN

--		INSERT INTO Sipgl.ProjetoServicoTerceirosPessoJuridica (projetoCursoUID, tipoServicoTerceirosPessoaJuridicaUID, quantidade, valorUnitario)

--			 VALUES (@ProjetoCursoUID, @TipoServicoTerceirosPessoaJuridicaUID, @QuantidadeServicoTerceirosPJ, @ValorUnitarioServicoTerceirosPJ)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 45
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoServicoTerceirosPessoJuridica
--		   SET tipoServicoTerceirosPessoaJuridicaUID = @TipoServicoTerceirosPessoaJuridicaUID
--			  ,quantidade = @QuantidadeServicoTerceirosPJ
--			  ,valorUnitario = @ValorUnitarioServicoTerceirosPJ
--		 WHERE tipoServicoTerceirosPessoaJuridicaUID = @TipoServicoTerceirosPessoaJuridicaUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 46
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoServicoTerceirosPessoJuridica
--		 WHERE tipoServicoTerceirosPessoaJuridicaUID = @TipoServicoTerceirosPessoaJuridicaUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 47
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCursoComplementoPresencial (projetoCursoUID, tipoTurnoOfertaUID, tipoPeriodicidadeUID, cargaHorariaPeriodicidade, enderecoUID)

--			 VALUES (@ProjetoCursoUID, @TipoTurnoOfertaUID, @TipoPeriodicidadeUID, @cargaHorariaPeriodicidade, @EnderecoUID)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 48
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoCursoComplementoPresencial
--		   SET tipoTurnoOfertaUID = @TipoTurnoOfertaUID
--			  ,tipoPeriodicidadeUID = @TipoPeriodicidadeUID
--			  ,cargaHorariaPeriodicidade = @cargaHorariaPeriodicidade
--			  ,enderecoUID = @EnderecoUID
--		 WHERE projetoCursoComplementoPresencialUID = @ProjetoCursoComplementoPresencialUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 49
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCursoComplementoPresencial
--		 WHERE projetoCursoComplementoPresencialUID = @ProjetoCursoComplementoPresencialUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 50
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCursoVagas (numeroVagas, tipoVagasUID)

--			 VALUES (@NumeroVagas, @TipoVagasUID)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 51
--	BEGIN

--		-- 
--		UPDATE Sipgl.ProjetoCursoVagas
--		   SET numeroVagas = @NumeroVagas
--			  ,tipoVagasUID = @TipoVagasUID
--		 WHERE projetoCursoVagasUID = @ProjetoCursoVagasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 52
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCursoVagas
--		 WHERE projetoCursoVagasUID = @ProjetoCursoVagasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 53
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCursoComplementoPresencialVagas (projetoCursoComplementoPresencialUID, projetoCursoVagasUID)

--			 VALUES (@ProjetoCursoComplementoPresencialUID, @ProjetoCursoVagasUID)

--	END

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 54
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCursoComplementoPresencialVagas
--		 WHERE projetoCursoComplementoPresencialVagasUID = @ProjetoCursoComplementoPresencialVagasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 55
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCursoComplementoEad (projetoCursoUID, descricaoMaterialDidaticoTextualMultimidia, descricaoAmbienteVirtualAprendizagem, dataInicioInscricao
--													 ,dataFimInscricao, dataInicioSelecao, dataFimSelecao, dataInicioMatricula, dataFimMatricula, dataPrevisaoInicioAulas
--													 ,criteriosSelecao, criteriosComprovacaoCarenciaFinanceira, descricaoSelecaoCandidatos, procedimentoRecursoAdm
--													 ,procedimentoDivulgacaoResultadoFinal, orientacoesProcedimentoMatricula, procedimentoRealizacaoSegundaChamada)

--			 VALUES (@ProjetoCursoUID, @DescricaoMaterialDidaticoTextualMultimidia, @DescricaoAmbienteVirtualAprendizagem, @DataInicioInscricao
--					,@DataFimInscricao, @DataInicioSelecao, @DataFimSelecao, @DataInicioMatricula, @DataFimMatricula, @DataPrevisaoInicioAulas
--					,@CriteriosSelecao, @criteriosComprovacaoCarenciaFinanceira, @descricaoSelecaoCandidatos, @ProcedimentoRecursoAdm
--					,@ProcedimentoDivulgacaoResultadoFinal, @OrientacoesProcedimentoMatricula, @ProcedimentoRealizacaoSegundaChamada)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 56
--	BEGIN
--		-- 
--		UPDATE Sipgl.ProjetoCursoComplementoEad
--		   SET descricaoMaterialDidaticoTextualMultimidia = @DescricaoMaterialDidaticoTextualMultimidia
--			  ,descricaoAmbienteVirtualAprendizagem = @DescricaoAmbienteVirtualAprendizagem
--			  ,dataInicioInscricao = @DataInicioInscricao
--			  ,dataFimInscricao = @DataFimInscricao
--			  ,dataInicioSelecao = @DataInicioSelecao
--			  ,dataFimSelecao = @DataFimSelecao
--			  ,dataInicioMatricula = @DataInicioMatricula
--			  ,dataFimMatricula = @DataFimMatricula
--			  ,dataPrevisaoInicioAulas = @DataPrevisaoInicioAulas
--			  ,criteriosSelecao = @CriteriosSelecao
--			  ,criteriosComprovacaoCarenciaFinanceira = @CriteriosComprovacaoCarenciaFinanceira
--			  ,descricaoSelecaoCandidatos = @DescricaoSelecaoCandidatos
--			  ,procedimentoRecursoAdm = @ProcedimentoRecursoAdm
--			  ,procedimentoDivulgacaoResultadoFinal = @ProcedimentoDivulgacaoResultadoFinal
--			  ,orientacoesProcedimentoMatricula = @OrientacoesProcedimentoMatricula
--			  ,procedimentoRealizacaoSegundaChamada = @ProcedimentoRealizacaoSegundaChamada
--		 WHERE projetoCursoComplementoEadUID = @ProjetoCursoComplementoEadUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 57
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCursoComplementoEad
--		 WHERE projetoCursoComplementoEadUID = @ProjetoCursoComplementoEadUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 58
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad (projetoCursoComplementoEadUID, servidorUID, descricaoMaterial, projetoDisciplinaUID)

--			 VALUES (@ProjetoCursoComplementoEadUID, @ServidorUID, @DescricaoMaterial, @ProjetoDisciplinaUID)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 59
--	BEGIN
--		-- 
--		UPDATE Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad
--		   SET servidorUID = @ServidorUID
--		      ,descricaoMaterial = @DescricaoMaterial
--		      ,projetoDisciplinaUID = @ProjetoDisciplinaUID
--		 WHERE projetoCorpoDocenteMaterialDidaticoEadUID = @ProjetoCorpoDocenteMaterialDidaticoEadUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 60
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCorpoDocenteMaterialDidaticoEad
--		 WHERE projetoCorpoDocenteMaterialDidaticoEadUID = @ProjetoCorpoDocenteMaterialDidaticoEadUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 61
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCursoComplementoEadEndereco (projetoCursoComplementoEadUID, enderecoUID, tipoEnderecoEadUID)

--			 VALUES (@ProjetoCursoComplementoEadUID, @EnderecoUID, @TipoEnderecoEadUID)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 62
--	BEGIN
--		-- 
--		UPDATE Sipgl.ProjetoCursoComplementoEadEndereco
--		   SET tipoEnderecoEadUID = @TipoEnderecoEadUID
--		 WHERE projetoCursoComplementoEadEnderecoUID = @ProjetoCursoComplementoEadEnderecoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 63
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCursoComplementoEadEndereco
--		 WHERE projetoCursoComplementoEadEnderecoUID = @ProjetoCursoComplementoEadEnderecoUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/

--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 64
--	BEGIN

--		INSERT INTO Sipgl.ProjetoCursoComplementoEadVagas (projetoCursoComplementoEadUID, projetoCursoVagasUID, poloEadEnderecoUID)

--			 VALUES (@ProjetoCursoComplementoEadUID, @ProjetoCursoVagasUID, @PoloEadEnderecoUID)

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 65
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoCursoComplementoEadVagas
--		 WHERE projetoCursoComplementoEadVagasUID = @ProjetoCursoComplementoEadVagasUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/



--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- INSERE UM NOVO REGISTRO
	
--	IF @Operacao = 66
--	BEGIN

--		INSERT INTO Sipgl.ProjetoServicoTerceirosPessoaFisica 
--		(  
--					projetoCursoUID
--				   ,pessoaUID
--				   ,atividadeNaoRegular
--				   ,dataInicio
--				   ,dataFim
--				   ,cargaHorariaMensal
--				   ,cargaHorariaTotal
--				   ,valorUnitarioCargaHoraria
--				   ,encargosSociais
           
--           )

--			 VALUES (
--				   @ProjetoCursoUID
--				 , @PessoaUID  
--				 , @AtividadeNaoRegularServicoTerceirosPF
--				 , @DataInicioServicoTerceirosPF
--				 , @DataFimServicoTerceirosPF
--				 , @CargaHorariaMensalSevicoTerceirosPF
--				 , @CargaHorariaTotalServicoTerceirosPF
--				 , @ValorUnitarioCargaHorariaServicoTerceirosPF
--				 , @EncargosSociaisServicoTerceirosPF
--			 )

--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- ALTERA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 67
--	BEGIN
--		-- 
--		UPDATE Sipgl.ProjetoServicoTerceirosPessoaFisica
--		   SET 
--			   projetoCursoUID = @ProjetoCursoUID
--			  ,pessoaUID = @PessoaUID
--			  ,atividadeNaoRegular = @AtividadeNaoRegularServicoTerceirosPF
--			  ,dataInicio = @DataInicioServicoTerceirosPF
--			  ,dataFim = @DataFimServicoTerceirosPF
--			  ,cargaHorariaMensal = @CargaHorariaMensalSevicoTerceirosPF
--			  ,cargaHorariaTotal = @CargaHorariaTotalServicoTerceirosPF
--			  ,valorUnitarioCargaHoraria = @ValorUnitarioCargaHorariaServicoTerceirosPF
--			  ,encargosSociais = @EncargosSociaisServicoTerceirosPF
--		WHERE projetoServicoTerceirosPessoaFisicaUID = @ProjetoServicoTerceirosPessoFisicaUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/
--	-- DELETA UM REGISTRO JÁ EXISTENTE
	
--	IF @Operacao = 68
--	BEGIN

--		-- 
--		DELETE FROM Sipgl.ProjetoServicoTerceirosPessoaFisica
--		 WHERE projetoServicoTerceirosPessoaFisicaUID = @ProjetoServicoTerceirosPessoFisicaUID
--	END
--/*###############################################################################################################*/
--/*###############################################################################################################*/






--END TRY

--BEGIN CATCH

--IF @@TRANCOUNT > 0
--	ROLLBACK TRANSACTION

--EXEC Sipgl.ProcedureRetornarInformacaoErro @MensagemErro OUTPUT
--SET @ErroSaida = @MensagemErro

--END CATCH

--IF @@TRANCOUNT > 0
--	COMMIT TRANSACTION


