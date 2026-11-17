using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class Usuario
{
	public long usuarioUID { get; set; }

	public long pessoaUID { get; set; }

	public string nomeAcesso { get; set; }

	public string senhaAcesso { get; set; }

	public bool bloqueado { get; set; }

	public DateTime? dataUltimoAcesso { get; set; }

	public DateTime? dataProximaTrocaSenha { get; set; }

	public DateTime? dataAcessoBloqueado { get; set; }

	public virtual ICollection<PermissaoUsuario> PermissaoUsuario { get; set; }

	public virtual PessoaIDBUFMT Pessoa { get; set; }

	public virtual ICollection<ProjetoPreInscricao> ProjetoPreInscricao { get; set; }

	public virtual ICollection<PreMatriculaInscricaoOcorrencia> PreMatriculaInscricaoOcorrencia { get; set; }

	public virtual ICollection<ProjetoFrequenciaHistorico> ProjetoFrequenciaHistorico { get; set; }

	public virtual ICollection<ProjetoNotaHistorico> ProjetoNotaHistorico { get; set; }

	public virtual ICollection<ProjetoUsuarioUnidade> ProjetoUsuarioUnidade { get; set; }

	public virtual ICollection<ProjetoCurso> ProjetoCurso { get; set; }

	public Usuario()
	{
		PermissaoUsuario = new HashSet<PermissaoUsuario>();
		ProjetoPreInscricao = new HashSet<ProjetoPreInscricao>();
		PreMatriculaInscricaoOcorrencia = new HashSet<PreMatriculaInscricaoOcorrencia>();
		ProjetoFrequenciaHistorico = new HashSet<ProjetoFrequenciaHistorico>();
		ProjetoNotaHistorico = new HashSet<ProjetoNotaHistorico>();
		ProjetoUsuarioUnidade = new HashSet<ProjetoUsuarioUnidade>();
		ProjetoCurso = new HashSet<ProjetoCurso>();
	}
}
