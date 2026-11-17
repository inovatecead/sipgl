using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetPermissoesPorAplicacaoCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public PermissaoModel[] Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (PermissaoModel[])results[0];
		}
	}

	internal GetPermissoesPorAplicacaoCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
