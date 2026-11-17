using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetPermissaoPorUsuarioAplicacaoCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public PermissaoUsuarioEntity[] Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (PermissaoUsuarioEntity[])results[0];
		}
	}

	internal GetPermissaoPorUsuarioAplicacaoCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
