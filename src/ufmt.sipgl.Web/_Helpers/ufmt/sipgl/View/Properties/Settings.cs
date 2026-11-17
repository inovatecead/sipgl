using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ufmt.sipgl.View.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
	private static Settings defaultInstance = (Settings)(object)SettingsBase.Synchronized((SettingsBase)(object)new Settings());

	public static Settings Default => defaultInstance;

	[ApplicationScopedSetting]
	[DebuggerNonUserCode]
	[SpecialSetting(SpecialSetting.WebServiceUrl)]
	[DefaultSettingValue("http://win-7jw7uwr0m27/ufmt.services/Autenticacao.svc")]
	public string ufmt_sipgl_View_br_ufmt_sistemas_Autenticacao => (string)((SettingsBase)this)["ufmt_sipgl_View_br_ufmt_sistemas_Autenticacao"];
}
