using System;

namespace ufmt.sipgl.DataAccess;

public class ProjetoCorpoDocenteDTO
{
	public long ProjetoCorpoDocenteUID { get; set; }

	public long? ServidorUID { get; set; }

	public string Siape { get; set; }

	public string SiapeDV { get; set; }

	public string Nome { get; set; }

	public string Sexo { get; set; }

	public DateTime? DataNascimento { get; set; }

	public string NomeMae { get; set; }

	public string NomePai { get; set; }

	public string Cpf { get; set; }

	public string Rg { get; set; }

	public DateTime? DataExpedicao { get; set; }

	public string TelefoneFixo { get; set; }

	public string Celular { get; set; }

	public string Email { get; set; }

	public int? TipoTitulacaoUID { get; set; }

	public string DescricaoTipoTitulacao { get; set; }

	public short? OrgaoExpedidorUID { get; set; }

	public string DescricaoOrgaoExpedidor { get; set; }

	public string orgaoExpedidorUFUID { get; set; }

	public string DescricaoOrgaoExpedidorUF { get; set; }
}
