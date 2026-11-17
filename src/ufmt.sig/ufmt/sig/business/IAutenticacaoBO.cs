using System;
using System.Collections.Generic;
using ufmt.sig.entity;

namespace ufmt.sig.business;

public interface IAutenticacaoBO : IDisposable
{
	Usuario GetUsuario(string nomeAcesso, string senhaAcesso);

	Usuario GetUsuario(long usuarioUID);

	bool VerificaNomeAcesso(string nomeAcesso);

	Usuario GetUsuarioPorPessoa(long pessoaUID);

	void CrieUsuario(Pessoa pessoa, string nomeAcesso, IList<Perfil> perfis);

	void CrieUsuario(IList<Permissao> permissoes, Pessoa pessoa, string nomeAcesso);

	void CrieUsuario(IList<Permissao> permissoes, IList<Perfil> perfis, Pessoa pessoa, string nomeAcesso, string mensagem);

	void CrieUsuario(IList<Permissao> permissoes, IList<Perfil> perfis, Pessoa pessoa, string nomeAcesso, string senhaAcesso, string mensagem);

	void AtualizaUsuario(Usuario novousuario);

	void TroqueSenha(Usuario usuario, string senhaAtual, string novaSenha);

	void ReiniciarSenha(Usuario usuario);

	Perfil GetPerfil(string nome);

	Permissao GetPermissao(long permissaoUID);

	bool VerifiquePermissao(long aplicacaoUID, long permissaoUID, long usuarioUID);

	Pessoa GetPessoa(long usuarioUID);

	void SalvePermissaoUsuario(Permissao permissao, Usuario usuario, DateTime? dataLimite);

	IEnumerable<PermissaoUsuario> GetPermissoesUsuario(long aplicacaoUID, long usuarioUID);

	PermissaoUsuario GetPermissaoUsuario(long aplicacaoUID, long permissaoUID, long usuarioUID);

	PermissaoUsuario GetPermissaoUsuario(long permissaoUsuarioUID);

	IList<Permissao> GetPermissaoPorAplicacao(long aplicacaoUID);

	void trocarEmail(Pessoa pessoa, string novoEmail);

	void confirmarEmail(string codigoConfirmacao);

	void enviarEmail(string emailDestinatario, string tituloDestinatario, string assunto, string conteudo);
}
