<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmIncluirLote.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmIncluirLote" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="ContentAlteracaoStatus" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
    </h1>

    <asp:Panel ID="PanelAcoes" runat="server" Style="padding: 10px">

        <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
        <asp:HiddenField ID="hddProjetoTurmaUID" runat="server" />

        <div id="containerValidacao">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
        </div>

        <fieldset>
            <legend style="font-size: x-large">Inclusão de Candidatos em Lote</legend>

            <table class="Largura100Porcento">
                <tr>
                    <td class="Largura150">Curso:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNomeCurso" Width="700px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">Turma:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDescricaoTurma" Width="700px" Enabled="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">
                        <asp:Label ID="lbIncluirLote" runat="server" Style="font-weight: 700" Text="Importar Arquivo:"></asp:Label>
                    </td>
                    <td colspan="5">
                        <asp:FileUpload ID="FileUploadIncluirLote" runat="server" />

                        <br />

                        <span>* O arquivo a ser importado deve ser em formato .csv (UTF-8)</span>
                    </td>
                </tr>
                <tr>
                    <td class="Largura150">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnIncluirLote" runat="server" Text="Salvar" SkinID="IncluirLote_Salvar" CssClass="ui-button" OnClick="btnIncluirLote_Click" />
                        <asp:Button ID="btnVoltar" runat="server" Text="Voltar" CssClass="ui-button" OnClick="btnVoltar_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
        </fieldset>

        <asp:GridView runat="server" ID="listaResultadoOperacaoGridView"
            AutoGenerateColumns="False"
            Width="100%"
            CssClass="mGrid"
            ShowHeaderWhenEmpty="true">

            <Columns>
                <asp:TemplateField HeaderText="Diagnóstico" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbInfo" runat="server" Text='<%# Eval("info") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="100%" />
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

    </asp:Panel>

</asp:Content>
