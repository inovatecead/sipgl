using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace ufmt.sipgl.View.br.ufmt.sistemas;

[Serializable]
[GeneratedCode("System.Xml", "4.8.3752.0")]
[XmlType(Namespace = "http://schemas.datacontract.org/2004/07/ufmt.sig.entity")]
public enum TipoUnidadeEnum
{
	INSTITUTO_ENSINO,
	DIRETORIA_INSTITUTO_ENSINO,
	DEPARTAMENTO_ENSINO,
	COORDENACAO_ENSINO_GRADUACAO,
	COORDENACAO_ENSINO_POS_GRADUACAO,
	UNIDADE_LOTACIONAL_DOCENTE,
	DIRETORIA_ADJUNTA,
	SUPERVISÃO_ENSINO_GRADUAÇÃO,
	INFORMAL
}
