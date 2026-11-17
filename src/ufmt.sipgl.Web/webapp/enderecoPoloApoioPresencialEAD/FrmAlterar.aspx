<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmAlterar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.enderecoPoloApoioPresencialEAD.FrmAlterar" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            var basePath = '<%=VirtualPathUtility.ToAbsolute("~/")%>';

            $(function () {

                $("#ContentPlaceHolder1_ddlEnderecoUF").change(function () {
                    $("#ContentPlaceHolder1_txtMunicipio").val("");
                });

                $(".tb").autocomplete({
                    source: function (request, response) {
                        uf = $("#ContentPlaceHolder1_ddlEnderecoUF").val();

                        console.log(basePath);

                        $.ajax({
                            url: basePath + "webapp/WSConsulta.asmx/GetMunicipioPorEstado",
                            data: "{'nome':'" + request.term + "', 'uf':'" + uf + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.MunicipioUID + " | " + item.Nome

                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(textStatus);
                            }
                        });
                    },
                    minLength: 3
                });
            });
        });
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <asp:HiddenField ID="hddEnderecoPoloUID" runat="server" />

    <asp:Panel ID="pnlFormularioInscricao" runat="server">
        <div id="containerValidacao">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
        </div>

        <table class="Largura100Porcento">
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbTipoUnidadeEnsino" runat="server" Style="font-weight: 700" Text="Unidade Adm./Acadêmica:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTipoUnidadeEnsino" ErrorMessage="Tipo de Unidade de Ensino" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTipoUnidadeEnsino" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Value="" Text="Selecione..."></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbDescricao" runat="server" Style="font-weight: 700" Text="Descrição:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescricao" ErrorMessage="Descrição" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtDescricao" runat="server" Width="486px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label27" runat="server" Style="font-weight: 700" Text="Estado:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlEnderecoUF" ErrorMessage="Estado" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEnderecoUF" runat="server" AppendDataBoundItems="true">
                        <asp:ListItem Text="Selecione..." Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label3" runat="server" Style="font-weight: 700" Text="Município:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtMunicipio" ErrorMessage="Município" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMunicipio" runat="server" CssClass="tb" Width="486px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbLogradouro" runat="server" Style="font-weight: 700" Text="Logradouro:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ControlToValidate="txtLogradouro" ErrorMessage="Logradouro" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtLogradouro" runat="server" Width="486px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbCEP" runat="server" Style="font-weight: 700" Text="CEP:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txtCEPendereco" ErrorMessage="CEP" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtCEPendereco" runat="server" Width="77px"></asp:TextBox>

                    <asp:MaskedEditExtender
                        ID="MaskedEditExtender1"
                        runat="server"
                        MaskType="None"
                        Mask="99999\-999"
                        TargetControlID="txtCEPendereco"
                        ClearMaskOnLostFocus="true"
                        ClearTextOnInvalid="true" />
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbNumero" runat="server" Style="font-weight: 700" Text="Número:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtNumeroEndereco" ErrorMessage="Número" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtNumeroEndereco" runat="server" Width="77px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbComplemento" runat="server" Style="font-weight: 700" Text="Complemento:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtComplementoEndereco" runat="server" Width="486px"></asp:TextBox>
                    <span>Ex. Apto 203</span>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbBairro" runat="server" Style="font-weight: 700" Text="Bairro:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="txtBairroEndereco" ErrorMessage="Bairro" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtBairroEndereco" runat="server" Width="486px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbInformacoesReferencia" runat="server" Style="font-weight: 700" Text="Informações de Referência:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtInfoReferenciaEndereco" runat="server" Height="44px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label57" runat="server" Style="font-weight: 700" Text="Telefone:"></asp:Label>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtTelefone" ErrorMessage="Telefone" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtTelefone" runat="server" Width="200px"></asp:TextBox>

                    <asp:MaskedEditExtender
                        ID="MaskedEditExtenderTelefone"
                        runat="server"
                        MaskType="None"
                        Mask="\(99\)9999\-9999"
                        TargetControlID="txtTelefone"
                        ClearMaskOnLostFocus="true"
                        ClearTextOnInvalid="true" />
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbFax" runat="server" Style="font-weight: 700" Text="Fax:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbEmail" runat="server" Style="font-weight: 700" Text="E-mail:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="486px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbSite" runat="server" Style="font-weight: 700" Text="Site:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSite" runat="server" Width="486px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150"></td>
                <td>
                    <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="False" />

                    <asp:Button ID="btnAlterar" runat="server" OnClick="btnAlterar_Click" Text="Alterar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
