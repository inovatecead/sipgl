<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmSelecionarPerfil.aspx.cs" Inherits="ufmt.sipgl.View.FrmSelecionarPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

<h1>
<asp:Label ID="lblProReitoria" runat="server" Text="Label"></asp:Label>
</h1>

    <div style="margin-bottom:20px;font-family:Arial Narrow;font-size:22px">
    Selecione o Perfil de Acesso: 
    </div>


        <asp:Repeater ID="rpPerfilAcesso" runat="server" 
        onitemcommand="rpPerfilAcesso_ItemCommand" 
        onitemdatabound="rpPerfilAcesso_ItemDataBound">
        <ItemTemplate>
        <div style="margin-bottom:5px;">
                <fieldset>
                    <legend><asp:Label ID="lblNomePermissao" runat="server" Text='<%# Eval("Nome") %>' CssClass="ArialTamanho22"></asp:Label></legend>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Descricao") %>'></asp:Label><br />
                    <br /><asp:LinkButton ID="lnkButton1" runat="server" CommandName="SetPermissao" CommandArgument='<%# Eval("PermissaoUID") %>'>Acessar</asp:LinkButton>

                </fieldset>
        </div>
        </ItemTemplate>
        </asp:Repeater>

</asp:Content>
