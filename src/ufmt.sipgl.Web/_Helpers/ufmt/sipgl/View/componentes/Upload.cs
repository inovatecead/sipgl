using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ufmt.sipgl.View.componentes;

public class Upload : Page
{
	public ObjUpload UploadFile(FileUpload up, string maxTamanhoArquivoUpload, string tipoArquivoUpload, string diretorioUpload)
	{
		ObjUpload objUpload = new ObjUpload();
		objUpload.MsgErro = null;
		if (up.HasFile)
		{
			string[] array = tipoArquivoUpload.Split(new char[1] { ',' });
			string text = string.Empty;
			_ = up.FileName;
			string extension = Path.GetExtension(up.FileName);
			bool flag = false;
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				text = text + " " + text2.ToString();
				if (extension.Trim() == text2)
				{
					flag = true;
				}
			}
			if (flag)
			{
				if (up.PostedFile.ContentLength > int.Parse(maxTamanhoArquivoUpload))
				{
					objUpload.MsgErro = "Arquivo ultrapassa o tamanho máximo permitido";
				}
				else
				{
					string text3 = Guid.NewGuid().ToString() + extension;
					if (!File.Exists(diretorioUpload + text3))
					{
						try
						{
							up.SaveAs(diretorioUpload + text3);
							objUpload.MsgErro = null;
							objUpload.NomeArquivo = text3;
						}
						catch (Exception)
						{
							objUpload.MsgErro = "Não foi possível enviar o arquivo.  Por favor, entre em contato com a coordenação do evento";
						}
					}
					else
					{
						objUpload.MsgErro = "Arquivo já existe no servidor";
					}
				}
			}
			else
			{
				objUpload.MsgErro = "Formato do arquivo inválido.  Formato(s) Permitido(s): " + text;
			}
		}
		return objUpload;
	}
}
