using System;
using NHibernate;
using ufmt.nhibernate;
using ufmt.sig.entity;

namespace ufmt.sig.business.implementation;

[Serializable]
public class LogBO : ILogBO, IDisposable
{
	private ISession session;

	internal LogBO()
	{
		session = SessionManager.GetSession();
	}

	public void Dispose()
	{
		SessionManager.CloseSession();
	}

	public void inserirLog(Aplicacao aplicacao, Usuario usuario, Log.OperacaoLog operacao, string ip, string valorAntigo, string valorNovo, string detalhes)
	{
		if (aplicacao == null)
		{
			throw new ArgumentNullException("Aplicação não informada.");
		}
		if (string.IsNullOrEmpty(ip))
		{
			throw new ArgumentNullException("O IP do usuário precisa estar definido.");
		}
		ITransaction transaction = session.Transaction;
		bool isActive = transaction.IsActive;
		try
		{
			if (!isActive)
			{
				transaction = session.BeginTransaction();
			}
			DateTime now = DateTime.Now;
			Log log = new Log();
			log.Aplicacao = aplicacao;
			log.Usuario = usuario;
			log.DataHora = now;
			log.Operacao = getOperacao(operacao);
			log.Ip = ip;
			log.ValorAntigo = valorAntigo;
			log.ValorNovo = valorNovo;
			log.Detalhes = detalhes;
			try
			{
				session.SaveOrUpdate(log);
				if (!isActive)
				{
					transaction.Commit();
				}
			}
			catch (Exception innerException)
			{
				throw new Exception("Não foi possível inserir o log.", innerException);
			}
		}
		catch (Exception ex)
		{
			if (!isActive)
			{
				transaction.Rollback();
			}
			throw ex;
		}
	}

	private string getOperacao(Log.OperacaoLog operacao)
	{
		return operacao switch
		{
			Log.OperacaoLog.ENTROU_NO_SISTEMA => "Entrou no sistema", 
			Log.OperacaoLog.CADASTROU_NO_IDBUFMT => "Cadastrou no idbufmt", 
			Log.OperacaoLog.REINICIOU_SENHA => "Reiniciou a senha", 
			_ => "", 
		};
	}
}
