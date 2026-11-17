using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CsvHelper;

namespace ufmt.sipgl.DataAccess;

public class ImportacaoDAL
{
	private readonly string _caminho;

	private const int tipoSituacaoInscricao = 3;

	public ImportacaoDAL(string caminho)
	{
		_caminho = caminho;
	}

	public void Homologados(int quantidade)
	{
		CsvReader csvReader = new CsvReader(File.OpenText(_caminho + "/App_Data/HomologadosEAD-2018-02-09.csv"));
		csvReader.Configuration.RegisterClassMap<ViewImportacaoDadosHomogadosPosGraduacaoEAD2017Map>();
		IEnumerable<ViewImportacaoDadosHomogadosPosGraduacaoEAD2017> records = csvReader.GetRecords<ViewImportacaoDadosHomogadosPosGraduacaoEAD2017>();
		EntidadesIdbufmt contextInstance = Contexto.GetContextInstance();
		int num = 0;
		foreach (ViewImportacaoDadosHomogadosPosGraduacaoEAD2017 item in records)
		{
			GetProjetoCursoID(item.NomeCurso.Trim());
			PreMatriculaPessoa pessoa = contextInstance.PreMatriculaPessoa.SingleOrDefault((PreMatriculaPessoa x) => x.cpf.Equals(item.CPF));
			if (pessoa != null)
			{
				if (contextInstance.PreMatriculaInscricao.Where((PreMatriculaInscricao x) => x.preMatriculaPessoaUID == pessoa.preMatriculaPessoaUID).SingleOrDefault() != null)
				{
					continue;
				}
				DadosPessoa(pessoa, item);
				contextInstance.Entry(pessoa).State = (EntityState)16;
			}
			else
			{
				pessoa = new PreMatriculaPessoa();
				DadosPessoa(pessoa, item);
				contextInstance.PreMatriculaPessoa.Add(pessoa);
			}
			PreMatriculaInscricao entity = new PreMatriculaInscricao
			{
				preMatriculaPessoaUID = pessoa.preMatriculaPessoaUID,
				numeroInscricao = GerarNumeroPreMatriculaInscricao(contextInstance),
				tipoSituacaoInscricaoUID = 3
			};
			contextInstance.PreMatriculaInscricao.Add(entity);
			contextInstance.SaveChanges();
			num++;
			if (num >= quantidade)
			{
				break;
			}
		}
	}

	private void DadosPessoa(PreMatriculaPessoa pessoa, ViewImportacaoDadosHomogadosPosGraduacaoEAD2017 item)
	{
		if (pessoa.preMatriculaPessoaUID == 0L)
		{
			pessoa.cpf = item.CPF;
			pessoa.graduacaoInstituicaoEnsinoUID = 1;
			pessoa.graduacaoDataColacaoGrau = new DateTime(2017, 1, 1);
			pessoa.dataHoraCadastro = DateTime.Now;
		}
		pessoa.nome = item.Nome;
		pessoa.sexo = item.Sexo.ElementAt(0).ToString();
		pessoa.nascimentoData = item.DataNascimento;
		pessoa.nomeMae = item.NomeMae;
		pessoa.nomePai = item.NomePai;
		pessoa.rgNumero = item.RgNumero;
		pessoa.rgUFUID = item.RgUFSigla;
		pessoa.rgOrgaoExpedidor = item.RgOrgaoExpedidor;
		pessoa.rgDataExpedicao = item.RgDataExpedicao;
		pessoa.tipoEstadoCivilUID = GetTipoEstadoCivil(item.EstadoCivilUID.GetValueOrDefault());
		pessoa.nacionalidade = item.Nacionalidade;
		pessoa.naturalidadeMunicipioUID = item.NaturalidadeMunicipioUID;
		pessoa.email = item.Email;
		pessoa.enderecoLogradouro = item.EnderecoLogradouro;
		pessoa.enderecoNumero = item.EnderecoNumero;
		pessoa.enderecoComplemento = item.EnderecoComplemento;
		pessoa.enderecoBairro = item.EnderecoBairro;
		pessoa.enderecoCEP = item.EnderecoCep;
		pessoa.enderecoMunicipioUID = item.EnderecoMunicipioUID;
		pessoa.telefoneFixo = item.TelefoneFixo;
		pessoa.telefoneMovel = item.TelefoneCelular;
		pessoa.diplomaGraduacaoExterior = false;
		pessoa.tipoFaixaRendaFamiliarUID = GetTipoFaixaRendaFamiliar(item.FaixaRendaFamiliar);
		pessoa.tipoCorRacaUID = item.CorRacaUID;
		pessoa.dataHoraUltimaAtualizacao = DateTime.Now;
		pessoa.senha = getMD5Hash(item.Senha);
	}

	private int GetProjetoCursoID(string nome)
	{
		return new Dictionary<int, string>
		{
			{ 130, "ESPECIALIZAÇÃO EM GESTÃO PÚBLICA" },
			{ 131, "ESPECIALIZAÇÃO EM DIVERSIDADE E EDUCAÇÃO INCLUSIVA NO CONTEXTO DAS CIÊNCIAS NATURAIS" },
			{ 132, "ESPECIALIZAÇÃO EM MÍDIAS DIGITAIS PARA A EDUCAÇÃO" },
			{ 133, "ESPECIALIZAÇÃO EM INFORMÁTICA NA EDUCAÇÃO" }
		}.First((KeyValuePair<int, string> x) => x.Value.Equals(nome)).Key;
	}

	private int GerarNumeroPreMatriculaInscricao(EntidadesIdbufmt contexto)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected Obj, but got Unknown
		ObjectParameter val = new ObjectParameter("NumeroInscricaoSaida", typeof(int));
		contexto.ProcedureGerarNumeroPreMatriculaInscricao(val);
		return (int)val.Value;
	}

	private byte GetTipoEstadoCivil(byte estadoCivil)
	{
		switch (estadoCivil)
		{
		case 5:
		case 6:
			return 2;
		case 0:
		case 7:
			return 1;
		default:
			return estadoCivil;
		}
	}

	private byte GetTipoFaixaRendaFamiliar(string faixaRendaFamiliar)
	{
		return 1;
	}

	private string getMD5Hash(string input)
	{
		MD5 mD = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = mD.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("X2"));
		}
		return stringBuilder.ToString().ToLower();
	}
}
