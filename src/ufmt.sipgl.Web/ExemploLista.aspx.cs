using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using ufmt.sig.entity;

namespace ufmt.sipgl.View;

public class ExemploLista : Page
{
	protected HtmlForm form1;

	protected void Page_Load(object sender, EventArgs e)
	{
		if (((Page)this).IsPostBack)
		{
			return;
		}
		long[] array = new long[3] { 10L, 20L, 30L };
		foreach (Unidade item in (IEnumerable<Unidade>)new List<Unidade>())
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == item.UnidadeUID)
				{
					((Page)this).Response.Write("localizado");
					break;
				}
				((Page)this).Response.Write("Não localizado");
			}
		}
	}
}
