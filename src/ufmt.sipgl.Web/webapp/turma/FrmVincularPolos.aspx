<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmVincularPolos.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmVincularPolos" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField runat="server" ID="hddProjetoCursoUID" />
    <asp:HiddenField runat="server" ID="hddProjetoTurmaUID" />


    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <asp:Panel ID="pnlFormularioInscricao" runat="server">
    
        <div id="containerValidacao">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
        </div>

        <br />

        <table class="Largura100Porcento">

            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbUnidade" runat="server" Style="font-weight: 700" Text="Unidades Disponíveis:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlUnidades" ErrorMessage="Polo" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>

                <td>
                    <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" Enabled="true" AppendDataBoundItems="true" Width="200px">
                        <asp:ListItem>Selecione...</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label8" runat="server" Style="font-weight: 700" Text="Quantidade de Vagas:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQuantidadeVagas" ErrorMessage="Quantidade de Vagas" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtQuantidadeVagas" runat="server" Width="100px"></asp:TextBox>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtQuantidadeVagas" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>
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

    </asp:Panel>

</asp:Content>
