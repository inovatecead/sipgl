<%@ Page Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="ConfirmacaoEmail.aspx.cs" Inherits="ufmt.sipgl.View.aluno.ConfirmacaoEmail" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel runat="server" CssClass="painelEmailConfirmado">
        <asp:Label runat="server" ID="lbPanelCofirmacaoEmail" Visible="false"></asp:Label>

        <br />
        <br />

        <asp:Button ID="btnVoltarHome" runat="server" Text="Realizar Login" OnClick="btnVoltar_Click"/>
    </asp:Panel>
</asp:Content>