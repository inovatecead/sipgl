using System;

namespace ufmt.sig.entity;

[Serializable]
public class CriticaEncargo
{
	private CategoriaCriticaEncargo categoria;

	private string descricao;

	public CategoriaCriticaEncargo Categoria => categoria;

	public string Descricao => descricao;

	internal CriticaEncargo(CategoriaCriticaEncargo categoria, string descricao)
	{
		this.categoria = categoria;
		this.descricao = descricao;
	}
}
