<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ufmt.sipgl.View.LoginN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="panelAviso" runat="server" Visible="false">
        <div class="pnlAviso">
            <img alt="" src="/media/images/alert.png" border="0" />
            &nbsp;&nbsp;
            <asp:Label ID="lblAlerta" runat="server" Text="" Visible="true"></asp:Label>
        </div>
    </asp:Panel>

    <div style="padding-top: 2%;"></div>

    <div class="tela_login">
        <div class="intro">

            <h3>Autenticação de Usuário</h3>
            
            <br />

            <p class="textintro">
                Esta autenticação de usuário utiliza o Login unificado dos Sistemas da UFMT.
            </p>

            <br />
            <br />
            <br />
            <br />

            <p class="textintro">
                <strong>Suporte disponível apenas através do e-mail: </strong><a href="mailto:apoio@ufmt.br">apoio@ufmt.br</a>
            </p>
        </div>

        <div class="login_box">
            <asp:Panel ID="pnlLogin" runat="server">
                <p>
                    <label>
                        <asp:Label runat="server">CPF</asp:Label>
                        <br />
                        <asp:TextBox ID="login" CssClass="login" runat="server"></asp:TextBox>
                    </label>
                </p>
                <p>
                    <label>
                        <asp:Label runat="server">Senha</asp:Label>
                        <br />
                        <asp:TextBox ID="senha" CssClass="senha" runat="server" TextMode="Password"></asp:TextBox>
                    </label>
                </p>
                <div>
                    <div style="float: right;">
                        <asp:ImageButton ID="btEntrar" runat="server" ImageUrl="~/media/images/bt_acessar.png" OnClick="btEntrar_Click" />
                    </div>
                </div>
            </asp:Panel>
        </div>

    </div>
</asp:Content>
