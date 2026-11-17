using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetUsuarioPorNomeAcessoCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public Usuario Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (Usuario)results[0];
		}
	}

	internal GetUsuarioPorNomeAcessoCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
