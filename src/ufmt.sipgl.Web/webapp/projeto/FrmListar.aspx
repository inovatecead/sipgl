<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.projeto.FrmListar" %>

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

    <asp:HiddenField ID="hddServidorUID" runat="server" />
    <asp:HiddenField ID="hddTipoSolicitanteUID" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="padding: 5px; text-align: left;">
                <h1><span class="allcaps">
                    <asp:Label ID="Label1" runat="server"></asp:Label>

                </span></h1>
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
                                <asp:Label runat="server" ID="lbCurso">Curso:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCriterio" runat="server" Width="503px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="LarguraFiltro">
                                <asp:Label runat="server" ID="Label2">Turmas:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStatusTurma" runat="server" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0">Selecione...</asp:ListItem>
                                    <asp:ListItem Value="1">Ativo</asp:ListItem>
                                </asp:DropDownList>
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
                    <asp:HyperLink ID="lnkNovoProjetoCurso" runat="server" CssClass="minibutton" SkinID="MenuCursos_NovoCurso">
                            <span>
                                <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; <asp:Label runat="server" Text="Adicionar Registro"></asp:Label>
                            </span>
                    </asp:HyperLink>

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
                    DataKeyNames="projetoCursoUID"
                    OnRowCommand="GridView1_RowCommand"
                    OnRowDataBound="GridView1_RowDataBound"
                    PageSize="10"
                    ShowHeaderWhenEmpty="true">

                    <Columns>

                        <asp:TemplateField HeaderText="Código" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblCodigoCurso" runat="server" Text='<%# Eval("projetoCursoUID") %>'
                                    Visible="true"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Modalidade" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Eval("TipoModalidade.nome") %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="10%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Descrição" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <a href="javascript:void(0);" class="mestre"><%# Eval("nomeCurso") %></a>

                                <div class="detalhes" style="display: none; background-color: #EBEBEB; color: Black; margin-top: 5px">
                                    <img src="../../media/images/link_out_bot.gif" alt="Detalhes" />
                                </div>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div style="text-align: center">
                                    <asp:HyperLink ID="lnkAtualizarProjetoCurso" runat="server" NavigateUrl='<%# "FrmAlterar.aspx?projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Atuallizar/Detalhes do Curso" SkinID="MenuCursos_EditarCurso">[ Editar ]<br /></asp:HyperLink>

                                    <asp:HyperLink ID="lnkTurma" runat="server" NavigateUrl='<%# "~/webapp/turma/FrmListar.aspx?projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Turmas do Curso" SkinID="MenuCursos_Turmas">[ Turmas ]<br /></asp:HyperLink>

                                    <asp:HyperLink ID="lnkDisciplina" runat="server" NavigateUrl='<%# "~/webapp/disciplina/FrmListar.aspx?projetoCursoUID=" + Eval("projetoCursoUID") %>' ToolTip="Disciplinas do Curso" SkinID="MenuCursos_Disciplinas">[ Disciplinas ]</asp:HyperLink>
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
