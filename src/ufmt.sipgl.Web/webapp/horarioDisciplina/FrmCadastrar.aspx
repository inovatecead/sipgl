<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmCadastrar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.horarioDisciplina.FrmCadastrar" MaintainScrollPositionOnPostback="true" %>
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

        <asp:HiddenField ID="hddCodigoRegistro" runat="server" />
        

        
    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />
        

        
    


        
    </div>
    

<asp:Panel ID="pnlFormularioInscricao" runat="server">
        

        <div id="containerMensagens0">
                <asp:Panel ID="PanelMsgResultado0" runat="server" Visible="false">
                    <asp:Label ID="lblMsgResultado0" runat="server"></asp:Label>
                </asp:Panel>
        </div>



<div>

<div id="containerValidacao">
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ForeColor="Red" 
        HeaderText="Para continuar, preencha corretamente os campos abaixo:" 
        CssClass="ResumoErro" />
</div>


       
<h1>Curso: <asp:Literal ID="LiteralDescricaoCurso" runat="server"></asp:Literal> 
    <br />
    Disciplina:
    <asp:Literal ID="LiteralDescricaoDisciplina" runat="server"></asp:Literal>
    <br />
    TURMA:
    <asp:Literal ID="LiteralTurma" runat="server"></asp:Literal>
    </h1>
    

<fieldset>
<legend style="font-size: x-large">Horário(s) da Disciplina</legend>
    <table class="Largura100Porcento">


        <tr>
            <td class="Largura150">
                <asp:Label ID="Label2" runat="server" style="font-weight: 700" 
                    Text="Data:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtData" 
                    ErrorMessage="Data" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtData" runat="server" Width="100px"></asp:TextBox>

                <asp:MaskedEditValidator ID="MEVData2" runat="server" 
                    ControlExtender="txtData_MaskedEditExtender" 
                    ControlToValidate="txtData" CssClass="failureNotification" 
                    Display="Dynamic" ErrorMessage="MEVData1" ForeColor="Red" 
                    InvalidValueMessage="Data no formato inválido">
                </asp:MaskedEditValidator>


                    <asp:MaskedEditExtender ID="txtData_MaskedEditExtender" 
                        runat="server" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                        CultureDateFormat="pt-br" CultureDatePlaceholder="" 
                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" 
                        CultureTimePlaceholder="" Enabled="True" Mask="99/99/9999" MaskType="Date" 
                        TargetControlID="txtData">
                    </asp:MaskedEditExtender>


            </td>




        </tr>


<tr>
            <td class="Largura150">
                <asp:Label ID="Label4" runat="server" style="font-weight: 700" 
                    Text="Hora início:"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtHoraInicio" 
                    ErrorMessage="Data início" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtHoraInicio" runat="server" Width="100px"></asp:TextBox>


                <asp:MaskedEditValidator ID="MaskedEditValidatorHoraInicio" runat="server" 
                    ControlExtender="txtHoraInicio_MaskedEditExtender" 
                    ControlToValidate="txtHoraInicio" CssClass="failureNotification" 
                    Display="Dynamic" ErrorMessage="MEVData1" ForeColor="Red" 
                    InvalidValueMessage="Horário no formato inválido">
                </asp:MaskedEditValidator>


                    <asp:MaskedEditExtender ID="txtHoraInicio_MaskedEditExtender" runat="server"
                        TargetControlID="txtHoraInicio"
                        AcceptAMPM="true"
                        Mask="99:99"
                        MaskType="Time" />

                Formato hh:mm</td>




        </tr>




        <tr>
            <td class="Largura150">
                <asp:Label ID="Label3" runat="server" style="font-weight: 700" 
                    Text="Hora Término:"></asp:Label>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtHoraTermino" 
                    ErrorMessage="Data término" ForeColor="Red">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtHoraTermino" runat="server" Width="100px"></asp:TextBox>

                 <asp:MaskedEditValidator ID="MaskedEditValidatorTxtHoraTermino" runat="server" 
                    ControlExtender="txtHoraTermino_MaskedEditExtender" 
                    ControlToValidate="txtHoraTermino" CssClass="failureNotification" 
                    Display="Dynamic" ErrorMessage="MEVData1" ForeColor="Red" 
                    InvalidValueMessage="Horário no formato inválido">
                </asp:MaskedEditValidator>


                    <asp:MaskedEditExtender ID="txtHoraTermino_MaskedEditExtender" runat="server"
                        TargetControlID="txtHoraTermino"
                        AcceptAMPM="true"
                        Mask="99:99"
                        MaskType="Time" />


                Formato hh:mm</td>




        </tr>


        <tr>
            <td class="Largura150">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnVoltar0" runat="server" OnClick="btnVoltar_Click" 
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
