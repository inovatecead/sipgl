using System;
using System.Collections.Generic;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCorpoDocente
{
	public long projetoCorpoDocenteUID { get; set; }

	public long? servidorUID { get; set; }

	public string nome { get; set; }

	public string sexo { get; set; }

	public DateTime? dataNascimento { get; set; }

	public string nomeMae { get; set; }

	public string nomePai { get; set; }

	public string cpf { get; set; }

	public string rg { get; set; }

	public DateTime? dataExpedicao { get; set; }

	public string telefoneFixo { get; set; }

	public string celular { get; set; }

	public string email { get; set; }

	public int? tipoTitulacaoUID { get; set; }

	public short? orgaoExpedidorUID { get; set; }

	public string orgaoExpedidorUFUID { get; set; }

	public virtual ServidorIDBUFMT Servidor { get; set; }

	public virtual TipoOrgaoExpedidorRg TipoOrgaoExpedidorRg { get; set; }

	public virtual TipoTitulacao TipoTitulacao { get; set; }

	public virtual UF UF { get; set; }

	public virtual ICollection<ProjetoTurmaDisciplina> ProjetoTurmaDisciplina { get; set; }

	public virtual ICollection<ProjetoTurmaDisciplina> ProjetoTurmaDisciplina1 { get; set; }

	public ProjetoCorpoDocente()
	{
		ProjetoTurmaDisciplina = new HashSet<ProjetoTurmaDisciplina>();
		ProjetoTurmaDisciplina1 = new HashSet<ProjetoTurmaDisciplina>();
	}
}
