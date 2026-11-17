<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmEditarExterno.aspx.cs" Inherits="ufmt.sipgl.View.webapp.docente.FrmEditarExterno" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

    <script type="text/javascript">

</script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <asp:Panel ID="pnlFormularioInscricao" runat="server">

        <asp:HiddenField ID="hddProjetoCorpoDocenteUID" runat="server" />

        <div id="containerValidacao">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
        </div>

        <br />

        <table class="Largura100Porcento">
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Titulação:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTitulacao" ErrorMessage="Titulação" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTitulacao" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label108" runat="server" Style="font-weight: 700" Text="Nome:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator213" runat="server" ControlToValidate="txtNome" ErrorMessage="Nome" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtNome" runat="server" Width="735px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label109" runat="server" Style="font-weight: 700" Text="Sexo:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator114" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Sexo" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSexo" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                        <asp:ListItem Value="F">Feminino</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label17" runat="server" Style="font-weight: 700" Text="Data Nascimento:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator115" runat="server" ControlToValidate="txtDataNascimento" ErrorMessage="Data de Nascimento" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtDataNascimento" runat="server" Width="92px"></asp:TextBox>

                    <asp:MaskedEditExtender
                        ID="txtDataNascimento_MaskedEditExtender"
                        runat="server"
                        CultureDateFormat="pt-br"
                        Enabled="True"
                        Mask="99/99/9999"
                        MaskType="Date"
                        TargetControlID="txtDataNascimento">
                    </asp:MaskedEditExtender>

                    <asp:MaskedEditValidator
                        ID="MaskedEditValidator3"
                        runat="server"
                        ControlExtender="txtDataNascimento_MaskedEditExtender"
                        ControlToValidate="txtDataNascimento"
                        CssClass="failureNotification"
                        Display="Dynamic" ForeColor="Red"
                        InvalidValueMessage="Data no formato inválido"
                        IsValidEmpty="True"></asp:MaskedEditValidator>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label110" runat="server" Style="font-weight: 700" Text="Nome da Mãe:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator116" runat="server" ControlToValidate="txtNomeMae" ErrorMessage="Nome do Pai" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtNomeMae" runat="server" Width="735px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label111" runat="server" Style="font-weight: 700" Text="Nome do Pai:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator117" runat="server" ControlToValidate="txtNomePai" ErrorMessage="Nome do Pai" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtNomePai" runat="server" Width="735px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label13" runat="server" Style="font-weight: 700" Text="CPF:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCpf" ErrorMessage="CPF" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtCpf" runat="server" Width="300px"></asp:TextBox>

                    <asp:MaskedEditExtender ID="MaskedEditExtenderCpf" runat="server" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="999\.999\.999\-99" MaskType="None" TargetControlID="txtCpf" />
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label18" runat="server" Style="font-weight: 700" Text="RG:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtRgNumero" ErrorMessage="Número RG" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtRgNumero" runat="server" Width="146px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label19" runat="server" Style="font-weight: 700" Text="Órgão Expedidor:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddlOrgaoExpedidor" ErrorMessage="Órgão Expedidor" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlOrgaoExpedidor" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label35" runat="server" Style="font-weight: 700" Text="UF Órgão Expedidor:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="ddlOrgaoExpedidor" ErrorMessage="Estado Civil" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlUFOrgaoExpedidor" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label20" runat="server" Style="font-weight: 700" Text="Data Expedição:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator118" runat="server" ControlToValidate="txtDataExpedicao" ErrorMessage="Data de Expedição" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtDataExpedicao" runat="server" Width="92px"></asp:TextBox>

                    <asp:MaskedEditExtender
                        ID="txtDataExpedicao_MaskedEditExtender"
                        runat="server"
                        CultureDateFormat="pt-br"
                        Enabled="True"
                        Mask="99/99/9999"
                        MaskType="Date"
                        TargetControlID="txtDataExpedicao">
                    </asp:MaskedEditExtender>

                    <asp:MaskedEditValidator
                        ID="MEVData1"
                        runat="server"
                        ControlExtender="txtDataExpedicao_MaskedEditExtender"
                        ControlToValidate="txtDataExpedicao"
                        CssClass="failureNotification"
                        Display="Dynamic"
                        ForeColor="Red"
                        InvalidValueMessage="Data no formato inválido"
                        IsValidEmpty="True">
                    </asp:MaskedEditValidator>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label14" runat="server" Style="font-weight: 700" Text="Telefone Fixo:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefoneFixo" runat="server" Width="200px"></asp:TextBox>

                    <asp:MaskedEditExtender ID="MaskedEditExtenderTelefone" runat="server" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="\(99\)9999\-9999" MaskType="None" TargetControlID="txtTelefoneFixo" />
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label113" runat="server" Style="font-weight: 700" Text="Celular:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCelular" ErrorMessage="Celular" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtCelular" runat="server" Width="200px"></asp:TextBox>

                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" ClearMaskOnLostFocus="true" ClearTextOnInvalid="true" Mask="\(99\)9\ 9999\-9999" MaskType="None" TargetControlID="txtCelular" />
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label115" runat="server" Style="font-weight: 700" Text="E-mail:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator119" runat="server" ControlToValidate="txtEmailPessoa" ErrorMessage="E-mail" ForeColor="Red">*</asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmailPessoa" ErrorMessage="E-mail no formato inválido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtEmailPessoa" runat="server" Width="735px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150"></td>
                <td>
                    <asp:Button ID="btnSalvarPessoa" runat="server" OnClick="btnEditarDocenteExterno_Click" Text="Salvar" />
                    <asp:Button ID="btnCancelarPessoa" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
