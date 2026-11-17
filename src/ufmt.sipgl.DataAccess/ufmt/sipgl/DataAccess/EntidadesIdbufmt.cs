using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;

namespace ufmt.sipgl.DataAccess;

public class EntidadesIdbufmt : DbContext
{
	public DbSet<ControleCodigoCurso> ControleCodigoCurso { get; set; }

	public DbSet<ControleEnvioEmail> ControleEnvioEmail { get; set; }

	public DbSet<ControleNumeroInscricao> ControleNumeroInscricao { get; set; }

	public DbSet<ControleRegistroDiscente> ControleRegistroDiscente { get; set; }

	public DbSet<Coordenador> Coordenador { get; set; }

	public DbSet<CorrecaoCurso> CorrecaoCurso { get; set; }

	public DbSet<CorrecaoCursoMensagens> CorrecaoCursoMensagens { get; set; }

	public DbSet<CorrecaoPreMatriculaInscricao> CorrecaoPreMatriculaInscricao { get; set; }

	public DbSet<Curso> Curso { get; set; }

	public DbSet<Discente> Discente { get; set; }

	public DbSet<Disciplina> Disciplina { get; set; }

	public DbSet<Docencia> Docencia { get; set; }

	public DbSet<EnderecoFuncionamentoCurso> EnderecoFuncionamentoCurso { get; set; }

	public DbSet<Especialidade> Especialidade { get; set; }

	public DbSet<EspecialidadeDisciplina> EspecialidadeDisciplina { get; set; }

	public DbSet<EstruturaCurricular> EstruturaCurricular { get; set; }

	public DbSet<Historico> Historico { get; set; }

	public DbSet<Horario> Horario { get; set; }

	public DbSet<ProjetoBolsaEstagioLei_11788_2008> ProjetoBolsaEstagioLei_11788_2008 { get; set; }

	public DbSet<ProjetoBolsaoLei_8958_94> ProjetoBolsaoLei_8958_94 { get; set; }

	public DbSet<ProjetoColegiadoCurso> ProjetoColegiadoCurso { get; set; }

	public DbSet<ProjetoControleCodigo> ProjetoControleCodigo { get; set; }

	public DbSet<ProjetoCursoComplementoEad> ProjetoCursoComplementoEad { get; set; }

	public DbSet<ProjetoCursoComplementoEadEndereco> ProjetoCursoComplementoEadEndereco { get; set; }

	public DbSet<ProjetoCursoComplementoEadVagas> ProjetoCursoComplementoEadVagas { get; set; }

	public DbSet<ProjetoCursoComplementoPresencial> ProjetoCursoComplementoPresencial { get; set; }

	public DbSet<ProjetoCursoComplementoPresencialVagas> ProjetoCursoComplementoPresencialVagas { get; set; }

	public DbSet<ProjetoCursoVagas> ProjetoCursoVagas { get; set; }

	public DbSet<ProjetoDespesas> ProjetoDespesas { get; set; }

	public DbSet<ProjetoDiarias> ProjetoDiarias { get; set; }

	public DbSet<ProjetoEquipamento> ProjetoEquipamento { get; set; }

	public DbSet<ProjetoInstalacao> ProjetoInstalacao { get; set; }

	public DbSet<ProjetoMaterialConsumo> ProjetoMaterialConsumo { get; set; }

	public DbSet<ProjetoMaterialPermanente> ProjetoMaterialPermanente { get; set; }

	public DbSet<ProjetoObras> ProjetoObras { get; set; }

	public DbSet<ProjetoPassagens> ProjetoPassagens { get; set; }

	public DbSet<ProjetoPessoalEncargos> ProjetoPessoalEncargos { get; set; }

	public DbSet<ProjetoPrevisaoReceitas> ProjetoPrevisaoReceitas { get; set; }

	public DbSet<ProjetoServicoTerceirosPessoaFisica> ProjetoServicoTerceirosPessoaFisica { get; set; }

	public DbSet<ProjetoServicoTerceirosPessoJuridica> ProjetoServicoTerceirosPessoJuridica { get; set; }

	public DbSet<TipoAtividade> TipoAtividade { get; set; }

	public DbSet<TipoCoordenador> TipoCoordenador { get; set; }

	public DbSet<TipoDespesa> TipoDespesa { get; set; }

	public DbSet<TipoEnderecoEad> TipoEnderecoEad { get; set; }

	public DbSet<TipoEquipamento> TipoEquipamento { get; set; }

	public DbSet<TipoEspecialidade> TipoEspecialidade { get; set; }

	public DbSet<TipoFinanciamento> TipoFinanciamento { get; set; }

	public DbSet<TipoFormaIngresso> TipoFormaIngresso { get; set; }

	public DbSet<TipoGestaoFinanceira> TipoGestaoFinanceira { get; set; }

	public DbSet<TipoInstalacao> TipoInstalacao { get; set; }

	public DbSet<TipoMaterialConsumo> TipoMaterialConsumo { get; set; }

	public DbSet<TipoMaterialPermanente> TipoMaterialPermanente { get; set; }

	public DbSet<TipoMembroColegiadoCurso> TipoMembroColegiadoCurso { get; set; }

	public DbSet<TipoObra> TipoObra { get; set; }

	public DbSet<TipoPassagem> TipoPassagem { get; set; }

	public DbSet<TipoPeriodicidade> TipoPeriodicidade { get; set; }

	public DbSet<TipoPeriodoIngresso> TipoPeriodoIngresso { get; set; }

	public DbSet<TipoReceita> TipoReceita { get; set; }

	public DbSet<TipoReservaVagas> TipoReservaVagas { get; set; }

	public DbSet<TipoServicoTerceirosPessoaJuridica> TipoServicoTerceirosPessoaJuridica { get; set; }

	public DbSet<TipoSituacaoInscricao> TipoSituacaoInscricao { get; set; }

	public DbSet<TipoSolicitanteCorrecaoCurso> TipoSolicitanteCorrecaoCurso { get; set; }

	public DbSet<TipoStatusCurso> TipoStatusCurso { get; set; }

	public DbSet<TipoStatusHomologacao> TipoStatusHomologacao { get; set; }

	public DbSet<TipoVagas> TipoVagas { get; set; }

	public DbSet<TurmaDisciplina> TurmaDisciplina { get; set; }

	public DbSet<ViewCNPqSubAreaConhecimento> ViewCNPqSubAreaConhecimento { get; set; }

	public DbSet<ViewCurso> ViewCurso { get; set; }

	public DbSet<ViewInstituicaoEnsinoSuperior> ViewInstituicaoEnsinoSuperior { get; set; }

	public DbSet<ViewProjetoCursoEAD> ViewProjetoCursoEAD { get; set; }

	public DbSet<ViewProjetoCursoPresencial> ViewProjetoCursoPresencial { get; set; }

	public DbSet<ViewRelatorioGeralCoodenadores> ViewRelatorioGeralCoodenadores { get; set; }

	public DbSet<ViewRelatorioGeralCursos> ViewRelatorioGeralCursos { get; set; }

	public DbSet<ViewUnidade> ViewUnidade { get; set; }

	public DbSet<TipoModalidade> TipoModalidade { get; set; }

	public DbSet<Campus> Campus { get; set; }

	public DbSet<CNPqAreaConhecimento> CNPqAreaConhecimento { get; set; }

	public DbSet<CNPqGrandeAreaConhecimento> CNPqGrandeAreaConhecimento { get; set; }

	public DbSet<CNPqSubAreaConhecimento> CNPqSubAreaConhecimento { get; set; }

	public DbSet<Municipio> Municipio { get; set; }

	public DbSet<TipoEstadoCivil> TipoEstadoCivil { get; set; }

	public DbSet<TipoInstituicaoEnsino> TipoInstituicaoEnsino { get; set; }

	public DbSet<TipoCorRaca> TipoCorRaca { get; set; }

	public DbSet<Pais> Pais { get; set; }

	public DbSet<TipoFaixaRendaFamiliar> TipoFaixaRendaFamiliar { get; set; }

	public DbSet<UF> UF { get; set; }

	public DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }

	public DbSet<ViewDadosCursoSiga> ViewDadosCursoSiga { get; set; }

	public DbSet<GetDiretorUnidade> GetDiretorUnidade { get; set; }

	public DbSet<ViewMunicipio> ViewMunicipio { get; set; }

	public DbSet<ViewCandidatoCoordenador> ViewCandidatoCoordenador { get; set; }

	public DbSet<PessoaIDBUFMT> PessoaIDBUFMT { get; set; }

	public DbSet<ServidorIDBUFMT> ServidorIDBUFMT { get; set; }

	public DbSet<TipoNecessidadeEspecial> TipoNecessidadeEspecial { get; set; }

	public DbSet<TipoOrgaoExpedidorRg> TipoOrgaoExpedidorRg { get; set; }

	public DbSet<ProjetoCorpoDocenteMaterialDidaticoEad> ProjetoCorpoDocenteMaterialDidaticoEad { get; set; }

	public DbSet<ProjetoEstruturaCurricular> ProjetoEstruturaCurricular { get; set; }

	public DbSet<ProjetoHistorico> ProjetoHistorico { get; set; }

	public DbSet<ProjetoHorario> ProjetoHorario { get; set; }

	public DbSet<ProjetoTurmaPolo> ProjetoTurmaPolo { get; set; }

	public DbSet<ViewPreMatriculaInscricaoOcorrencia> ViewPreMatriculaInscricaoOcorrencia { get; set; }

	public DbSet<ViewProjetoTurmaPolo> ViewProjetoTurmaPolo { get; set; }

	public DbSet<EnderecoPoloApoioPresencialEAD> EnderecoPoloApoioPresencialEAD { get; set; }

	public DbSet<ViewEnderecoPoloEAD> ViewEnderecoPoloEAD { get; set; }

	public DbSet<ProjetoEncontroPresencial> ProjetoEncontroPresencial { get; set; }

	public DbSet<ViewProjetoEncontroPresencial> ViewProjetoEncontroPresencial { get; set; }

	public DbSet<ProjetoFrequencia> ProjetoFrequencia { get; set; }

	public DbSet<ProjetoDiscente> ProjetoDiscente { get; set; }

	public DbSet<PreMatriculaInscricao> PreMatriculaInscricao { get; set; }

	public DbSet<ViewPreMatriculaInscricaoTurma> ViewPreMatriculaInscricaoTurma { get; set; }

	public DbSet<ProjetoTurmaDisciplina> ProjetoTurmaDisciplina { get; set; }

	public DbSet<TipoTitulacao> TipoTitulacao { get; set; }

	public DbSet<ViewProjetoDocente> ViewProjetoDocente { get; set; }

	public DbSet<ProjetoTipoGraduacao> ProjetoTipoGraduacao { get; set; }

	public DbSet<ProjetoDisciplina> ProjetoDisciplina { get; set; }

	public DbSet<ProjetoNota> ProjetoNota { get; set; }

	public DbSet<ViewDocenteUFMT> ViewDocenteUFMT { get; set; }

	public DbSet<ProjetoCorpoDocente> ProjetoCorpoDocente { get; set; }

	public DbSet<Permissao> Permissao { get; set; }

	public DbSet<ProjetoPermissaoRecurso> ProjetoPermissaoRecurso { get; set; }

	public DbSet<ProjetoRecurso> ProjetoRecurso { get; set; }

	public DbSet<PreMatriculaInscricaoOcorrencia> PreMatriculaInscricaoOcorrencia { get; set; }

	public DbSet<ProjetoFrequenciaHistorico> ProjetoFrequenciaHistorico { get; set; }

	public DbSet<ProjetoNotaHistorico> ProjetoNotaHistorico { get; set; }

	public DbSet<ProjetoTurma> ProjetoTurma { get; set; }

	public DbSet<ViewProjetoCursoTurma> ViewProjetoCursoTurma { get; set; }

	public DbSet<ProjetoPreInscricao> ProjetoPreInscricao { get; set; }

	public DbSet<ViewPreMatriculaInscricao> ViewPreMatriculaInscricao { get; set; }

	public DbSet<PermissaoUsuario> PermissaoUsuario { get; set; }

	public DbSet<Usuario> Usuario { get; set; }

	public DbSet<ProjetoUsuarioUnidade> ProjetoUsuarioUnidade { get; set; }

	public DbSet<ViewCoordenadorUFMT> ViewCoordenadorUFMT { get; set; }

	public DbSet<ProjetoCurso> ProjetoCurso { get; set; }

	public DbSet<PreMatriculaPessoa> PreMatriculaPessoa { get; set; }

	public DbSet<ViewPreMatriculaPessoa> ViewPreMatriculaPessoa { get; set; }

	public EntidadesIdbufmt()
		: base("name=EntidadesIdbufmt")
	{
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}

	public virtual int ProcedureRetornarInformacaoErro(ObjectParameter mensagemErro)
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureRetornarInformacaoErro", new ObjectParameter[1] { mensagemErro });
	}

	public virtual int PocedureInserirCoordenador(long? cursoUID, long? servidorUID, byte? tipoCoordenadorUID)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		ObjectParameter val = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		ObjectParameter val2 = (servidorUID.HasValue ? new ObjectParameter("ServidorUID", (object)servidorUID) : new ObjectParameter("ServidorUID", typeof(long)));
		ObjectParameter val3 = (tipoCoordenadorUID.HasValue ? new ObjectParameter("TipoCoordenadorUID", (object)tipoCoordenadorUID) : new ObjectParameter("TipoCoordenadorUID", typeof(byte)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PocedureInserirCoordenador", new ObjectParameter[3] { val, val2, val3 });
	}

	public virtual int PocedureExcluirCoordenador(long? cursoUID, byte? tipoCoordenadorUID)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		ObjectParameter val = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		ObjectParameter val2 = (tipoCoordenadorUID.HasValue ? new ObjectParameter("TipoCoordenadorUID", (object)tipoCoordenadorUID) : new ObjectParameter("TipoCoordenadorUID", typeof(byte)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PocedureExcluirCoordenador", new ObjectParameter[2] { val, val2 });
	}

	public virtual int ProcedureGerarCodigoCurso(DateTime? dataResolucaoConsepe, ObjectParameter codigoCursoSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (dataResolucaoConsepe.HasValue ? new ObjectParameter("DataResolucaoConsepe", (object)dataResolucaoConsepe) : new ObjectParameter("DataResolucaoConsepe", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureGerarCodigoCurso", new ObjectParameter[2] { val, codigoCursoSaida });
	}

	public virtual int ProcedureInserirEditarCoordenador(long? cursoUID, long? coordenadorServidorUID, long? viceCoordenadorServidorUID)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		ObjectParameter val = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		ObjectParameter val2 = (coordenadorServidorUID.HasValue ? new ObjectParameter("CoordenadorServidorUID", (object)coordenadorServidorUID) : new ObjectParameter("CoordenadorServidorUID", typeof(long)));
		ObjectParameter val3 = (viceCoordenadorServidorUID.HasValue ? new ObjectParameter("ViceCoordenadorServidorUID", (object)viceCoordenadorServidorUID) : new ObjectParameter("ViceCoordenadorServidorUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureInserirEditarCoordenador", new ObjectParameter[3] { val, val2, val3 });
	}

	public virtual int ProcedureInserirEditarArea(long? areaUID, long? estruturaCurricularUID, string nome, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		ObjectParameter val = (areaUID.HasValue ? new ObjectParameter("AreaUID", (object)areaUID) : new ObjectParameter("AreaUID", typeof(long)));
		ObjectParameter val2 = (estruturaCurricularUID.HasValue ? new ObjectParameter("EstruturaCurricularUID", (object)estruturaCurricularUID) : new ObjectParameter("EstruturaCurricularUID", typeof(long)));
		ObjectParameter val3 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureInserirEditarArea", new ObjectParameter[4] { val, val2, val3, erroSaida });
	}

	public virtual int ProcedureExcluirCurso(long? cursoUID, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureExcluirCurso", new ObjectParameter[2] { val, erroSaida });
	}

	public virtual int ProcedureExcluirArea(long? areaUID, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (areaUID.HasValue ? new ObjectParameter("AreaUID", (object)areaUID) : new ObjectParameter("AreaUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureExcluirArea", new ObjectParameter[2] { val, erroSaida });
	}

	public virtual int ProcedureMaterPermissaoCoordenadorPROPG(byte? operacao, long? permissaoCoordenadorPROPGUID, string nome, string cpf, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		ObjectParameter val = (operacao.HasValue ? new ObjectParameter("Operacao", (object)operacao) : new ObjectParameter("Operacao", typeof(byte)));
		ObjectParameter val2 = (permissaoCoordenadorPROPGUID.HasValue ? new ObjectParameter("PermissaoCoordenadorPROPGUID", (object)permissaoCoordenadorPROPGUID) : new ObjectParameter("PermissaoCoordenadorPROPGUID", typeof(long)));
		ObjectParameter val3 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		ObjectParameter val4 = ((cpf != null) ? new ObjectParameter("Cpf", (object)cpf) : new ObjectParameter("Cpf", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureMaterPermissaoCoordenadorPROPG", new ObjectParameter[5] { val, val2, val3, val4, erroSaida });
	}

	public virtual int ProcedureHomologarCurso(long? cursoUID, byte? tipoSolicitanteCorrecaoCursoUID, string descricaoCorrecao, DateTime? dataHoraUltimaAtualizacao, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		ObjectParameter val = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		ObjectParameter val2 = (tipoSolicitanteCorrecaoCursoUID.HasValue ? new ObjectParameter("TipoSolicitanteCorrecaoCursoUID", (object)tipoSolicitanteCorrecaoCursoUID) : new ObjectParameter("TipoSolicitanteCorrecaoCursoUID", typeof(byte)));
		ObjectParameter val3 = ((descricaoCorrecao != null) ? new ObjectParameter("DescricaoCorrecao", (object)descricaoCorrecao) : new ObjectParameter("DescricaoCorrecao", typeof(string)));
		ObjectParameter val4 = (dataHoraUltimaAtualizacao.HasValue ? new ObjectParameter("DataHoraUltimaAtualizacao", (object)dataHoraUltimaAtualizacao) : new ObjectParameter("DataHoraUltimaAtualizacao", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureHomologarCurso", new ObjectParameter[5] { val, val2, val3, val4, erroSaida });
	}

	public virtual int ProcedureHomologarPreMatriculaDiscente(long? prematricuaDiscenteUID, byte? tipoFormaIngressoUID, byte? tipoPeriodoIngressoUID, byte? tipoReservaVagasUID, string descricaoCorrecao, DateTime? dataHoraUltimaAtualizacao, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected Obj, but got Unknown
		ObjectParameter val = (prematricuaDiscenteUID.HasValue ? new ObjectParameter("PrematricuaDiscenteUID", (object)prematricuaDiscenteUID) : new ObjectParameter("PrematricuaDiscenteUID", typeof(long)));
		ObjectParameter val2 = (tipoFormaIngressoUID.HasValue ? new ObjectParameter("TipoFormaIngressoUID", (object)tipoFormaIngressoUID) : new ObjectParameter("TipoFormaIngressoUID", typeof(byte)));
		ObjectParameter val3 = (tipoPeriodoIngressoUID.HasValue ? new ObjectParameter("TipoPeriodoIngressoUID", (object)tipoPeriodoIngressoUID) : new ObjectParameter("TipoPeriodoIngressoUID", typeof(byte)));
		ObjectParameter val4 = (tipoReservaVagasUID.HasValue ? new ObjectParameter("TipoReservaVagasUID", (object)tipoReservaVagasUID) : new ObjectParameter("TipoReservaVagasUID", typeof(byte)));
		ObjectParameter val5 = ((descricaoCorrecao != null) ? new ObjectParameter("DescricaoCorrecao", (object)descricaoCorrecao) : new ObjectParameter("DescricaoCorrecao", typeof(string)));
		ObjectParameter val6 = (dataHoraUltimaAtualizacao.HasValue ? new ObjectParameter("DataHoraUltimaAtualizacao", (object)dataHoraUltimaAtualizacao) : new ObjectParameter("DataHoraUltimaAtualizacao", typeof(DateTime)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureHomologarPreMatriculaDiscente", new ObjectParameter[7] { val, val2, val3, val4, val5, val6, erroSaida });
	}

	public virtual int ProcedureExcluirEspecialidade(long? especialidadeUID, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (especialidadeUID.HasValue ? new ObjectParameter("EspecialidadeUID", (object)especialidadeUID) : new ObjectParameter("EspecialidadeUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureExcluirEspecialidade", new ObjectParameter[2] { val, erroSaida });
	}

	public virtual int ProcedureInserirEditarEspecialidade(long? especialidadeUID, long? estruturaCurricularUID, string nome, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		ObjectParameter val = (especialidadeUID.HasValue ? new ObjectParameter("EspecialidadeUID", (object)especialidadeUID) : new ObjectParameter("EspecialidadeUID", typeof(long)));
		ObjectParameter val2 = (estruturaCurricularUID.HasValue ? new ObjectParameter("EstruturaCurricularUID", (object)estruturaCurricularUID) : new ObjectParameter("EstruturaCurricularUID", typeof(long)));
		ObjectParameter val3 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureInserirEditarEspecialidade", new ObjectParameter[4] { val, val2, val3, erroSaida });
	}

	public virtual int ProcedureConfirmarCorrecaoPreMatriculaDiscente(long? preMatriculaDiscenteUID, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (preMatriculaDiscenteUID.HasValue ? new ObjectParameter("PreMatriculaDiscenteUID", (object)preMatriculaDiscenteUID) : new ObjectParameter("PreMatriculaDiscenteUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureConfirmarCorrecaoPreMatriculaDiscente", new ObjectParameter[2] { val, erroSaida });
	}

	public virtual int ProcedureConfirmarCorrecaoCurso(long? cursoUID, byte? tipoSolicitanteCorrecaoCursoUID, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		ObjectParameter val = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		ObjectParameter val2 = (tipoSolicitanteCorrecaoCursoUID.HasValue ? new ObjectParameter("TipoSolicitanteCorrecaoCursoUID", (object)tipoSolicitanteCorrecaoCursoUID) : new ObjectParameter("TipoSolicitanteCorrecaoCursoUID", typeof(byte)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureConfirmarCorrecaoCurso", new ObjectParameter[3] { val, val2, erroSaida });
	}

	public virtual int ProcedureInserirEditarPreMatriculaDiscente(long? preMatriculaDiscenteUID, long? cursoUID, long? especialidadeUID, string nome, string sexo, DateTime? nascimentoData, string nomeMae, string nomePai, string cpf, string rgNumero, string rgUFUID, string rgOrgaoExpedidor, DateTime? rgDataExpedicao, byte? tipoEstadoCivilUID, string nacionalidade, string nascimentoPaisUID, int? naturalidadeMunicipioUID, string email, string enderecoLogradouro, string enderecoNumero, string enderecoComplemento, string enderecoBairro, string enderecoCEP, int? enderecoMunicipioUID, string telefoneFixo, string telefoneMovel, string telefoneComercial, int? graduacaoInstituicaoEnsinoSuperiorUID, DateTime? gaduacaoDataColacaoGrau, byte? tipoFaixaRendaFamiliar, byte? tipoCorRacaUID, ObjectParameter numeroInscricaoSaida, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected Obj, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected Obj, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected Obj, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected Obj, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected Obj, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected Obj, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected Obj, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected Obj, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected Obj, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected Obj, but got Unknown
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected Obj, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected Obj, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected Obj, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected Obj, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected Obj, but got Unknown
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected Obj, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected Obj, but got Unknown
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected Obj, but got Unknown
		//IL_03d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected Obj, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected Obj, but got Unknown
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Expected Obj, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected Obj, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Expected Obj, but got Unknown
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Expected Obj, but got Unknown
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e5: Expected Obj, but got Unknown
		//IL_0510: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Expected Obj, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected Obj, but got Unknown
		ObjectParameter val = (preMatriculaDiscenteUID.HasValue ? new ObjectParameter("PreMatriculaDiscenteUID", (object)preMatriculaDiscenteUID) : new ObjectParameter("PreMatriculaDiscenteUID", typeof(long)));
		ObjectParameter val2 = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		ObjectParameter val3 = (especialidadeUID.HasValue ? new ObjectParameter("EspecialidadeUID", (object)especialidadeUID) : new ObjectParameter("EspecialidadeUID", typeof(long)));
		ObjectParameter val4 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		ObjectParameter val5 = ((sexo != null) ? new ObjectParameter("Sexo", (object)sexo) : new ObjectParameter("Sexo", typeof(string)));
		ObjectParameter val6 = (nascimentoData.HasValue ? new ObjectParameter("NascimentoData", (object)nascimentoData) : new ObjectParameter("NascimentoData", typeof(DateTime)));
		ObjectParameter val7 = ((nomeMae != null) ? new ObjectParameter("NomeMae", (object)nomeMae) : new ObjectParameter("NomeMae", typeof(string)));
		ObjectParameter val8 = ((nomePai != null) ? new ObjectParameter("NomePai", (object)nomePai) : new ObjectParameter("NomePai", typeof(string)));
		ObjectParameter val9 = ((cpf != null) ? new ObjectParameter("Cpf", (object)cpf) : new ObjectParameter("Cpf", typeof(string)));
		ObjectParameter val10 = ((rgNumero != null) ? new ObjectParameter("RgNumero", (object)rgNumero) : new ObjectParameter("RgNumero", typeof(string)));
		ObjectParameter val11 = ((rgUFUID != null) ? new ObjectParameter("RgUFUID", (object)rgUFUID) : new ObjectParameter("RgUFUID", typeof(string)));
		ObjectParameter val12 = ((rgOrgaoExpedidor != null) ? new ObjectParameter("RgOrgaoExpedidor", (object)rgOrgaoExpedidor) : new ObjectParameter("RgOrgaoExpedidor", typeof(string)));
		ObjectParameter val13 = (rgDataExpedicao.HasValue ? new ObjectParameter("RgDataExpedicao", (object)rgDataExpedicao) : new ObjectParameter("RgDataExpedicao", typeof(DateTime)));
		ObjectParameter val14 = (tipoEstadoCivilUID.HasValue ? new ObjectParameter("TipoEstadoCivilUID", (object)tipoEstadoCivilUID) : new ObjectParameter("TipoEstadoCivilUID", typeof(byte)));
		ObjectParameter val15 = ((nacionalidade != null) ? new ObjectParameter("Nacionalidade", (object)nacionalidade) : new ObjectParameter("Nacionalidade", typeof(string)));
		ObjectParameter val16 = ((nascimentoPaisUID != null) ? new ObjectParameter("NascimentoPaisUID", (object)nascimentoPaisUID) : new ObjectParameter("NascimentoPaisUID", typeof(string)));
		ObjectParameter val17 = (naturalidadeMunicipioUID.HasValue ? new ObjectParameter("NaturalidadeMunicipioUID", (object)naturalidadeMunicipioUID) : new ObjectParameter("NaturalidadeMunicipioUID", typeof(int)));
		ObjectParameter val18 = ((email != null) ? new ObjectParameter("Email", (object)email) : new ObjectParameter("Email", typeof(string)));
		ObjectParameter val19 = ((enderecoLogradouro != null) ? new ObjectParameter("EnderecoLogradouro", (object)enderecoLogradouro) : new ObjectParameter("EnderecoLogradouro", typeof(string)));
		ObjectParameter val20 = ((enderecoNumero != null) ? new ObjectParameter("EnderecoNumero", (object)enderecoNumero) : new ObjectParameter("EnderecoNumero", typeof(string)));
		ObjectParameter val21 = ((enderecoComplemento != null) ? new ObjectParameter("EnderecoComplemento", (object)enderecoComplemento) : new ObjectParameter("EnderecoComplemento", typeof(string)));
		ObjectParameter val22 = ((enderecoBairro != null) ? new ObjectParameter("EnderecoBairro", (object)enderecoBairro) : new ObjectParameter("EnderecoBairro", typeof(string)));
		ObjectParameter val23 = ((enderecoCEP != null) ? new ObjectParameter("EnderecoCEP", (object)enderecoCEP) : new ObjectParameter("EnderecoCEP", typeof(string)));
		ObjectParameter val24 = (enderecoMunicipioUID.HasValue ? new ObjectParameter("EnderecoMunicipioUID", (object)enderecoMunicipioUID) : new ObjectParameter("EnderecoMunicipioUID", typeof(int)));
		ObjectParameter val25 = ((telefoneFixo != null) ? new ObjectParameter("TelefoneFixo", (object)telefoneFixo) : new ObjectParameter("TelefoneFixo", typeof(string)));
		ObjectParameter val26 = ((telefoneMovel != null) ? new ObjectParameter("TelefoneMovel", (object)telefoneMovel) : new ObjectParameter("TelefoneMovel", typeof(string)));
		ObjectParameter val27 = ((telefoneComercial != null) ? new ObjectParameter("TelefoneComercial", (object)telefoneComercial) : new ObjectParameter("TelefoneComercial", typeof(string)));
		ObjectParameter val28 = (graduacaoInstituicaoEnsinoSuperiorUID.HasValue ? new ObjectParameter("GraduacaoInstituicaoEnsinoSuperiorUID", (object)graduacaoInstituicaoEnsinoSuperiorUID) : new ObjectParameter("GraduacaoInstituicaoEnsinoSuperiorUID", typeof(int)));
		ObjectParameter val29 = (gaduacaoDataColacaoGrau.HasValue ? new ObjectParameter("GaduacaoDataColacaoGrau", (object)gaduacaoDataColacaoGrau) : new ObjectParameter("GaduacaoDataColacaoGrau", typeof(DateTime)));
		ObjectParameter val30 = (tipoFaixaRendaFamiliar.HasValue ? new ObjectParameter("TipoFaixaRendaFamiliar", (object)tipoFaixaRendaFamiliar) : new ObjectParameter("TipoFaixaRendaFamiliar", typeof(byte)));
		ObjectParameter val31 = (tipoCorRacaUID.HasValue ? new ObjectParameter("TipoCorRacaUID", (object)tipoCorRacaUID) : new ObjectParameter("TipoCorRacaUID", typeof(byte)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureInserirEditarPreMatriculaDiscente", new ObjectParameter[33]
		{
			val, val2, val3, val4, val5, val6, val7, val8, val9, val10,
			val11, val12, val13, val14, val15, val16, val17, val18, val19, val20,
			val21, val22, val23, val24, val25, val26, val27, val28, val29, val30,
			val31, numeroInscricaoSaida, erroSaida
		});
	}

	public virtual int ProcedureInserirEditarCurso(long? cursoUID, long? unidadeUID, long? cNPqSubAreaConhecimentoUID, string nome, byte? tipoModalidadeUID, short? cargaHoraria, short? numeroResolucaoConsepe, DateTime? dataResolucaoConsepe, string numeroPortariaPropg, DateTime? dataPortariaPropg, byte? tipoStatusCursoUID, string descricaoCancelamento, long? coordenadorServidorUID, long? viceCoordenadorServidorUID, ObjectParameter cursoUIDSaida, ObjectParameter codigoCursoSaida, DateTime? dataIncioEstrutura, DateTime? dataFimEstrutura, ObjectParameter estruturaCurricularUIDSaida, DateTime? dataInicioInscricao, DateTime? dataFimInscricao, byte? tipoStatusHomologacaoUID, string codigoAcesso, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected Obj, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected Obj, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Obj, but got Unknown
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected Obj, but got Unknown
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected Obj, but got Unknown
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected Obj, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected Obj, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected Obj, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected Obj, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected Obj, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Obj, but got Unknown
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Expected Obj, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected Obj, but got Unknown
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected Obj, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Expected Obj, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected Obj, but got Unknown
		ObjectParameter val = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		ObjectParameter val2 = (unidadeUID.HasValue ? new ObjectParameter("UnidadeUID", (object)unidadeUID) : new ObjectParameter("UnidadeUID", typeof(long)));
		ObjectParameter val3 = (cNPqSubAreaConhecimentoUID.HasValue ? new ObjectParameter("CNPqSubAreaConhecimentoUID", (object)cNPqSubAreaConhecimentoUID) : new ObjectParameter("CNPqSubAreaConhecimentoUID", typeof(long)));
		ObjectParameter val4 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		ObjectParameter val5 = (tipoModalidadeUID.HasValue ? new ObjectParameter("TipoModalidadeUID", (object)tipoModalidadeUID) : new ObjectParameter("TipoModalidadeUID", typeof(byte)));
		ObjectParameter val6 = (cargaHoraria.HasValue ? new ObjectParameter("CargaHoraria", (object)cargaHoraria) : new ObjectParameter("CargaHoraria", typeof(short)));
		ObjectParameter val7 = (numeroResolucaoConsepe.HasValue ? new ObjectParameter("NumeroResolucaoConsepe", (object)numeroResolucaoConsepe) : new ObjectParameter("NumeroResolucaoConsepe", typeof(short)));
		ObjectParameter val8 = (dataResolucaoConsepe.HasValue ? new ObjectParameter("DataResolucaoConsepe", (object)dataResolucaoConsepe) : new ObjectParameter("DataResolucaoConsepe", typeof(DateTime)));
		ObjectParameter val9 = ((numeroPortariaPropg != null) ? new ObjectParameter("NumeroPortariaPropg", (object)numeroPortariaPropg) : new ObjectParameter("NumeroPortariaPropg", typeof(string)));
		ObjectParameter val10 = (dataPortariaPropg.HasValue ? new ObjectParameter("DataPortariaPropg", (object)dataPortariaPropg) : new ObjectParameter("DataPortariaPropg", typeof(DateTime)));
		ObjectParameter val11 = (tipoStatusCursoUID.HasValue ? new ObjectParameter("TipoStatusCursoUID", (object)tipoStatusCursoUID) : new ObjectParameter("TipoStatusCursoUID", typeof(byte)));
		ObjectParameter val12 = ((descricaoCancelamento != null) ? new ObjectParameter("DescricaoCancelamento", (object)descricaoCancelamento) : new ObjectParameter("DescricaoCancelamento", typeof(string)));
		ObjectParameter val13 = (coordenadorServidorUID.HasValue ? new ObjectParameter("CoordenadorServidorUID", (object)coordenadorServidorUID) : new ObjectParameter("CoordenadorServidorUID", typeof(long)));
		ObjectParameter val14 = (viceCoordenadorServidorUID.HasValue ? new ObjectParameter("ViceCoordenadorServidorUID", (object)viceCoordenadorServidorUID) : new ObjectParameter("ViceCoordenadorServidorUID", typeof(long)));
		ObjectParameter val15 = (dataIncioEstrutura.HasValue ? new ObjectParameter("DataIncioEstrutura", (object)dataIncioEstrutura) : new ObjectParameter("DataIncioEstrutura", typeof(DateTime)));
		ObjectParameter val16 = (dataFimEstrutura.HasValue ? new ObjectParameter("DataFimEstrutura", (object)dataFimEstrutura) : new ObjectParameter("DataFimEstrutura", typeof(DateTime)));
		ObjectParameter val17 = (dataInicioInscricao.HasValue ? new ObjectParameter("DataInicioInscricao", (object)dataInicioInscricao) : new ObjectParameter("DataInicioInscricao", typeof(DateTime)));
		ObjectParameter val18 = (dataFimInscricao.HasValue ? new ObjectParameter("DataFimInscricao", (object)dataFimInscricao) : new ObjectParameter("DataFimInscricao", typeof(DateTime)));
		ObjectParameter val19 = (tipoStatusHomologacaoUID.HasValue ? new ObjectParameter("TipoStatusHomologacaoUID", (object)tipoStatusHomologacaoUID) : new ObjectParameter("TipoStatusHomologacaoUID", typeof(byte)));
		ObjectParameter val20 = ((codigoAcesso != null) ? new ObjectParameter("CodigoAcesso", (object)codigoAcesso) : new ObjectParameter("CodigoAcesso", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureInserirEditarCurso", new ObjectParameter[24]
		{
			val, val2, val3, val4, val5, val6, val7, val8, val9, val10,
			val11, val12, val13, val14, cursoUIDSaida, codigoCursoSaida, val15, val16, estruturaCurricularUIDSaida, val17,
			val18, val19, val20, erroSaida
		});
	}

	public virtual int ProcedureManterPreMatriculaInscricao(byte? operacao, long? preMatriculaPessoaUID, long? projetoCursoUID, long? preMatriculaInscricaoUID, byte? tipoFormaIngressoUID, byte? tipoPeriodoIngressoUID, byte? tipoReservaVagasUID, DateTime? dataHoraUltimaAtualizacao, string descricaoCorrecao, long? servidorUID, ObjectParameter numeroInscricaoSaida, ObjectParameter registroDiscenteSaida, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected Obj, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Expected Obj, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected Obj, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected Obj, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected Obj, but got Unknown
		ObjectParameter val = (operacao.HasValue ? new ObjectParameter("Operacao", (object)operacao) : new ObjectParameter("Operacao", typeof(byte)));
		ObjectParameter val2 = (preMatriculaPessoaUID.HasValue ? new ObjectParameter("PreMatriculaPessoaUID", (object)preMatriculaPessoaUID) : new ObjectParameter("PreMatriculaPessoaUID", typeof(long)));
		ObjectParameter val3 = (projetoCursoUID.HasValue ? new ObjectParameter("ProjetoCursoUID", (object)projetoCursoUID) : new ObjectParameter("ProjetoCursoUID", typeof(long)));
		ObjectParameter val4 = (preMatriculaInscricaoUID.HasValue ? new ObjectParameter("PreMatriculaInscricaoUID", (object)preMatriculaInscricaoUID) : new ObjectParameter("PreMatriculaInscricaoUID", typeof(long)));
		ObjectParameter val5 = (tipoFormaIngressoUID.HasValue ? new ObjectParameter("TipoFormaIngressoUID", (object)tipoFormaIngressoUID) : new ObjectParameter("TipoFormaIngressoUID", typeof(byte)));
		ObjectParameter val6 = (tipoPeriodoIngressoUID.HasValue ? new ObjectParameter("TipoPeriodoIngressoUID", (object)tipoPeriodoIngressoUID) : new ObjectParameter("TipoPeriodoIngressoUID", typeof(byte)));
		ObjectParameter val7 = (tipoReservaVagasUID.HasValue ? new ObjectParameter("TipoReservaVagasUID", (object)tipoReservaVagasUID) : new ObjectParameter("TipoReservaVagasUID", typeof(byte)));
		ObjectParameter val8 = (dataHoraUltimaAtualizacao.HasValue ? new ObjectParameter("DataHoraUltimaAtualizacao", (object)dataHoraUltimaAtualizacao) : new ObjectParameter("DataHoraUltimaAtualizacao", typeof(DateTime)));
		ObjectParameter val9 = ((descricaoCorrecao != null) ? new ObjectParameter("DescricaoCorrecao", (object)descricaoCorrecao) : new ObjectParameter("DescricaoCorrecao", typeof(string)));
		ObjectParameter val10 = (servidorUID.HasValue ? new ObjectParameter("ServidorUID", (object)servidorUID) : new ObjectParameter("ServidorUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureManterPreMatriculaInscricao", new ObjectParameter[13]
		{
			val, val2, val3, val4, val5, val6, val7, val8, val9, val10,
			numeroInscricaoSaida, registroDiscenteSaida, erroSaida
		});
	}

	public virtual int ProcedureManterPreMatriculaPessoa(byte? operacao, long? preMatriculaPessoaUID, string nome, string sexo, DateTime? nascimentoData, string nomeMae, string nomePai, string cpf, string rgNumero, string rgUFUID, string rgOrgaoExpedidor, DateTime? rgDataExpedicao, byte? tipoEstadoCivilUID, string nacionalidade, string nascimentoPaisUID, int? naturalidadeMunicipioUID, string email, string enderecoLogradouro, string enderecoNumero, string enderecoComplemento, string enderecoBairro, string enderecoCEP, int? enderecoMunicipioUID, string telefoneFixo, string telefoneMovel, string telefoneComercial, bool? diplomaGraduacaoExterior, string numeroRegistroApostilaRevalidacao, int? graduacaoInstituicaoEnsinoUID, DateTime? graduacaoDataColacaoGrau, byte? tipoFaixaRendaFamiliar, byte? tipoCorRacaUID, string senha, ObjectParameter preMatriculaPessoaUIDSaida, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected Obj, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected Obj, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected Obj, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected Obj, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected Obj, but got Unknown
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected Obj, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected Obj, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected Obj, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected Obj, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected Obj, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected Obj, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Expected Obj, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected Obj, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected Obj, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected Obj, but got Unknown
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d6: Expected Obj, but got Unknown
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected Obj, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected Obj, but got Unknown
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Expected Obj, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected Obj, but got Unknown
		//IL_04a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected Obj, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected Obj, but got Unknown
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected Obj, but got Unknown
		//IL_0537: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Expected Obj, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected Obj, but got Unknown
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0598: Expected Obj, but got Unknown
		ObjectParameter val = (operacao.HasValue ? new ObjectParameter("Operacao", (object)operacao) : new ObjectParameter("Operacao", typeof(byte)));
		ObjectParameter val2 = (preMatriculaPessoaUID.HasValue ? new ObjectParameter("PreMatriculaPessoaUID", (object)preMatriculaPessoaUID) : new ObjectParameter("PreMatriculaPessoaUID", typeof(long)));
		ObjectParameter val3 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		ObjectParameter val4 = ((sexo != null) ? new ObjectParameter("Sexo", (object)sexo) : new ObjectParameter("Sexo", typeof(string)));
		ObjectParameter val5 = (nascimentoData.HasValue ? new ObjectParameter("NascimentoData", (object)nascimentoData) : new ObjectParameter("NascimentoData", typeof(DateTime)));
		ObjectParameter val6 = ((nomeMae != null) ? new ObjectParameter("NomeMae", (object)nomeMae) : new ObjectParameter("NomeMae", typeof(string)));
		ObjectParameter val7 = ((nomePai != null) ? new ObjectParameter("NomePai", (object)nomePai) : new ObjectParameter("NomePai", typeof(string)));
		ObjectParameter val8 = ((cpf != null) ? new ObjectParameter("Cpf", (object)cpf) : new ObjectParameter("Cpf", typeof(string)));
		ObjectParameter val9 = ((rgNumero != null) ? new ObjectParameter("RgNumero", (object)rgNumero) : new ObjectParameter("RgNumero", typeof(string)));
		ObjectParameter val10 = ((rgUFUID != null) ? new ObjectParameter("RgUFUID", (object)rgUFUID) : new ObjectParameter("RgUFUID", typeof(string)));
		ObjectParameter val11 = ((rgOrgaoExpedidor != null) ? new ObjectParameter("RgOrgaoExpedidor", (object)rgOrgaoExpedidor) : new ObjectParameter("RgOrgaoExpedidor", typeof(string)));
		ObjectParameter val12 = (rgDataExpedicao.HasValue ? new ObjectParameter("RgDataExpedicao", (object)rgDataExpedicao) : new ObjectParameter("RgDataExpedicao", typeof(DateTime)));
		ObjectParameter val13 = (tipoEstadoCivilUID.HasValue ? new ObjectParameter("TipoEstadoCivilUID", (object)tipoEstadoCivilUID) : new ObjectParameter("TipoEstadoCivilUID", typeof(byte)));
		ObjectParameter val14 = ((nacionalidade != null) ? new ObjectParameter("Nacionalidade", (object)nacionalidade) : new ObjectParameter("Nacionalidade", typeof(string)));
		ObjectParameter val15 = ((nascimentoPaisUID != null) ? new ObjectParameter("NascimentoPaisUID", (object)nascimentoPaisUID) : new ObjectParameter("NascimentoPaisUID", typeof(string)));
		ObjectParameter val16 = (naturalidadeMunicipioUID.HasValue ? new ObjectParameter("NaturalidadeMunicipioUID", (object)naturalidadeMunicipioUID) : new ObjectParameter("NaturalidadeMunicipioUID", typeof(int)));
		ObjectParameter val17 = ((email != null) ? new ObjectParameter("Email", (object)email) : new ObjectParameter("Email", typeof(string)));
		ObjectParameter val18 = ((enderecoLogradouro != null) ? new ObjectParameter("EnderecoLogradouro", (object)enderecoLogradouro) : new ObjectParameter("EnderecoLogradouro", typeof(string)));
		ObjectParameter val19 = ((enderecoNumero != null) ? new ObjectParameter("EnderecoNumero", (object)enderecoNumero) : new ObjectParameter("EnderecoNumero", typeof(string)));
		ObjectParameter val20 = ((enderecoComplemento != null) ? new ObjectParameter("EnderecoComplemento", (object)enderecoComplemento) : new ObjectParameter("EnderecoComplemento", typeof(string)));
		ObjectParameter val21 = ((enderecoBairro != null) ? new ObjectParameter("EnderecoBairro", (object)enderecoBairro) : new ObjectParameter("EnderecoBairro", typeof(string)));
		ObjectParameter val22 = ((enderecoCEP != null) ? new ObjectParameter("EnderecoCEP", (object)enderecoCEP) : new ObjectParameter("EnderecoCEP", typeof(string)));
		ObjectParameter val23 = (enderecoMunicipioUID.HasValue ? new ObjectParameter("EnderecoMunicipioUID", (object)enderecoMunicipioUID) : new ObjectParameter("EnderecoMunicipioUID", typeof(int)));
		ObjectParameter val24 = ((telefoneFixo != null) ? new ObjectParameter("TelefoneFixo", (object)telefoneFixo) : new ObjectParameter("TelefoneFixo", typeof(string)));
		ObjectParameter val25 = ((telefoneMovel != null) ? new ObjectParameter("TelefoneMovel", (object)telefoneMovel) : new ObjectParameter("TelefoneMovel", typeof(string)));
		ObjectParameter val26 = ((telefoneComercial != null) ? new ObjectParameter("TelefoneComercial", (object)telefoneComercial) : new ObjectParameter("TelefoneComercial", typeof(string)));
		ObjectParameter val27 = (diplomaGraduacaoExterior.HasValue ? new ObjectParameter("DiplomaGraduacaoExterior", (object)diplomaGraduacaoExterior) : new ObjectParameter("DiplomaGraduacaoExterior", typeof(bool)));
		ObjectParameter val28 = ((numeroRegistroApostilaRevalidacao != null) ? new ObjectParameter("NumeroRegistroApostilaRevalidacao", (object)numeroRegistroApostilaRevalidacao) : new ObjectParameter("NumeroRegistroApostilaRevalidacao", typeof(string)));
		ObjectParameter val29 = (graduacaoInstituicaoEnsinoUID.HasValue ? new ObjectParameter("GraduacaoInstituicaoEnsinoUID", (object)graduacaoInstituicaoEnsinoUID) : new ObjectParameter("GraduacaoInstituicaoEnsinoUID", typeof(int)));
		ObjectParameter val30 = (graduacaoDataColacaoGrau.HasValue ? new ObjectParameter("GraduacaoDataColacaoGrau", (object)graduacaoDataColacaoGrau) : new ObjectParameter("GraduacaoDataColacaoGrau", typeof(DateTime)));
		ObjectParameter val31 = (tipoFaixaRendaFamiliar.HasValue ? new ObjectParameter("TipoFaixaRendaFamiliar", (object)tipoFaixaRendaFamiliar) : new ObjectParameter("TipoFaixaRendaFamiliar", typeof(byte)));
		ObjectParameter val32 = (tipoCorRacaUID.HasValue ? new ObjectParameter("TipoCorRacaUID", (object)tipoCorRacaUID) : new ObjectParameter("TipoCorRacaUID", typeof(byte)));
		ObjectParameter val33 = ((senha != null) ? new ObjectParameter("Senha", (object)senha) : new ObjectParameter("Senha", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureManterPreMatriculaPessoa", new ObjectParameter[35]
		{
			val, val2, val3, val4, val5, val6, val7, val8, val9, val10,
			val11, val12, val13, val14, val15, val16, val17, val18, val19, val20,
			val21, val22, val23, val24, val25, val26, val27, val28, val29, val30,
			val31, val32, val33, preMatriculaPessoaUIDSaida, erroSaida
		});
	}

	public virtual int ProcedureManterTurma(byte? operacao, long? turmaUID, string nome, int? ano, byte? periodo, byte? turno, long? cursoUID, ObjectParameter turmaUIDSaida, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected Obj, but got Unknown
		ObjectParameter val = (operacao.HasValue ? new ObjectParameter("Operacao", (object)operacao) : new ObjectParameter("Operacao", typeof(byte)));
		ObjectParameter val2 = (turmaUID.HasValue ? new ObjectParameter("TurmaUID", (object)turmaUID) : new ObjectParameter("TurmaUID", typeof(long)));
		ObjectParameter val3 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		ObjectParameter val4 = (ano.HasValue ? new ObjectParameter("Ano", (object)ano) : new ObjectParameter("Ano", typeof(int)));
		ObjectParameter val5 = (periodo.HasValue ? new ObjectParameter("Periodo", (object)periodo) : new ObjectParameter("Periodo", typeof(byte)));
		ObjectParameter val6 = (turno.HasValue ? new ObjectParameter("Turno", (object)turno) : new ObjectParameter("Turno", typeof(byte)));
		ObjectParameter val7 = (cursoUID.HasValue ? new ObjectParameter("CursoUID", (object)cursoUID) : new ObjectParameter("CursoUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureManterTurma", new ObjectParameter[9] { val, val2, val3, val4, val5, val6, val7, turmaUIDSaida, erroSaida });
	}

	public virtual int ProcedureGerarCodigoProjeto(ObjectParameter projetoCodigoSaida)
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureGerarCodigoProjeto", new ObjectParameter[1] { projetoCodigoSaida });
	}

	public virtual int ProcedureGerarNumeroPreMatriculaInscricao(ObjectParameter numeroInscricaoSaida)
	{
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureGerarNumeroPreMatriculaInscricao", new ObjectParameter[1] { numeroInscricaoSaida });
	}

	public virtual int ProcedureManterDisciplina(byte? operacao, long? disciplinaUID, string nome, string sigla, decimal? cargaHorariaTeorica, decimal? cargaHorariaPratica, decimal? cargaHorariaSemanal, decimal? cargaHorariaTotal, ObjectParameter disciplinaUIDSaida, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected Obj, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		ObjectParameter val = (operacao.HasValue ? new ObjectParameter("Operacao", (object)operacao) : new ObjectParameter("Operacao", typeof(byte)));
		ObjectParameter val2 = (disciplinaUID.HasValue ? new ObjectParameter("DisciplinaUID", (object)disciplinaUID) : new ObjectParameter("DisciplinaUID", typeof(long)));
		ObjectParameter val3 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		ObjectParameter val4 = ((sigla != null) ? new ObjectParameter("Sigla", (object)sigla) : new ObjectParameter("Sigla", typeof(string)));
		ObjectParameter val5 = (cargaHorariaTeorica.HasValue ? new ObjectParameter("CargaHorariaTeorica", (object)cargaHorariaTeorica) : new ObjectParameter("CargaHorariaTeorica", typeof(decimal)));
		ObjectParameter val6 = (cargaHorariaPratica.HasValue ? new ObjectParameter("CargaHorariaPratica", (object)cargaHorariaPratica) : new ObjectParameter("CargaHorariaPratica", typeof(decimal)));
		ObjectParameter val7 = (cargaHorariaSemanal.HasValue ? new ObjectParameter("CargaHorariaSemanal", (object)cargaHorariaSemanal) : new ObjectParameter("CargaHorariaSemanal", typeof(decimal)));
		ObjectParameter val8 = (cargaHorariaTotal.HasValue ? new ObjectParameter("CargaHorariaTotal", (object)cargaHorariaTotal) : new ObjectParameter("CargaHorariaTotal", typeof(decimal)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureManterDisciplina", new ObjectParameter[10] { val, val2, val3, val4, val5, val6, val7, val8, disciplinaUIDSaida, erroSaida });
	}

	public virtual int ProcedureExcluirProjetoCurso(long? projetoUID, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (projetoUID.HasValue ? new ObjectParameter("ProjetoUID", (object)projetoUID) : new ObjectParameter("ProjetoUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureExcluirProjetoCurso", new ObjectParameter[2] { val, erroSaida });
	}

	public virtual ObjectResult<ProcedureObterCoordenadorCurso_Result> ProcedureObterCoordenadorCurso(int? aplicacaoUID)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (aplicacaoUID.HasValue ? new ObjectParameter("aplicacaoUID", (object)aplicacaoUID) : new ObjectParameter("aplicacaoUID", typeof(int)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProcedureObterCoordenadorCurso_Result>("ProcedureObterCoordenadorCurso", new ObjectParameter[1] { val });
	}

	public virtual int ProcedureManterProjetoCurso(byte? operacao, long? projetoCursoUID, ObjectParameter codigoProjetoCurso, byte? tipoModalidadeUID, string nomeCurso, long? cNPqAreaConhecimentoUID, long? proponenteUnidadeUID, string telefone, string fax, string email, string siteCurso, long? coordenadorServidorUID, int? titulacaoCoordenadorUID, int? regimeTrabalhoCoordenadorUID, string telefoneResidencialCoordenador, string telefoneCelularCoordenador, string emailCoordenador, long? viceCoordenadorServidorUID, int? titulacaoViceCoordenadorUID, int? regimeTrabalhoViceCoordenadorUID, string telefoneResidencialViceCoordenador, string telefoneCelularViceCoordenador, string emailViceCoordenador, DateTime? realizacaoDataInicio, DateTime? realizacaoDataTermino, int? cargahorariaTotal, int? turnoOfertaUID, int? periodicidadeUID, int? cargaHorariaDiario, int? cargaHorariaModular, string nomeCursoModular, string publicoAlvo, string descricaoInstalacoes, string descricaoEquipamentos, string descricaoMaterialBibliografico, string justificativaCurso, string objetivosCurso, byte[] minutaEdital, string formasAvaliacao, string caracteristicasMonografiaTcc, int? notaMinimaAprovacao, int? frequenciaMinimaAprovacao, byte[] financiamentoCurso, byte[] termoConvenio, byte? tipoFinanciamentoUID, byte? tipoGestaoFinanceiraUID, byte[] planoAplicacaoSuperavit, int? quantidadeEgresso, int? quantidadeVagas, DateTime? dataDocumentoRealizacaoCurso, byte[] documentoRealizacaoCurso, bool? vinculoCursoGraduacao, int? sigaCodCurso, string cEP, int? municipioEnderecoUID, string identificacaoEndereco, int? numeroEndereco, string complementoBairro, string bairroEndereco, string informacoesReferenciaEndereco, ObjectParameter projetoCursoUID_Saida, long? projetocorpoDocenteUID, long? servidorUID, long? projetoColegiadoCursoUID, byte? tipoMembroColegiadoUID, long? projetoBolsaEstagioLei_11788_2008, long? pessoaUID, short? quantidade, decimal? valorUnitario, long? projetoBolsaoLei_8958_94_UID, bool? atividadeNaoRegular, DateTime? dataInicio, DateTime? dataFim, short? cargaHorariaMensal, short? cargaHoraiaTotal, decimal? valorUnitarioCargaHoraria, long? projetoMaterialPermanenteUID, short? tipoMaterialPemanenteUID, short? quantidadeMaterialPermanente, decimal? valorUnitarioMaterialPermanente, long? projetoObrasUID, short? tipoObraUID, short? quantidadeObra, decimal? valorUnitarioObra, long? projetoDisciplinaUID, string nomeDisciplina, short? cargaHorariaDisciplina, DateTime? dataInicioDisciplina, DateTime? dataTerminoDisciplina, string ementa, string bibliografia, long? projetoDiariasUID, long? municipioUID, DateTime? dataInicioDiarias, DateTime? dataFimDiarias, decimal? quantidadeDiarias, decimal? valorUnitarioDiarias, long? projetoMaterialConsumoUID, short? tipoMaterialConsumoUID, short? quantidadeMaterialConsumo, decimal? valorUnitarioMaterialConsumo, long? projetoPassagensUID, byte? tipoPassagemUID, string trecho, short? quantidadePassagens, decimal? valorUnitarioPassagens, long? projetoEquipamentoUID, short? tipoEquipamentoUID, short? quantidadeEquipamentos, decimal? valorUnitarioEquipamentos, long? projetoPessoalEncargosUID, byte? tipoAtividadeUID, DateTime? dataInicioPessoalEncargos, DateTime? dataFimPessoalEncargos, decimal? valorMensalPessoalEncargos, long? projetoDespesasUID, short? tipoDespesaUID, short? quantidadeDespesa, decimal? valorUnitarioDespesa, long? projetoPrevisaoReceitasUID, short? tipoReceitaUID, short? numeroAlunos, short? numeroParcelas, decimal? valorUnitarioPrevisaoReceita, long? projetoServicoTerceirosPessoJuridicaUID, short? tipoServicoTerceirosPessoaJuridicaUID, short? quantidadeServicoTerceirosPJ, decimal? valorUnitarioServicoTerceirosPJ, long? projetoCursoComplementoPresencialUID, byte? tipoTurnoOfertaUID, byte? tipoPeriodicidadeUID, short? cargaHorariaPeriodicidade, long? enderecoUID, long? projetoCursoVagasUID, short? numeroVagas, byte? tipoVagasUID, long? projetoCursoComplementoPresencialVagasUID, long? projetoCursoComplementoEadUID, string descricaoMaterialDidaticoTextualMultimidia, string descricaoAmbienteVirtualAprendizagem, DateTime? dataInicioInscricao, DateTime? dataFimInscricao, DateTime? dataInicioSelecao, DateTime? dataFimSelecao, DateTime? dataInicioMatricula, DateTime? dataFimMatricula, DateTime? dataPrevisaoInicioAulas, string criteriosSelecao, string criteriosComprovacaoCarenciaFinanceira, string descricaoSelecaoCandidatos, string procedimentoRecursoAdm, string procedimentoDivulgacaoResultadoFinal, string orientacoesProcedimentoMatricula, string procedimentoRealizacaoSegundaChamada, long? projetoCorpoDocenteMaterialDidaticoEadUID, string descricaoMaterial, long? projetoCursoComplementoEadEnderecoUID, byte? tipoEnderecoEadUID, long? projetoCursoComplementoEadVagasUID, long? poloEadEnderecoUID, long? projetoServicoTerceirosPessoFisicaUID, bool? atividadeNaoRegularServicoTerceirosPF, DateTime? dataInicioServicoTerceirosPF, DateTime? dataFimServicoTerceirosPF, short? cargaHorariaMensalSevicoTerceirosPF, short? cargaHorariaTotalServicoTerceirosPF, decimal? valorUnitarioCargaHorariaServicoTerceirosPF, decimal? encargosSociaisServicoTerceirosPF, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected Obj, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected Obj, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected Obj, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected Obj, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected Obj, but got Unknown
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected Obj, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected Obj, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected Obj, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected Obj, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected Obj, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected Obj, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected Obj, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected Obj, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected Obj, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Expected Obj, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected Obj, but got Unknown
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected Obj, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected Obj, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_046e: Expected Obj, but got Unknown
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Expected Obj, but got Unknown
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Expected Obj, but got Unknown
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Expected Obj, but got Unknown
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0536: Expected Obj, but got Unknown
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Expected Obj, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Expected Obj, but got Unknown
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ae: Expected Obj, but got Unknown
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected Obj, but got Unknown
		//IL_05f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected Obj, but got Unknown
		//IL_061f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected Obj, but got Unknown
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Expected Obj, but got Unknown
		//IL_066f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_0676: Expected Obj, but got Unknown
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Expected Obj, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Expected Obj, but got Unknown
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06de: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected Obj, but got Unknown
		//IL_0723: Unknown result type (might be due to invalid IL or missing references)
		//IL_0710: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Expected Obj, but got Unknown
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Expected Obj, but got Unknown
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_0765: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Expected Obj, but got Unknown
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Expected Obj, but got Unknown
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07de: Expected Obj, but got Unknown
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0806: Expected Obj, but got Unknown
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Expected Obj, but got Unknown
		//IL_0863: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Expected Obj, but got Unknown
		//IL_0895: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Expected Obj, but got Unknown
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c4: Expected Obj, but got Unknown
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f6: Expected Obj, but got Unknown
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Expected Obj, but got Unknown
		//IL_0949: Unknown result type (might be due to invalid IL or missing references)
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Expected Obj, but got Unknown
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Unknown result type (might be due to invalid IL or missing references)
		//IL_0982: Expected Obj, but got Unknown
		//IL_09a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0995: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected Obj, but got Unknown
		//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dc: Expected Obj, but got Unknown
		//IL_09fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a04: Expected Obj, but got Unknown
		//IL_0a25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2c: Expected Obj, but got Unknown
		//IL_0a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Expected Obj, but got Unknown
		//IL_0a7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Expected Obj, but got Unknown
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Expected Obj, but got Unknown
		//IL_0ae3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aea: Expected Obj, but got Unknown
		//IL_0b15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1c: Expected Obj, but got Unknown
		//IL_0b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4e: Expected Obj, but got Unknown
		//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b80: Expected Obj, but got Unknown
		//IL_0bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb2: Expected Obj, but got Unknown
		//IL_0bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be4: Expected Obj, but got Unknown
		//IL_0c0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c16: Expected Obj, but got Unknown
		//IL_0c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c48: Expected Obj, but got Unknown
		//IL_0c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7a: Expected Obj, but got Unknown
		//IL_0ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Expected Obj, but got Unknown
		//IL_0cd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cde: Expected Obj, but got Unknown
		//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d10: Expected Obj, but got Unknown
		//IL_0d3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Expected Obj, but got Unknown
		//IL_0d6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d74: Expected Obj, but got Unknown
		//IL_0d9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da6: Expected Obj, but got Unknown
		//IL_0dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd8: Expected Obj, but got Unknown
		//IL_0e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0a: Expected Obj, but got Unknown
		//IL_0e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3c: Expected Obj, but got Unknown
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6e: Expected Obj, but got Unknown
		//IL_0e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea0: Expected Obj, but got Unknown
		//IL_0ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed2: Expected Obj, but got Unknown
		//IL_0efd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f04: Expected Obj, but got Unknown
		//IL_0f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2c: Expected Obj, but got Unknown
		//IL_0f57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5e: Expected Obj, but got Unknown
		//IL_0f89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f90: Expected Obj, but got Unknown
		//IL_0fbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc2: Expected Obj, but got Unknown
		//IL_0fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fea: Expected Obj, but got Unknown
		//IL_100b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1012: Expected Obj, but got Unknown
		//IL_103d: Unknown result type (might be due to invalid IL or missing references)
		//IL_102a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1044: Expected Obj, but got Unknown
		//IL_106f: Unknown result type (might be due to invalid IL or missing references)
		//IL_105c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1076: Expected Obj, but got Unknown
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_108e: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a8: Expected Obj, but got Unknown
		//IL_10d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Expected Obj, but got Unknown
		//IL_1105: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_110c: Expected Obj, but got Unknown
		//IL_1137: Unknown result type (might be due to invalid IL or missing references)
		//IL_1124: Unknown result type (might be due to invalid IL or missing references)
		//IL_113e: Expected Obj, but got Unknown
		//IL_1169: Unknown result type (might be due to invalid IL or missing references)
		//IL_1156: Unknown result type (might be due to invalid IL or missing references)
		//IL_1170: Expected Obj, but got Unknown
		//IL_119b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1188: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a2: Expected Obj, but got Unknown
		//IL_11cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d4: Expected Obj, but got Unknown
		//IL_11ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1206: Expected Obj, but got Unknown
		//IL_1231: Unknown result type (might be due to invalid IL or missing references)
		//IL_121e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1238: Expected Obj, but got Unknown
		//IL_1263: Unknown result type (might be due to invalid IL or missing references)
		//IL_1250: Unknown result type (might be due to invalid IL or missing references)
		//IL_126a: Expected Obj, but got Unknown
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_127d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1292: Expected Obj, but got Unknown
		//IL_12bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c4: Expected Obj, but got Unknown
		//IL_12ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_12dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f6: Expected Obj, but got Unknown
		//IL_1321: Unknown result type (might be due to invalid IL or missing references)
		//IL_130e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1328: Expected Obj, but got Unknown
		//IL_1353: Unknown result type (might be due to invalid IL or missing references)
		//IL_1340: Unknown result type (might be due to invalid IL or missing references)
		//IL_135a: Expected Obj, but got Unknown
		//IL_1385: Unknown result type (might be due to invalid IL or missing references)
		//IL_1372: Unknown result type (might be due to invalid IL or missing references)
		//IL_138c: Expected Obj, but got Unknown
		//IL_13b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13be: Expected Obj, but got Unknown
		//IL_13e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f0: Expected Obj, but got Unknown
		//IL_141b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1408: Unknown result type (might be due to invalid IL or missing references)
		//IL_1422: Expected Obj, but got Unknown
		//IL_144d: Unknown result type (might be due to invalid IL or missing references)
		//IL_143a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1454: Expected Obj, but got Unknown
		//IL_147f: Unknown result type (might be due to invalid IL or missing references)
		//IL_146c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1486: Expected Obj, but got Unknown
		//IL_14b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_149e: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b8: Expected Obj, but got Unknown
		//IL_14e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ea: Expected Obj, but got Unknown
		//IL_1515: Unknown result type (might be due to invalid IL or missing references)
		//IL_1502: Unknown result type (might be due to invalid IL or missing references)
		//IL_151c: Expected Obj, but got Unknown
		//IL_1547: Unknown result type (might be due to invalid IL or missing references)
		//IL_1534: Unknown result type (might be due to invalid IL or missing references)
		//IL_154e: Expected Obj, but got Unknown
		//IL_1579: Unknown result type (might be due to invalid IL or missing references)
		//IL_1566: Unknown result type (might be due to invalid IL or missing references)
		//IL_1580: Expected Obj, but got Unknown
		//IL_15ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b2: Expected Obj, but got Unknown
		//IL_15dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e4: Expected Obj, but got Unknown
		//IL_160f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1616: Expected Obj, but got Unknown
		//IL_1641: Unknown result type (might be due to invalid IL or missing references)
		//IL_162e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1648: Expected Obj, but got Unknown
		//IL_1673: Unknown result type (might be due to invalid IL or missing references)
		//IL_1660: Unknown result type (might be due to invalid IL or missing references)
		//IL_167a: Expected Obj, but got Unknown
		//IL_16a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1692: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ac: Expected Obj, but got Unknown
		//IL_16d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16de: Expected Obj, but got Unknown
		//IL_1709: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1710: Expected Obj, but got Unknown
		//IL_173b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1728: Unknown result type (might be due to invalid IL or missing references)
		//IL_1742: Expected Obj, but got Unknown
		//IL_176d: Unknown result type (might be due to invalid IL or missing references)
		//IL_175a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1774: Expected Obj, but got Unknown
		//IL_179f: Unknown result type (might be due to invalid IL or missing references)
		//IL_178c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a6: Expected Obj, but got Unknown
		//IL_17d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17be: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d8: Expected Obj, but got Unknown
		//IL_1803: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_180a: Expected Obj, but got Unknown
		//IL_1835: Unknown result type (might be due to invalid IL or missing references)
		//IL_1822: Unknown result type (might be due to invalid IL or missing references)
		//IL_183c: Expected Obj, but got Unknown
		//IL_1867: Unknown result type (might be due to invalid IL or missing references)
		//IL_1854: Unknown result type (might be due to invalid IL or missing references)
		//IL_186e: Expected Obj, but got Unknown
		//IL_1899: Unknown result type (might be due to invalid IL or missing references)
		//IL_1886: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a0: Expected Obj, but got Unknown
		//IL_18cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d2: Expected Obj, but got Unknown
		//IL_18fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1904: Expected Obj, but got Unknown
		//IL_192f: Unknown result type (might be due to invalid IL or missing references)
		//IL_191c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1936: Expected Obj, but got Unknown
		//IL_1957: Unknown result type (might be due to invalid IL or missing references)
		//IL_1949: Unknown result type (might be due to invalid IL or missing references)
		//IL_195e: Expected Obj, but got Unknown
		//IL_197f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1971: Unknown result type (might be due to invalid IL or missing references)
		//IL_1986: Expected Obj, but got Unknown
		//IL_19b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_199e: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b8: Expected Obj, but got Unknown
		//IL_19e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ea: Expected Obj, but got Unknown
		//IL_1a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1c: Expected Obj, but got Unknown
		//IL_1a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4e: Expected Obj, but got Unknown
		//IL_1a79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a80: Expected Obj, but got Unknown
		//IL_1aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a98: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab2: Expected Obj, but got Unknown
		//IL_1add: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae4: Expected Obj, but got Unknown
		//IL_1b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0c: Expected Obj, but got Unknown
		//IL_1b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b34: Expected Obj, but got Unknown
		//IL_1b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5c: Expected Obj, but got Unknown
		//IL_1b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b84: Expected Obj, but got Unknown
		//IL_1ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bac: Expected Obj, but got Unknown
		//IL_1bcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd4: Expected Obj, but got Unknown
		//IL_1bf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfc: Expected Obj, but got Unknown
		//IL_1c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c14: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2e: Expected Obj, but got Unknown
		//IL_1c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c56: Expected Obj, but got Unknown
		//IL_1c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c88: Expected Obj, but got Unknown
		//IL_1cb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cba: Expected Obj, but got Unknown
		//IL_1ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cec: Expected Obj, but got Unknown
		//IL_1d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1e: Expected Obj, but got Unknown
		//IL_1d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d50: Expected Obj, but got Unknown
		//IL_1d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d68: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d82: Expected Obj, but got Unknown
		//IL_1dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db4: Expected Obj, but got Unknown
		//IL_1ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de6: Expected Obj, but got Unknown
		//IL_1e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e18: Expected Obj, but got Unknown
		//IL_1e43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e4a: Expected Obj, but got Unknown
		//IL_1e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e62: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7c: Expected Obj, but got Unknown
		//IL_1ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eae: Expected Obj, but got Unknown
		ObjectParameter val = (operacao.HasValue ? new ObjectParameter("Operacao", (object)operacao) : new ObjectParameter("Operacao", typeof(byte)));
		ObjectParameter val2 = (projetoCursoUID.HasValue ? new ObjectParameter("ProjetoCursoUID", (object)projetoCursoUID) : new ObjectParameter("ProjetoCursoUID", typeof(long)));
		ObjectParameter val3 = (tipoModalidadeUID.HasValue ? new ObjectParameter("TipoModalidadeUID", (object)tipoModalidadeUID) : new ObjectParameter("TipoModalidadeUID", typeof(byte)));
		ObjectParameter val4 = ((nomeCurso != null) ? new ObjectParameter("NomeCurso", (object)nomeCurso) : new ObjectParameter("NomeCurso", typeof(string)));
		ObjectParameter val5 = (cNPqAreaConhecimentoUID.HasValue ? new ObjectParameter("CNPqAreaConhecimentoUID", (object)cNPqAreaConhecimentoUID) : new ObjectParameter("CNPqAreaConhecimentoUID", typeof(long)));
		ObjectParameter val6 = (proponenteUnidadeUID.HasValue ? new ObjectParameter("ProponenteUnidadeUID", (object)proponenteUnidadeUID) : new ObjectParameter("ProponenteUnidadeUID", typeof(long)));
		ObjectParameter val7 = ((telefone != null) ? new ObjectParameter("Telefone", (object)telefone) : new ObjectParameter("Telefone", typeof(string)));
		ObjectParameter val8 = ((fax != null) ? new ObjectParameter("Fax", (object)fax) : new ObjectParameter("Fax", typeof(string)));
		ObjectParameter val9 = ((email != null) ? new ObjectParameter("Email", (object)email) : new ObjectParameter("Email", typeof(string)));
		ObjectParameter val10 = ((siteCurso != null) ? new ObjectParameter("SiteCurso", (object)siteCurso) : new ObjectParameter("SiteCurso", typeof(string)));
		ObjectParameter val11 = (coordenadorServidorUID.HasValue ? new ObjectParameter("CoordenadorServidorUID", (object)coordenadorServidorUID) : new ObjectParameter("CoordenadorServidorUID", typeof(long)));
		ObjectParameter val12 = (titulacaoCoordenadorUID.HasValue ? new ObjectParameter("titulacaoCoordenadorUID", (object)titulacaoCoordenadorUID) : new ObjectParameter("titulacaoCoordenadorUID", typeof(int)));
		ObjectParameter val13 = (regimeTrabalhoCoordenadorUID.HasValue ? new ObjectParameter("regimeTrabalhoCoordenadorUID", (object)regimeTrabalhoCoordenadorUID) : new ObjectParameter("regimeTrabalhoCoordenadorUID", typeof(int)));
		ObjectParameter val14 = ((telefoneResidencialCoordenador != null) ? new ObjectParameter("telefoneResidencialCoordenador", (object)telefoneResidencialCoordenador) : new ObjectParameter("telefoneResidencialCoordenador", typeof(string)));
		ObjectParameter val15 = ((telefoneCelularCoordenador != null) ? new ObjectParameter("telefoneCelularCoordenador", (object)telefoneCelularCoordenador) : new ObjectParameter("telefoneCelularCoordenador", typeof(string)));
		ObjectParameter val16 = ((emailCoordenador != null) ? new ObjectParameter("emailCoordenador", (object)emailCoordenador) : new ObjectParameter("emailCoordenador", typeof(string)));
		ObjectParameter val17 = (viceCoordenadorServidorUID.HasValue ? new ObjectParameter("viceCoordenadorServidorUID", (object)viceCoordenadorServidorUID) : new ObjectParameter("viceCoordenadorServidorUID", typeof(long)));
		ObjectParameter val18 = (titulacaoViceCoordenadorUID.HasValue ? new ObjectParameter("titulacaoViceCoordenadorUID", (object)titulacaoViceCoordenadorUID) : new ObjectParameter("titulacaoViceCoordenadorUID", typeof(int)));
		ObjectParameter val19 = (regimeTrabalhoViceCoordenadorUID.HasValue ? new ObjectParameter("regimeTrabalhoViceCoordenadorUID", (object)regimeTrabalhoViceCoordenadorUID) : new ObjectParameter("regimeTrabalhoViceCoordenadorUID", typeof(int)));
		ObjectParameter val20 = ((telefoneResidencialViceCoordenador != null) ? new ObjectParameter("telefoneResidencialViceCoordenador", (object)telefoneResidencialViceCoordenador) : new ObjectParameter("telefoneResidencialViceCoordenador", typeof(string)));
		ObjectParameter val21 = ((telefoneCelularViceCoordenador != null) ? new ObjectParameter("telefoneCelularViceCoordenador", (object)telefoneCelularViceCoordenador) : new ObjectParameter("telefoneCelularViceCoordenador", typeof(string)));
		ObjectParameter val22 = ((emailViceCoordenador != null) ? new ObjectParameter("emailViceCoordenador", (object)emailViceCoordenador) : new ObjectParameter("emailViceCoordenador", typeof(string)));
		ObjectParameter val23 = (realizacaoDataInicio.HasValue ? new ObjectParameter("RealizacaoDataInicio", (object)realizacaoDataInicio) : new ObjectParameter("RealizacaoDataInicio", typeof(DateTime)));
		ObjectParameter val24 = (realizacaoDataTermino.HasValue ? new ObjectParameter("realizacaoDataTermino", (object)realizacaoDataTermino) : new ObjectParameter("realizacaoDataTermino", typeof(DateTime)));
		ObjectParameter val25 = (cargahorariaTotal.HasValue ? new ObjectParameter("CargahorariaTotal", (object)cargahorariaTotal) : new ObjectParameter("CargahorariaTotal", typeof(int)));
		ObjectParameter val26 = (turnoOfertaUID.HasValue ? new ObjectParameter("turnoOfertaUID", (object)turnoOfertaUID) : new ObjectParameter("turnoOfertaUID", typeof(int)));
		ObjectParameter val27 = (periodicidadeUID.HasValue ? new ObjectParameter("periodicidadeUID", (object)periodicidadeUID) : new ObjectParameter("periodicidadeUID", typeof(int)));
		ObjectParameter val28 = (cargaHorariaDiario.HasValue ? new ObjectParameter("cargaHorariaDiario", (object)cargaHorariaDiario) : new ObjectParameter("cargaHorariaDiario", typeof(int)));
		ObjectParameter val29 = (cargaHorariaModular.HasValue ? new ObjectParameter("cargaHorariaModular", (object)cargaHorariaModular) : new ObjectParameter("cargaHorariaModular", typeof(int)));
		ObjectParameter val30 = ((nomeCursoModular != null) ? new ObjectParameter("nomeCursoModular", (object)nomeCursoModular) : new ObjectParameter("nomeCursoModular", typeof(string)));
		ObjectParameter val31 = ((publicoAlvo != null) ? new ObjectParameter("PublicoAlvo", (object)publicoAlvo) : new ObjectParameter("PublicoAlvo", typeof(string)));
		ObjectParameter val32 = ((descricaoInstalacoes != null) ? new ObjectParameter("DescricaoInstalacoes", (object)descricaoInstalacoes) : new ObjectParameter("DescricaoInstalacoes", typeof(string)));
		ObjectParameter val33 = ((descricaoEquipamentos != null) ? new ObjectParameter("DescricaoEquipamentos", (object)descricaoEquipamentos) : new ObjectParameter("DescricaoEquipamentos", typeof(string)));
		ObjectParameter val34 = ((descricaoMaterialBibliografico != null) ? new ObjectParameter("DescricaoMaterialBibliografico", (object)descricaoMaterialBibliografico) : new ObjectParameter("DescricaoMaterialBibliografico", typeof(string)));
		ObjectParameter val35 = ((justificativaCurso != null) ? new ObjectParameter("JustificativaCurso", (object)justificativaCurso) : new ObjectParameter("JustificativaCurso", typeof(string)));
		ObjectParameter val36 = ((objetivosCurso != null) ? new ObjectParameter("ObjetivosCurso", (object)objetivosCurso) : new ObjectParameter("ObjetivosCurso", typeof(string)));
		ObjectParameter val37 = ((minutaEdital != null) ? new ObjectParameter("MinutaEdital", (object)minutaEdital) : new ObjectParameter("MinutaEdital", typeof(byte[])));
		ObjectParameter val38 = ((formasAvaliacao != null) ? new ObjectParameter("FormasAvaliacao", (object)formasAvaliacao) : new ObjectParameter("FormasAvaliacao", typeof(string)));
		ObjectParameter val39 = ((caracteristicasMonografiaTcc != null) ? new ObjectParameter("CaracteristicasMonografiaTcc", (object)caracteristicasMonografiaTcc) : new ObjectParameter("CaracteristicasMonografiaTcc", typeof(string)));
		ObjectParameter val40 = (notaMinimaAprovacao.HasValue ? new ObjectParameter("NotaMinimaAprovacao", (object)notaMinimaAprovacao) : new ObjectParameter("NotaMinimaAprovacao", typeof(int)));
		ObjectParameter val41 = (frequenciaMinimaAprovacao.HasValue ? new ObjectParameter("FrequenciaMinimaAprovacao", (object)frequenciaMinimaAprovacao) : new ObjectParameter("FrequenciaMinimaAprovacao", typeof(int)));
		ObjectParameter val42 = ((financiamentoCurso != null) ? new ObjectParameter("FinanciamentoCurso", (object)financiamentoCurso) : new ObjectParameter("FinanciamentoCurso", typeof(byte[])));
		ObjectParameter val43 = ((termoConvenio != null) ? new ObjectParameter("TermoConvenio", (object)termoConvenio) : new ObjectParameter("TermoConvenio", typeof(byte[])));
		ObjectParameter val44 = (tipoFinanciamentoUID.HasValue ? new ObjectParameter("TipoFinanciamentoUID", (object)tipoFinanciamentoUID) : new ObjectParameter("TipoFinanciamentoUID", typeof(byte)));
		ObjectParameter val45 = (tipoGestaoFinanceiraUID.HasValue ? new ObjectParameter("TipoGestaoFinanceiraUID", (object)tipoGestaoFinanceiraUID) : new ObjectParameter("TipoGestaoFinanceiraUID", typeof(byte)));
		ObjectParameter val46 = ((planoAplicacaoSuperavit != null) ? new ObjectParameter("PlanoAplicacaoSuperavit", (object)planoAplicacaoSuperavit) : new ObjectParameter("PlanoAplicacaoSuperavit", typeof(byte[])));
		ObjectParameter val47 = (quantidadeEgresso.HasValue ? new ObjectParameter("QuantidadeEgresso", (object)quantidadeEgresso) : new ObjectParameter("QuantidadeEgresso", typeof(int)));
		ObjectParameter val48 = (quantidadeVagas.HasValue ? new ObjectParameter("QuantidadeVagas", (object)quantidadeVagas) : new ObjectParameter("QuantidadeVagas", typeof(int)));
		ObjectParameter val49 = (dataDocumentoRealizacaoCurso.HasValue ? new ObjectParameter("DataDocumentoRealizacaoCurso", (object)dataDocumentoRealizacaoCurso) : new ObjectParameter("DataDocumentoRealizacaoCurso", typeof(DateTime)));
		ObjectParameter val50 = ((documentoRealizacaoCurso != null) ? new ObjectParameter("DocumentoRealizacaoCurso", (object)documentoRealizacaoCurso) : new ObjectParameter("DocumentoRealizacaoCurso", typeof(byte[])));
		ObjectParameter val51 = (vinculoCursoGraduacao.HasValue ? new ObjectParameter("VinculoCursoGraduacao", (object)vinculoCursoGraduacao) : new ObjectParameter("VinculoCursoGraduacao", typeof(bool)));
		ObjectParameter val52 = (sigaCodCurso.HasValue ? new ObjectParameter("SigaCodCurso", (object)sigaCodCurso) : new ObjectParameter("SigaCodCurso", typeof(int)));
		ObjectParameter val53 = ((cEP != null) ? new ObjectParameter("CEP", (object)cEP) : new ObjectParameter("CEP", typeof(string)));
		ObjectParameter val54 = (municipioEnderecoUID.HasValue ? new ObjectParameter("MunicipioEnderecoUID", (object)municipioEnderecoUID) : new ObjectParameter("MunicipioEnderecoUID", typeof(int)));
		ObjectParameter val55 = ((identificacaoEndereco != null) ? new ObjectParameter("IdentificacaoEndereco", (object)identificacaoEndereco) : new ObjectParameter("IdentificacaoEndereco", typeof(string)));
		ObjectParameter val56 = (numeroEndereco.HasValue ? new ObjectParameter("NumeroEndereco", (object)numeroEndereco) : new ObjectParameter("NumeroEndereco", typeof(int)));
		ObjectParameter val57 = ((complementoBairro != null) ? new ObjectParameter("ComplementoBairro", (object)complementoBairro) : new ObjectParameter("ComplementoBairro", typeof(string)));
		ObjectParameter val58 = ((bairroEndereco != null) ? new ObjectParameter("BairroEndereco", (object)bairroEndereco) : new ObjectParameter("BairroEndereco", typeof(string)));
		ObjectParameter val59 = ((informacoesReferenciaEndereco != null) ? new ObjectParameter("InformacoesReferenciaEndereco", (object)informacoesReferenciaEndereco) : new ObjectParameter("InformacoesReferenciaEndereco", typeof(string)));
		ObjectParameter val60 = (projetocorpoDocenteUID.HasValue ? new ObjectParameter("ProjetocorpoDocenteUID", (object)projetocorpoDocenteUID) : new ObjectParameter("ProjetocorpoDocenteUID", typeof(long)));
		ObjectParameter val61 = (servidorUID.HasValue ? new ObjectParameter("ServidorUID", (object)servidorUID) : new ObjectParameter("ServidorUID", typeof(long)));
		ObjectParameter val62 = (projetoColegiadoCursoUID.HasValue ? new ObjectParameter("ProjetoColegiadoCursoUID", (object)projetoColegiadoCursoUID) : new ObjectParameter("ProjetoColegiadoCursoUID", typeof(long)));
		ObjectParameter val63 = (tipoMembroColegiadoUID.HasValue ? new ObjectParameter("TipoMembroColegiadoUID", (object)tipoMembroColegiadoUID) : new ObjectParameter("TipoMembroColegiadoUID", typeof(byte)));
		ObjectParameter val64 = (projetoBolsaEstagioLei_11788_2008.HasValue ? new ObjectParameter("ProjetoBolsaEstagioLei_11788_2008", (object)projetoBolsaEstagioLei_11788_2008) : new ObjectParameter("ProjetoBolsaEstagioLei_11788_2008", typeof(long)));
		ObjectParameter val65 = (pessoaUID.HasValue ? new ObjectParameter("PessoaUID", (object)pessoaUID) : new ObjectParameter("PessoaUID", typeof(long)));
		ObjectParameter val66 = (quantidade.HasValue ? new ObjectParameter("Quantidade", (object)quantidade) : new ObjectParameter("Quantidade", typeof(short)));
		ObjectParameter val67 = (valorUnitario.HasValue ? new ObjectParameter("ValorUnitario", (object)valorUnitario) : new ObjectParameter("ValorUnitario", typeof(decimal)));
		ObjectParameter val68 = (projetoBolsaoLei_8958_94_UID.HasValue ? new ObjectParameter("ProjetoBolsaoLei_8958_94_UID", (object)projetoBolsaoLei_8958_94_UID) : new ObjectParameter("ProjetoBolsaoLei_8958_94_UID", typeof(long)));
		ObjectParameter val69 = (atividadeNaoRegular.HasValue ? new ObjectParameter("AtividadeNaoRegular", (object)atividadeNaoRegular) : new ObjectParameter("AtividadeNaoRegular", typeof(bool)));
		ObjectParameter val70 = (dataInicio.HasValue ? new ObjectParameter("DataInicio", (object)dataInicio) : new ObjectParameter("DataInicio", typeof(DateTime)));
		ObjectParameter val71 = (dataFim.HasValue ? new ObjectParameter("DataFim", (object)dataFim) : new ObjectParameter("DataFim", typeof(DateTime)));
		ObjectParameter val72 = (cargaHorariaMensal.HasValue ? new ObjectParameter("CargaHorariaMensal", (object)cargaHorariaMensal) : new ObjectParameter("CargaHorariaMensal", typeof(short)));
		ObjectParameter val73 = (cargaHoraiaTotal.HasValue ? new ObjectParameter("CargaHoraiaTotal", (object)cargaHoraiaTotal) : new ObjectParameter("CargaHoraiaTotal", typeof(short)));
		ObjectParameter val74 = (valorUnitarioCargaHoraria.HasValue ? new ObjectParameter("ValorUnitarioCargaHoraria", (object)valorUnitarioCargaHoraria) : new ObjectParameter("ValorUnitarioCargaHoraria", typeof(decimal)));
		ObjectParameter val75 = (projetoMaterialPermanenteUID.HasValue ? new ObjectParameter("ProjetoMaterialPermanenteUID", (object)projetoMaterialPermanenteUID) : new ObjectParameter("ProjetoMaterialPermanenteUID", typeof(long)));
		ObjectParameter val76 = (tipoMaterialPemanenteUID.HasValue ? new ObjectParameter("TipoMaterialPemanenteUID", (object)tipoMaterialPemanenteUID) : new ObjectParameter("TipoMaterialPemanenteUID", typeof(short)));
		ObjectParameter val77 = (quantidadeMaterialPermanente.HasValue ? new ObjectParameter("QuantidadeMaterialPermanente", (object)quantidadeMaterialPermanente) : new ObjectParameter("QuantidadeMaterialPermanente", typeof(short)));
		ObjectParameter val78 = (valorUnitarioMaterialPermanente.HasValue ? new ObjectParameter("ValorUnitarioMaterialPermanente", (object)valorUnitarioMaterialPermanente) : new ObjectParameter("ValorUnitarioMaterialPermanente", typeof(decimal)));
		ObjectParameter val79 = (projetoObrasUID.HasValue ? new ObjectParameter("ProjetoObrasUID", (object)projetoObrasUID) : new ObjectParameter("ProjetoObrasUID", typeof(long)));
		ObjectParameter val80 = (tipoObraUID.HasValue ? new ObjectParameter("TipoObraUID", (object)tipoObraUID) : new ObjectParameter("TipoObraUID", typeof(short)));
		ObjectParameter val81 = (quantidadeObra.HasValue ? new ObjectParameter("QuantidadeObra", (object)quantidadeObra) : new ObjectParameter("QuantidadeObra", typeof(short)));
		ObjectParameter val82 = (valorUnitarioObra.HasValue ? new ObjectParameter("ValorUnitarioObra", (object)valorUnitarioObra) : new ObjectParameter("ValorUnitarioObra", typeof(decimal)));
		ObjectParameter val83 = (projetoDisciplinaUID.HasValue ? new ObjectParameter("ProjetoDisciplinaUID", (object)projetoDisciplinaUID) : new ObjectParameter("ProjetoDisciplinaUID", typeof(long)));
		ObjectParameter val84 = ((nomeDisciplina != null) ? new ObjectParameter("NomeDisciplina", (object)nomeDisciplina) : new ObjectParameter("NomeDisciplina", typeof(string)));
		ObjectParameter val85 = (cargaHorariaDisciplina.HasValue ? new ObjectParameter("CargaHorariaDisciplina", (object)cargaHorariaDisciplina) : new ObjectParameter("CargaHorariaDisciplina", typeof(short)));
		ObjectParameter val86 = (dataInicioDisciplina.HasValue ? new ObjectParameter("DataInicioDisciplina", (object)dataInicioDisciplina) : new ObjectParameter("DataInicioDisciplina", typeof(DateTime)));
		ObjectParameter val87 = (dataTerminoDisciplina.HasValue ? new ObjectParameter("DataTerminoDisciplina", (object)dataTerminoDisciplina) : new ObjectParameter("DataTerminoDisciplina", typeof(DateTime)));
		ObjectParameter val88 = ((ementa != null) ? new ObjectParameter("Ementa", (object)ementa) : new ObjectParameter("Ementa", typeof(string)));
		ObjectParameter val89 = ((bibliografia != null) ? new ObjectParameter("Bibliografia", (object)bibliografia) : new ObjectParameter("Bibliografia", typeof(string)));
		ObjectParameter val90 = (projetoDiariasUID.HasValue ? new ObjectParameter("ProjetoDiariasUID", (object)projetoDiariasUID) : new ObjectParameter("ProjetoDiariasUID", typeof(long)));
		ObjectParameter val91 = (municipioUID.HasValue ? new ObjectParameter("MunicipioUID", (object)municipioUID) : new ObjectParameter("MunicipioUID", typeof(long)));
		ObjectParameter val92 = (dataInicioDiarias.HasValue ? new ObjectParameter("DataInicioDiarias", (object)dataInicioDiarias) : new ObjectParameter("DataInicioDiarias", typeof(DateTime)));
		ObjectParameter val93 = (dataFimDiarias.HasValue ? new ObjectParameter("DataFimDiarias", (object)dataFimDiarias) : new ObjectParameter("DataFimDiarias", typeof(DateTime)));
		ObjectParameter val94 = (quantidadeDiarias.HasValue ? new ObjectParameter("QuantidadeDiarias", (object)quantidadeDiarias) : new ObjectParameter("QuantidadeDiarias", typeof(decimal)));
		ObjectParameter val95 = (valorUnitarioDiarias.HasValue ? new ObjectParameter("ValorUnitarioDiarias", (object)valorUnitarioDiarias) : new ObjectParameter("ValorUnitarioDiarias", typeof(decimal)));
		ObjectParameter val96 = (projetoMaterialConsumoUID.HasValue ? new ObjectParameter("ProjetoMaterialConsumoUID", (object)projetoMaterialConsumoUID) : new ObjectParameter("ProjetoMaterialConsumoUID", typeof(long)));
		ObjectParameter val97 = (tipoMaterialConsumoUID.HasValue ? new ObjectParameter("TipoMaterialConsumoUID", (object)tipoMaterialConsumoUID) : new ObjectParameter("TipoMaterialConsumoUID", typeof(short)));
		ObjectParameter val98 = (quantidadeMaterialConsumo.HasValue ? new ObjectParameter("QuantidadeMaterialConsumo", (object)quantidadeMaterialConsumo) : new ObjectParameter("QuantidadeMaterialConsumo", typeof(short)));
		ObjectParameter val99 = (valorUnitarioMaterialConsumo.HasValue ? new ObjectParameter("ValorUnitarioMaterialConsumo", (object)valorUnitarioMaterialConsumo) : new ObjectParameter("ValorUnitarioMaterialConsumo", typeof(decimal)));
		ObjectParameter val100 = (projetoPassagensUID.HasValue ? new ObjectParameter("ProjetoPassagensUID", (object)projetoPassagensUID) : new ObjectParameter("ProjetoPassagensUID", typeof(long)));
		ObjectParameter val101 = (tipoPassagemUID.HasValue ? new ObjectParameter("TipoPassagemUID", (object)tipoPassagemUID) : new ObjectParameter("TipoPassagemUID", typeof(byte)));
		ObjectParameter val102 = ((trecho != null) ? new ObjectParameter("Trecho", (object)trecho) : new ObjectParameter("Trecho", typeof(string)));
		ObjectParameter val103 = (quantidadePassagens.HasValue ? new ObjectParameter("QuantidadePassagens", (object)quantidadePassagens) : new ObjectParameter("QuantidadePassagens", typeof(short)));
		ObjectParameter val104 = (valorUnitarioPassagens.HasValue ? new ObjectParameter("ValorUnitarioPassagens", (object)valorUnitarioPassagens) : new ObjectParameter("ValorUnitarioPassagens", typeof(decimal)));
		ObjectParameter val105 = (projetoEquipamentoUID.HasValue ? new ObjectParameter("ProjetoEquipamentoUID", (object)projetoEquipamentoUID) : new ObjectParameter("ProjetoEquipamentoUID", typeof(long)));
		ObjectParameter val106 = (tipoEquipamentoUID.HasValue ? new ObjectParameter("TipoEquipamentoUID", (object)tipoEquipamentoUID) : new ObjectParameter("TipoEquipamentoUID", typeof(short)));
		ObjectParameter val107 = (quantidadeEquipamentos.HasValue ? new ObjectParameter("QuantidadeEquipamentos", (object)quantidadeEquipamentos) : new ObjectParameter("QuantidadeEquipamentos", typeof(short)));
		ObjectParameter val108 = (valorUnitarioEquipamentos.HasValue ? new ObjectParameter("ValorUnitarioEquipamentos", (object)valorUnitarioEquipamentos) : new ObjectParameter("ValorUnitarioEquipamentos", typeof(decimal)));
		ObjectParameter val109 = (projetoPessoalEncargosUID.HasValue ? new ObjectParameter("ProjetoPessoalEncargosUID", (object)projetoPessoalEncargosUID) : new ObjectParameter("ProjetoPessoalEncargosUID", typeof(long)));
		ObjectParameter val110 = (tipoAtividadeUID.HasValue ? new ObjectParameter("TipoAtividadeUID", (object)tipoAtividadeUID) : new ObjectParameter("TipoAtividadeUID", typeof(byte)));
		ObjectParameter val111 = (dataInicioPessoalEncargos.HasValue ? new ObjectParameter("DataInicioPessoalEncargos", (object)dataInicioPessoalEncargos) : new ObjectParameter("DataInicioPessoalEncargos", typeof(DateTime)));
		ObjectParameter val112 = (dataFimPessoalEncargos.HasValue ? new ObjectParameter("DataFimPessoalEncargos", (object)dataFimPessoalEncargos) : new ObjectParameter("DataFimPessoalEncargos", typeof(DateTime)));
		ObjectParameter val113 = (valorMensalPessoalEncargos.HasValue ? new ObjectParameter("ValorMensalPessoalEncargos", (object)valorMensalPessoalEncargos) : new ObjectParameter("ValorMensalPessoalEncargos", typeof(decimal)));
		ObjectParameter val114 = (projetoDespesasUID.HasValue ? new ObjectParameter("ProjetoDespesasUID", (object)projetoDespesasUID) : new ObjectParameter("ProjetoDespesasUID", typeof(long)));
		ObjectParameter val115 = (tipoDespesaUID.HasValue ? new ObjectParameter("TipoDespesaUID", (object)tipoDespesaUID) : new ObjectParameter("TipoDespesaUID", typeof(short)));
		ObjectParameter val116 = (quantidadeDespesa.HasValue ? new ObjectParameter("QuantidadeDespesa", (object)quantidadeDespesa) : new ObjectParameter("QuantidadeDespesa", typeof(short)));
		ObjectParameter val117 = (valorUnitarioDespesa.HasValue ? new ObjectParameter("ValorUnitarioDespesa", (object)valorUnitarioDespesa) : new ObjectParameter("ValorUnitarioDespesa", typeof(decimal)));
		ObjectParameter val118 = (projetoPrevisaoReceitasUID.HasValue ? new ObjectParameter("ProjetoPrevisaoReceitasUID", (object)projetoPrevisaoReceitasUID) : new ObjectParameter("ProjetoPrevisaoReceitasUID", typeof(long)));
		ObjectParameter val119 = (tipoReceitaUID.HasValue ? new ObjectParameter("TipoReceitaUID", (object)tipoReceitaUID) : new ObjectParameter("TipoReceitaUID", typeof(short)));
		ObjectParameter val120 = (numeroAlunos.HasValue ? new ObjectParameter("NumeroAlunos", (object)numeroAlunos) : new ObjectParameter("NumeroAlunos", typeof(short)));
		ObjectParameter val121 = (numeroParcelas.HasValue ? new ObjectParameter("NumeroParcelas", (object)numeroParcelas) : new ObjectParameter("NumeroParcelas", typeof(short)));
		ObjectParameter val122 = (valorUnitarioPrevisaoReceita.HasValue ? new ObjectParameter("ValorUnitarioPrevisaoReceita", (object)valorUnitarioPrevisaoReceita) : new ObjectParameter("ValorUnitarioPrevisaoReceita", typeof(decimal)));
		ObjectParameter val123 = (projetoServicoTerceirosPessoJuridicaUID.HasValue ? new ObjectParameter("ProjetoServicoTerceirosPessoJuridicaUID", (object)projetoServicoTerceirosPessoJuridicaUID) : new ObjectParameter("ProjetoServicoTerceirosPessoJuridicaUID", typeof(long)));
		ObjectParameter val124 = (tipoServicoTerceirosPessoaJuridicaUID.HasValue ? new ObjectParameter("TipoServicoTerceirosPessoaJuridicaUID", (object)tipoServicoTerceirosPessoaJuridicaUID) : new ObjectParameter("TipoServicoTerceirosPessoaJuridicaUID", typeof(short)));
		ObjectParameter val125 = (quantidadeServicoTerceirosPJ.HasValue ? new ObjectParameter("QuantidadeServicoTerceirosPJ", (object)quantidadeServicoTerceirosPJ) : new ObjectParameter("QuantidadeServicoTerceirosPJ", typeof(short)));
		ObjectParameter val126 = (valorUnitarioServicoTerceirosPJ.HasValue ? new ObjectParameter("ValorUnitarioServicoTerceirosPJ", (object)valorUnitarioServicoTerceirosPJ) : new ObjectParameter("ValorUnitarioServicoTerceirosPJ", typeof(decimal)));
		ObjectParameter val127 = (projetoCursoComplementoPresencialUID.HasValue ? new ObjectParameter("ProjetoCursoComplementoPresencialUID", (object)projetoCursoComplementoPresencialUID) : new ObjectParameter("ProjetoCursoComplementoPresencialUID", typeof(long)));
		ObjectParameter val128 = (tipoTurnoOfertaUID.HasValue ? new ObjectParameter("TipoTurnoOfertaUID", (object)tipoTurnoOfertaUID) : new ObjectParameter("TipoTurnoOfertaUID", typeof(byte)));
		ObjectParameter val129 = (tipoPeriodicidadeUID.HasValue ? new ObjectParameter("TipoPeriodicidadeUID", (object)tipoPeriodicidadeUID) : new ObjectParameter("TipoPeriodicidadeUID", typeof(byte)));
		ObjectParameter val130 = (cargaHorariaPeriodicidade.HasValue ? new ObjectParameter("cargaHorariaPeriodicidade", (object)cargaHorariaPeriodicidade) : new ObjectParameter("cargaHorariaPeriodicidade", typeof(short)));
		ObjectParameter val131 = (enderecoUID.HasValue ? new ObjectParameter("EnderecoUID", (object)enderecoUID) : new ObjectParameter("EnderecoUID", typeof(long)));
		ObjectParameter val132 = (projetoCursoVagasUID.HasValue ? new ObjectParameter("ProjetoCursoVagasUID", (object)projetoCursoVagasUID) : new ObjectParameter("ProjetoCursoVagasUID", typeof(long)));
		ObjectParameter val133 = (numeroVagas.HasValue ? new ObjectParameter("NumeroVagas", (object)numeroVagas) : new ObjectParameter("NumeroVagas", typeof(short)));
		ObjectParameter val134 = (tipoVagasUID.HasValue ? new ObjectParameter("TipoVagasUID", (object)tipoVagasUID) : new ObjectParameter("TipoVagasUID", typeof(byte)));
		ObjectParameter val135 = (projetoCursoComplementoPresencialVagasUID.HasValue ? new ObjectParameter("ProjetoCursoComplementoPresencialVagasUID", (object)projetoCursoComplementoPresencialVagasUID) : new ObjectParameter("ProjetoCursoComplementoPresencialVagasUID", typeof(long)));
		ObjectParameter val136 = (projetoCursoComplementoEadUID.HasValue ? new ObjectParameter("ProjetoCursoComplementoEadUID", (object)projetoCursoComplementoEadUID) : new ObjectParameter("ProjetoCursoComplementoEadUID", typeof(long)));
		ObjectParameter val137 = ((descricaoMaterialDidaticoTextualMultimidia != null) ? new ObjectParameter("DescricaoMaterialDidaticoTextualMultimidia", (object)descricaoMaterialDidaticoTextualMultimidia) : new ObjectParameter("DescricaoMaterialDidaticoTextualMultimidia", typeof(string)));
		ObjectParameter val138 = ((descricaoAmbienteVirtualAprendizagem != null) ? new ObjectParameter("DescricaoAmbienteVirtualAprendizagem", (object)descricaoAmbienteVirtualAprendizagem) : new ObjectParameter("DescricaoAmbienteVirtualAprendizagem", typeof(string)));
		ObjectParameter val139 = (dataInicioInscricao.HasValue ? new ObjectParameter("DataInicioInscricao", (object)dataInicioInscricao) : new ObjectParameter("DataInicioInscricao", typeof(DateTime)));
		ObjectParameter val140 = (dataFimInscricao.HasValue ? new ObjectParameter("DataFimInscricao", (object)dataFimInscricao) : new ObjectParameter("DataFimInscricao", typeof(DateTime)));
		ObjectParameter val141 = (dataInicioSelecao.HasValue ? new ObjectParameter("DataInicioSelecao", (object)dataInicioSelecao) : new ObjectParameter("DataInicioSelecao", typeof(DateTime)));
		ObjectParameter val142 = (dataFimSelecao.HasValue ? new ObjectParameter("DataFimSelecao", (object)dataFimSelecao) : new ObjectParameter("DataFimSelecao", typeof(DateTime)));
		ObjectParameter val143 = (dataInicioMatricula.HasValue ? new ObjectParameter("DataInicioMatricula", (object)dataInicioMatricula) : new ObjectParameter("DataInicioMatricula", typeof(DateTime)));
		ObjectParameter val144 = (dataFimMatricula.HasValue ? new ObjectParameter("DataFimMatricula", (object)dataFimMatricula) : new ObjectParameter("DataFimMatricula", typeof(DateTime)));
		ObjectParameter val145 = (dataPrevisaoInicioAulas.HasValue ? new ObjectParameter("DataPrevisaoInicioAulas", (object)dataPrevisaoInicioAulas) : new ObjectParameter("DataPrevisaoInicioAulas", typeof(DateTime)));
		ObjectParameter val146 = ((criteriosSelecao != null) ? new ObjectParameter("CriteriosSelecao", (object)criteriosSelecao) : new ObjectParameter("CriteriosSelecao", typeof(string)));
		ObjectParameter val147 = ((criteriosComprovacaoCarenciaFinanceira != null) ? new ObjectParameter("CriteriosComprovacaoCarenciaFinanceira", (object)criteriosComprovacaoCarenciaFinanceira) : new ObjectParameter("CriteriosComprovacaoCarenciaFinanceira", typeof(string)));
		ObjectParameter val148 = ((descricaoSelecaoCandidatos != null) ? new ObjectParameter("DescricaoSelecaoCandidatos", (object)descricaoSelecaoCandidatos) : new ObjectParameter("DescricaoSelecaoCandidatos", typeof(string)));
		ObjectParameter val149 = ((procedimentoRecursoAdm != null) ? new ObjectParameter("ProcedimentoRecursoAdm", (object)procedimentoRecursoAdm) : new ObjectParameter("ProcedimentoRecursoAdm", typeof(string)));
		ObjectParameter val150 = ((procedimentoDivulgacaoResultadoFinal != null) ? new ObjectParameter("ProcedimentoDivulgacaoResultadoFinal", (object)procedimentoDivulgacaoResultadoFinal) : new ObjectParameter("ProcedimentoDivulgacaoResultadoFinal", typeof(string)));
		ObjectParameter val151 = ((orientacoesProcedimentoMatricula != null) ? new ObjectParameter("OrientacoesProcedimentoMatricula", (object)orientacoesProcedimentoMatricula) : new ObjectParameter("OrientacoesProcedimentoMatricula", typeof(string)));
		ObjectParameter val152 = ((procedimentoRealizacaoSegundaChamada != null) ? new ObjectParameter("ProcedimentoRealizacaoSegundaChamada", (object)procedimentoRealizacaoSegundaChamada) : new ObjectParameter("ProcedimentoRealizacaoSegundaChamada", typeof(string)));
		ObjectParameter val153 = (projetoCorpoDocenteMaterialDidaticoEadUID.HasValue ? new ObjectParameter("ProjetoCorpoDocenteMaterialDidaticoEadUID", (object)projetoCorpoDocenteMaterialDidaticoEadUID) : new ObjectParameter("ProjetoCorpoDocenteMaterialDidaticoEadUID", typeof(long)));
		ObjectParameter val154 = ((descricaoMaterial != null) ? new ObjectParameter("DescricaoMaterial", (object)descricaoMaterial) : new ObjectParameter("DescricaoMaterial", typeof(string)));
		ObjectParameter val155 = (projetoCursoComplementoEadEnderecoUID.HasValue ? new ObjectParameter("ProjetoCursoComplementoEadEnderecoUID", (object)projetoCursoComplementoEadEnderecoUID) : new ObjectParameter("ProjetoCursoComplementoEadEnderecoUID", typeof(long)));
		ObjectParameter val156 = (tipoEnderecoEadUID.HasValue ? new ObjectParameter("TipoEnderecoEadUID", (object)tipoEnderecoEadUID) : new ObjectParameter("TipoEnderecoEadUID", typeof(byte)));
		ObjectParameter val157 = (projetoCursoComplementoEadVagasUID.HasValue ? new ObjectParameter("ProjetoCursoComplementoEadVagasUID", (object)projetoCursoComplementoEadVagasUID) : new ObjectParameter("ProjetoCursoComplementoEadVagasUID", typeof(long)));
		ObjectParameter val158 = (poloEadEnderecoUID.HasValue ? new ObjectParameter("PoloEadEnderecoUID", (object)poloEadEnderecoUID) : new ObjectParameter("PoloEadEnderecoUID", typeof(long)));
		ObjectParameter val159 = (projetoServicoTerceirosPessoFisicaUID.HasValue ? new ObjectParameter("ProjetoServicoTerceirosPessoFisicaUID", (object)projetoServicoTerceirosPessoFisicaUID) : new ObjectParameter("ProjetoServicoTerceirosPessoFisicaUID", typeof(long)));
		ObjectParameter val160 = (atividadeNaoRegularServicoTerceirosPF.HasValue ? new ObjectParameter("AtividadeNaoRegularServicoTerceirosPF", (object)atividadeNaoRegularServicoTerceirosPF) : new ObjectParameter("AtividadeNaoRegularServicoTerceirosPF", typeof(bool)));
		ObjectParameter val161 = (dataInicioServicoTerceirosPF.HasValue ? new ObjectParameter("DataInicioServicoTerceirosPF", (object)dataInicioServicoTerceirosPF) : new ObjectParameter("DataInicioServicoTerceirosPF", typeof(DateTime)));
		ObjectParameter val162 = (dataFimServicoTerceirosPF.HasValue ? new ObjectParameter("DataFimServicoTerceirosPF", (object)dataFimServicoTerceirosPF) : new ObjectParameter("DataFimServicoTerceirosPF", typeof(DateTime)));
		ObjectParameter val163 = (cargaHorariaMensalSevicoTerceirosPF.HasValue ? new ObjectParameter("CargaHorariaMensalSevicoTerceirosPF", (object)cargaHorariaMensalSevicoTerceirosPF) : new ObjectParameter("CargaHorariaMensalSevicoTerceirosPF", typeof(short)));
		ObjectParameter val164 = (cargaHorariaTotalServicoTerceirosPF.HasValue ? new ObjectParameter("CargaHorariaTotalServicoTerceirosPF", (object)cargaHorariaTotalServicoTerceirosPF) : new ObjectParameter("CargaHorariaTotalServicoTerceirosPF", typeof(short)));
		ObjectParameter val165 = (valorUnitarioCargaHorariaServicoTerceirosPF.HasValue ? new ObjectParameter("ValorUnitarioCargaHorariaServicoTerceirosPF", (object)valorUnitarioCargaHorariaServicoTerceirosPF) : new ObjectParameter("ValorUnitarioCargaHorariaServicoTerceirosPF", typeof(decimal)));
		ObjectParameter val166 = (encargosSociaisServicoTerceirosPF.HasValue ? new ObjectParameter("EncargosSociaisServicoTerceirosPF", (object)encargosSociaisServicoTerceirosPF) : new ObjectParameter("EncargosSociaisServicoTerceirosPF", typeof(decimal)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureManterProjetoCurso", new ObjectParameter[169]
		{
			val, val2, codigoProjetoCurso, val3, val4, val5, val6, val7, val8, val9,
			val10, val11, val12, val13, val14, val15, val16, val17, val18, val19,
			val20, val21, val22, val23, val24, val25, val26, val27, val28, val29,
			val30, val31, val32, val33, val34, val35, val36, val37, val38, val39,
			val40, val41, val42, val43, val44, val45, val46, val47, val48, val49,
			val50, val51, val52, val53, val54, val55, val56, val57, val58, val59,
			projetoCursoUID_Saida, val60, val61, val62, val63, val64, val65, val66, val67, val68,
			val69, val70, val71, val72, val73, val74, val75, val76, val77, val78,
			val79, val80, val81, val82, val83, val84, val85, val86, val87, val88,
			val89, val90, val91, val92, val93, val94, val95, val96, val97, val98,
			val99, val100, val101, val102, val103, val104, val105, val106, val107, val108,
			val109, val110, val111, val112, val113, val114, val115, val116, val117, val118,
			val119, val120, val121, val122, val123, val124, val125, val126, val127, val128,
			val129, val130, val131, val132, val133, val134, val135, val136, val137, val138,
			val139, val140, val141, val142, val143, val144, val145, val146, val147, val148,
			val149, val150, val151, val152, val153, val154, val155, val156, val157, val158,
			val159, val160, val161, val162, val163, val164, val165, val166, erroSaida
		});
	}

	public virtual int ProcedureManterProjetoDisciplina(byte? operacao, long? projetoDisciplinaUID, string nome, short? cargaHoraria, DateTime? dataInicio, DateTime? dataTermino, string ementa, string bibliografia, ObjectParameter disciplinaUIDSaida, ObjectParameter erroSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		ObjectParameter val = (operacao.HasValue ? new ObjectParameter("Operacao", (object)operacao) : new ObjectParameter("Operacao", typeof(byte)));
		ObjectParameter val2 = (projetoDisciplinaUID.HasValue ? new ObjectParameter("ProjetoDisciplinaUID", (object)projetoDisciplinaUID) : new ObjectParameter("ProjetoDisciplinaUID", typeof(long)));
		ObjectParameter val3 = ((nome != null) ? new ObjectParameter("Nome", (object)nome) : new ObjectParameter("Nome", typeof(string)));
		ObjectParameter val4 = (cargaHoraria.HasValue ? new ObjectParameter("CargaHoraria", (object)cargaHoraria) : new ObjectParameter("CargaHoraria", typeof(short)));
		ObjectParameter val5 = (dataInicio.HasValue ? new ObjectParameter("DataInicio", (object)dataInicio) : new ObjectParameter("DataInicio", typeof(DateTime)));
		ObjectParameter val6 = (dataTermino.HasValue ? new ObjectParameter("DataTermino", (object)dataTermino) : new ObjectParameter("DataTermino", typeof(DateTime)));
		ObjectParameter val7 = ((ementa != null) ? new ObjectParameter("Ementa", (object)ementa) : new ObjectParameter("Ementa", typeof(string)));
		ObjectParameter val8 = ((bibliografia != null) ? new ObjectParameter("Bibliografia", (object)bibliografia) : new ObjectParameter("Bibliografia", typeof(string)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureManterProjetoDisciplina", new ObjectParameter[10] { val, val2, val3, val4, val5, val6, val7, val8, disciplinaUIDSaida, erroSaida });
	}

	public virtual int ProcedureGerarRegistroDiscentes(long? estruturaCurricularUID, ObjectParameter registroDiscenteSaida)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		ObjectParameter val = (estruturaCurricularUID.HasValue ? new ObjectParameter("EstruturaCurricularUID", (object)estruturaCurricularUID) : new ObjectParameter("EstruturaCurricularUID", typeof(long)));
		return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProcedureGerarRegistroDiscentes", new ObjectParameter[2] { val, registroDiscenteSaida });
	}
}
