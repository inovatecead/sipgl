using System;

namespace ufmt.sipgl.View.componentes.exception;

public class EmailException : ApplicationException
{
	public EmailException(string msg)
		: base(msg)
	{
	}
}
