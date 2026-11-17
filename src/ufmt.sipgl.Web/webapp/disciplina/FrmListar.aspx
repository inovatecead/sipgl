<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.disciplina.FrmListar" %>

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

    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />

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
                <img alt="Filtrar Registros" class="style2" src="../../media/images/ico_filters.png" />
                <span>Filtrar Registros</span>
            </legend>

            <table>
                <tr>
                    <td class="LarguraFiltro">Descrição:</td>
                    <td>
                        <asp:TextBox ID="txtCriterio" runat="server" Width="500px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="LarguraFiltro"></td>
                    <td>
                        <asp:LinkButton ID="lnkConsultar" runat="server" CssClass="minibutton" OnClick="lnkConsultar_Click">
                            <span>Consultar </span>
                        </asp:LinkButton>

                        <asp:LinkButton ID="lnkMostrarTodos" runat="server" CssClass="minibutton" OnClick="lnkMostrarTodos_Click">
                            <span>Mostrar Todos </span>
                        </asp:LinkButton>
                    </td>
                </tr>
            </table>
        </fieldset>

        <asp:Panel ID="PanelAcoes" runat="server">

            <asp:HyperLink ID="lnkNovoRegistro" runat="server" CssClass="minibutton" SkinID="Disciplinas_NovaDisciplina">
                <span>
                    <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; 
                    <asp:Label runat="server">Adicionar Registro</asp:Label>
                </span>
            </asp:HyperLink>

            <div style="float: right;">
                <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
            </div>
        </asp:Panel>

        <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
            AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            Width="100%"
            CssClass="mGrid"
            DataKeyNames="projetoDisciplinaUID"
            PageSize="10"
            ShowHeaderWhenEmpty="true"
            OnRowDataBound="GridView1_RowDataBound">

            <Columns>
                <asp:TemplateField HeaderText="Código" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblSigla" runat="server" Text='<%# Eval("projetoDisciplinaUID") %>'
                            Visible="true"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Carga Horária" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Eval("cargaHoraria") %> horas
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nome" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <a href="javascript:void(0);" class="mestre"><%# Eval("nome") %></a>
                        <div class="detalhes" style="display: none; background-color: #EBEBEB; color: Black; margin-top: 5px">
                            <img src="../../media/images/link_out_bot.gif" alt="Detalhes" />
                            <fieldset>
                                <legend>Ementa</legend>
                                <%# Eval("ementa")%>
                            </fieldset>

                            <fieldset>
                                <legend>Bibliografia</legend>
                                <%# Eval("bibliografia")%>
                            </fieldset>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tipo da Disciplina" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbTipoDisciplina" runat="server" CssClass="mestre"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ações" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkAtualizarRegistro" runat="server" NavigateUrl='<%# "~/webapp/disciplina/FrmAlterar.aspx?projetoDisciplinaUID=" + Eval("projetoDisciplinaUID") + "&projetoCursoUID=" + hddProjetoCursoUID.Value %>' ToolTip="Editar Dados" SkinID="Disciplinas_Editar">[ Editar ]</asp:HyperLink>
                        <br />
                        <asp:LinkButton ID="lnkExcluirRegistro" runat="server" OnClientClick="return confirm('Deseja realmente excluir este registro?');" CommandName="lnkExcluir_Click" OnCommand="lnkExcluir_Click" CommandArgument='<%# Eval("projetoDisciplinaUID") %>' SkinID="Disciplinas_Excluir">[ Excluir ]</asp:LinkButton>
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
                <div style="text-align: center; padding-top: 20px; padding-bottom: 20px; font-size: 18px; font-family: Arial Narrow; font-weight: bold">
                    <asp:Label ID="lblMsgNenhumRegistro" runat="server" Text="Nenhum registro localizado no critério da consulta."></asp:Label>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </div>
</asp:Content>
