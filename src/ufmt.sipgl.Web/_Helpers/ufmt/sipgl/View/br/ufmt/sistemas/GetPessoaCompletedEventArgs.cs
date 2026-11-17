using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[GeneratedCode("System.Web.Services", "4.8.3752.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
public class GetPessoaCompletedEventArgs : AsyncCompletedEventArgs
{
	private object[] results;

	public PessoaEntity Result
	{
		get
		{
			RaiseExceptionIfNecessary();
			return (PessoaEntity)results[0];
		}
	}

	internal GetPessoaCompletedEventArgs(object[] results, Exception exception, bool cancelled, object userState)
		: base(exception, cancelled, userState)
	{
		this.results = results;
	}
}
