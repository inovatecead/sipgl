<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmImportacao.aspx.cs" Inherits="ufmt.sipgl.View.webapp.importacao.FrmImportacao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="Quantidade" runat="server"></asp:TextBox>
    <asp:LinkButton ID="ImportarHomologados" runat="server" OnClick="ImportarHomologados_Click">Importar Homologados</asp:LinkButton>
    <asp:Label ID="Label1" runat="server" Text="TotalPessoas: "></asp:Label><asp:Label ID="TotalPessoas" runat="server" Text=""></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="TotalInscricoes: "></asp:Label><asp:Label ID="TotalInscricoes" runat="server" Text=""></asp:Label>
</asp:Content>