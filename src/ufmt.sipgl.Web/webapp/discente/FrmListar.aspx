<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.discente.FrmListar" %>

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


        $('.mestre').live('click', function () {
            $(this).siblings('.detalhes').toggle(500);
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding: 5px; text-align: left;">
        <h1>
            <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
            &nbsp;<asp:Label ID="lblTitulo" runat="server"></asp:Label>
        </h1>
        <div id="containerMensagens">
            <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
            </asp:Panel>
        </div>

        <fieldset style="padding: 10px">
            <legend>
                <img alt="Filtrar Registros" class="style2"
                    src="../../media/images/ico_filters.png" />
                Filtrar Registros</legend>
            <asp:Panel ID="PanelFiltro" runat="server">

                <table class="Largura100Porcento">
                    <tr>
                        <td class="LarguraFiltro">
                            <asp:Label ID="lblNomeCandidato" runat="server" Style="font-weight: 700" Text="Nome do Candidato:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNomeCandidato" runat="server" Width="503px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LarguraFiltro">
                            <asp:Label ID="lblCPF" runat="server" Style="font-weight: 700" Text="CPF:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCPF" runat="server" Width="90px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LarguraFiltro">
                            <asp:Label ID="lblSituacaoInscricao" runat="server" Style="font-weight: 700" Text="Situação da Inscrição:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSituacaoInscricao" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="LarguraFiltro"></td>
                        <td>
                            <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="minibutton" OnClick="lnkConsultar_Click">
                               <span>Consultar</span>
                            </asp:LinkButton>

                            <asp:LinkButton ID="lnkMostrarTodos" runat="server" CssClass="minibutton" OnClick="lnkMostrarTodos_Click">
                               <span>Mostrar Todos</span>
                            </asp:LinkButton>
                        </td>
                    </tr>
                </table>


            </asp:Panel>

        </fieldset>

        <div class="addbutton" style="float: left; margin-right: 5px;">
            <asp:HyperLink ID="lnkNovoRegistro" runat="server" CssClass="minibutton">
                            <span>
                                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Adicionar Registro</span>

            </asp:HyperLink>

        </div>

        <asp:Panel ID="PanelAcoes" runat="server" Style="padding: 10px">

            <div style="clear: both"></div>
            <asp:HiddenField ID="hddProjetoPoloCursoUID" runat="server" />

            <div style="float: left; width: 300px; margin-left: 10px">
                <asp:Label ID="lblResultadoConsulta" runat="server"></asp:Label>
                &nbsp;<asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
            </div>

            <div style="clear: both" />
        </asp:Panel>

        <asp:GridView 
            ID="GridView1" 
            runat="server" 
            AllowPaging="True"
            AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging" 
            Width="100%" 
            CssClass="mGrid"
            DataKeyNames="projetoCursoUID"
            OnRowDataBound="GridView1_RowDataBound"
            OnRowCreated="GridView1_RowCreated"
            PageSize="10">
            
            <Columns>
                <asp:TemplateField HeaderText="Inscrição" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNumeroInscricao" runat="server" Text='<%# Eval("numeroInscricao") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Número de Registro" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNumeroRegistro" runat="server" Text='<%# Eval("registro") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Candidato" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a href="javascript:void(0);" class="mestre"><%# Eval("pessoaNome") %></a>
                        <div class="detalhes" style="display: none; background-color: #EBEBEB; color: Black; margin-top: 5px">
                            <img src="../../media/images/link_out_bot.gif" alt="Detalhes" />
                            <fieldset>
                                <legend>Curso</legend>
                                <%# Eval("cursoNome") %>
                            </fieldset>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCpf" runat="server" Text='<%# Eval("cpf") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Situação Atual" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>

                        <asp:Label ID="lblDescricaoSituacaoInscricao" runat="server" Text='<%# Eval("tipoSituacaoInscricaoNome") %>'></asp:Label>

                        <asp:LinkButton ID="lnkBtnAtualizarRegistro" runat="server" CommandName="showCorrecoes" CommandArgument='<%# Eval("preMatriculaInscricaoUID") %>' CssClass="linkChat" ToolTip="Visualizar o cadastro e as solicitações das correções" Text='<%# Eval("tipoSituacaoInscricaoNome") %>' />

                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                  <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>

                        <asp:HyperLink ID="lnkAtualizarRegistro" runat="server"
                            NavigateUrl='<%# "~/webapp/discente/FrmAlteracaoPessoa.aspx?preMatriculaPessoaUID=" + Eval("preMatriculaPessoaUID") + "&projetoPoloCursoUID=" + Eval("projetoPoloCursoUID") %>'
                            ToolTip="Editar Dados">[ Alterar Registro ]</asp:HyperLink>
                        <br />
                    
                        <asp:HyperLink ID="lnkAlterarStatus" runat="server"
                            NavigateUrl='<%# "~/webapp/discente/FrmAlteracaoStatus.aspx?preMatriculaInscricaoUID=" + Eval("preMatriculaInscricaoUID") + "&projetoPoloCursoUID=" + Eval("projetoPoloCursoUID") %>'
                            ToolTip="Alterar Status">[ Alterar Situação ]</asp:HyperLink>
                        <br />

                        <asp:HyperLink ID="lnkNota" runat="server"
                            NavigateUrl='<%# "~/webapp/nota/FrmCadastrar.aspx?preMatriculaInscricaoUID=" + Eval("preMatriculaInscricaoUID") + "&projetoPoloCursoUID=" + Eval("projetoPoloCursoUID") %>'
                            ToolTip="Alterar Status">[ Notas ]</asp:HyperLink>

                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

            </Columns>
            <PagerTemplate>
                <asp:Panel ID="Panel1" runat="server">
                    <div style="text-align: left">
                        <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" ImageUrl="../../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />

                        <asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" ImageUrl="../../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />

                        <asp:ImageButton ID="cmdNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" ImageUrl="../../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" CssClass="espacamentoPaginador" />

                        <asp:ImageButton ID="cmdLast" runat="server" CausesValidation="False" CommandArgument="Last" CommandName="Page" ImageUrl="../../media/images/i_ultima_pagina.gif" ToolTip="Ir para a última página" />
                        
                        <span class="espacamentoPaginador">Página</span>
                        
                        <asp:Label ID="lblTotalPaginaAtual" runat="server" Font-Bold="True" Text="<%# GridView1.PageIndex + 1 %>"></asp:Label>

                        <span>de</span>
                        
                        <asp:Label ID="lblTotalPaginas" runat="server" Text="<% # GridView1.PageCount %>"></asp:Label>
                    </div>
                </asp:Panel>
            </PagerTemplate>
            <EmptyDataTemplate>
                <div
                    style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                    <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
