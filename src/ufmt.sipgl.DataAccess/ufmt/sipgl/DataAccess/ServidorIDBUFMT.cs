using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ServidorIDBUFMT
{
	public long servidorUID { get; set; }

	public long pessoaUID { get; set; }

	public string registro { get; set; }

	public string registroDV { get; set; }

	public string tipoRegistro { get; set; }

	public string regimeJuridico { get; set; }

	public int jornadaTrabalhoUID { get; set; }

	public long cargoUID { get; set; }

	public string cargoClasse { get; set; }

	public string cargoReferenciaNivelPadrao { get; set; }

	public long? unidadeLotacaoUID { get; set; }

	public string aposentadoriaNumeroProcesso { get; set; }

	public int? aposentadoriaAnoPrevisto { get; set; }

	public string aposentadoriaOpcaoIntegral { get; set; }

	public int? situacaoSiape { get; set; }

	public int situacaoServidorUID { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ICollection<Coordenador> Coordenador { get; set; }

	public virtual ICollection<CorrecaoCursoMensagens> CorrecaoCursoMensagens { get; set; }

	public virtual ICollection<Docencia> Docencia { get; set; }

	public virtual ICollection<ProjetoBolsaoLei_8958_94> ProjetoBolsaoLei_8958_94 { get; set; }

	public virtual ICollection<ProjetoColegiadoCurso> ProjetoColegiadoCurso { get; set; }

	public virtual ICollection<ProjetoCorpoDocenteMaterialDidaticoEad> ProjetoCorpoDocenteMaterialDidaticoEad { get; set; }

	public virtual ICollection<ProjetoCorpoDocente> ProjetoCorpoDocente { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso1 { get; set; }

	public ServidorIDBUFMT()
	{
		Coordenador = new HashSet<Coordenador>();
		CorrecaoCursoMensagens = new HashSet<CorrecaoCursoMensagens>();
		Docencia = new HashSet<Docencia>();
		ProjetoBolsaoLei_8958_94 = new HashSet<ProjetoBolsaoLei_8958_94>();
		ProjetoColegiadoCurso = new HashSet<ProjetoColegiadoCurso>();
		ProjetoCorpoDocenteMaterialDidaticoEad = new HashSet<ProjetoCorpoDocenteMaterialDidaticoEad>();
		ProjetoCorpoDocente = new HashSet<ProjetoCorpoDocente>();
		ProjetoCurso = new HashSet<ProjetoCurso>();
		ProjetoCurso1 = new HashSet<ProjetoCurso>();
	}
}
