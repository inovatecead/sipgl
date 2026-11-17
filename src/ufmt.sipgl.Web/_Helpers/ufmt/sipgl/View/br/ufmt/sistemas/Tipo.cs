using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[XmlType(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.services.entities")]
public enum Tipo
{
	Servidor,
	AlunoGraduacao,
	AlunoPos
}
