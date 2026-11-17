<%@ Page Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="RecuperacaoSenha.aspx.cs" Inherits="ufmt.sipgl.View.aluno.RecuperacaoSenha" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Recuperar Senha</h1>

    <br />

    <asp:Panel ID="pnlFormularioInscricao" runat="server">

        <div id="containerValidacao">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
        </div>

        <asp:HiddenField runat="server" ID="hddCPF" />
        <asp:HiddenField runat="server" ID="hddChaveRecuperacaoSenha" />

        <div class="cpfPanel" runat="server" id="divFormulario">

            <br />

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbNovaSenha" runat="server" Style="font-weight: 700" Text="Nova Senha"></asp:Label>

                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNovaSenha" ControlToValidate="txtConfirmarSenha" Display="Dynamic" ErrorMessage="* As senhas não são iguais " ForeColor="Red">* </asp:CompareValidator>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNovaSenha" Display="Dynamic" ErrorMessage="* Nova Senha" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div style="padding-bottom: 8px;">
                            <asp:TextBox ID="txtNovaSenha" runat="server" MaxLength="15" TextMode="Password" Width="177px"></asp:TextBox>

                            
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lbQuantidadeCaracteres" runat="server" Style="font-weight: 500" Text="* Mínimo de 6 caracteres"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbConfirmarSenha" runat="server" Text="Confirmar Senha" Style="font-weight: 700"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtConfirmarSenha" Display="Dynamic" ErrorMessage="* Confirmar Senha" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmarSenha" runat="server" MaxLength="15" TextMode="Password" Width="177px"></asp:TextBox>
                    </td>
                </tr>

                <tr style="padding: 10px; text-align: center">
                    <td colspan="2">

                        <br />

                        <asp:Button ID="btnAlterarSenha" runat="server" Text="Alterar Senha" CssClass="ui-button" ValidationGroup="recsenha" OnClick="btnAlterarSenha_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-button" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>

        </div>
    </asp:Panel>
</asp:Content>

<%--<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Panel runat="server" CssClass="painelEmailConfirmado">

        <asp:HiddenField runat="server" ID="hddCPF"/>
        <asp:HiddenField runat="server" ID="hddChaveRecuperacaoSenha"/>

        <fieldset>
            <legend style="font-size: x-large">Recuperação de senha</legend>

            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblSenha" runat="server" Style="font-weight: 700" Text="Crie sua senha"></asp:Label>

                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtSenha" ControlToValidate="txtConfirmarSenha" Display="Dynamic" ErrorMessage="* As senhas não são iguais " ForeColor="Red">* </asp:CompareValidator>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtSenha" Display="Dynamic" ErrorMessage="* Senha" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div style="padding-bottom: 8px;">
                            <asp:TextBox ID="txtSenha" runat="server" MaxLength="15" TextMode="Password" Width="177px"></asp:TextBox>

                            <asp:Label ID="Label28" runat="server" Style="font-weight: 700" Text="* Mínimo de 6 caracteres"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label33" runat="server" Text="Digite a senha novamente" Style="font-weight: 700"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtConfirmarSenha" Display="Dynamic" ErrorMessage="* Confirmar Senha" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtConfirmarSenha" runat="server" MaxLength="15" TextMode="Password" Width="177px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnEnviar" runat="server" Text="Alterar Senha" CssClass="ui-button" ValidationGroup="recsenha" OnClick="btnRecuperarSenha_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-button" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
</asp:Content>--%>
