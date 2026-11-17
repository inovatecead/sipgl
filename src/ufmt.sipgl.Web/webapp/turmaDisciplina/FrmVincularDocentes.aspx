<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmVincularDocentes.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turmaDisciplina.FrmVincularDocentes" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>


    <asp:Panel ID="pnlDetalheInscricao" runat="server" Visible="false" CssClass="pnlAviso">
        <asp:Panel ID="Panel1" runat="server" Style="text-align: center; padding: 10px">
            <asp:Label ID="lblMsgCadastro" runat="server"></asp:Label>
        </asp:Panel>

    </asp:Panel>

    <div style="padding-top: 30px; text-align: center">
        <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
        <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />
        <asp:HiddenField ID="hddProjetoDisciplinaUID" runat="server" />
        <asp:HiddenField ID="hddProjetoTurmaDisciplinaUID" runat="server" />
    </div>

    <asp:Panel ID="pnlFormularioInscricao" runat="server">

        <div id="containerMensagens">
            <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
            </asp:Panel>
        </div>

        <div>
            <div id="containerValidacao">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
            </div>

            <fieldset>
                <legend style="font-size: x-large">Disciplina</legend>
                <table class="Largura100Porcento">
                    <tr>
                        <td class="Largura150">&nbsp;
                            <asp:Label ID="lbNome" runat="server" Style="font-weight: 700" Text="Nome:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="735px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbCargaHoraria" runat="server" Style="font-weight: 700" Text="Carga Horária:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCargaHoraria" runat="server" Width="100px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbDocentePrincipal" runat="server" Style="font-weight: 700" Text="Docente Principal:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="ddlDocentePrincipal" ErrorMessage="Docente Principal" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDocentePrincipal" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbRemuneracaoPrincipal" runat="server" Style="font-weight: 700" Text="Docente possui remuneração?"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlRemuneracaoDocentePrincipal" ErrorMessage="Remuneração do Docente Principal" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>

                            <asp:DropDownList ID="ddlRemuneracaoDocentePrincipal" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlRemuneracaoDocentePrincipal_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Panel runat="server" ID="pnlTipoRemuneracaoPrincipal" Visible="false">
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="lbTipoRemuneracaoPrincipal" runat="server" Style="font-weight: 700" Text="Tipo da Remuneração:"></asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlTipoRemuneracaoDocentePrincipal" ErrorMessage="Tipo da Remuneração do Docente Principal" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>

                                <asp:DropDownList ID="ddlTipoRemuneracaoDocentePrincipal" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlTipoRemuneracaoDocentePrincipal_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>

                                <asp:Label runat="server" ID="lbQualPrincipal" Visible="false">Qual?</asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtOutraRemuneracaoPrincipal" ErrorMessage="Descrição do Tipo de Remuneração para Docente Principal" ForeColor="Red">*</asp:RequiredFieldValidator>

                                <asp:TextBox ID="txtOutraRemuneracaoPrincipal" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbDocenteSecundario" runat="server" Style="font-weight: 700" Text="Docente Secundário:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlDocenteSecundario" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDocenteSecundario_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbRemuneracaoSecundario" runat="server" Style="font-weight: 700" Text="Docente possui remuneração?"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRemuneracaoDocenteSecundario" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlRemuneracaoDocenteSecundario_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Panel runat="server" ID="pnlTipoRemuneracaoSecundario" Visible="false">
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="lbTipoRemuneracaoSecundario" runat="server" Style="font-weight: 700" Text="Tipo da Remuneração:"></asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlTipoRemuneracaoDocenteSecundario" ErrorMessage="Tipo de Remuneração para Docente Secundário" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoRemuneracaoDocenteSecundario" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlTipoRemuneracaoDocenteSecundario_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="">Selecione</asp:ListItem>
                                </asp:DropDownList>

                                <asp:Label runat="server" ID="lbQualSecundario" Visible="false">Qual?</asp:Label>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtOutraRemuneracaoSecundario" ErrorMessage="Descrição do Tipo de Remuneração para Docente Secundário" ForeColor="Red">*</asp:RequiredFieldValidator>

                                <asp:TextBox ID="txtOutraRemuneracaoSecundario" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbDataInicio" runat="server" Style="font-weight: 700" Text="Data Início:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDataInicio" ErrorMessage="Data início" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataInicio" runat="server" Width="100px"></asp:TextBox>

                            <asp:MaskedEditValidator
                                ID="MEVData2" runat="server"
                                ControlExtender="txtDataInicio_MaskedEditExtender"
                                ControlToValidate="txtDataInicio"
                                CssClass="failureNotification"
                                Display="Dynamic"
                                ErrorMessage="MEVData2"
                                ForeColor="Red"
                                InvalidValueMessage="Data no formato inválido">
                            </asp:MaskedEditValidator>

                            <asp:MaskedEditExtender
                                ID="txtDataInicio_MaskedEditExtender"
                                runat="server"
                                CultureCurrencySymbolPlaceholder=""
                                CultureDateFormat="pt-br"
                                Enabled="True"
                                Mask="99/99/9999"
                                MaskType="Date"
                                TargetControlID="txtDataInicio">
                            </asp:MaskedEditExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbDataTermino" runat="server" Style="font-weight: 700" Text="Data Término:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDataTermino" ErrorMessage="Data término" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataTermino" runat="server" Width="100px"></asp:TextBox>

                            <asp:MaskedEditExtender
                                ID="txtDataTermino_MaskedEditExtender"
                                runat="server"
                                CultureDateFormat="pt-br"
                                Enabled="True"
                                Mask="99/99/9999"
                                MaskType="Date"
                                TargetControlID="txtDataTermino">
                            </asp:MaskedEditExtender>

                            <asp:MaskedEditValidator
                                ID="MEVData3"
                                runat="server"
                                ControlExtender="txtDataTermino_MaskedEditExtender"
                                ControlToValidate="txtDataTermino"
                                CssClass="failureNotification"
                                Display="Dynamic"
                                ErrorMessage="MEVData1"
                                ForeColor="Red"
                                InvalidValueMessage="Data no formato inválido">
                            </asp:MaskedEditValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150"></td>
                        <td>
                            <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="false" />
                            <asp:Button ID="btnSalvar" runat="server" OnClick="btnVincular_Click" Text="Salvar" SkinID="VincularDocentes_Salvar" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
