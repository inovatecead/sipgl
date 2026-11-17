using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace ufmt.sipgl.View;

public class GeraXML : Page
{
	protected HtmlForm form1;

	protected void Page_Load(object sender, EventArgs e)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter("c:\\builds\\bb.xml", null);
		xmlTextWriter.WriteStartDocument();
		xmlTextWriter.Formatting = Formatting.Indented;
		xmlTextWriter.WriteStartElement("bookcatalogue");
		xmlTextWriter.WriteStartElement("book");
		xmlTextWriter.WriteAttributeString("ISBN", "0-06-064831-7");
		xmlTextWriter.WriteElementString("Title", "XML Essentials");
		xmlTextWriter.WriteElementString("Author", "Brennet Bronx");
		xmlTextWriter.WriteElementString("Price", "$12.34");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteStartElement("book");
		xmlTextWriter.WriteAttributeString("ISBN", "0-16-003321-4");
		xmlTextWriter.WriteElementString("Title", "Understanding XML");
		xmlTextWriter.WriteElementString("Author", "Jagadeesh Bose");
		xmlTextWriter.WriteElementString("Price", "$15.00");
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndElement();
		xmlTextWriter.WriteEndDocument();
		xmlTextWriter.Close();
	}
}
