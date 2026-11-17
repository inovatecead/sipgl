using System;
using ufmt.sig.business.cineclube;
using ufmt.sig.business.implementation;
using ufmt.sig.business.implementation.cineclube;
using ufmt.sig.business.implementation.progressaofuncional;
using ufmt.sig.business.implementation.sisvote;
using ufmt.sig.business.progressaofuncional;
using ufmt.sig.business.sisvote;

namespace ufmt.sig.business;

public sealed class BusinessFactory
{
	public static I GetInstance<I>()
	{
		try
		{
			if ((object)typeof(I) == typeof(IPessoaBO))
			{
				return (I)Activator.CreateInstance(typeof(PessoaBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(ICursoBO))
			{
				return (I)Activator.CreateInstance(typeof(CursoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(ILocalizacaoBO))
			{
				return (I)Activator.CreateInstance(typeof(LocalizacaoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(IAutenticacaoBO))
			{
				return (I)Activator.CreateInstance(typeof(AutenticacaoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(IEncargoBO))
			{
				return (I)Activator.CreateInstance(typeof(EncargoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(IAplicacaoBO))
			{
				return (I)Activator.CreateInstance(typeof(AplicacaoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(ILogBO))
			{
				return (I)Activator.CreateInstance(typeof(LogBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(ICargoBO))
			{
				return (I)Activator.CreateInstance(typeof(CargoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(ICandidatoBO))
			{
				return (I)Activator.CreateInstance(typeof(CandidatoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(IVotoBO))
			{
				return (I)Activator.CreateInstance(typeof(VotoBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(IFilmeBO))
			{
				return (I)Activator.CreateInstance(typeof(FilmeBO), nonPublic: true);
			}
			if ((object)typeof(I) == typeof(IProgressaoFuncionalBO))
			{
				return (I)Activator.CreateInstance(typeof(ProgressaoFuncionalBO), nonPublic: true);
			}
		}
		catch (Exception innerException)
		{
			throw new Exception("Erro ao obter instância de objeto de negócio. Por favor entre em contato com o Administrador do Sistema.", innerException);
		}
		throw new NotSupportedException();
	}
}
