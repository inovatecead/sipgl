<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmCadastrarInterno.aspx.cs" Inherits="ufmt.sipgl.View.webapp.docente.FrmCadastrarInterno" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                                        value: item.servidorUID + " | " + item.nome

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

    <asp:Panel ID="pnlFormularioInscricao" runat="server">

        <div id="containerValidacao">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" HeaderText="Para continuar, preencha corretamente os campos abaixo:" CssClass="ResumoErro" />
        </div>

        <br />

        <table class="Largura100Porcento">
            <tr>
                <td class="Largura150">
                    <asp:Label ID="Label59" runat="server" Style="font-weight: 700" Text="Nome do Docente:"></asp:Label>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtCorpoDocente" ErrorMessage="Selecione algum docente" ForeColor="Red" >*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtCorpoDocente" runat="server" class="tb" Width="650px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Largura150"></td>
                <td>
                    <asp:Button ID="btnCadastrarDocenteInterno" runat="server" OnClick="btnCadastrarDocenteInterno_Click" Text="Salvar" ValidationGroup="cd" />
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
