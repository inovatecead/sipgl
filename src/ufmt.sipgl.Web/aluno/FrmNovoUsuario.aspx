<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="FrmNovoUsuario.aspx.cs" Inherits="ufmt.sipgl.View.FrmNovoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        Cadastro de novo usuário</h1>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/FrmProReitoria.aspx" runat="server">&gt;&gt; Voltar</asp:HyperLink>
    <asp:Panel ID="PanelFormulario" runat="server">
        <div class="containerFormulario">
            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">
                        <label>
                            CPF:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtcpf" runat="server" Width="80px"></asp:TextBox>
                        * Sem pontos ou vírgulas. Apenas números.
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <label>
                            Data de Nascimento:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtdatanascimento" runat="server" Width="70px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <label>
                            E-mail:</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtemail" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                     <td class="Largura150">
                     &nbsp;
                     </td>
                    <td align="left">
                        <asp:ImageButton ID="btSalvar" runat="server" 
                        ImageUrl="~/media/images/savebutton.png" onclick="btSalvar_Click" />
                    </td>
                </tr>
            </table>
</div>
</asp:Panel>
<asp:Panel ID="panelAviso" runat="server" Visible="false">    
        <div class="pnlAviso">
                    <img alt="" src="/media/images/alerta.png" border="0" />&nbsp;&nbsp;
                    <asp:Label ID="lblAlerta" runat="server" Text="" Visible="true"></asp:Label>
        </div>
</asp:Panel>
</asp:Content>
