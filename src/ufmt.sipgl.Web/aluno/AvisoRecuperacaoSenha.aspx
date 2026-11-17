<%@ Page Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="AvisoRecuperacaoSenha.aspx.cs" Inherits="ufmt.sipgl.View.aluno.AvisoRecuperacaoSenha" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Recuperar Senha</h1>

    <br />

    <asp:Panel ID="pnlFormularioInscricao" runat="server">
        <div class="cpfPanel" runat="server" id="divFormulario">

            <br />

            <table>
                <tr>
                    <td>
                        <asp:Label runat="server"  ID="emailRecuperacaoMassage"></asp:Label>

                    </td>
                </tr>

                <tr style="padding: 10px; text-align: center">
                    <td colspan="2">

                        <br />

                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="ui-button" OnClick="btnVoltar_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>

        </div>
    </asp:Panel>
</asp:Content>
