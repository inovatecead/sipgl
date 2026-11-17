using System;

namespace ufmt.sig.entity.sisvote;

public static class SituacaoEleicaoEnumExtension
{
	public static string Descricao(this SituacaoEleicaoEnum situacaoEleicaoEnum)
	{
		if (SituacaoEleicaoEnum.ABERTA.Equals(situacaoEleicaoEnum))
		{
			return "ABERTA";
		}
		if (SituacaoEleicaoEnum.FECHADA.Equals(situacaoEleicaoEnum))
		{
			return "FECHADA";
		}
		throw new NotSupportedException("Situação da eleição desconhecida.");
	}
}
