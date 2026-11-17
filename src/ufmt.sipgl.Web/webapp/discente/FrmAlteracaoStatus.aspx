<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmAlteracaoStatus.aspx.cs" Inherits="ufmt.sipgl.View.webapp.discente.FrmAlteracaoStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function showDialog(id) {
            $('.' + id).dialog("open");
        }

        function closeDialog(id) {
            $('.' + id).dialog("close");
        }
    </script>
</asp:Content>

<asp:Content ID="ContentAlteracaoStatus" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <asp:Panel ID="PanelAcoes" runat="server" Style="padding: 10px">

        <asp:HiddenField ID="hddPreMatriculaInscricaoUID" runat="server" />
        <asp:HiddenField ID="hddProjetoPoloCursoUID" runat="server" />
        <asp:HiddenField ID="hddPreMatriculaPessoaUID" runat="server" />

         <div id="containerValidacao">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
            </div>

        <fieldset>
            <legend style="font-size: x-large">Alterar Situação</legend>

            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">Polo</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPolo" Width="700px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">Curso</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomeCurso" Width="700px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">Nome:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomeCandidato" Width="700px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">CPF:</td>
                    <td>
                        <asp:TextBox ID="txtCPF" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblTipoSituacaoInscricao" runat="server" Style="font-weight: 700" Text="Situação"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldTipoSituacaoInscricao" runat="server" ControlToValidate="ddlSituacaoInscricao" Display="Dynamic" ErrorMessage="Situação da Inscrição" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div style="padding-bottom: 8px;">
                            <asp:DropDownList ID="ddlSituacaoInscricao" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblTipoFormaIngresso" runat="server" Style="font-weight: 700" Text="Forma de Ingresso"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldFormaIngresso" runat="server" ControlToValidate="ddlTipoFormaIngresso" Display="Dynamic" ErrorMessage="Forma de Ingresso" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div style="padding-bottom: 8px;">
                            <asp:DropDownList ID="ddlTipoFormaIngresso" runat="server" AppendDataBoundItems="true">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblDataIngresso" runat="server" Style="font-weight: 700" Text="Data de Ingresso:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldDataIngresso" runat="server" ControlToValidate="txtDataIngresso" Display="Dynamic" ErrorMessage="Data de Ingresso" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataIngresso" runat="server" Width="92px"></asp:TextBox>
                        <asp:CalendarExtender ID="txtDataIngresso_CalendarExtender" runat="server" Enabled="False" Format="dd/MM/yyyy" PopupButtonID="imgCalendarioData6" TargetControlID="txtDataIngresso"></asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="txtDataIngresso_MaskedEditExtender" runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="pt-br" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" TargetControlID="txtDataIngresso"></asp:MaskedEditExtender>
                        <asp:MaskedEditValidator ID="MEVData2" runat="server" ControlExtender="txtDataIngresso_MaskedEditExtender" ControlToValidate="txtDataIngresso" CssClass="failureNotification" Display="Dynamic" ErrorMessage="MEVData1" ForeColor="Red" InvalidValueMessage="Data no formato inválido"></asp:MaskedEditValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblTipoPeriodoIngresso" runat="server" Style="font-weight: 700" Text="Período do Ingresso"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldPeriodoIngresso" runat="server" ControlToValidate="ddlTipoPeriodoIngresso" Display="Dynamic" ErrorMessage="Período de Ingresso" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoPeriodoIngresso" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblTipoReservaVagas" runat="server" Style="font-weight: 700" Text="Tipo de Reserva de Vagas"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldReservaVagas" runat="server" ControlToValidate="ddlTipoReservaVagas" Display="Dynamic" ErrorMessage="Reserva de vagas" ForeColor="Red">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoReservaVagas" runat="server" AppendDataBoundItems="true">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lblObservacao" runat="server" Style="font-weight: 700" Text="Observação:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtObservacao" runat="server" Height="105px" TextMode="MultiLine" Width="700px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnAlterarSituacao" runat="server" Text="Salvar" CssClass="ui-button" OnClick="btnAlterarSituacao_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="ui-button" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </asp:Panel>
</asp:Content>