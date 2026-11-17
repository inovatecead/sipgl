using ufmt.sipgl.DataAccess.Enums;

namespace ufmt.sipgl.DataAccess;

public class ResultadoOperacao
{
	public int? CodigoCursoSaida { get; set; }

	public int? CodigoProjetoCursoSaida { get; set; }

	public long? CursoUIDSaida { get; set; }

	public long? UIDSaida { get; set; }

	public long? EstruturaCurricularUIDSaida { get; set; }

	public int? resultado { get; set; }

	public bool Erro { get; set; }

	public TypeMessageEnum TypeMessageEnum { get; set; }

	public string TextMessage { get; set; }

	public string Data { get; set; }

	public ResultadoOperacao()
	{
		Erro = false;
	}
}
