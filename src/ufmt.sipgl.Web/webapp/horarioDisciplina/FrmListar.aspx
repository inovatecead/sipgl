<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.horarioDisciplina.FrmListar" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js"type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js"type="text/javascript"></script>

<script language="javascript" type="text/javascript">

    $(document).ready(function () {

        $('.janelaCorrecao').dialog({
            autoOpen: false,
            width: 600,
            height: 500,
            modal: true,
            title: "Correções Solicitadas Pelo Coordenador",
            draggable: true,
            resizable: false,
            open: function (type, data) {
                $(this).parent().appendTo("form");
            }

        });

        $("a").easyTooltip();
    });


    function showDialog(id) {
        $('.' + id).dialog("open");
    }

    function closeDialog(id) {
        $('.' + id).dialog("close");
    }


    $('.mestre').live('click', function () {
        $(this).siblings('.detalhes').toggle(500);
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="janelaCorrecao">

            <br />

            <asp:UpdatePanel ID="upCorrigir" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>
        <div>
                                            <asp:Repeater ID="rpCorrecoes" runat="server">
                                                <SeparatorTemplate>
                                                <hr />
                                                </SeparatorTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label37" runat="server" Text='<%# Eval("descricao") %>'></asp:Label>
                                                </ItemTemplate>
                        
                                                </asp:Repeater>
</div>
              

            </ContentTemplate>
            </asp:UpdatePanel>


                </div>

 <asp:UpdatePanel ID="upGeral" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
  <ContentTemplate>
    <div style="padding:5px;text-align:left;">
        <h1>
            <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
            &nbsp;<asp:Label ID="lblTitulo" runat="server"></asp:Label>
        </h1>
        <div id="containerMensagens">
                <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                    <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
                </asp:Panel>
        </div>
       

<div style="display:none">

                                <fieldset style="padding: 10px">
                                    <legend>
                                        <img alt="Filtrar Registros" class="style2" 
                                            src="../../media/images/ico_filters.png" />
                                        Filtrar Registros</legend>
                                         <asp:Panel ID="PanelFiltro" runat="server">
                                    &nbsp;<asp:TextBox ID="txtCriterio" runat="server" Width="503px" 
                                        EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                                    
       <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="minibutton" onclick="lnkConsultar_Click">
              
                                       
    <span>

                                             
                                             Consultar



    </span>
                                             

                                           

                                             

                                             
</asp:LinkButton>

<asp:LinkButton ID="lnkMostrarTodos" runat="server" CssClass="minibutton" onclick="lnkMostrarTodos_Click">

                          
    <span>
        Mostrar Todos

    </span>
                                             
</asp:LinkButton>

    

</asp:Panel>


                                </fieldset>


</div>
                            
<asp:Panel ID="PanelAcoes" runat="server" style="padding:10px">
    
    <div style="clear:both"></div>


<div class="addbutton" style="float:left;margin-right:5px"> 
     <asp:HyperLink ID="lnkNovoRegistro" runat="server" CssClass="minibutton">

    <span>


     <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Adicionar Registro</span>

        </asp:HyperLink>
     <asp:HiddenField ID="hddOperacao" runat="server" />
 </div>


<asp:HiddenField ID="hddProjetoDisciplinaUID" runat="server" />                                     
<div class="addbutton" style="float:left;" runat="server" ID="divExcluir"> 
<asp:LinkButton ID="lnkExcluir" runat="server" onclick="lnkExcluirSelecionados_Click" CssClass="minibutton" OnClientClick="javascript:return window.confirm('Tem certeza que deseja remover este registro?');">




    <span>
        

       

    <img src="../../media/images/delete2.png" 
                                                style="width: 16px; height: 16px" alt="Excluir selecionados"
                                                runat="server" id="imgExcluir" />&nbsp; 
    
Excluir selecionados


        
    </span>
    




</asp:LinkButton>
    
</div>

<div style="float:left;width:300px;margin-left:10px">
        <asp:Label ID="lblResultadoConsulta" runat="server"></asp:Label>
        &nbsp;<asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
    </div>
    
<div style="clear:both" />
</asp:Panel>
        

<h1>Curso: <asp:Literal ID="LiteralDescricaoCurso" runat="server"></asp:Literal>
    <br />
    Disciplina:
    <asp:Literal ID="LiteralDescricaoDisciplina" runat="server"></asp:Literal>
        </h1>


        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" 
            OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" CssClass="mGrid" 
            DataKeyNames="horarioUID" onrowcommand="GridView1_RowCommand" 
            onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("horarioUID") %>' 
                            Visible="false"></asp:Label>
                        <asp:CheckBox ID="chkRegistro" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Código" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSigla" runat="server" Text='<%# Eval("horarioUID") %>' 
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Ações" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                            
                            <asp:HyperLink ID="lnkAtualizarRegistro" runat="server" 
                            ImageUrl="../../media/images/edit_20.png" 
                                                                                            
                                NavigateUrl='<%# "~/webapp/horarioDisciplina/FrmCadastrar.aspx?operacao=editar&projetoCursoUID=" + Request.QueryString["projetoCursoUID"]  + "&projetoTurmaDisciplinaUID=" + Eval("turmaDisciplinaUID") + "&curso=" + Request.QueryString["curso"] + "&disciplina=" + Request.QueryString["disciplina"] + "&registroUID=" + Eval("horarioUID") + "&turmaUID=" + Request.QueryString["turmaUID"] + "&turma=" + Request.QueryString["turma"]%>' 
                                ToolTip="Editar Dados">Atualizar Registro</asp:HyperLink>

                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Docente" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>

                        <a href="javascript:void(0);" class="mestre"><%# Eval("data")%></a>
                        <div class="detalhes" style="display:none;background-color:#EBEBEB;color:Black;margin-top:5px">
                        <img src="../../media/images/link_out_bot.gif" alt="Detalhes" />
 
                        
                        <fieldset><legend>Hora Início</legend>
                            <%# Eval("horaInicio") %>
                        </fieldset>

                        <fieldset><legend>Hora Términio</legend>
                        <%# Eval("horaFim")%>
                        </fieldset>

                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                </asp:TemplateField>


            </Columns>


            <PagerTemplate>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="cmdIr">
                    <div style="text-align: left">
                        <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False" 
                            CommandArgument="First" CommandName="Page" 
                            ImageUrl="../../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />
                        &nbsp;<asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False" 
                            CommandArgument="Prev" CommandName="Page" 
                            ImageUrl="../../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="cmdNext" runat="server" 
                            CausesValidation="False" CommandArgument="Next" CommandName="Page" 
                            ImageUrl="../../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" />
                        &nbsp;<asp:ImageButton ID="cmdLast" runat="server" CausesValidation="False" 
                            CommandArgument="Last" CommandName="Page" 
                            ImageUrl="../../media/images/i_ultima_pagina.gif" ToolTip="Ir para a última página" />
                        &nbsp;&nbsp; Ir para a página
                        Ir para a página
                        <asp:TextBox ID="txtPagina" runat="server" 
                            Text="<% # GridView1.PageIndex + 1 %>" ValidationGroup="grid" Width="29px"></asp:TextBox>
                        &nbsp;<asp:ImageButton ID="cmdIr" runat="server" ImageUrl="../../media/images/btnIr.gif" 
                            OnClick="cmdIr2_Click" ValidationGroup="grid" />
                        <b>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtPagina" Display="Dynamic" 
                            ErrorMessage="* Entre com um valor para continuar" Font-Bold="False" 
                            ValidationGroup="grid"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="txtPagina" Display="Dynamic" 
                            ErrorMessage="* Digite somente números para continuar" Font-Bold="False" 
                            ValidationExpression="^[0-9]+$" ValidationGroup="grid">* Digite somente números* Digite somente números</asp:RegularExpressionValidator>
                        </b>
                    </div>
                    <div style="text-align: left">
                        Página&nbsp;Página&nbsp;<asp:Label ID="lblTotalPaginaAtual" runat="server" 
                            Font-Bold="True" Text="<%# GridView1.PageIndex + 1 %>"></asp:Label>
                        &nbsp;de&nbsp;&nbsp;de&nbsp;<asp:Label ID="lblTotalPaginas" runat="server" 
                            Text="<% # GridView1.PageCount %>"></asp:Label>
                        &nbsp;
                    </div>
                </asp:Panel>
            </PagerTemplate>
            <EmptyDataTemplate>
                <div 
                    style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px;
                                                    font-family: Arial Narrow; font-weight: bold">
                    <asp:Label ID="lblMsgNenhumRegistro" runat="server" 
                        Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>


               <asp:modalpopupextender 
                ID="ModalPopupExtender1"
                BehaviorID="behavior"
                runat="server"
                TargetControlID="lnkModal"
                PopupControlID="PanelDetalhes"
                BackgroundCssClass="modalBackground"
                DropShadow="True"
                DynamicServicePath="" 
                Enabled="True"
        
        />

        <asp:HyperLink ID="lnkModal" runat="server"  />

 <asp:Panel ID="PanelDetalhes" runat="server" CssClass="modalPopup" style="display:none">
          <div id="ContainerDetalhes" style="width:800px">
          <div id="MenuDetalhes" style="background-color:White;padding-left:5px;padding-bottom:5px;height:40px">
            <div style="width:650px; float:left; height: 32px;">
                <h2 style="height: 35px"><asp:Label ID="Label2" runat="server" Text="Label">Solicitações de Correções</asp:Label></h2>
            </div>
            <div style="float:left;width:130px;text-align:right; padding-top:10px;">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="../../media/images/close24.png" OnclientClick="$find('behavior').hide(); return false;" ToolTip="Fechar Janela" ImageAlign="AbsMiddle" />
                &nbsp;<asp:LinkButton ID="LinkButtonFechar" runat="server" Visible="False" 
                    Text="Fechar" OnclientClick="$find('behavior').hide(); return false;"   />
            </div>
          </div>
           <div id="corpoDetalhes" style="border:1px solid #cccccc;height:450px;padding-top:10px;background-color:#f7f7f7">
            
               
               <asp:Panel ID="pnlChat" runat="server" ScrollBars="Auto" Width="780" Height="430px" style="padding-left:10px">
                    <asp:Repeater ID="rpChat" runat="server">
                    <SeparatorTemplate>
                    <hr />
                    </SeparatorTemplate>
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("descricao") %>'></asp:Label>
                    </ItemTemplate>
                        
                    </asp:Repeater>
               </asp:Panel>
               
           </div> 


          </div>      
</asp:Panel>



    </div>
  </ContentTemplate>
  </asp:UpdatePanel>

</asp:Content>
