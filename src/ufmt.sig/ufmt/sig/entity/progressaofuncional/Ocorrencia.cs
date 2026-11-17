using System;
using ufmt.sig.business;

namespace ufmt.sig.entity.progressaofuncional;

[Serializable]
public class Ocorrencia : IEntidade
{
	public virtual int Id { get; set; }

	public virtual string Observacao { get; set; }

	public virtual DateTime Data { get; set; }

	public virtual int ProgressaoFuncionalID { get; set; }

	public virtual ProgressaoFuncional ProgressaoFuncional { get; set; }

	public virtual string IdObervacao => Id + " - " + Observacao;
}
