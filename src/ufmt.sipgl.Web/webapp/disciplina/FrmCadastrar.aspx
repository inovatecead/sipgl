<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmCadastrar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.disciplina.FrmCadastrar" MaintainScrollPositionOnPostback="true" %>

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

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome" ErrorMessage="Nome" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="735px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbCargaHoraria" runat="server" Style="font-weight: 700" Text="Carga Horária:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCargaHoraria" ErrorMessage="Carga Horária" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCargaHoraria" runat="server" Width="100px"></asp:TextBox>

                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtCargaHoraria" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbTipoDisciplina" runat="server" Style="font-weight: 700" Text="Tipo da Disciplina:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoDisciplina" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Value="">Selecione</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>


                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbEmenta" runat="server" Style="font-weight: 700" Text="Ementa:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmenta" ErrorMessage="Ementa" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmenta" runat="server" Width="735px" Height="95px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="lbBibliografia" runat="server" Style="font-weight: 700" Text="Bibliografia:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBibliografia" ErrorMessage="Bibliografia" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBibliografia" runat="server" Width="735px" Height="95px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150"></td>
                        <td>
                            <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="false" />
                            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </asp:Panel>
</asp:Content>
