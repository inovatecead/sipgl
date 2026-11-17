<%@ Page Title="" Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="FrmAlterarSenha.aspx.cs" Inherits="ufmt.sipgl.View.FrmAlterarSenha" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hddPreMatriculaPessoaUID" runat="server" />

    <asp:Panel ID="pnlFormularioInscricao" runat="server" CssClass="passwordPanel">
        <div class="containerAlteracaoSenha" runat="server" id="divFormulario">
            <h1>Alterar Senha</h1>

            <br />

            <div id="containerValidacao">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
            </div>

            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">&nbsp;
                        <asp:Label ID="lbSenhaAntiga" runat="server" Style="font-weight: 700" Text="Senha Antiga:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSenhaAntiga" Display="Dynamic" ErrorMessage="Senha Antiga" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSenhaAntiga" runat="server" Width="250px" MaxLength="15" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">&nbsp;
                        <asp:Label ID="lbNovaSenha" runat="server" Style="font-weight: 700" Text="Nova Senha:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNovaSenha" Display="Dynamic" ErrorMessage="Nova Senha" ForeColor="Red">*</asp:RequiredFieldValidator>

                        <asp:CompareValidator ID="CompareValidatorSenhas" runat="server" ControlToCompare="txtNovaSenha" ControlToValidate="txtConfirmarSenha" Display="Dynamic" ErrorMessage="As senhas não são iguais " ForeColor="Red" ValidationGroup="senha">* </asp:CompareValidator>

                    </td>
                    <td>
                        <asp:TextBox ID="txtNovaSenha" runat="server" Width="250px" MaxLength="15" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">&nbsp;
                        <asp:Label ID="lbConfirmarSenha" runat="server" Style="font-weight: 700" Text="Confirmar Senha:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmarSenha" Display="Dynamic" ErrorMessage="Confirmar Senha" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmarSenha" runat="server" Width="250px" MaxLength="15" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <br />

            <div style="padding: 10px; text-align: center">
                <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" CssClass="ui-button" Text="Salvar" />
                <asp:Button ID="btnVoltar" runat="server" CausesValidation="False" OnClick="btnVoltar_Click" Text="Cancelar" CssClass="ui-button" />
            </div>
        </div>

    </asp:Panel>

</asp:Content>
