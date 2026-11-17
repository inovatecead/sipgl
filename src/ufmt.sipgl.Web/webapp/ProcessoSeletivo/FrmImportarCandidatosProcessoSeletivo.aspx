<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmImportarCandidatosProcessoSeletivo.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmImportarCandidatosProcessoSeletivo" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>

    <fieldset style="padding: 10px">
        <legend>
            <span>Importar Candidatos</span>
        </legend>

        <table class="Largura100Porcento">
            <tr>
                <td class="Largura150">
                    <asp:Label ID="lbImportarAlunosProcessoSeletivo" runat="server" Style="font-weight: 700" Text="Importar Arquivo:"></asp:Label>
                </td>
                <td colspan="5">
                    <asp:FileUpload ID="FileUploadAlunosProcessoSeletivo" runat="server" />

                    <br />

                    <span>* O arquivo a ser importado deve ser em formato .xlsx</span>
                </td>
            </tr>
            <tr>
                <td class="Largura150"></td>
                <td>
                    <asp:Button runat="server" ID="btnImportarCandidatos" SkinID="ImportarCandidatos_Importar" OnClick="importarAlunos_Click" Text="Importar" />
                </td>
            </tr>
        </table>

    </fieldset>

</asp:Content>
