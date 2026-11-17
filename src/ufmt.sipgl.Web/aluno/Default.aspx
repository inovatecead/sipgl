<%@ Page Title="" Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ufmt.sipgl.View.FrmLoginPreMatricula" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelAviso" runat="server" Visible="false">
        <div class="pnlAviso">
            <img alt="" src="/media/images/alert.png" border="0" />
            <asp:Label ID="lblAlerta" runat="server" Text="" Visible="true"></asp:Label>
        </div>
    </asp:Panel>

    <div style="padding-top: 30px;"></div>

    <div class="tela_login">
        <div class="intro">

            <h3>Área do ALUNO</h3>
            <p class="textintro">
                Informe o seu CPF e Número e senha para continuar.
            </p>
            <p class="textintro">
                <asp:HyperLink ID="lnkCadastrar" runat="server">Ainda não possui cadastro? Clique aqui</asp:HyperLink>
                <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
            </p>
            <p class="textintro">
                <asp:HyperLink ID="lnkRecuperarSenha" runat="server">Esqueceu a sua senha? Clique aqui</asp:HyperLink>
            </p>
        </div>

        <div class="login_box">
            <asp:Panel ID="pnlLogin" runat="server">

                <p>
                    <asp:Label runat="server" Text="CPF"> </asp:Label>
                    <br />
                    <asp:TextBox ID="login" CssClass="login" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Label runat="server" Text="Senha"> </asp:Label>
                    <br />
                    <asp:TextBox ID="senha" CssClass="senha" runat="server" TextMode="Password"></asp:TextBox>
                </p>
                <div>
                    <div style="float: right">
                        <asp:ImageButton ID="btEntrar" runat="server" ImageUrl="~/media/images/bt_acessar.png" OnClick="btEntrar_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
