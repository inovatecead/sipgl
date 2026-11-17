<%@ Page Title="" Language="C#" MasterPageFile="~/webapp/MasterPage.Master" AutoEventWireup="true" CodeBehind="FrmListarPolos.aspx.cs" Inherits="ufmt.sipgl.View.webapp.projeto.FrmListarPolos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../../scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <script src="../../scripts/jquery.ui.datepicker-pt-BR.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:HyperLink ID="lnkTitulo" runat="server">[lnkTitulo]</asp:HyperLink>
        <asp:Label ID="lbTitulo" runat="server"></asp:Label>
    </h1>

    <asp:UpdatePanel ID="upGeral" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
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
                        <span>Filtrar Registros</span>
                    </legend>

                    <table>
                        <tr>
                            <td class="LarguraFiltro">
                                <asp:Label ID="lbDescricao" runat="server">Descrição:</asp:Label>
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

                <asp:Panel ID="PanelAcoes" runat="server" Style="padding: 10px">

                    <asp:HiddenField ID="hddProjetoCursoUID" runat="server" />

                    <div style="float: left; width: 300px; margin-left: 10px">
                        <asp:Label ID="lblResultadoConsulta" runat="server"></asp:Label>
                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="ArialBlack16"></asp:Label>
                    </div>
                </asp:Panel>

                <br />

                <asp:GridView ID="GridView1"
                    runat="server"
                    AllowPaging="True"
                    AutoGenerateColumns="False"
                    OnPageIndexChanging="GridView1_PageIndexChanging"
                    Width="100%"
                    CssClass="mGrid"
                    DataKeyNames="enderecoUID"
                    PageSize="10">

                    <Columns>
                        <asp:TemplateField HeaderText="Código" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span><%# Eval("enderecoUID")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="5%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Descrição" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span><%# Eval("identificacaoEndereco")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="center" Width="15%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Municipio" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span><%# Eval("municipio")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Bairro" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("bairroEndereco")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Rua" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <span class="mestre"><%# Eval("rua")%></span>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="30%" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ações" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <div style="text-align: center">
                                    <asp:HyperLink ID="lnkDiscente" runat="server" NavigateUrl='<%# "~/webapp/discente/FrmListar.aspx?projetoPoloCursoUID=" + Eval("projetoPoloCursoUID") %>' ToolTip="Discentes">[ Discentes ]</asp:HyperLink>
                                </div>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                        </asp:TemplateField>

                    </Columns>

                    <PagerTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <div style="text-align: left">
                                <asp:ImageButton ID="cmdFirst" runat="server" CausesValidation="False" CommandArgument="First" CommandName="Page" ImageUrl="../../media/images/i_primeira_pagina.gif" ToolTip="Ir para a primeira página" />

                                <asp:ImageButton ID="cmdPrev" runat="server" CausesValidation="False" CommandArgument="Prev" CommandName="Page" ImageUrl="../../media/images/i_pagina_anterior.gif" ToolTip="Ir para a página anterior" />

                                <asp:ImageButton ID="cmdNext" runat="server" CausesValidation="False" CommandArgument="Next" CommandName="Page" ImageUrl="../../media/images/i_proxima_pagina.gif" ToolTip="Ir para a próxima página" CssClass="espacamentoPaginador"/>

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

