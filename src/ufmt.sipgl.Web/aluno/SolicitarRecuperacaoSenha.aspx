<%@ Page Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="SolicitarRecuperacaoSenha.aspx.cs" Inherits="ufmt.sipgl.View.aluno.SolicitarRecuperacaoSenha" %>

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
                        <asp:Label ID="lbCPF" runat="server" Text="Informe seu CPF para continuar:" Style="font-weight: 700"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtCpf" ErrorMessage="CPF" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCpf" runat="server" Width="175px"></asp:TextBox>

                        <asp:MaskedEditExtender ID="txtVerificarCpf_MaskedEditExtender" runat="server"
                            ClearMaskOnLostFocus="true"
                            ClearTextOnInvalid="true"
                            Mask="999\.999\.999\-99"
                            MaskType="None"
                            TargetControlID="txtCpf">
                        </asp:MaskedEditExtender>
                    </td>
                </tr>

                <tr style="padding: 10px; text-align: center">
                    <td colspan="2">

                        <br />

                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="ui-button" ValidationGroup="recsenha" OnClick="btnSolicitarRecuperacaoSenha_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-button" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>

        </div>
    </asp:Panel>
</asp:Content>
