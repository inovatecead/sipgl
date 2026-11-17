<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.turma.FrmListar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">

        $('.mestre').live('click', function () {
            $(this).siblings('.detalhes').toggle(500);
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField runat="server" ID="hddProjetoCursoUID" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding: 5px; text-align: left;">

                <h1>
                    <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                </h1>

                <div id="containerMensagens">
                    <asp:Panel ID="PanelMsgResultado" runat="server" Visible="false">
                        <asp:Label ID="lblMsgResultado" runat="server"></asp:Label>
                    </asp:Panel>
                </div>

                <fieldset style="padding: 10px">
                    <legend>
                        <img alt="Filtrar Registros" class="style2" src="../../media/images/ico_filters.png" />
                        <span>Filtrar Registros</span>
                    </legend>

                    <table>
                        <tr>
                            <td class="LarguraFiltro">
                                <asp:Label runat="server" ID="lbCurso">Descrição:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCriterio" runat="server" Width="503px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
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
                </fieldset>

                <asp:Panel ID="PanelAcoes" runat="server">
                    <div class="addbutton" style="float: left; margin-right: 5px">
                        <asp:HyperLink ID="lnkNovoRegistro" runat="server" CssClass="minibutton" SkinID="Turma_NovaTurma">
                            <span>
                                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Adicionar Registro
                            </span>
                        </asp:HyperLink>
                    </div>

                    <div style="float: right;">
                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
                    </div>
                </asp:Panel>

                <asp:GridView ID="GridView1"
                    runat="server"
                    AllowPaging="True"
                    AutoGenerateColumns="False"
                    OnPageIndexChanging="GridView1_PageIndexChanging"
                    Width="100%"
                    CssClass="mGrid"
                    DataKeyNames="projetoTurmaUID"
                    OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound"
                    PageSize="10">
                    <Columns>
                        <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbCodigo" runat="server" Text='<%# Eval("projetoTurmaUID") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbNome" runat="server" Text='<%# Eval("nome") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ano" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbAno" runat="server" Text='<%# Eval("ano") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Periodo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbPeriodo" runat="server" Text='<%# Eval("periodo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Turno" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbTurno" runat="server" Text='<%# Eval("turno") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Data de Início" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbDataInicio" runat="server" Text='<%# Eval("dataInicio", "{0:dd/MM/yyyy}")%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Data de Fim" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbDataFim" runat="server" Text='<%# Eval("dataFim", "{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbStatus" runat="server" Text='<%# Eval("isAtivo") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div style="text-align: center">
                                    <asp:HyperLink ID="lnkAtualizarTurma" runat="server" NavigateUrl='<%# "FrmAlterar.aspx?projetoTurmaUID=" + Eval("projetoTurmaUID") + "&projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Atualizar/Detalhes da Turma" SkinID="Turma_EditarTurma">[ Editar ]<br /></asp:HyperLink>
                                    
                                    <asp:HyperLink ID="lnkVincularPolos" runat="server" NavigateUrl='<%# "~/webapp/turma/FrmListarPolos.aspx?projetoTurmaUID=" + Eval("projetoTurmaUID") + "&projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Vincular Unidades de Adm./Acadêmicas" SkinID="Turma_VincularUnidades">[ Vincular Unidades ]<br /></asp:HyperLink>
                                    
                                    <asp:HyperLink ID="lnkListarDiscentes" runat="server" NavigateUrl='<%# "~/webapp/turma/FrmListarDiscentes.aspx?projetoTurmaUID=" + Eval("projetoTurmaUID") + "&projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Controle de Discentes" SkinID="Turma_Discentes">[ Discentes ]<br /></asp:HyperLink>
                                    
                                    <asp:HyperLink ID="lnkDisciplina" runat="server" NavigateUrl='<%# "~/webapp/turmaDisciplina/FrmListar.aspx?projetoTurmaUID=" + Eval("projetoTurmaUID") + "&projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Gerenciar Disciplinas" SkinID="Turma_GerenciarDisciplinas">[ Gerenciar Disciplinas ]<br /></asp:HyperLink>
                                    
                                    <asp:HyperLink ID="lnkNotas" runat="server" NavigateUrl='<%# "~/webapp/nota/FrmNotas.aspx?projetoTurmaUID=" + Eval("projetoTurmaUID") + "&projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Lançamento de Notas" SkinID="Turma_Notas">[ Notas ]<br /></asp:HyperLink>
                                
                                    <asp:HyperLink ID="lnkFrequencia" runat="server" NavigateUrl='<%# "~/webapp/Frequencia/FrmFrequencia.aspx?projetoTurmaUID=" + Eval("projetoTurmaUID") + "&projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Lançamento de Frequência" SkinID="Turma_Frequencia">[ Frequências ]<br /></asp:HyperLink>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
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

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>
