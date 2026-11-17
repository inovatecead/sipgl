using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using ufmt.sipgl.View.Properties;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[WebServiceBinding(Name = "BasicHttpBinding_IAutenticacao", Namespace = "http://tempuri.org/")]
public class Autenticacao : SoapHttpClientProtocol
{
	private SendOrPostCallback GetVinculosPorPessoaBySituacaoOperationCompleted;

	private SendOrPostCallback LoginDelphiOperationCompleted;

	private SendOrPostCallback LoginOperationCompleted;

	private SendOrPostCallback LoginDocenteOperationCompleted;

	private SendOrPostCallback LoginPorSituacaoOperationCompleted;

	private SendOrPostCallback VerificaDadosOperationCompleted;

	private SendOrPostCallback GetVinculoPessoaSimplesOperationCompleted;

	private SendOrPostCallback GetVinculoDocenteOperationCompleted;

	private SendOrPostCallback GetPessoaOperationCompleted;

	private SendOrPostCallback GetPessoasOperationCompleted;

	private SendOrPostCallback GetVinculosPorPessoaOperationCompleted;

	private SendOrPostCallback LoginAlunoOperationCompleted;

	private SendOrPostCallback LoginAlunoPorChaveOperationCompleted;

	private SendOrPostCallback LoginDiscenteOperationCompleted;

	private SendOrPostCallback LoginCoordenadorCursoOperationCompleted;

	private SendOrPostCallback GetPermissaoOperationCompleted;

	private SendOrPostCallback GetPermissaoPorUsuarioAplicacaoOperationCompleted;

	private SendOrPostCallback GetCoordenadorPorChaveOperationCompleted;

	private SendOrPostCallback GetColaboradorCAEPorChaveOperationCompleted;

	private SendOrPostCallback GetCoordenadorPorChaveCodigoCursoOperationCompleted;

	private SendOrPostCallback ReiniciarSenhaOperationCompleted;

	private SendOrPostCallback ReiniciarSenhaIPOperationCompleted;

	private SendOrPostCallback ReiniciarSenhaIntegradoOperationCompleted;

	private SendOrPostCallback CriarUsuarioOperationCompleted;

	private SendOrPostCallback AlterarSenhaOperationCompleted;

	private SendOrPostCallback AlterarSenhaIPOperationCompleted;

	private SendOrPostCallback GetPessoasPorPermissaoOperationCompleted;

	private SendOrPostCallback SalvarPermissaoUsuarioOperationCompleted;

	private SendOrPostCallback GetUsuarioPorPessoaOperationCompleted;

	private SendOrPostCallback GetUsuarioPorNomeAcessoOperationCompleted;

	private SendOrPostCallback GetDocentePorChaveOperationCompleted;

	private SendOrPostCallback LoginEstudanteGeralOperationCompleted;

	private SendOrPostCallback LoginEstudanteGeralPorCampiOperationCompleted;

	private SendOrPostCallback GetPermissaoCampusPorPermissaoOperationCompleted;

	private SendOrPostCallback LoginEstudanteDPROperationCompleted;

	private SendOrPostCallback ValidarTokenOperationCompleted;

	private SendOrPostCallback ValidarTokenAlunoOperationCompleted;

	private SendOrPostCallback GetPermissoesPorAplicacaoOperationCompleted;

	private SendOrPostCallback GetPermissoesAtivasEUsuariosPorAplicacaoOperationCompleted;

	private SendOrPostCallback CriarUsuarioExternoOperationCompleted;

	private SendOrPostCallback CriarUsuarioExternoComSenhaOperationCompleted;

	private SendOrPostCallback GetPerfilAcessoOperationCompleted;

	private bool useDefaultCredentialsSetExplicitly;

	public string Url
	{
		get
		{
			return ((WebClientProtocol)this).Url;
		}
		set
		{
			if (IsLocalFileSystemWebService(((WebClientProtocol)this).Url) && !useDefaultCredentialsSetExplicitly && !IsLocalFileSystemWebService(value))
			{
				((WebClientProtocol)this).UseDefaultCredentials = false;
			}
			((WebClientProtocol)this).Url = value;
		}
	}

	public bool UseDefaultCredentials
	{
		get
		{
			return ((WebClientProtocol)this).UseDefaultCredentials;
		}
		set
		{
			((WebClientProtocol)this).UseDefaultCredentials = value;
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	public event GetVinculosPorPessoaBySituacaoCompletedEventHandler GetVinculosPorPessoaBySituacaoCompleted;

	public event LoginDelphiCompletedEventHandler LoginDelphiCompleted;

	public event LoginCompletedEventHandler LoginCompleted;

	public event LoginDocenteCompletedEventHandler LoginDocenteCompleted;

	public event LoginPorSituacaoCompletedEventHandler LoginPorSituacaoCompleted;

	public event VerificaDadosCompletedEventHandler VerificaDadosCompleted;

	public event GetVinculoPessoaSimplesCompletedEventHandler GetVinculoPessoaSimplesCompleted;

	public event GetVinculoDocenteCompletedEventHandler GetVinculoDocenteCompleted;

	public event GetPessoaCompletedEventHandler GetPessoaCompleted;

	public event GetPessoasCompletedEventHandler GetPessoasCompleted;

	public event GetVinculosPorPessoaCompletedEventHandler GetVinculosPorPessoaCompleted;

	public event LoginAlunoCompletedEventHandler LoginAlunoCompleted;

	public event LoginAlunoPorChaveCompletedEventHandler LoginAlunoPorChaveCompleted;

	public event LoginDiscenteCompletedEventHandler LoginDiscenteCompleted;

	public event LoginCoordenadorCursoCompletedEventHandler LoginCoordenadorCursoCompleted;

	public event GetPermissaoCompletedEventHandler GetPermissaoCompleted;

	public event GetPermissaoPorUsuarioAplicacaoCompletedEventHandler GetPermissaoPorUsuarioAplicacaoCompleted;

	public event GetCoordenadorPorChaveCompletedEventHandler GetCoordenadorPorChaveCompleted;

	public event GetColaboradorCAEPorChaveCompletedEventHandler GetColaboradorCAEPorChaveCompleted;

	public event GetCoordenadorPorChaveCodigoCursoCompletedEventHandler GetCoordenadorPorChaveCodigoCursoCompleted;

	public event ReiniciarSenhaCompletedEventHandler ReiniciarSenhaCompleted;

	public event ReiniciarSenhaIPCompletedEventHandler ReiniciarSenhaIPCompleted;

	public event ReiniciarSenhaIntegradoCompletedEventHandler ReiniciarSenhaIntegradoCompleted;

	public event CriarUsuarioCompletedEventHandler CriarUsuarioCompleted;

	public event AlterarSenhaCompletedEventHandler AlterarSenhaCompleted;

	public event AlterarSenhaIPCompletedEventHandler AlterarSenhaIPCompleted;

	public event GetPessoasPorPermissaoCompletedEventHandler GetPessoasPorPermissaoCompleted;

	public event SalvarPermissaoUsuarioCompletedEventHandler SalvarPermissaoUsuarioCompleted;

	public event GetUsuarioPorPessoaCompletedEventHandler GetUsuarioPorPessoaCompleted;

	public event GetUsuarioPorNomeAcessoCompletedEventHandler GetUsuarioPorNomeAcessoCompleted;

	public event GetDocentePorChaveCompletedEventHandler GetDocentePorChaveCompleted;

	public event LoginEstudanteGeralCompletedEventHandler LoginEstudanteGeralCompleted;

	public event LoginEstudanteGeralPorCampiCompletedEventHandler LoginEstudanteGeralPorCampiCompleted;

	public event GetPermissaoCampusPorPermissaoCompletedEventHandler GetPermissaoCampusPorPermissaoCompleted;

	public event LoginEstudanteDPRCompletedEventHandler LoginEstudanteDPRCompleted;

	public event ValidarTokenCompletedEventHandler ValidarTokenCompleted;

	public event ValidarTokenAlunoCompletedEventHandler ValidarTokenAlunoCompleted;

	public event GetPermissoesPorAplicacaoCompletedEventHandler GetPermissoesPorAplicacaoCompleted;

	public event GetPermissoesAtivasEUsuariosPorAplicacaoCompletedEventHandler GetPermissoesAtivasEUsuariosPorAplicacaoCompleted;

	public event CriarUsuarioExternoCompletedEventHandler CriarUsuarioExternoCompleted;

	public event CriarUsuarioExternoComSenhaCompletedEventHandler CriarUsuarioExternoComSenhaCompleted;

	public event GetPerfilAcessoCompletedEventHandler GetPerfilAcessoCompleted;

	public Autenticacao()
	{
		Url = Settings.Default.ufmt_sipgl_View_br_ufmt_sistemas_Autenticacao;
		if (IsLocalFileSystemWebService(Url))
		{
			UseDefaultCredentials = true;
			useDefaultCredentialsSetExplicitly = false;
		}
		else
		{
			useDefaultCredentialsSetExplicitly = true;
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.sig.entity")]
	public Servidor[] GetVinculosPorPessoaBySituacao(long pessoaUID, [XmlIgnore] bool pessoaUIDSpecified, bool somenteAtivos, [XmlIgnore] bool somenteAtivosSpecified)
	{
		return (Servidor[])this.Invoke("GetVinculosPorPessoaBySituacao", new object[4] { pessoaUID, pessoaUIDSpecified, somenteAtivos, somenteAtivosSpecified })[0];
	}

	public void GetVinculosPorPessoaBySituacaoAsync(long pessoaUID, bool pessoaUIDSpecified, bool somenteAtivos, bool somenteAtivosSpecified)
	{
		GetVinculosPorPessoaBySituacaoAsync(pessoaUID, pessoaUIDSpecified, somenteAtivos, somenteAtivosSpecified, null);
	}

	public void GetVinculosPorPessoaBySituacaoAsync(long pessoaUID, bool pessoaUIDSpecified, bool somenteAtivos, bool somenteAtivosSpecified, object userState)
	{
		if (GetVinculosPorPessoaBySituacaoOperationCompleted == null)
		{
			GetVinculosPorPessoaBySituacaoOperationCompleted = OnGetVinculosPorPessoaBySituacaoOperationCompleted;
		}
		this.InvokeAsync("GetVinculosPorPessoaBySituacao", new object[4] { pessoaUID, pessoaUIDSpecified, somenteAtivos, somenteAtivosSpecified }, GetVinculosPorPessoaBySituacaoOperationCompleted, userState);
	}

	private void OnGetVinculosPorPessoaBySituacaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetVinculosPorPessoaBySituacaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetVinculosPorPessoaBySituacaoCompleted(this, new GetVinculosPorPessoaBySituacaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Usuario LoginDelphi([XmlElement(IsNullable = true)] string nomeAcesso, [XmlElement(IsNullable = true)] string senha)
	{
		return (Usuario)this.Invoke("LoginDelphi", new object[2] { nomeAcesso, senha })[0];
	}

	public void LoginDelphiAsync(string nomeAcesso, string senha)
	{
		LoginDelphiAsync(nomeAcesso, senha, null);
	}

	public void LoginDelphiAsync(string nomeAcesso, string senha, object userState)
	{
		if (LoginDelphiOperationCompleted == null)
		{
			LoginDelphiOperationCompleted = OnLoginDelphiOperationCompleted;
		}
		this.InvokeAsync("LoginDelphi", new object[2] { nomeAcesso, senha }, LoginDelphiOperationCompleted, userState);
	}

	private void OnLoginDelphiOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginDelphiCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginDelphiCompleted(this, new LoginDelphiCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Usuario Login([XmlElement(IsNullable = true)] string nomeAcesso, [XmlElement(IsNullable = true)] string senha)
	{
		return (Usuario)this.Invoke("Login", new object[2] { nomeAcesso, senha })[0];
	}

	public void LoginAsync(string nomeAcesso, string senha)
	{
		LoginAsync(nomeAcesso, senha, null);
	}

	public void LoginAsync(string nomeAcesso, string senha, object userState)
	{
		if (LoginOperationCompleted == null)
		{
			LoginOperationCompleted = OnLoginOperationCompleted;
		}
		this.InvokeAsync("Login", new object[2] { nomeAcesso, senha }, LoginOperationCompleted, userState);
	}

	private void OnLoginOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginCompleted(this, new LoginCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Usuario LoginDocente([XmlElement(IsNullable = true)] string nomeAcesso, [XmlElement(IsNullable = true)] string senha)
	{
		return (Usuario)this.Invoke("LoginDocente", new object[2] { nomeAcesso, senha })[0];
	}

	public void LoginDocenteAsync(string nomeAcesso, string senha)
	{
		LoginDocenteAsync(nomeAcesso, senha, null);
	}

	public void LoginDocenteAsync(string nomeAcesso, string senha, object userState)
	{
		if (LoginDocenteOperationCompleted == null)
		{
			LoginDocenteOperationCompleted = OnLoginDocenteOperationCompleted;
		}
		this.InvokeAsync("LoginDocente", new object[2] { nomeAcesso, senha }, LoginDocenteOperationCompleted, userState);
	}

	private void OnLoginDocenteOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginDocenteCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginDocenteCompleted(this, new LoginDocenteCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Usuario LoginPorSituacao([XmlElement(IsNullable = true)] string nomeAcesso, [XmlElement(IsNullable = true)] string senhaAcesso, [XmlArray(IsNullable = true)][XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services", IsNullable = false)] SituacaoDoServidor[] situacoes)
	{
		return (Usuario)this.Invoke("LoginPorSituacao", new object[3] { nomeAcesso, senhaAcesso, situacoes })[0];
	}

	public void LoginPorSituacaoAsync(string nomeAcesso, string senhaAcesso, SituacaoDoServidor[] situacoes)
	{
		LoginPorSituacaoAsync(nomeAcesso, senhaAcesso, situacoes, null);
	}

	public void LoginPorSituacaoAsync(string nomeAcesso, string senhaAcesso, SituacaoDoServidor[] situacoes, object userState)
	{
		if (LoginPorSituacaoOperationCompleted == null)
		{
			LoginPorSituacaoOperationCompleted = OnLoginPorSituacaoOperationCompleted;
		}
		this.InvokeAsync("LoginPorSituacao", new object[3] { nomeAcesso, senhaAcesso, situacoes }, LoginPorSituacaoOperationCompleted, userState);
	}

	private void OnLoginPorSituacaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginPorSituacaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginPorSituacaoCompleted(this, new LoginPorSituacaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public string VerificaDados([XmlElement(IsNullable = true)] string nomeAcesso, [XmlElement(IsNullable = true)] string senha)
	{
		return (string)this.Invoke("VerificaDados", new object[2] { nomeAcesso, senha })[0];
	}

	public void VerificaDadosAsync(string nomeAcesso, string senha)
	{
		VerificaDadosAsync(nomeAcesso, senha, null);
	}

	public void VerificaDadosAsync(string nomeAcesso, string senha, object userState)
	{
		if (VerificaDadosOperationCompleted == null)
		{
			VerificaDadosOperationCompleted = OnVerificaDadosOperationCompleted;
		}
		this.InvokeAsync("VerificaDados", new object[2] { nomeAcesso, senha }, VerificaDadosOperationCompleted, userState);
	}

	private void OnVerificaDadosOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (VerificaDadosCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			VerificaDadosCompleted(this, new VerificaDadosCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Servidor GetVinculoPessoaSimples(long pessoaUID, [XmlIgnore] bool pessoaUIDSpecified)
	{
		return (Servidor)this.Invoke("GetVinculoPessoaSimples", new object[2] { pessoaUID, pessoaUIDSpecified })[0];
	}

	public void GetVinculoPessoaSimplesAsync(long pessoaUID, bool pessoaUIDSpecified)
	{
		GetVinculoPessoaSimplesAsync(pessoaUID, pessoaUIDSpecified, null);
	}

	public void GetVinculoPessoaSimplesAsync(long pessoaUID, bool pessoaUIDSpecified, object userState)
	{
		if (GetVinculoPessoaSimplesOperationCompleted == null)
		{
			GetVinculoPessoaSimplesOperationCompleted = OnGetVinculoPessoaSimplesOperationCompleted;
		}
		this.InvokeAsync("GetVinculoPessoaSimples", new object[2] { pessoaUID, pessoaUIDSpecified }, GetVinculoPessoaSimplesOperationCompleted, userState);
	}

	private void OnGetVinculoPessoaSimplesOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetVinculoPessoaSimplesCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetVinculoPessoaSimplesCompleted(this, new GetVinculoPessoaSimplesCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.sig.entity")]
	public Servidor[] GetVinculoDocente(long pessoaUID, [XmlIgnore] bool pessoaUIDSpecified)
	{
		return (Servidor[])this.Invoke("GetVinculoDocente", new object[2] { pessoaUID, pessoaUIDSpecified })[0];
	}

	public void GetVinculoDocenteAsync(long pessoaUID, bool pessoaUIDSpecified)
	{
		GetVinculoDocenteAsync(pessoaUID, pessoaUIDSpecified, null);
	}

	public void GetVinculoDocenteAsync(long pessoaUID, bool pessoaUIDSpecified, object userState)
	{
		if (GetVinculoDocenteOperationCompleted == null)
		{
			GetVinculoDocenteOperationCompleted = OnGetVinculoDocenteOperationCompleted;
		}
		this.InvokeAsync("GetVinculoDocente", new object[2] { pessoaUID, pessoaUIDSpecified }, GetVinculoDocenteOperationCompleted, userState);
	}

	private void OnGetVinculoDocenteOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetVinculoDocenteCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetVinculoDocenteCompleted(this, new GetVinculoDocenteCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public PessoaEntity GetPessoa(long pessoaUID, [XmlIgnore] bool pessoaUIDSpecified)
	{
		return (PessoaEntity)this.Invoke("GetPessoa", new object[2] { pessoaUID, pessoaUIDSpecified })[0];
	}

	public void GetPessoaAsync(long pessoaUID, bool pessoaUIDSpecified)
	{
		GetPessoaAsync(pessoaUID, pessoaUIDSpecified, null);
	}

	public void GetPessoaAsync(long pessoaUID, bool pessoaUIDSpecified, object userState)
	{
		if (GetPessoaOperationCompleted == null)
		{
			GetPessoaOperationCompleted = OnGetPessoaOperationCompleted;
		}
		this.InvokeAsync("GetPessoa", new object[2] { pessoaUID, pessoaUIDSpecified }, GetPessoaOperationCompleted, userState);
	}

	private void OnGetPessoaOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPessoaCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPessoaCompleted(this, new GetPessoaCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.sig.entity")]
	public Pessoa[] GetPessoas([XmlElement(IsNullable = true)] string Nome)
	{
		return (Pessoa[])this.Invoke("GetPessoas", new object[1] { Nome })[0];
	}

	public void GetPessoasAsync(string Nome)
	{
		GetPessoasAsync(Nome, null);
	}

	public void GetPessoasAsync(string Nome, object userState)
	{
		if (GetPessoasOperationCompleted == null)
		{
			GetPessoasOperationCompleted = OnGetPessoasOperationCompleted;
		}
		this.InvokeAsync("GetPessoas", new object[1] { Nome }, GetPessoasOperationCompleted, userState);
	}

	private void OnGetPessoasOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPessoasCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPessoasCompleted(this, new GetPessoasCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.sig.entity")]
	public Servidor[] GetVinculosPorPessoa(long pessoaUID, [XmlIgnore] bool pessoaUIDSpecified)
	{
		return (Servidor[])this.Invoke("GetVinculosPorPessoa", new object[2] { pessoaUID, pessoaUIDSpecified })[0];
	}

	public void GetVinculosPorPessoaAsync(long pessoaUID, bool pessoaUIDSpecified)
	{
		GetVinculosPorPessoaAsync(pessoaUID, pessoaUIDSpecified, null);
	}

	public void GetVinculosPorPessoaAsync(long pessoaUID, bool pessoaUIDSpecified, object userState)
	{
		if (GetVinculosPorPessoaOperationCompleted == null)
		{
			GetVinculosPorPessoaOperationCompleted = OnGetVinculosPorPessoaOperationCompleted;
		}
		this.InvokeAsync("GetVinculosPorPessoa", new object[2] { pessoaUID, pessoaUIDSpecified }, GetVinculosPorPessoaOperationCompleted, userState);
	}

	private void OnGetVinculosPorPessoaOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetVinculosPorPessoaCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetVinculosPorPessoaCompleted(this, new GetVinculosPorPessoaCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Aluno LoginAluno([XmlElement(IsNullable = true)] string rga, [XmlElement(IsNullable = true)] string senha)
	{
		return (Aluno)this.Invoke("LoginAluno", new object[2] { rga, senha })[0];
	}

	public void LoginAlunoAsync(string rga, string senha)
	{
		LoginAlunoAsync(rga, senha, null);
	}

	public void LoginAlunoAsync(string rga, string senha, object userState)
	{
		if (LoginAlunoOperationCompleted == null)
		{
			LoginAlunoOperationCompleted = OnLoginAlunoOperationCompleted;
		}
		this.InvokeAsync("LoginAluno", new object[2] { rga, senha }, LoginAlunoOperationCompleted, userState);
	}

	private void OnLoginAlunoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginAlunoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginAlunoCompleted(this, new LoginAlunoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Aluno LoginAlunoPorChave([XmlElement(IsNullable = true)] string chave)
	{
		return (Aluno)this.Invoke("LoginAlunoPorChave", new object[1] { chave })[0];
	}

	public void LoginAlunoPorChaveAsync(string chave)
	{
		LoginAlunoPorChaveAsync(chave, null);
	}

	public void LoginAlunoPorChaveAsync(string chave, object userState)
	{
		if (LoginAlunoPorChaveOperationCompleted == null)
		{
			LoginAlunoPorChaveOperationCompleted = OnLoginAlunoPorChaveOperationCompleted;
		}
		this.InvokeAsync("LoginAlunoPorChave", new object[1] { chave }, LoginAlunoPorChaveOperationCompleted, userState);
	}

	private void OnLoginAlunoPorChaveOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginAlunoPorChaveCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginAlunoPorChaveCompleted(this, new LoginAlunoPorChaveCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Aluno LoginDiscente([XmlElement(IsNullable = true)] string rga, [XmlElement(IsNullable = true)] string senha)
	{
		return (Aluno)this.Invoke("LoginDiscente", new object[2] { rga, senha })[0];
	}

	public void LoginDiscenteAsync(string rga, string senha)
	{
		LoginDiscenteAsync(rga, senha, null);
	}

	public void LoginDiscenteAsync(string rga, string senha, object userState)
	{
		if (LoginDiscenteOperationCompleted == null)
		{
			LoginDiscenteOperationCompleted = OnLoginDiscenteOperationCompleted;
		}
		this.InvokeAsync("LoginDiscente", new object[2] { rga, senha }, LoginDiscenteOperationCompleted, userState);
	}

	private void OnLoginDiscenteOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginDiscenteCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginDiscenteCompleted(this, new LoginDiscenteCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Coordenador LoginCoordenadorCurso([XmlElement(IsNullable = true)] string username, [XmlElement(IsNullable = true)] string password)
	{
		return (Coordenador)this.Invoke("LoginCoordenadorCurso", new object[2] { username, password })[0];
	}

	public void LoginCoordenadorCursoAsync(string username, string password)
	{
		LoginCoordenadorCursoAsync(username, password, null);
	}

	public void LoginCoordenadorCursoAsync(string username, string password, object userState)
	{
		if (LoginCoordenadorCursoOperationCompleted == null)
		{
			LoginCoordenadorCursoOperationCompleted = OnLoginCoordenadorCursoOperationCompleted;
		}
		this.InvokeAsync("LoginCoordenadorCurso", new object[2] { username, password }, LoginCoordenadorCursoOperationCompleted, userState);
	}

	private void OnLoginCoordenadorCursoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginCoordenadorCursoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginCoordenadorCursoCompleted(this, new LoginCoordenadorCursoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public PermissaoUsuario GetPermissao(long aplicacaoUID, [XmlIgnore] bool aplicacaoUIDSpecified, long permissaoUID, [XmlIgnore] bool permissaoUIDSpecified, long usuarioUID, [XmlIgnore] bool usuarioUIDSpecified)
	{
		return (PermissaoUsuario)this.Invoke("GetPermissao", new object[6] { aplicacaoUID, aplicacaoUIDSpecified, permissaoUID, permissaoUIDSpecified, usuarioUID, usuarioUIDSpecified })[0];
	}

	public void GetPermissaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified, long permissaoUID, bool permissaoUIDSpecified, long usuarioUID, bool usuarioUIDSpecified)
	{
		GetPermissaoAsync(aplicacaoUID, aplicacaoUIDSpecified, permissaoUID, permissaoUIDSpecified, usuarioUID, usuarioUIDSpecified, null);
	}

	public void GetPermissaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified, long permissaoUID, bool permissaoUIDSpecified, long usuarioUID, bool usuarioUIDSpecified, object userState)
	{
		if (GetPermissaoOperationCompleted == null)
		{
			GetPermissaoOperationCompleted = OnGetPermissaoOperationCompleted;
		}
		this.InvokeAsync("GetPermissao", new object[6] { aplicacaoUID, aplicacaoUIDSpecified, permissaoUID, permissaoUIDSpecified, usuarioUID, usuarioUIDSpecified }, GetPermissaoOperationCompleted, userState);
	}

	private void OnGetPermissaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPermissaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPermissaoCompleted(this, new GetPermissaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
	public PermissaoUsuarioEntity[] GetPermissaoPorUsuarioAplicacao(long aplicacaoUID, [XmlIgnore] bool aplicacaoUIDSpecified, long usuarioUID, [XmlIgnore] bool usuarioUIDSpecified)
	{
		return (PermissaoUsuarioEntity[])this.Invoke("GetPermissaoPorUsuarioAplicacao", new object[4] { aplicacaoUID, aplicacaoUIDSpecified, usuarioUID, usuarioUIDSpecified })[0];
	}

	public void GetPermissaoPorUsuarioAplicacaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified, long usuarioUID, bool usuarioUIDSpecified)
	{
		GetPermissaoPorUsuarioAplicacaoAsync(aplicacaoUID, aplicacaoUIDSpecified, usuarioUID, usuarioUIDSpecified, null);
	}

	public void GetPermissaoPorUsuarioAplicacaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified, long usuarioUID, bool usuarioUIDSpecified, object userState)
	{
		if (GetPermissaoPorUsuarioAplicacaoOperationCompleted == null)
		{
			GetPermissaoPorUsuarioAplicacaoOperationCompleted = OnGetPermissaoPorUsuarioAplicacaoOperationCompleted;
		}
		this.InvokeAsync("GetPermissaoPorUsuarioAplicacao", new object[4] { aplicacaoUID, aplicacaoUIDSpecified, usuarioUID, usuarioUIDSpecified }, GetPermissaoPorUsuarioAplicacaoOperationCompleted, userState);
	}

	private void OnGetPermissaoPorUsuarioAplicacaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPermissaoPorUsuarioAplicacaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPermissaoPorUsuarioAplicacaoCompleted(this, new GetPermissaoPorUsuarioAplicacaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Coordenador GetCoordenadorPorChave([XmlElement(IsNullable = true)] string chave)
	{
		return (Coordenador)this.Invoke("GetCoordenadorPorChave", new object[1] { chave })[0];
	}

	public void GetCoordenadorPorChaveAsync(string chave)
	{
		GetCoordenadorPorChaveAsync(chave, null);
	}

	public void GetCoordenadorPorChaveAsync(string chave, object userState)
	{
		if (GetCoordenadorPorChaveOperationCompleted == null)
		{
			GetCoordenadorPorChaveOperationCompleted = OnGetCoordenadorPorChaveOperationCompleted;
		}
		this.InvokeAsync("GetCoordenadorPorChave", new object[1] { chave }, GetCoordenadorPorChaveOperationCompleted, userState);
	}

	private void OnGetCoordenadorPorChaveOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetCoordenadorPorChaveCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetCoordenadorPorChaveCompleted(this, new GetCoordenadorPorChaveCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public PessoaEntity GetColaboradorCAEPorChave([XmlElement(IsNullable = true)] string chave)
	{
		return (PessoaEntity)this.Invoke("GetColaboradorCAEPorChave", new object[1] { chave })[0];
	}

	public void GetColaboradorCAEPorChaveAsync(string chave)
	{
		GetColaboradorCAEPorChaveAsync(chave, null);
	}

	public void GetColaboradorCAEPorChaveAsync(string chave, object userState)
	{
		if (GetColaboradorCAEPorChaveOperationCompleted == null)
		{
			GetColaboradorCAEPorChaveOperationCompleted = OnGetColaboradorCAEPorChaveOperationCompleted;
		}
		this.InvokeAsync("GetColaboradorCAEPorChave", new object[1] { chave }, GetColaboradorCAEPorChaveOperationCompleted, userState);
	}

	private void OnGetColaboradorCAEPorChaveOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetColaboradorCAEPorChaveCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetColaboradorCAEPorChaveCompleted(this, new GetColaboradorCAEPorChaveCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Coordenador GetCoordenadorPorChaveCodigoCurso([XmlElement(IsNullable = true)] string chave, [XmlElement(IsNullable = true)] string codigoCurso)
	{
		return (Coordenador)this.Invoke("GetCoordenadorPorChaveCodigoCurso", new object[2] { chave, codigoCurso })[0];
	}

	public void GetCoordenadorPorChaveCodigoCursoAsync(string chave, string codigoCurso)
	{
		GetCoordenadorPorChaveCodigoCursoAsync(chave, codigoCurso, null);
	}

	public void GetCoordenadorPorChaveCodigoCursoAsync(string chave, string codigoCurso, object userState)
	{
		if (GetCoordenadorPorChaveCodigoCursoOperationCompleted == null)
		{
			GetCoordenadorPorChaveCodigoCursoOperationCompleted = OnGetCoordenadorPorChaveCodigoCursoOperationCompleted;
		}
		this.InvokeAsync("GetCoordenadorPorChaveCodigoCurso", new object[2] { chave, codigoCurso }, GetCoordenadorPorChaveCodigoCursoOperationCompleted, userState);
	}

	private void OnGetCoordenadorPorChaveCodigoCursoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetCoordenadorPorChaveCodigoCursoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetCoordenadorPorChaveCodigoCursoCompleted(this, new GetCoordenadorPorChaveCodigoCursoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void ReiniciarSenha([XmlElement(IsNullable = true)] string cpf)
	{
		this.Invoke("ReiniciarSenha", new object[1] { cpf });
	}

	public void ReiniciarSenhaAsync(string cpf)
	{
		ReiniciarSenhaAsync(cpf, null);
	}

	public void ReiniciarSenhaAsync(string cpf, object userState)
	{
		if (ReiniciarSenhaOperationCompleted == null)
		{
			ReiniciarSenhaOperationCompleted = OnReiniciarSenhaOperationCompleted;
		}
		this.InvokeAsync("ReiniciarSenha", new object[1] { cpf }, ReiniciarSenhaOperationCompleted, userState);
	}

	private void OnReiniciarSenhaOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (ReiniciarSenhaCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			ReiniciarSenhaCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void ReiniciarSenhaIP([XmlElement(IsNullable = true)] string cpf, [XmlElement(IsNullable = true)] string ip)
	{
		this.Invoke("ReiniciarSenhaIP", new object[2] { cpf, ip });
	}

	public void ReiniciarSenhaIPAsync(string cpf, string ip)
	{
		ReiniciarSenhaIPAsync(cpf, ip, null);
	}

	public void ReiniciarSenhaIPAsync(string cpf, string ip, object userState)
	{
		if (ReiniciarSenhaIPOperationCompleted == null)
		{
			ReiniciarSenhaIPOperationCompleted = OnReiniciarSenhaIPOperationCompleted;
		}
		this.InvokeAsync("ReiniciarSenhaIP", new object[2] { cpf, ip }, ReiniciarSenhaIPOperationCompleted, userState);
	}

	private void OnReiniciarSenhaIPOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (ReiniciarSenhaIPCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			ReiniciarSenhaIPCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void ReiniciarSenhaIntegrado([XmlElement(IsNullable = true)] string cpf)
	{
		this.Invoke("ReiniciarSenhaIntegrado", new object[1] { cpf });
	}

	public void ReiniciarSenhaIntegradoAsync(string cpf)
	{
		ReiniciarSenhaIntegradoAsync(cpf, null);
	}

	public void ReiniciarSenhaIntegradoAsync(string cpf, object userState)
	{
		if (ReiniciarSenhaIntegradoOperationCompleted == null)
		{
			ReiniciarSenhaIntegradoOperationCompleted = OnReiniciarSenhaIntegradoOperationCompleted;
		}
		this.InvokeAsync("ReiniciarSenhaIntegrado", new object[1] { cpf }, ReiniciarSenhaIntegradoOperationCompleted, userState);
	}

	private void OnReiniciarSenhaIntegradoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (ReiniciarSenhaIntegradoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			ReiniciarSenhaIntegradoCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void CriarUsuario([XmlElement(IsNullable = true)] string cpf, [XmlElement(IsNullable = true)] string siape, [XmlElement(IsNullable = true)] string email)
	{
		this.Invoke("CriarUsuario", new object[3] { cpf, siape, email });
	}

	public void CriarUsuarioAsync(string cpf, string siape, string email)
	{
		CriarUsuarioAsync(cpf, siape, email, null);
	}

	public void CriarUsuarioAsync(string cpf, string siape, string email, object userState)
	{
		if (CriarUsuarioOperationCompleted == null)
		{
			CriarUsuarioOperationCompleted = OnCriarUsuarioOperationCompleted;
		}
		this.InvokeAsync("CriarUsuario", new object[3] { cpf, siape, email }, CriarUsuarioOperationCompleted, userState);
	}

	private void OnCriarUsuarioOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (CriarUsuarioCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			CriarUsuarioCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void AlterarSenha([XmlElement(IsNullable = true)] string cpf, [XmlElement(IsNullable = true)] string senhaAtual, [XmlElement(IsNullable = true)] string novaSenha)
	{
		this.Invoke("AlterarSenha", new object[3] { cpf, senhaAtual, novaSenha });
	}

	public void AlterarSenhaAsync(string cpf, string senhaAtual, string novaSenha)
	{
		AlterarSenhaAsync(cpf, senhaAtual, novaSenha, null);
	}

	public void AlterarSenhaAsync(string cpf, string senhaAtual, string novaSenha, object userState)
	{
		if (AlterarSenhaOperationCompleted == null)
		{
			AlterarSenhaOperationCompleted = OnAlterarSenhaOperationCompleted;
		}
		this.InvokeAsync("AlterarSenha", new object[3] { cpf, senhaAtual, novaSenha }, AlterarSenhaOperationCompleted, userState);
	}

	private void OnAlterarSenhaOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (AlterarSenhaCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			AlterarSenhaCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void AlterarSenhaIP([XmlElement(IsNullable = true)] string cpf, [XmlElement(IsNullable = true)] string senhaAtual, [XmlElement(IsNullable = true)] string novaSenha, [XmlElement(IsNullable = true)] string ip)
	{
		this.Invoke("AlterarSenhaIP", new object[4] { cpf, senhaAtual, novaSenha, ip });
	}

	public void AlterarSenhaIPAsync(string cpf, string senhaAtual, string novaSenha, string ip)
	{
		AlterarSenhaIPAsync(cpf, senhaAtual, novaSenha, ip, null);
	}

	public void AlterarSenhaIPAsync(string cpf, string senhaAtual, string novaSenha, string ip, object userState)
	{
		if (AlterarSenhaIPOperationCompleted == null)
		{
			AlterarSenhaIPOperationCompleted = OnAlterarSenhaIPOperationCompleted;
		}
		this.InvokeAsync("AlterarSenhaIP", new object[4] { cpf, senhaAtual, novaSenha, ip }, AlterarSenhaIPOperationCompleted, userState);
	}

	private void OnAlterarSenhaIPOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (AlterarSenhaIPCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			AlterarSenhaIPCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
	public PessoaEntity[] GetPessoasPorPermissao(long permissaoUID, [XmlIgnore] bool permissaoUIDSpecified)
	{
		return (PessoaEntity[])this.Invoke("GetPessoasPorPermissao", new object[2] { permissaoUID, permissaoUIDSpecified })[0];
	}

	public void GetPessoasPorPermissaoAsync(long permissaoUID, bool permissaoUIDSpecified)
	{
		GetPessoasPorPermissaoAsync(permissaoUID, permissaoUIDSpecified, null);
	}

	public void GetPessoasPorPermissaoAsync(long permissaoUID, bool permissaoUIDSpecified, object userState)
	{
		if (GetPessoasPorPermissaoOperationCompleted == null)
		{
			GetPessoasPorPermissaoOperationCompleted = OnGetPessoasPorPermissaoOperationCompleted;
		}
		this.InvokeAsync("GetPessoasPorPermissao", new object[2] { permissaoUID, permissaoUIDSpecified }, GetPessoasPorPermissaoOperationCompleted, userState);
	}

	private void OnGetPessoasPorPermissaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPessoasPorPermissaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPessoasPorPermissaoCompleted(this, new GetPessoasPorPermissaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void SalvarPermissaoUsuario(long usuarioUID, [XmlIgnore] bool usuarioUIDSpecified, long permissaoUID, [XmlIgnore] bool permissaoUIDSpecified, [XmlElement(IsNullable = true)] DateTime? dataLimite, [XmlElement(IsNullable = true)][XmlIgnore] bool dataLimiteSpecified)
	{
		this.Invoke("SalvarPermissaoUsuario", new object[6] { usuarioUID, usuarioUIDSpecified, permissaoUID, permissaoUIDSpecified, dataLimite, dataLimiteSpecified });
	}

	public void SalvarPermissaoUsuarioAsync(long usuarioUID, bool usuarioUIDSpecified, long permissaoUID, bool permissaoUIDSpecified, DateTime? dataLimite, bool dataLimiteSpecified)
	{
		SalvarPermissaoUsuarioAsync(usuarioUID, usuarioUIDSpecified, permissaoUID, permissaoUIDSpecified, dataLimite, dataLimiteSpecified, null);
	}

	public void SalvarPermissaoUsuarioAsync(long usuarioUID, bool usuarioUIDSpecified, long permissaoUID, bool permissaoUIDSpecified, DateTime? dataLimite, bool dataLimiteSpecified, object userState)
	{
		if (SalvarPermissaoUsuarioOperationCompleted == null)
		{
			SalvarPermissaoUsuarioOperationCompleted = OnSalvarPermissaoUsuarioOperationCompleted;
		}
		this.InvokeAsync("SalvarPermissaoUsuario", new object[6] { usuarioUID, usuarioUIDSpecified, permissaoUID, permissaoUIDSpecified, dataLimite, dataLimiteSpecified }, SalvarPermissaoUsuarioOperationCompleted, userState);
	}

	private void OnSalvarPermissaoUsuarioOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (SalvarPermissaoUsuarioCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			SalvarPermissaoUsuarioCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Usuario GetUsuarioPorPessoa(long pessoaUID, [XmlIgnore] bool pessoaUIDSpecified)
	{
		return (Usuario)this.Invoke("GetUsuarioPorPessoa", new object[2] { pessoaUID, pessoaUIDSpecified })[0];
	}

	public void GetUsuarioPorPessoaAsync(long pessoaUID, bool pessoaUIDSpecified)
	{
		GetUsuarioPorPessoaAsync(pessoaUID, pessoaUIDSpecified, null);
	}

	public void GetUsuarioPorPessoaAsync(long pessoaUID, bool pessoaUIDSpecified, object userState)
	{
		if (GetUsuarioPorPessoaOperationCompleted == null)
		{
			GetUsuarioPorPessoaOperationCompleted = OnGetUsuarioPorPessoaOperationCompleted;
		}
		this.InvokeAsync("GetUsuarioPorPessoa", new object[2] { pessoaUID, pessoaUIDSpecified }, GetUsuarioPorPessoaOperationCompleted, userState);
	}

	private void OnGetUsuarioPorPessoaOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetUsuarioPorPessoaCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetUsuarioPorPessoaCompleted(this, new GetUsuarioPorPessoaCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Usuario GetUsuarioPorNomeAcesso([XmlElement(IsNullable = true)] string nomeAcesso)
	{
		return (Usuario)this.Invoke("GetUsuarioPorNomeAcesso", new object[1] { nomeAcesso })[0];
	}

	public void GetUsuarioPorNomeAcessoAsync(string nomeAcesso)
	{
		GetUsuarioPorNomeAcessoAsync(nomeAcesso, null);
	}

	public void GetUsuarioPorNomeAcessoAsync(string nomeAcesso, object userState)
	{
		if (GetUsuarioPorNomeAcessoOperationCompleted == null)
		{
			GetUsuarioPorNomeAcessoOperationCompleted = OnGetUsuarioPorNomeAcessoOperationCompleted;
		}
		this.InvokeAsync("GetUsuarioPorNomeAcesso", new object[1] { nomeAcesso }, GetUsuarioPorNomeAcessoOperationCompleted, userState);
	}

	private void OnGetUsuarioPorNomeAcessoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetUsuarioPorNomeAcessoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetUsuarioPorNomeAcessoCompleted(this, new GetUsuarioPorNomeAcessoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public PessoaEntity GetDocentePorChave([XmlElement(IsNullable = true)] string chave)
	{
		return (PessoaEntity)this.Invoke("GetDocentePorChave", new object[1] { chave })[0];
	}

	public void GetDocentePorChaveAsync(string chave)
	{
		GetDocentePorChaveAsync(chave, null);
	}

	public void GetDocentePorChaveAsync(string chave, object userState)
	{
		if (GetDocentePorChaveOperationCompleted == null)
		{
			GetDocentePorChaveOperationCompleted = OnGetDocentePorChaveOperationCompleted;
		}
		this.InvokeAsync("GetDocentePorChave", new object[1] { chave }, GetDocentePorChaveOperationCompleted, userState);
	}

	private void OnGetDocentePorChaveOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetDocentePorChaveCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetDocentePorChaveCompleted(this, new GetDocentePorChaveCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Aluno LoginEstudanteGeral([XmlElement(IsNullable = true)] string rga, [XmlElement(IsNullable = true)] string senha, [XmlArray(IsNullable = true)][XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services", IsNullable = false)] TipoEstudante[] tiposEstudante)
	{
		return (Aluno)this.Invoke("LoginEstudanteGeral", new object[3] { rga, senha, tiposEstudante })[0];
	}

	public void LoginEstudanteGeralAsync(string rga, string senha, TipoEstudante[] tiposEstudante)
	{
		LoginEstudanteGeralAsync(rga, senha, tiposEstudante, null);
	}

	public void LoginEstudanteGeralAsync(string rga, string senha, TipoEstudante[] tiposEstudante, object userState)
	{
		if (LoginEstudanteGeralOperationCompleted == null)
		{
			LoginEstudanteGeralOperationCompleted = OnLoginEstudanteGeralOperationCompleted;
		}
		this.InvokeAsync("LoginEstudanteGeral", new object[3] { rga, senha, tiposEstudante }, LoginEstudanteGeralOperationCompleted, userState);
	}

	private void OnLoginEstudanteGeralOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginEstudanteGeralCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginEstudanteGeralCompleted(this, new LoginEstudanteGeralCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Aluno LoginEstudanteGeralPorCampi([XmlElement(IsNullable = true)] string rga, [XmlElement(IsNullable = true)] string senha, [XmlArray(IsNullable = true)][XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services", IsNullable = false)] TipoEstudante[] tiposEstudante, [XmlArray(IsNullable = true)][XmlArrayItem(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = false)] int[] campusUID)
	{
		return (Aluno)this.Invoke("LoginEstudanteGeralPorCampi", new object[4] { rga, senha, tiposEstudante, campusUID })[0];
	}

	public void LoginEstudanteGeralPorCampiAsync(string rga, string senha, TipoEstudante[] tiposEstudante, int[] campusUID)
	{
		LoginEstudanteGeralPorCampiAsync(rga, senha, tiposEstudante, campusUID, null);
	}

	public void LoginEstudanteGeralPorCampiAsync(string rga, string senha, TipoEstudante[] tiposEstudante, int[] campusUID, object userState)
	{
		if (LoginEstudanteGeralPorCampiOperationCompleted == null)
		{
			LoginEstudanteGeralPorCampiOperationCompleted = OnLoginEstudanteGeralPorCampiOperationCompleted;
		}
		this.InvokeAsync("LoginEstudanteGeralPorCampi", new object[4] { rga, senha, tiposEstudante, campusUID }, LoginEstudanteGeralPorCampiOperationCompleted, userState);
	}

	private void OnLoginEstudanteGeralPorCampiOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginEstudanteGeralPorCampiCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginEstudanteGeralPorCampiCompleted(this, new LoginEstudanteGeralPorCampiCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
	public PermissaoCampusEntity[] GetPermissaoCampusPorPermissao(long permissaoUID, [XmlIgnore] bool permissaoUIDSpecified)
	{
		return (PermissaoCampusEntity[])this.Invoke("GetPermissaoCampusPorPermissao", new object[2] { permissaoUID, permissaoUIDSpecified })[0];
	}

	public void GetPermissaoCampusPorPermissaoAsync(long permissaoUID, bool permissaoUIDSpecified)
	{
		GetPermissaoCampusPorPermissaoAsync(permissaoUID, permissaoUIDSpecified, null);
	}

	public void GetPermissaoCampusPorPermissaoAsync(long permissaoUID, bool permissaoUIDSpecified, object userState)
	{
		if (GetPermissaoCampusPorPermissaoOperationCompleted == null)
		{
			GetPermissaoCampusPorPermissaoOperationCompleted = OnGetPermissaoCampusPorPermissaoOperationCompleted;
		}
		this.InvokeAsync("GetPermissaoCampusPorPermissao", new object[2] { permissaoUID, permissaoUIDSpecified }, GetPermissaoCampusPorPermissaoOperationCompleted, userState);
	}

	private void OnGetPermissaoCampusPorPermissaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPermissaoCampusPorPermissaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPermissaoCampusPorPermissaoCompleted(this, new GetPermissaoCampusPorPermissaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Aluno LoginEstudanteDPR([XmlElement(IsNullable = true)] string rga, [XmlElement(IsNullable = true)] string senha)
	{
		return (Aluno)this.Invoke("LoginEstudanteDPR", new object[2] { rga, senha })[0];
	}

	public void LoginEstudanteDPRAsync(string rga, string senha)
	{
		LoginEstudanteDPRAsync(rga, senha, null);
	}

	public void LoginEstudanteDPRAsync(string rga, string senha, object userState)
	{
		if (LoginEstudanteDPROperationCompleted == null)
		{
			LoginEstudanteDPROperationCompleted = OnLoginEstudanteDPROperationCompleted;
		}
		this.InvokeAsync("LoginEstudanteDPR", new object[2] { rga, senha }, LoginEstudanteDPROperationCompleted, userState);
	}

	private void OnLoginEstudanteDPROperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (LoginEstudanteDPRCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			LoginEstudanteDPRCompleted(this, new LoginEstudanteDPRCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public UsuarioEntity ValidarToken([XmlElement(IsNullable = true)] string token)
	{
		return (UsuarioEntity)this.Invoke("ValidarToken", new object[1] { token })[0];
	}

	public void ValidarTokenAsync(string token)
	{
		ValidarTokenAsync(token, null);
	}

	public void ValidarTokenAsync(string token, object userState)
	{
		if (ValidarTokenOperationCompleted == null)
		{
			ValidarTokenOperationCompleted = OnValidarTokenOperationCompleted;
		}
		this.InvokeAsync("ValidarToken", new object[1] { token }, ValidarTokenOperationCompleted, userState);
	}

	private void OnValidarTokenOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (ValidarTokenCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			ValidarTokenCompleted(this, new ValidarTokenCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlElement(IsNullable = true)]
	public Aluno ValidarTokenAluno([XmlElement(IsNullable = true)] string token)
	{
		return (Aluno)this.Invoke("ValidarTokenAluno", new object[1] { token })[0];
	}

	public void ValidarTokenAlunoAsync(string token)
	{
		ValidarTokenAlunoAsync(token, null);
	}

	public void ValidarTokenAlunoAsync(string token, object userState)
	{
		if (ValidarTokenAlunoOperationCompleted == null)
		{
			ValidarTokenAlunoOperationCompleted = OnValidarTokenAlunoOperationCompleted;
		}
		this.InvokeAsync("ValidarTokenAluno", new object[1] { token }, ValidarTokenAlunoOperationCompleted, userState);
	}

	private void OnValidarTokenAlunoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (ValidarTokenAlunoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			ValidarTokenAlunoCompleted(this, new ValidarTokenAlunoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
	public PermissaoModel[] GetPermissoesPorAplicacao(long aplicacaoUID, [XmlIgnore] bool aplicacaoUIDSpecified)
	{
		return (PermissaoModel[])this.Invoke("GetPermissoesPorAplicacao", new object[2] { aplicacaoUID, aplicacaoUIDSpecified })[0];
	}

	public void GetPermissoesPorAplicacaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified)
	{
		GetPermissoesPorAplicacaoAsync(aplicacaoUID, aplicacaoUIDSpecified, null);
	}

	public void GetPermissoesPorAplicacaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified, object userState)
	{
		if (GetPermissoesPorAplicacaoOperationCompleted == null)
		{
			GetPermissoesPorAplicacaoOperationCompleted = OnGetPermissoesPorAplicacaoOperationCompleted;
		}
		this.InvokeAsync("GetPermissoesPorAplicacao", new object[2] { aplicacaoUID, aplicacaoUIDSpecified }, GetPermissoesPorAplicacaoOperationCompleted, userState);
	}

	private void OnGetPermissoesPorAplicacaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPermissoesPorAplicacaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPermissoesPorAplicacaoCompleted(this, new GetPermissoesPorAplicacaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
	public UsuarioPermissaoModel[] GetPermissoesAtivasEUsuariosPorAplicacao(long aplicacaoUID, [XmlIgnore] bool aplicacaoUIDSpecified)
	{
		return (UsuarioPermissaoModel[])this.Invoke("GetPermissoesAtivasEUsuariosPorAplicacao", new object[2] { aplicacaoUID, aplicacaoUIDSpecified })[0];
	}

	public void GetPermissoesAtivasEUsuariosPorAplicacaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified)
	{
		GetPermissoesAtivasEUsuariosPorAplicacaoAsync(aplicacaoUID, aplicacaoUIDSpecified, null);
	}

	public void GetPermissoesAtivasEUsuariosPorAplicacaoAsync(long aplicacaoUID, bool aplicacaoUIDSpecified, object userState)
	{
		if (GetPermissoesAtivasEUsuariosPorAplicacaoOperationCompleted == null)
		{
			GetPermissoesAtivasEUsuariosPorAplicacaoOperationCompleted = OnGetPermissoesAtivasEUsuariosPorAplicacaoOperationCompleted;
		}
		this.InvokeAsync("GetPermissoesAtivasEUsuariosPorAplicacao", new object[2] { aplicacaoUID, aplicacaoUIDSpecified }, GetPermissoesAtivasEUsuariosPorAplicacaoOperationCompleted, userState);
	}

	private void OnGetPermissoesAtivasEUsuariosPorAplicacaoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPermissoesAtivasEUsuariosPorAplicacaoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPermissoesAtivasEUsuariosPorAplicacaoCompleted(this, new GetPermissoesAtivasEUsuariosPorAplicacaoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void CriarUsuarioExterno([XmlElement(IsNullable = true)] string cpf, [XmlElement(IsNullable = true)] string email)
	{
		this.Invoke("CriarUsuarioExterno", new object[2] { cpf, email });
	}

	public void CriarUsuarioExternoAsync(string cpf, string email)
	{
		CriarUsuarioExternoAsync(cpf, email, null);
	}

	public void CriarUsuarioExternoAsync(string cpf, string email, object userState)
	{
		if (CriarUsuarioExternoOperationCompleted == null)
		{
			CriarUsuarioExternoOperationCompleted = OnCriarUsuarioExternoOperationCompleted;
		}
		this.InvokeAsync("CriarUsuarioExterno", new object[2] { cpf, email }, CriarUsuarioExternoOperationCompleted, userState);
	}

	private void OnCriarUsuarioExternoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (CriarUsuarioExternoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			CriarUsuarioExternoCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	public void CriarUsuarioExternoComSenha([XmlElement(IsNullable = true)] string cpf, [XmlElement(IsNullable = true)] string senha, [XmlElement(IsNullable = true)] string email)
	{
		this.Invoke("CriarUsuarioExternoComSenha", new object[3] { cpf, senha, email });
	}

	public void CriarUsuarioExternoComSenhaAsync(string cpf, string senha, string email)
	{
		CriarUsuarioExternoComSenhaAsync(cpf, senha, email, null);
	}

	public void CriarUsuarioExternoComSenhaAsync(string cpf, string senha, string email, object userState)
	{
		if (CriarUsuarioExternoComSenhaOperationCompleted == null)
		{
			CriarUsuarioExternoComSenhaOperationCompleted = OnCriarUsuarioExternoComSenhaOperationCompleted;
		}
		this.InvokeAsync("CriarUsuarioExternoComSenha", new object[3] { cpf, senha, email }, CriarUsuarioExternoComSenhaOperationCompleted, userState);
	}

	private void OnCriarUsuarioExternoComSenhaOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (CriarUsuarioExternoComSenhaCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			CriarUsuarioExternoComSenhaCompleted(this, new AsyncCompletedEventArgs(((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	[SoapDocumentMethod(/*Could not decode attribute arguments.*/)]
	[return: XmlArray(IsNullable = true)]
	[return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
	public VinculoPessoaEntity[] GetPerfilAcesso([XmlElement(IsNullable = true)] string cpf)
	{
		return (VinculoPessoaEntity[])this.Invoke("GetPerfilAcesso", new object[1] { cpf })[0];
	}

	public void GetPerfilAcessoAsync(string cpf)
	{
		GetPerfilAcessoAsync(cpf, null);
	}

	public void GetPerfilAcessoAsync(string cpf, object userState)
	{
		if (GetPerfilAcessoOperationCompleted == null)
		{
			GetPerfilAcessoOperationCompleted = OnGetPerfilAcessoOperationCompleted;
		}
		this.InvokeAsync("GetPerfilAcesso", new object[1] { cpf }, GetPerfilAcessoOperationCompleted, userState);
	}

	private void OnGetPerfilAcessoOperationCompleted(object arg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected Obj, but got Unknown
		if (GetPerfilAcessoCompleted != null)
		{
			InvokeCompletedEventArgs e = (InvokeCompletedEventArgs)arg;
			GetPerfilAcessoCompleted(this, new GetPerfilAcessoCompletedEventArgs(e.Results, ((AsyncCompletedEventArgs)(object)e).Error, ((AsyncCompletedEventArgs)(object)e).Cancelled, ((AsyncCompletedEventArgs)(object)e).UserState));
		}
	}

	public void CancelAsync(object userState)
	{
		this.CancelAsync(userState);
	}

	private bool IsLocalFileSystemWebService(string url)
	{
		if (url == null || url == string.Empty)
		{
			return false;
		}
		Uri uri = new Uri(url);
		if (uri.Port >= 1024 && string.Compare(uri.Host, "localHost", StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		return false;
	}
}
