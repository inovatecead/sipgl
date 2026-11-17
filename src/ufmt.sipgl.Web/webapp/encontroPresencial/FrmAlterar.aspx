<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmAlterar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.encontroPresencial.FrmAlterar" MaintainScrollPositionOnPostback="true" %>

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
        <asp:HiddenField ID="hddProjetoDisciplinaUID" runat="server" />
        <asp:HiddenField ID="hddProjetoEncontroPresencialUID" runat="server" />
        <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />

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
                <legend style="font-size: x-large">Encontro Presencial</legend>

                <table class="Largura100Porcento">
                     <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbTurma" runat="server" Style="font-weight: 700" Text="Turma:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtTurma" Enabled="false" Width="20%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbDisciplina" runat="server" Style="font-weight: 700" Text="Disciplina:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDisciplina" Enabled="false" Width="20%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text="Unidade Adm./Acadêmica:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlUnidade" ErrorMessage="Unidade Adm./Acadêmica" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUnidade" runat="server" AppendDataBoundItems="true" Width="20%">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label17" runat="server" Style="font-weight: 700" Text="Data do Encontro:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtDataEncontroPresencial" ErrorMessage="Data do Encontro" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataEncontroPresencial" runat="server" Width="92px"></asp:TextBox>

                            <asp:MaskedEditExtender ID="txtDataEncontroPresencial_MaskedEditExtender" runat="server"
                                CultureDateFormat="pt-br" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                TargetControlID="txtDataEncontroPresencial">
                            </asp:MaskedEditExtender>

                            <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                ControlExtender="txtDataEncontroPresencial_MaskedEditExtender"
                                ControlToValidate="txtDataEncontroPresencial" CssClass="failureNotification"
                                Display="Dynamic" ForeColor="Red"
                                InvalidValueMessage="Data no formato inválido" IsValidEmpty="True"></asp:MaskedEditValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label1" runat="server" Style="font-weight: 700"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="ckEncontroObrigatorio" runat="server" Width="200px" Text="Encontro Obrigatório">
                            </asp:CheckBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150"></td>
                        <td>
                            <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="false" />
                            <asp:Button ID="btnAlterar" runat="server" OnClick="btnAlterar_Click" Text="Salvar" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
