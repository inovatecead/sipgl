<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmCadastroPessoa.aspx.cs" Inherits="ufmt.sipgl.View.webapp.matriculaPessoa.FrmCadastroPessoa" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>
    &nbsp;
    <asp:Panel ID="pnlDetalheInscricao" runat="server" Visible="false" CssClass="pnlAviso">
        <asp:Panel ID="Panel1" runat="server" Style="text-align: center; padding: 10px">
            <asp:Label ID="lblMsgCadastro" runat="server"></asp:Label>
            &nbsp;
        </asp:Panel>

    </asp:Panel>

    <asp:Panel ID="pnlFormularioInscricao" runat="server">

        <div id="containerMensagens">
            <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
            </asp:Panel>
        </div>

        <div>
            <fieldset>
                <legend style="font-size: x-large">Dados Pessoais</legend>
                <table class="Largura100Porcento">

                    <tr>
                        <td class="Largura150">&nbsp;
                                    <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Nome:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome" ErrorMessage="Nome" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="735px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text="Sexo:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Sexo" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                            <asp:Label ID="Label17" runat="server" Style="font-weight: 700"
                                Text="Data Nascimento:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server"
                                ControlToValidate="txtDataNascimento" ErrorMessage="Data de Nascimento"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataNascimento" runat="server" Width="92px"></asp:TextBox>

                            <asp:MaskedEditExtender ID="txtDataNascimento_MaskedEditExtender" runat="server"
                                CultureDateFormat="pt-br" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                TargetControlID="txtDataNascimento">
                            </asp:MaskedEditExtender>

                            <asp:MaskedEditValidator ID="MaskedEditValidator1" runat="server"
                                ControlExtender="txtDataNascimento_MaskedEditExtender"
                                ControlToValidate="txtDataNascimento" CssClass="failureNotification"
                                Display="Dynamic" ForeColor="Red"
                                InvalidValueMessage="Data no formato inválido" IsValidEmpty="True"></asp:MaskedEditValidator>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label6" runat="server" Style="font-weight: 700"
                                Text="Nome da Mãe:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="txtNomeMae" ErrorMessage="Nome do Pai" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNomeMae" runat="server" Width="735px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label8" runat="server" Style="font-weight: 700"
                                Text="Nome do Pai:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ControlToValidate="txtNomePai" ErrorMessage="Nome do Pai" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                            <asp:MaskedEditExtender ID="MaskedEditExtenderCpf" runat="server" MaskType="None" Mask="999\.999\.999\-99" ClearTextOnInvalid="true" ClearMaskOnLostFocus="true" TargetControlID="txtCpf" />


                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label18" runat="server" Style="font-weight: 700" Text="RG:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                ControlToValidate="txtRgNumero" ErrorMessage="Número RG" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRgNumero" runat="server" Width="146px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label19" runat="server" Style="font-weight: 700" Text="Órgão Expedidor:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtOrgaoExpedidor" ErrorMessage="Órgão Expedidor" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrgaoExpedidor" runat="server" Width="146px" MaxLength="51"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label35" runat="server" Style="font-weight: 700" Text="UF Órgão Expedidor:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="ddlUFOrgaoExpedidor" ErrorMessage="Estado Civil" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlUFOrgaoExpedidor" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label20" runat="server" Style="font-weight: 700"
                                Text="Data Expedição:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server"
                                ControlToValidate="txtDataExpedicao" ErrorMessage="Data de Expedição"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataExpedicao" runat="server" Width="92px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="txtDataExpedicao_MaskedEditExtender" runat="server"
                                CultureDateFormat="pt-br" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                TargetControlID="txtDataExpedicao">
                            </asp:MaskedEditExtender>
                            <asp:MaskedEditValidator ID="MEVData1" runat="server"
                                ControlExtender="txtDataExpedicao_MaskedEditExtender"
                                ControlToValidate="txtDataExpedicao" CssClass="failureNotification"
                                Display="Dynamic" ForeColor="Red"
                                InvalidValueMessage="Data no formato inválido" IsValidEmpty="True"></asp:MaskedEditValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label21" runat="server" Style="font-weight: 700"
                                Text="Estado Civil:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                ControlToValidate="ddlEstadoCivil" ErrorMessage="Estado Civil" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstadoCivil" runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label14" runat="server" Style="font-weight: 700"
                                Text="Telefone Fixo:"></asp:Label>

                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefoneFixo" runat="server"
                                Width="200px"></asp:TextBox>
                            <asp:MaskedEditExtender
                                ID="MaskedEditExtenderTelefone"
                                runat="server"
                                MaskType="None"
                                Mask="\(99\)9999\-9999"
                                TargetControlID="txtTelefoneFixo"
                                ClearMaskOnLostFocus="true"
                                ClearTextOnInvalid="true" />
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label15" runat="server" Style="font-weight: 700"
                                Text="Celular:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server"
                                ControlToValidate="txtTelefoneMovel" ErrorMessage="Celular"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefoneMovel" runat="server"
                                Width="200px"></asp:TextBox>
                            <asp:MaskedEditExtender
                                ID="MaskedEditExtender1"
                                runat="server"
                                MaskType="None"
                                Mask="\(99\)9\ 9999\-9999"
                                TargetControlID="txtTelefoneMovel"
                                ClearMaskOnLostFocus="true"
                                ClearTextOnInvalid="true" />
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label4" runat="server" Style="font-weight: 700" Text="E-mail:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server"
                                ControlToValidate="txtEmail" ErrorMessage="E-mail" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="txtEmail" ErrorMessage="E-mail no formato inválido"
                                ForeColor="Red"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Width="735px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label41" runat="server" Style="font-weight: 700" Text="Titulo de Eleitoral:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtTituloEleitoral" ErrorMessage="Título de Eleitoral" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTituloEleitoral" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label42" runat="server" Style="font-weight: 700" Text="Zona:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtZona" ErrorMessage="Zona" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtZona" runat="server" Width="50px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label43" runat="server" Style="font-weight: 700" Text="UF Titulo de Eleitor:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlTituloEleitorUF" ErrorMessage="UF Título de Eleitor" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTituloEleitorUF" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlTituloEleitorUF_SelectedIndexChanged">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label44" runat="server" Style="font-weight: 700" Text="Município Título Eleitor:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="ddlTituloEleitorMunicipio" ErrorMessage="Município" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTituloEleitorMunicipio" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>


                </table>
            </fieldset>

            <fieldset>
                <legend style="font-size: x-large">Naturalidade</legend>
                <table class="Largura100Porcento">

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label25" runat="server" Style="font-weight: 700" Text="Nacionalidade:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlNacionalidade" ErrorMessage="Nacionalidade" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlNacionalidade" runat="server"
                                AppendDataBoundItems="true">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                                <asp:ListItem Value="B">Brasileira</asp:ListItem>
                                <asp:ListItem Value="E">Estrangeira</asp:ListItem>
                                <asp:ListItem Value="N">Naturalizado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label40" runat="server" Style="font-weight: 700" Text="Passaporte:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPassaporte" Width="300px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label26" runat="server" Style="font-weight: 700" Text="País de Nascimento:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPaisNascimento" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="Brasil" Value="BRA"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label27" runat="server" Style="font-weight: 700" Text="UF:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlNaturalidadeUF" ErrorMessage="UF Endereço" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlNaturalidadeUF" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlNaturalidadeUF_SelectedIndexChanged">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label3" runat="server" Style="font-weight: 700" Text="Município:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="ddlNaturalidadeMunicipio" ErrorMessage="Município" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlNaturalidadeMunicipio" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </fieldset>

            <fieldset>
                <legend style="font-size: x-large">Endereço</legend>
                <table class="Largura100Porcento">

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label7" runat="server" Style="font-weight: 700" Text="Endereço:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                ControlToValidate="txtEndereco" ErrorMessage="Endereço" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEndereco" runat="server" Width="735px"></asp:TextBox>
                            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label22" runat="server" Style="font-weight: 700"
                                Text="Número:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                ControlToValidate="txtEnderecoNumero" ErrorMessage="Número Endereço"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnderecoNumero" runat="server"
                                Width="100px"></asp:TextBox>
                        </td>
                    </tr>


                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label9" runat="server" Style="font-weight: 700"
                                Text="Complemento:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEnderecoComplemento" runat="server" Width="735px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;</td>
                    </tr>


                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label10" runat="server" Style="font-weight: 700"
                                Text="Bairro:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server"
                                ControlToValidate="txtBairro" ErrorMessage="Bairro Endereço" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBairro" runat="server"
                                Width="735px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;</td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label11" runat="server" Style="font-weight: 700"
                                Text="CEP:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server"
                                ControlToValidate="txtCep" ErrorMessage="CEP Endereço" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCep" runat="server"
                                Width="200px"></asp:TextBox>
                            <asp:MaskedEditExtender
                                ID="MaskedEditExtenderCep"
                                runat="server"
                                Mask="99999\-999"
                                MaskType="Number"
                                TargetControlID="txtCep"
                                ClearMaskOnLostFocus="true"
                                ClearTextOnInvalid="true" />
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label34" runat="server" Style="font-weight: 700" Text="UF:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="ddlEnderecoUF" ErrorMessage="UF Município" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEnderecoUF" runat="server" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlEnderecoUF_SelectedIndexChanged">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label12" runat="server" Style="font-weight: 700" Text="Município:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddlEnderecoMunicipio" ErrorMessage="Município" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEnderecoMunicipio" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                </table>
            </fieldset>

            <fieldset>
                <legend style="font-size: x-large">Dados da Graduação</legend>

                <table class="Largura100Porcento">

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label31" runat="server" Style="font-weight: 700" Text="Graduado no Exterior?"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblGraduacaoExterior" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblGraduacaoExterior_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem Value="true">SIM</asp:ListItem>
                                <asp:ListItem Selected="True" Value="false">NÃO</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                </table>

                <asp:Panel ID="pnlNumeroRegistroApostilaRevalidacao" runat="server" Visible="false">
                    <table class="Largura100Porcento">
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label32" runat="server" Style="font-weight: 700"
                                    Text="Número do Registro da Apostila de Revalidação"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server"
                                    ControlToValidate="txtNumeroRegistroApostilaRevalidacao"
                                    ErrorMessage="Número do Registro da Apostila de Revalidação" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtNumeroRegistroApostilaRevalidacao" runat="server"
                                    Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>


                <asp:Panel ID="pnlInstituicaoSuperior" runat="server">
                    <table class="Largura100Porcento">
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label29" runat="server" Style="font-weight: 700"
                                    Text="UF de Graduação:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server"
                                    ControlToValidate="ddlUFGraduacao" ErrorMessage="UF de Graduação"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlUFGraduacao" runat="server"
                                    AppendDataBoundItems="true">
                                    <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="lbTipoGraduacao" runat="server" Style="font-weight: 700" Text="Tipo de Graduação:"></asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTipoGraducao" ErrorMessage="Tipo de Graduação" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoGraducao" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label28" runat="server" Style="font-weight: 700" Text="Curso de Graduação:"></asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCursoGraduacao" ErrorMessage="Curso de Graduação" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtCursoGraduacao" Width="711px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label33" runat="server" Style="font-weight: 700" Text="Número de Registro do Diploma:"></asp:Label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNumeroRegistroDiploma" ErrorMessage="Número de Registro do Diploma" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNumeroRegistroDiploma" Width="711px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="Largura150">
                                <asp:Label ID="Label23" runat="server" Style="font-weight: 700" Text="Instituição de Graduação:"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="ddlInstituicaoEnsino" ErrorMessage="Instituição de Graduação" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlInstituicaoEnsino" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <table class="Largura100Porcento">

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label30" runat="server" Style="font-weight: 700"
                                Text="Data de Colação de Grau:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server"
                                ControlToValidate="txtDataColacaoGrau" ErrorMessage="Data de Colação de Grau"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDataColacaoGrau" runat="server" Width="92px"></asp:TextBox>

                            <asp:MaskedEditExtender ID="txtDataColacaoGrau_MaskedEditExtender" runat="server"
                                CultureDateFormat="pt-br" Enabled="True" Mask="99/99/9999" MaskType="Date"
                                TargetControlID="txtDataColacaoGrau">
                            </asp:MaskedEditExtender>

                            <asp:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                                ControlExtender="txtDataColacaoGrau_MaskedEditExtender"
                                ControlToValidate="txtDataColacaoGrau" CssClass="failureNotification"
                                Display="Dynamic" ForeColor="Red"
                                InvalidValueMessage="Data no formato inválido" IsValidEmpty="True"></asp:MaskedEditValidator>
                        </td>
                    </tr>

                </table>
            </fieldset>

            <fieldset>
                <legend style="font-size: x-large">Profissão</legend>

                <table class="Largura100Porcento">
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label36" runat="server" Style="font-weight: 700" Text="Profissão:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtProfissao" Width="711px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label37" runat="server" Style="font-weight: 700" Text="Empresa onde trabalha:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmpresaTrabalho" Width="711px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label16" runat="server" Style="font-weight: 700" Text="Telefone Comercial:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTelefoneComercial" runat="server" Width="200px"></asp:TextBox>
                            <asp:MaskedEditExtender
                                ID="MaskedEditExtender2"
                                runat="server"
                                MaskType="None"
                                Mask="\(99\)9999\-9999"
                                TargetControlID="txtTelefoneComercial"
                                ClearMaskOnLostFocus="true"
                                ClearTextOnInvalid="true" />
                        </td>
                    </tr>

                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label39" runat="server" Style="font-weight: 700" Text="Celular Comercial:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCelularComercial" runat="server" Width="200px"></asp:TextBox>
                            <asp:MaskedEditExtender
                                ID="MaskedEditExtender3"
                                runat="server"
                                MaskType="None"
                                Mask="\(99\)9 9999\-9999"
                                TargetControlID="txtCelularComercial"
                                ClearMaskOnLostFocus="true"
                                ClearTextOnInvalid="true" />
                        </td>
                    </tr>


                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label38" runat="server" Style="font-weight: 700" Text="E-mail Comercial:"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtEmailComercial"
                                ErrorMessage="E-mail no formato inválido"
                                ForeColor="Red"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmailComercial" runat="server" Width="735px"></asp:TextBox>
                        </td>
                    </tr>

                </table>
            </fieldset>

            <br />

        </div>


        <div style="padding-top: 10px; text-align: center">
            <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Cadastrar" CssClass="ui-button" />
            <asp:Button ID="btnCancelar" runat="server" CssClass="ui-button" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />

            <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
            <asp:HiddenField ID="hddNomeCurso" runat="server" />
            <asp:HiddenField ID="hddEnderecoPoloUID" runat="server" />

        </div>

    </asp:Panel>

</asp:Content>
