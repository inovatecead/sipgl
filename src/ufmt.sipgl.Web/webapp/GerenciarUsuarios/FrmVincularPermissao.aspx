<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmVincularPermissao.aspx.cs" Inherits="ufmt.sipgl.View.webapp.GerenciarUsuarios.FrmVincularPermissao" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <asp:HiddenField ID="hddUsuarioUID" runat="server" />

    <asp:Panel ID="pnlFormularioInscricao" runat="server">
        <div id="containerMensagens">
            <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
            </asp:Panel>
        </div>

        <br />

        <div>
            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbNome" runat="server" Style="font-weight: 700" Text="Nome:"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="txtNome" runat="server" Width="735px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbCPF" runat="server" Style="font-weight: 700" Text="CPF:"></asp:Label>
                    </td>

                    <td>
                        <asp:TextBox ID="txtCPF" runat="server" Width="110px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Permissões:"></asp:Label>
                    </td>

                    <td>
                        <asp:CheckBoxList runat="server" ID="cbxPermissoes" AppendDataBoundItems="true" TextAlign="Right">
                        </asp:CheckBoxList>
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
