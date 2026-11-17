using System;
using System.Collections.Generic;
using ufmt.sig.entity;

namespace ufmt.sig.business;

public interface ICursoBO : IDisposable
{
	AlocacaoDisciplinar GetAlocacaoDisciplinar(long alocacaoDisciplinarUID);

	void CrieAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID);

	void CrieAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID, float cargaHoraria);

	void RemovaAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID);

	void RemovaDivisaoDisciplinar(long alocacaoDisciplinarUID);

	void CrieDivisaoDisciplinarSubTurmas(long alocacaoDisciplinarPrincipalUID, int quantidadeSubTurmas, IList<string> identificacoesSubTurmas, string justificativa, long servidorEditorUID, bool isCoordenador);

	void CrieDivisaoDisciplinarCoMinistrada(long alocacaoDisciplinarPrincipalUID, int quantidadeProfessores, long servidorEditorUID, bool isCoordenador);

	void CrieDivisaoDisciplinarFracionamento(long alocacaoDisciplinarPrincipalUID, IList<DivisaoDisciplinar> divisoesDisciplinares, long servidorEditorUID, bool isCoordenador);

	void CrieDivisaoDisciplinarFracionamentoModificado(long alocacaoDisciplinarPrincipalUID, IList<DivisaoDisciplinar> divisoesDisciplinares, long servidorEditorUID, bool isCoordenador);

	PlanoPedagogico GetPlanoPedagogicoMaisAtual(long codigoExterno, int nivelCursoUID, int formatoCursoUID);

	PlanoPedagogico getPlanoPedagogico(long matrizCurricularUID);

	void cadastrarPlanoPedagogico(long matrizCurricularUID, string nomeArquivo, string tipoConteudo, byte[] arquivo, DateTime dataModificacao);

	void AlocarDisciplina(long alocacaoDisciplinarUID, long servidorDocenteUID, int? quantidadeOrientandos, bool forcarSemestral);

	void DesalocarDisciplina(long alocacaoDisciplinarUID, long servidorDocenteUID);

	bool verificarRemocaoCascata(long alocacaoDisciplinarUID);

	bool verificarPermissaoRemocaoCascata(long alocacaoPrincipalUID);

	bool verificarProfessorAlocadoCascata(long alocacaoPrincipalUID);

	void marqueAlocacaoComoNaoFracionada(long alocacaoPrincipalUID);

	void removeAlocacaoEmCascata(long alocacaoPrincipalUID);

	IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, int? campusUID, int? nivelCursoUID, long? unidadeOfertanteDisciplinaUID, int? firstRowIndex, int? maximumRows);

	IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, long unidadeOfertanteUID);

	IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, int? campusUID, int? nivelCursoUID, long? unidadeOfertanteDisciplinaUID, int formatoCursoUID, int? firstRowIndex, int? maximumRows);

	IList<Curso> GetCursosAlocacoesDisciplinares(int ano, short periodo, long unidadeOfertanteUID, int formatoCursoUID);

	IList<MatrizDisciplinar> GetMatrizesDisciplinaresAlocacoesDisciplinares(int ano, short periodo, long matrizCurricularUID);

	IList<MatrizDisciplinar> GetMatrizesDisciplinaresAlocacoesDisciplinares(int ano, short periodo, long matrizCurricularUID, long unidadeOfertanteUID);

	IList<AlocacaoDisciplinar> GetDivisoesDisciplinares(long alocacaoDisciplinarPrincipalUID);

	IList<MatrizCurricular> GetMatrizesCurricularesAlocacoesDisciplinares(int ano, short periodo, int? campusUID, int? nivelCursoUID, long? cursoUID, long? unidadeOfertanteDisciplinaUID, int? firstRowIndex, int? maximumRows);

	IList<MatrizCurricular> GetMatrizesCurricularesAlocacoesDisciplinares(int ano, short periodo, long cursoUID, long unidadeOfertanteUID);

	void SalveAlocacaoDisciplinar(AlocacaoDisciplinar alocacaoDisciplinar, bool horaPreparoPadrao, bool forcarSemestral);

	void RealocarDisciplinasDeOutroPeriodo(int ano, short periodo, IList<AlocacaoDisciplinar> alocacoes);

	IList<AlocacaoDisciplinar> GetAlocacoesDisciplinares(int ano, short periodo, long? cursoUID, long? matrizCurricularUID, int? firstRowIndex, int? maximumRows);

	IList<AlocacaoDisciplinar> GetAlocacoesDisciplinares(int ano, short? periodo, long servidorDocenteUID, int? nivelCursoUID, long? cursoUID, long? matrizCurricularUID, int? firstRowIndex, int? maximumRows);

	IList<AlocacaoDisciplinar> GetAlocacoesDisciplinares(int ano, short periodo, long matrizDisciplinarUID);

	Curso GetCurso(long cursoUID);

	IList<Curso> GetCursos(int? campusUID, int? nivelCursoUID, long? pessoaCoordenadorUID, int? firstRowIndex, int? maximumRows);

	IList<Curso> GetCursos(int? campusUID, int? nivelCursoUID, int? firstRowIndex, int? maximumRows);

	IList<Curso> GetCursos(int? campusUID, long? unidadeOfertanteUID);

	void SalveCurso(Curso curso);

	IList<MatrizCurricular> GetMatrizesCurriculares(int? campusUID, int? nivelCursoUID, long? cursoUID, int? firstRowIndex, int? maximumRows);

	IList<MatrizCurricular> GetMatrizesCurricularesAtivas(int? campusUID, int? nivelCursoUID, long? cursoUID, int? firstRowIndex, int? maximumRows);

	MatrizCurricular GetMatrizCurricular(long matrizCurricularUID);

	IList<MatrizDisciplinar> GetMatrizesDisciplinares(int? campusUID, int? nivelCursoUID, long? cursoUID, long? matrizCurricularUID, int? firstRowIndex, int? maximumRows);

	bool ExisteAlocacaoDisciplinar(int ano, short periodo, long matrizDisciplinarUID);

	MatrizDisciplinar GetMatrizDisciplinar(long matrizDisciplinarUID);

	void SalveMatrizDisciplinar(MatrizDisciplinar matrizDisciplinar);

	void DefinaUnidadeOfertanteMatrizDisciplinar(long matrizDisciplinarUID, long unidadeUID);

	void DefinaUnidadeOfertanteCurso(long cursoUID, long unidadeUID);

	void RemovaUnidadeOfertanteCurso(long cursoUID);

	IList<TipoTecnologiaAssistiva> getTiposTecnologiaAssistiva();

	IList<TecnologiaAssistiva> getTecnologiasAssistivas(long cursoUID);

	void cadastrarTecnologiaAssistiva(long cursoUID, string tipoTecnologiaAssistivaUID);

	void removerTecnologiaAssistiva(long cursoUID, string tipoTecnologiaAssistivaUID);
}
