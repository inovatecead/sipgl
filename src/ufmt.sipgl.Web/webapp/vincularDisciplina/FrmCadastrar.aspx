<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmCadastrar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.vincularDisciplina.FrmCadastrar" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js"type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js"type="text/javascript"></script>
	<script type="text/javascript">

	    $(document).ready(function () {

	        var basePath = '<%=VirtualPathUtility.ToAbsolute("~/")%>';
            
            $(".tb").autocomplete({
	            source: function (request, response) {
	                $.ajax({
	                    url: basePath + "webapp/WSConsulta.asmx/GetInstituicaoEnsinoSuperior",
	                    data: "{ 'nome': '" + request.term + "' }",
	                    dataType: "json",
	                    type: "POST",
	                    contentType: "application/json; charset=utf-8",
	                    dataFilter: function (data) { return data; },
	                    success: function (data) {
	                        response($.map(data.d, function (item) {
	                            return {
	                                value: item.InstituicaoEnsinoSuperiorUID + " | " + item.Nome

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

	        $(".tb2").autocomplete({
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
	                                value: item.MunicipioUID + " | " + item.Nome

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


	        $('.janelaHomologacao').dialog({
	            autoOpen: false,
	            width: 600,
	            height: 210,
	            modal: true,
	            title: "Homologar Inscrição",
	            draggable: true,
	            resizable: false,
	            open: function (type, data) {
	                $(this).parent().appendTo("form");
	            }
	        });

	        $('.janelaCorrecao').dialog({
	            autoOpen: false,
	            width: 600,
	            height: 300,
	            modal: true,
	            title: "Solicitar Correção",
	            draggable: true,
	            resizable: false,
	            open: function (type, data) {
	                $(this).parent().appendTo("form");
	            }
	        });

	        carregarJQuery();

	    });

	    function showDialog(id) {
	        $('.' + id).dialog("open");
	    }

	    function closeDialog(id) {
	        $('.' + id).dialog("close");
	    }


	    function carregarJQuery() {
	        $(".accordion").accordion({ collapsible: true, active: true, autoHeight: false });
	        $(".datePicker").datepicker();
	        $(".tabs").tabs({ selected: 0 });
	    }



function btnSolicitarCorrecao_onclick() {

}

	</script> 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
    </h1>


<asp:Panel ID="pnlDetalheInscricao" runat="server" Visible="false" CssClass="pnlAviso">
    <asp:Panel ID="Panel1" runat="server" style="text-align:center;padding:10px">
        <asp:Label ID="lblMsgCadastro" runat="server"></asp:Label>
        &nbsp;</asp:Panel>
    
</asp:Panel>

<div style="padding-top: 30px; text-align: center">

<%--        <input type="button" id="btnHomologar" class="ui-button" 
            value="Homologar Inscrição" onclick="showDialog('janelaHomologacao')" /> --%>&nbsp;<asp:HiddenField ID="hddCodigoRegistro" runat="server" />
        

        
    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
        

        
    </div>
    <asp:Panel ID="pnlFormularioInscricao" runat="server">
        

        <div id="containerMensagens">
                <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                    <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
                </asp:Panel>
        </div>



<div>

<div id="containerValidacao">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" 
        HeaderText="Para continuar, preencha corretamente os campos abaixo:" 
        CssClass="ResumoErro" />
</div>


       
<h1>Curso: <asp:Literal ID="LiteralDescricaoCurso" runat="server"></asp:Literal> 
    <br />
    Turma:
    <asp:Literal ID="LiteralDescricaoTurma" runat="server"></asp:Literal>
    </h1>
    

<fieldset>
<legend style="font-size: x-large">Vincular Disciplina e Docente</legend>
    <table class="Largura100Porcento">


        <tr>
<td class="Largura150">
                &nbsp;Disciplina:<asp:RequiredFieldValidator ID="RequiredFieldValidator8" 
                    runat="server" ControlToValidate="lstDisciplinas" 
                    ErrorMessage="Selecione a Disciplina" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
            <td>
                <asp:ListBox ID="lstDisciplinas" runat="server" Width="885px" Height="200px"></asp:ListBox>
    </td>
        </tr>


        <tr>
            <td class="Largura150">
                Docente:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="lstDocentes" ErrorMessage="Selecione o Docente" 
                    ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:ListBox ID="lstDocentes" runat="server" Width="885px" Height="200px"></asp:ListBox>
            </td>
        </tr>


        <tr>
            <td class="Largura150">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" 
                    Text="Voltar" />
                &nbsp;<asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" 
                    Text="Salvar" />
            </td>
        </tr>


</table>
</fieldset>





<br />


    


</div>

</asp:Panel>

</asp:Content>
