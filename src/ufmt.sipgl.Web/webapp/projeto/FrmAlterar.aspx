<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmAlterar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.projeto.FrmAlterar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            var basePath = '<%=VirtualPathUtility.ToAbsolute("~/")%>';

            $(function () {
                $(".tb").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: basePath + "webapp/WSConsulta.asmx/GetCoordenador",
                            data: "{ 'nome': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.siape + " | " + item.nome

                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(textStatus);
                            }
                        });
                    },
                    minLength: 4
                });
            });


            $(function () {
                $(".tb2").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: basePath + "webapp/WSConsulta.asmx/GetUnidade",
                            data: "{ 'nome': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.unidadeUID + " | " + item.nomeConcatenado

                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(textStatus);
                            }
                        });
                    },
                    minLength: 2
                });
            });

            $(function () {

                $(".tb4").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: basePath + "webapp/WSConsulta.asmx/GetMunicipio",
                            data: "{ 'nome': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.MunicipioUID + " | " + item.Nome + ", " + item.UF

                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(textStatus);
                            }
                        });
                    },
                    minLength: 2
                });
            });

            $(function () {
                $(".tb5").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: basePath + "webapp/WSConsulta.asmx/GetPessoaIDBUFMT",
                            data: "{ 'nome': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            success: function (data) {
                                response($.map(data.d, function (item) {
                                    return {
                                        value: item.Cpf + " | " + item.Nome

                                    }
                                }))
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                alert(textStatus);
                            }
                        });
                    },
                    minLength: 4
                });
            });

            $(function () {
                $("#tabs").tabs();
            });

        });
    </script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        <asp:Label ID="lblTitulo" runat="server">Editar Curso</asp:Label>
        <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
    </h1>

    <div id="containerMensagens">
        <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
            <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
        </asp:Panel>
    </div>

    <asp:Panel ID="PanelObjProjetoCurso" runat="server">
        <div class="containerFormulario">
            <div id="containerValidacao">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
            </div>

            <table class="Largura100Porcento">

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label8" runat="server" Style="font-weight: 700" Text="Modalidade:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="ddlModalidade" ErrorMessage="Modalidade" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlModalidade" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModalidade_SelectedIndexChanged" Enabled="true">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label105" runat="server" Style="font-weight: 700" Text="Grande Área:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ControlToValidate="ddlGrandeArea" ErrorMessage="Grande Área" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGrandeArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGrandeArea_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label106" runat="server" Style="font-weight: 700" Text="Área:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="ddlSubArea" ErrorMessage="Área" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label107" runat="server" Style="font-weight: 700" Text="Sub-Área:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" ControlToValidate="ddlSubArea" ErrorMessage="Sub-Área" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubArea" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label7" runat="server" Style="font-weight: 700" Text="Código EMEC:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCodigoEMEC" ErrorMessage="Código EMEC" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigoEMEC" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label34" runat="server" Style="font-weight: 700" Text="Nome do Curso Lato Sensu:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtNomeCurso" ErrorMessage="Nome do Curso Lato Sensu" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNomeCurso" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <asp:Panel ID="pnlPeriodicidade" runat="server" Visible="false">
                        <td class="Largura150">
                            <asp:Label runat="server" Text="Periodicidade:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator112" runat="server" ControlToValidate="rblPeriodicidade" ErrorMessage="Periodicidade" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblPeriodicidade" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblPeriodicidade_SelectedIndexChanged">
                            </asp:RadioButtonList>

                            <asp:Panel ID="pnlPeriodicidadeDiario" runat="server">
                                <strong>
                                    <asp:Label runat="server" Text="Diário – Carga Horária:"></asp:Label>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator109" runat="server" ControlToValidate="txtCargaHorariaDiario" ErrorMessage="Carga Horária Diário" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </strong>

                                <br />

                                <asp:TextBox ID="txtCargaHorariaDiario" runat="server" MaxLength="4" Width="77px"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtCargaHorariaDiario" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>

                                <br />

                            </asp:Panel>

                            <asp:Panel ID="pnlPeriodicidadeModular" runat="server">
                                <strong>
                                    <asp:Label runat="server" Text="Modular – Carga Horária:"></asp:Label>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator110" runat="server" ControlToValidate="txtCargaHorariaModular" ErrorMessage="Carga Horária Modular" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </strong>

                                <br />

                                <asp:TextBox ID="txtCargaHorariaModular" runat="server" MaxLength="4" Width="77px"></asp:TextBox>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtCargaHorariaModular" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>

                                <br />

                                <strong>
                                    <asp:Label runat="server" Text="Nome do Curso Modular:"></asp:Label>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNomeCursoModular" runat="server" ControlToValidate="txtNomeCursoModular" ErrorMessage="Nome do curso modular" ForeColor="Red">*</asp:RequiredFieldValidator>
                                </strong>

                                <br />

                                <asp:TextBox ID="txtNomeCursoModular" runat="server" Width="486px"></asp:TextBox>

                                <br />

                                <span>* o servidor somente poderá participar do curso fora do horário previsto para exercer suas funções.</span>

                            </asp:Panel>
                        </td>
                    </asp:Panel>

                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label35" runat="server" Style="font-weight: 700" Text="Unidade Proponente:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtUnidadeProponente" ErrorMessage="Unidade Proponente" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUnidadeProponente" runat="server" CssClass="tb2" Width="600px"></asp:TextBox>

                        <asp:Label ID="lblNomeUnidade" runat="server"></asp:Label>

                        <asp:HiddenField ID="hddUnidadeUID" runat="server" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtUnidadeProponente" Display="Dynamic" ErrorMessage="Escolha a Unidade" ForeColor="Red" ValidationGroup="unid">* Escolha a unidade</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150"></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Endereço:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ControlToValidate="txtEndereco" ErrorMessage="Endereço" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEndereco" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Cidade:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ControlToValidate="txtCidade" ErrorMessage="Cidade" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCidade" runat="server" Width="486px" CssClass="tb4"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="CEP:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txtCEPendereco" ErrorMessage="CEP" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCEPendereco" runat="server" Width="77px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Número:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtNumeroEndereco" ErrorMessage="Número" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroEndereco" runat="server" Width="77px"></asp:TextBox>

                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator11"
                            runat="server"
                            ControlToValidate="txtNumeroEndereco"
                            Display="Dynamic"
                            ErrorMessage="* São permitidos apenas números"
                            ForeColor="Red"
                            ValidationExpression="^[0-9]+$">
                            <span>* Digite somente números</span>
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Complemento:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtComplementoEndereco" runat="server" Width="486px"></asp:TextBox>

                        <span>Ex. Apto 203</span>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Bairro:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="txtBairroEndereco" ErrorMessage="Bairro" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBairroEndereco" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Informações de Referência:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtInfoReferenciaEndereco" runat="server" class="tb" Height="44px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label57" runat="server" Style="font-weight: 700" Text="Telefone do Curso:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtTelefone" ErrorMessage="Telefone do Curso" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                        <asp:Label ID="Label56" runat="server" Style="font-weight: 700" Text="Fax:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFax" runat="server" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label36" runat="server" Style="font-weight: 700" Text="E-mail:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail do Curso" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label37" runat="server" Style="font-weight: 700" Text="Site do Curso:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSiteCurso" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label38" runat="server" Style="font-weight: 700" Text="Coordenador:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtCoordenador" ErrorMessage="Coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCoordenador" runat="server" class="tb" Width="415px"></asp:TextBox>

                        <asp:Label ID="lblNomeCoordenador" runat="server"></asp:Label>

                        <asp:HiddenField ID="hddCoordenadorServidorUID" runat="server" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtCoordenador" Display="Dynamic" ErrorMessage="Escolha o Coordenador" ForeColor="Red" ValidationGroup="coord">* Escolha o Coordenador</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Titulação Coordenador:">

                        </asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="ddlTitulacaoCoordenador" ErrorMessage="Titulação coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTitulacaoCoordenador" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Regime de Trabalho Coordenador:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="ddlRegimeTabalhoCoordenador" ErrorMessage="Regime de Trabalho Coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRegimeTabalhoCoordenador" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Telefone Residencial:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefoneCoordenador" runat="server" Width="200px"></asp:TextBox>

                        <asp:MaskedEditExtender
                            ID="MaskedEditExtender2"
                            runat="server"
                            MaskType="None"
                            Mask="\(99\)9999\-9999"
                            TargetControlID="txtTelefoneCoordenador"
                            ClearMaskOnLostFocus="true"
                            ClearTextOnInvalid="true" />
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Telefone Celular:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefoneCelularCoordenador" runat="server" Width="200px"></asp:TextBox>

                        <asp:MaskedEditExtender
                            ID="MaskedEditExtender3"
                            runat="server"
                            MaskType="None"
                            Mask="\(99\)9\ 9999\-9999"
                            TargetControlID="txtTelefoneCelularCoordenador"
                            ClearMaskOnLostFocus="true"
                            ClearTextOnInvalid="true" />
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="E-mail:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="txtEmailCoordenador" ErrorMessage="E-mail Coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailCoordenador" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label10" runat="server" Style="font-weight: 700" Text="Vice-Coordenador:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCoordenador" ErrorMessage="Vice-Coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtViceCoordenador" runat="server" Width="415px" class="tb"></asp:TextBox>

                        <asp:Label ID="lblNomeViceCoordenador" runat="server"></asp:Label>

                        <asp:HiddenField ID="hddViceCoordenadorServidorUID" runat="server" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtViceCoordenador" Display="Dynamic" ErrorMessage="Escolha o Coordenador" ForeColor="Red" ValidationGroup="coord">* Escolha o Coordenador</asp:RequiredFieldValidator>
                    </td>
                </tr>


                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label6" runat="server" Style="font-weight: 700" Text="Titulação Vice-Coordenador:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="ddlTitulacaoViceCoordenador" ErrorMessage="Titulação Vice-Coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTitulacaoViceCoordenador" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Regime de Trabalho Vice-Coordenador:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="ddlRegimeTabalhoViceCoordenador" ErrorMessage="Regime de trabalho Vice-Coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlRegimeTabalhoViceCoordenador" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Telefone Residencial:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefoneViceCoordenador" runat="server" Width="200px"></asp:TextBox>

                        <asp:MaskedEditExtender
                            ID="MaskedEditExtender5"
                            runat="server"
                            MaskType="None"
                            Mask="\(99\)9999\-9999"
                            TargetControlID="txtTelefoneViceCoordenador"
                            ClearMaskOnLostFocus="true"
                            ClearTextOnInvalid="true" />
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Telefone Celular:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefoneCelularViceCoordenador" runat="server" Width="200px"></asp:TextBox>

                        <asp:MaskedEditExtender
                            ID="MaskedEditExtender4"
                            runat="server"
                            MaskType="None"
                            Mask="\(99\)9\ 9999\-9999"
                            TargetControlID="txtTelefoneCelularViceCoordenador"
                            ClearMaskOnLostFocus="true"
                            ClearTextOnInvalid="true" />
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="E-mail:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEmailViceCoordenador" ErrorMessage="E-mail Vice-Coordenador" ForeColor="Red">*</asp:RequiredFieldValidator>

                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailViceCoordenador" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>

                <%-- Secretário --%>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbSecretario" runat="server" Style="font-weight: 700" Text="Secretário:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSecretario" ErrorMessage="Secretario" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSecretario" runat="server" class="tb5" Width="415px"></asp:TextBox>

                        <asp:Label ID="lbNomeSecretario" runat="server"></asp:Label>

                        <asp:HiddenField ID="hddSecretarioUID" runat="server" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtSecretario" Display="Dynamic" ErrorMessage="Escolha o Secretario" ForeColor="Red" ValidationGroup="coord">* Escolha o Secretário</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="E-mail:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEmailSecretario" ErrorMessage="E-mail Secretário" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailSecretario" runat="server" Width="486px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Telefone Celular:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelularSecretario" runat="server" Width="200px"></asp:TextBox>

                        <asp:MaskedEditExtender
                            ID="MaskedEditExtender6"
                            runat="server"
                            MaskType="None"
                            Mask="\(99\)9\ 9999\-9999"
                            TargetControlID="txtCelularSecretario"
                            ClearMaskOnLostFocus="true"
                            ClearTextOnInvalid="true" />
                    </td>
                </tr>

                <%-- Fim Secretário --%>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label15" runat="server" Style="font-weight: 700" Text="Data de Início da Realização:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="txtDataInicioRealizacao" ErrorMessage="Data de Início da Realização" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataInicioRealizacao" runat="server" Width="92px"></asp:TextBox>

                        <asp:CalendarExtender
                            ID="txtDataInicioRealizacao_CalendarExtender"
                            runat="server"
                            Enabled="False"
                            Format="dd/MM/yyyy"
                            PopupButtonID="imgCalendarioData6"
                            TargetControlID="txtDataInicioRealizacao">
                        </asp:CalendarExtender>

                        <asp:MaskedEditExtender
                            ID="txtDataInicioRealizacao_MaskedEditExtender"
                            runat="server"
                            CultureDateFormat="pt-br"
                            CultureDatePlaceholder=""
                            Enabled="True"
                            Mask="99/99/9999"
                            MaskType="Date"
                            TargetControlID="txtDataInicioRealizacao">
                        </asp:MaskedEditExtender>

                        <asp:MaskedEditValidator
                            ID="MEVData2"
                            runat="server"
                            ControlExtender="txtDataInicioRealizacao_MaskedEditExtender"
                            ControlToValidate="txtDataInicioRealizacao"
                            CssClass="failureNotification"
                            Display="Dynamic"
                            ErrorMessage="MEVData1"
                            ForeColor="Red"
                            InvalidValueMessage="Data no Formato Inválido"></asp:MaskedEditValidator>

                        <span>* Data de início efetivo das aulas do curso.</span>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label16" runat="server" Style="font-weight: 700" Text="Data de Fim da Realização:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator100" runat="server" ControlToValidate="txtDataFimRealizacao" ErrorMessage="Data de Fim da Realização" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataFimRealizacao" runat="server" Width="92px"></asp:TextBox>

                        <asp:CalendarExtender
                            ID="CalendarExtender1"
                            runat="server"
                            Enabled="False"
                            Format="dd/MM/yyyy"
                            PopupButtonID="imgCalendarioData6"
                            TargetControlID="txtDataFimRealizacao">
                        </asp:CalendarExtender>

                        <asp:MaskedEditExtender
                            ID="MaskedEditExtender1"
                            runat="server"
                            CultureDateFormat="pt-br"
                            CultureDatePlaceholder=""
                            Enabled="True"
                            Mask="99/99/9999"
                            MaskType="Date"
                            TargetControlID="txtDataFimRealizacao">
                        </asp:MaskedEditExtender>

                        <asp:MaskedEditValidator
                            ID="MaskedEditValidator1"
                            runat="server"
                            ControlExtender="MaskedEditExtender1"
                            ControlToValidate="txtDataFimRealizacao"
                            CssClass="failureNotification"
                            Display="Dynamic"
                            ErrorMessage="MEVData1"
                            ForeColor="Red"
                            InvalidValueMessage="Data no formato inválido">
                        </asp:MaskedEditValidator>

                        <span>* Data da defesa da última monografia ou trabalho de conclusão do curso</span>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label46" runat="server" Style="font-weight: 700" Text="Minuta de Edital:"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUploadMinutaEdital" runat="server" />

                        <asp:Button ID="btnDownloadMinutaEdital" runat="server" OnClick="DownloadMinutaEdital_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Minuta de Edital.pdf" CausesValidation="false" />

                        <br />

                        <span>* Arquivo em PDF com minuta de edital elaborado nos moldes do Anexo IV da Resolução Consepe nº 55/2014.</span>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label5" runat="server" Style="font-weight: 700" Text="Data do Documento de Aprovação do Curso:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server" ControlToValidate="txtDataDocumentoAprovacaoCurso" ErrorMessage="Data do Documento de Aprovação do Curso" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataDocumentoAprovacaoCurso" runat="server" Width="92px"></asp:TextBox>

                        <asp:CalendarExtender
                            ID="txtDataDocumentoAprovacaoCurso_CalendarExtender"
                            runat="server"
                            Enabled="False"
                            Format="dd/MM/yyyy"
                            PopupButtonID="imgCalendarioData6"
                            TargetControlID="txtDataDocumentoAprovacaoCurso">
                        </asp:CalendarExtender>

                        <asp:MaskedEditExtender
                            ID="txtDataDocumentoAprovacaoCurso_MaskedEditExtender"
                            runat="server"
                            CultureDateFormat="pt-br"
                            CultureDatePlaceholder=""
                            Enabled="True"
                            Mask="99/99/9999"
                            MaskType="Date"
                            TargetControlID="txtDataDocumentoAprovacaoCurso">
                        </asp:MaskedEditExtender>

                        <asp:MaskedEditValidator
                            ID="MEVData3"
                            runat="server"
                            ControlExtender="txtDataInicioRealizacao_MaskedEditExtender"
                            ControlToValidate="txtDataDocumentoAprovacaoCurso"
                            CssClass="failureNotification"
                            Display="Dynamic"
                            ErrorMessage="MEVData1"
                            ForeColor="Red"
                            InvalidValueMessage="Data no formato inválido">
                        </asp:MaskedEditValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label2" runat="server" Style="font-weight: 700" Text="Documento de Aprovação do Curso:"></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUploaDocumentoAprovacaoCurso" runat="server" />

                        <asp:Button ID="btnDownloadDocumentoAprovacaoCurso" runat="server" OnClick="DownloadDocumentoAprovacao_Click" OnClientClick="window.document.forms[0].target='_blank';" Text="Documento de Aprovação.pdf" CausesValidation="false" />

                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label40" runat="server" Style="font-weight: 700" Text="Carga Horária Total:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtCargaHorariaTotal" ErrorMessage="Carga Horária Total" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCargaHorariaTotal" runat="server" MaxLength="4" Width="77px"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtCargaHorariaTotal" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>

                        <span>* mínimo de 360 horas</span>
                    </td>
                </tr>
                <asp:Panel ID="pnlTurnoOferta" runat="server">
                    <tr>
                        <td class="Largura150">
                            <asp:Label runat="server" Text="Turno de Oferta:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator108" runat="server" ControlToValidate="ddlTurnoOferta" ErrorMessage="Turno de Oferta" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTurnoOferta" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td class="Largura150">
                        <asp:Label runat="server" Text="Quantidade de Vagas:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator97" runat="server" ControlToValidate="txtQtdVagas" ErrorMessage="Quandidade de Vagas" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQtdVagas" runat="server" MaxLength="4" Width="77px"></asp:TextBox>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtQtdVagas" Display="Dynamic" ErrorMessage="* São permitidos apenas números" ForeColor="Red" ValidationExpression="^[0-9]+$">* Digite somente números</asp:RegularExpressionValidator>

                        <span>* Este item deverá especificar o número de vagas total ofertado, assim como o número de vagas reservadas, conforme resolução Consepe nº 55/2014, para os servidores (mínimo 5%) e para a comunidade carente (mínimo 5%).</span>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label49" runat="server" Style="font-weight: 700" Text="Nota Mínima Aprovação:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNotaMinimaAprovacao" runat="server" MaxLength="4" Width="77px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label50" runat="server" Style="font-weight: 700" Text="Frequência Mínima Aprovação:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFrequenciaMinimaAprovacao" runat="server" MaxLength="4" Width="77px" Enabled="false"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label3" runat="server" Style="font-weight: 700" Text="Justificativa do Curso:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtJustificativaCurso" ErrorMessage="Justificativa do Curso" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtJustificativaCurso" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label4" runat="server" Style="font-weight: 700" Text="Objetivos do Curso:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtObjetivosCurso" ErrorMessage="Objetivos do Curso" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtObjetivosCurso" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label58" runat="server" Style="font-weight: 700" Text="Público Alvo:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtPublicoAlvo" ErrorMessage="Público alvo" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublicoAlvo" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label41" runat="server" Style="font-weight: 700" Text="Descrição das Instalações:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtDescricaoInstalacoes" ErrorMessage="Descrição das Instalações" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescricaoInstalacoes" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label42" runat="server" Style="font-weight: 700" Text="Descrição dos Equipamentos:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtDescricaoEquipamentos" ErrorMessage="Descrição dos Equipamentos" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescricaoEquipamentos" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblDescricaoMaterialBibliografico" runat="server" Style="font-weight: 700"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtDescricaoMaterialBibliografico" ErrorMessage="Descrição do Material Bibliográfico" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescricaoMaterialBibliografico" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="Label47" runat="server" Style="font-weight: 700" Text="Formas de Avaliação:"></asp:Label>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtFormasAvaliacao" ErrorMessage="Formas de Avaliação" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFormasAvaliacao" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                    </td>
                </tr>
                <asp:Panel runat="server" ID="pnlAVA">
                    <tr>
                        <td class="Largura150">
                            <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Ambiente Virtual de Aprendizagem:"></asp:Label>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAmbienteVirtualAprendizagem" ErrorMessage="Ambiente Virtual de Aprendizagem" ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAmbienteVirtualAprendizagem" runat="server" Height="105px" TextMode="MultiLine" Width="485px"></asp:TextBox>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td class="Largura150"></td>
                    <td>
                        <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Voltar" CausesValidation="false" />
                        <asp:Button ID="btnSalvar" runat="server" OnClick="btnAlterar_Click" Text="Salvar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
