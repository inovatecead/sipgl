using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ufmt.sig.entity;
using ufmt.sipgl.Business;
using ufmt.sipgl.DataAccess;

namespace ufmt.sipgl.View.webapp.Login_Old;

public class AutenticarBase : Page
{
	private int aplicacaoUID = int.Parse(WebConfigurationManager.AppSettings["aplicacaoUID"]);

	protected HtmlForm form1;

	protected void Page_Load(object sender, EventArgs e)
	{
		long usuarioUID = (long)((Page)this).Session["usuarioUID"];
		AutenticacaoBO autenticacaoBO = new AutenticacaoBO();
		ufmt.sig.entity.Usuario usuario = autenticacaoBO.GetUsuario(usuarioUID);
		List<ufmt.sig.entity.PermissaoUsuario> list = autenticacaoBO.VerificaPermissoes(usuario.UsuarioUID, aplicacaoUID);
		if (list.Count > 0)
		{
			((Page)this).Session["autenticado"] = "true";
			Servidor servidorAtivo = autenticacaoBO.GetServidorAtivo(usuario.Pessoa.PessoaUID);
			if (servidorAtivo != null)
			{
				((Page)this).Session["servidorUID"] = servidorAtivo.ServidorUID;
			}
			List<long> listaPermissaoUID = list.Select((ufmt.sig.entity.PermissaoUsuario x) => x.Permissao.PermissaoUID).ToList();
			List<string> list2 = (from t in new ProjetoRecursoBO().ListarRecursosPorPerfis(listaPermissaoUID)
				select t.nome).ToList();
			((Page)this).Session["listaRecursos"] = list2;
			ufmt.sig.entity.Permissao permissao = (from p in list
				where p.Permissao.Nome.Contains("ADMINISTRADOR")
				select p.Permissao).FirstOrDefault();
			ufmt.sig.entity.Permissao permissao2 = (from p in list
				where p.Permissao.Nome.Contains("COORDENADOR")
				select p.Permissao).FirstOrDefault();
			ufmt.sig.entity.Permissao permissao3 = (from p in list
				where p.Permissao.Nome.Contains("SECRETARIO")
				select p.Permissao).FirstOrDefault();
			ufmt.sig.entity.Permissao permissao4 = (from p in list
				where p.Permissao.Nome.Contains("PROFESSOR")
				select p.Permissao).FirstOrDefault();
			List<long> list3 = new List<long>();
			if (permissao != null)
			{
				list3.Add(permissao.PermissaoUID);
			}
			if (permissao2 != null)
			{
				list3.Add(permissao2.PermissaoUID);
			}
			if (permissao3 != null)
			{
				list3.Add(permissao3.PermissaoUID);
			}
			if (permissao4 != null)
			{
				list3.Add(permissao4.PermissaoUID);
			}
			((Page)this).Session["listaPerfis"] = list3;
			((Page)this).Response.Redirect("~/webapp/FrmPrincipal.aspx", false);
		}
		else
		{
			((Page)this).Session["autenticado"] = null;
			((Page)this).Session["usuarioUID"] = null;
			((Page)this).Response.Redirect("~/Default.aspx");
		}
	}
}
