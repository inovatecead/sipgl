<%@ Page Title="" Language="C#" MasterPageFile="~/aluno/Default.Master" AutoEventWireup="true" CodeBehind="FrmVerificarCadastro.aspx.cs" Inherits="ufmt.sipgl.View.FrmVerificarCadastro" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Verificação de Cadastro</h1>

    <br />

    <asp:Panel ID="pnlFormularioInscricao" runat="server">
        <div class="cpfPanel" runat="server" id="divFormulario">

            <br />

            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbCPF" runat="server" Text="Informe seu CPF para continuar:" Style="font-weight: 700"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtCPF" ErrorMessage="CPF" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCPF" runat="server" Width="175px"></asp:TextBox>

                        <asp:MaskedEditExtender ID="txtVerificarCpf_MaskedEditExtender" runat="server"
                            ClearMaskOnLostFocus="true"
                            ClearTextOnInvalid="true"
                            Mask="999\.999\.999\-99"
                            MaskType="None"
                            TargetControlID="txtCPF">
                        </asp:MaskedEditExtender>
                    </td>
                </tr>

                <tr style="padding: 10px; text-align: center">
                    <td colspan="2">

                        <br />

                        <asp:Button ID="btnVerificarCadastro" runat="server" OnClick="btnVerificarCadastro_Click" CssClass="ui-button" Text="Verificar" />
                        <asp:Button ID="btnCancelar" runat="server" CausesValidation="False" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="ui-button" />
                    </td>
                </tr>
            </table>
        </div>

    </asp:Panel>

</asp:Content>
