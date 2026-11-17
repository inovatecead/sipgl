<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListar.aspx.cs" Inherits="ufmt.sipgl.View.webapp.matriculaPessoa.FrmListar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding: 5px; text-align: left;">
        <h1>
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
                Filtrar Registros
            </legend>

            <asp:Panel ID="PanelFiltro" runat="server">

                <table class="Largura100Porcento">
                    <tr>
                        <td class="LarguraFiltro">
                            <asp:Label ID="lblNome" runat="server" Style="font-weight: 700" Text="Nome:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNome" runat="server" Width="400px" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="LarguraFiltro">
                            <asp:Label ID="lblCPF" runat="server" Style="font-weight: 700" Text="CPF:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCPF" runat="server" EnableViewState="False" ViewStateMode="Disabled"></asp:TextBox>
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

        <asp:Panel ID="PanelAcoes" runat="server">
            <div class="addbutton" style="float: left; margin-right: 5px;">
                <asp:HyperLink ID="lnkNovoRegistro" runat="server" CssClass="minibutton" SkinID="MenuDiscentes_NovoDiscente">
                <span>
                    <img alt="" src="../../media/images/add.png" border="0" />&nbsp;&nbsp; Adicionar Registro
                </span>
                </asp:HyperLink>
            </div>

            <div class="addbutton" style="float: left; margin-right: 5px;">
                <asp:HyperLink ID="lnkImportarCandidatos" runat="server" CssClass="minibutton" SkinID = "MenuDiscentes_ImportarCandidatos">
                <span>
                    Importar Candidatos
                </span>
                </asp:HyperLink>
            </div>

            <div style="float: right;">
                <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
            </div>
        </asp:Panel>

        <asp:GridView ID="GridView1" runat="server"
            AllowPaging="True"
            AutoGenerateColumns="False"
            OnPageIndexChanging="GridView1_PageIndexChanging"
            Width="100%"
            CssClass="mGrid"
            DataKeyNames="PreMatriculaPessoaUID"
            OnRowCommand="GridView1_RowCommand"
            OnRowDataBound="GridView1_RowDataBound"
            PageSize="10"
            ShowHeaderWhenEmpty="true">

            <Columns>
                <asp:TemplateField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblNome" runat="server" Text='<%# Eval("nome") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left" Width="45%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CPF" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCPF" runat="server" Text='<%# Eval("CPF") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="10%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="E-mail" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="20%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Celular" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblCelular" runat="server" Text='<%# Eval("telefoneMovel") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="center" Width="15%" />
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkVisualizarMatriculas" runat="server" ImageUrl="../../media/images/view_20.png" NavigateUrl='<%# "~/webapp/matriculaPessoa/FrmListarMatriculas.aspx?&preMatriculaPessoaUID=" + Eval("preMatriculaPessoaUID")%>' ToolTip="Visualizar Matrículas" SkinID="MenuDiscentes_VisualizarMatriculas">Atualizar Registro</asp:HyperLink>

                        <asp:HyperLink ID="lnkAtualizarRegistro" runat="server" ImageUrl="../../media/images/edit_20.png" NavigateUrl='<%# "~/webapp/matriculaPessoa/FrmAlteracaoPessoa.aspx?&preMatriculaPessoaUID=" + Eval("preMatriculaPessoaUID")%>' ToolTip="Editar Dados" SkinID="MenuDiscentes_Editar">Atualizar Registro</asp:HyperLink>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Center" Width="10%" />
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
