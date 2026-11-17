<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmAlterar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmAlterar" MaintainScrollPositionOnPostback="true" %>

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

    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
    <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />

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

            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Nome:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome" ErrorMessage="Nome" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>

                    <td>
                        <asp:TextBox ID="txtNome" runat="server" Width="735px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label6" runat="server" Style="font-weight: 700" Text="Ano:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAno" ErrorMessage="Ano" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAno" runat="server" Width="71px"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtAno" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label8" runat="server" Style="font-weight: 700" Text="Qtd. de Períodos:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPeriodo" ErrorMessage="Qtd. de Períodos" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPeriodo" runat="server" Width="100px"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtPeriodo" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbTurno" runat="server" Style="font-weight: 700" Text="Turno:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTurno" ErrorMessage="Turno" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTurno" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbDataInicio" runat="server" Style="font-weight: 700" Text="Data de Início:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDataInicio" ErrorMessage="Data de Início" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataInicio" runat="server" Width="100px"></asp:TextBox>

                        <asp:MaskedEditExtender
                            ID="txtDataInicio_MaskedEditExtender"
                            runat="server"
                            CultureDateFormat="pt-br"
                            Enabled="True"
                            Mask="99/99/9999"
                            MaskType="Date"
                            TargetControlID="txtDataInicio">
                        </asp:MaskedEditExtender>

                        <asp:MaskedEditValidator
                            ID="txtDataInicio_MaskedEditValidator"
                            runat="server"
                            ControlExtender="txtDataInicio_MaskedEditExtender"
                            ControlToValidate="txtDataInicio"
                            CssClass="failureNotification"
                            Display="Dynamic"
                            ForeColor="Red"
                            InvalidValueMessage="Data no formato inválido"
                            IsValidEmpty="True">
                        </asp:MaskedEditValidator>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbDataFim" runat="server" Style="font-weight: 700" Text="Data de Fim:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDataFim" ErrorMessage="Data de Fim" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataFim" runat="server" Width="100px"></asp:TextBox>

                        <asp:MaskedEditExtender
                            ID="txtDataFim_MaskedEditExtender"
                            runat="server"
                            CultureDateFormat="pt-br"
                            Enabled="True"
                            Mask="99/99/9999"
                            MaskType="Date"
                            TargetControlID="txtDataFim">
                        </asp:MaskedEditExtender>

                        <asp:MaskedEditValidator
                            ID="txtDataFim_MaskedEditValidator"
                            runat="server"
                            ControlExtender="txtDataFim_MaskedEditExtender"
                            ControlToValidate="txtDataFim"
                            CssClass="failureNotification"
                            Display="Dynamic"
                            ForeColor="Red"
                            InvalidValueMessage="Data no formato inválido"
                            IsValidEmpty="True">
                        </asp:MaskedEditValidator>

                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label3" runat="server" Style="font-weight: 700" Text="Ativa?"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlStatusTurma" ErrorMessage="Status" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatusTurma" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Value="1">Ativo</asp:ListItem>
                            <asp:ListItem Value="0">Inativo</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="false" />

                        <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>

</asp:Content>
